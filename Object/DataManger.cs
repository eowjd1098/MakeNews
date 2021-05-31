using System.Data.SQLite;
using System.IO;

namespace MakeNews
{
	public class DataManger
	{
		Common com =new Common();
		//Stack<Writing> writingStack;
		//List<Writing> writinglist = new List<Writing>();

		#region Single Tone Pattern
		private static DataManger instance;
		public static DataManger Instance()
		{
			if (instance == null)
			{
				instance = new DataManger();
			}
			return instance;
		}
		#endregion

		#region 고정형 텍스트
		public FixText GetFixText(string path)
		{
			if (!File.Exists(path))
			{
				using (File.Create(path)) { }
				return new FixText("", "", "", "", "");
			}
			else
			{
				string[] lines = File.ReadAllLines(path);
				if (lines.Length == 0)
				{
					return new FixText("", "", "", "", "");
				}
				string[] s =lines[0].Split(',');

				return new FixText(s[0], s[1], s[2], s[3], s[4]);
			}
		}

		public void SetFixText(string path, FixText fixText)
		{
			if (!File.Exists(path))
			{
				using (File.Create(path)) { }
			}
			using (StreamWriter sw = new StreamWriter(path, false))
			{
				sw.WriteLine(fixText.ToString());
			}

		}

		#endregion

		#region Data Base
		

		
		//DB File Create + Table Create
		public void InitDataBase() 
		{
			if (File.Exists(Common.DBPath))
			{
				return;
			}
			
			SQLiteConnection.CreateFile(Common.DBPath);

			using (SQLiteConnection conn = new SQLiteConnection(Common.DBDataPath))
			{
				conn.Open();

				string sql = 
				@"CREATE TABLE Data (
					Num INTEGER NOT NULL,
					Session INTEGER NOT NULL,
					ImgUse	INTEGER NOT NULL,
					PopupUse	INTEGER NOT NULL,
					Emogi	INTEGER,
					Title	TEXT,
					Contents	TEXT,
					Url	TEXT,
					ImgUrl	TEXT,
					Category	TEXT,
					Date	TEXT,
					PopupTitle	TEXT,
					PopupImgSrc	TEXT,
					PopupContent	TEXT,
					PRIMARY KEY(Num AUTOINCREMENT)
				)";
				 
				SQLiteCommand command = new SQLiteCommand(sql, conn);
				int result = command.ExecuteNonQuery();

				conn.Close();
			}
		}

		public void InsertInfo(Writing writing)
		{
			// 추가중 세션별로 꽉 차있는경우에 역으로 검색 하여 처음 들어온 값에 세션을검색 업데이트후 인서트 
			using (SQLiteConnection conn = new SQLiteConnection(Common.DBDataPath))
			{
				conn.Open();
				int session = 1;
				int result = -1;
				if (writing.Popup.Equals(false)) //팝업이없음 = 뉴스 일경우
				{
					result = SelectCountSession(session);
					if (result < 0) //read 가 6이상일경우 마지막데이터 업데이트 진행 아닐경우 인서트 진행 
					{
						System.Windows.Forms.MessageBox.Show("Err: Count Qurey Fail - News Insert");
						return;
					} 
					else if (result >= 6) 
					{
						//Updata
					}
				}
				else //팝업이있음 = 정보 일경우
				{
					result = SelectCountSession(++session);
					if (result < 0) //read 가 6이상일경우 마지막데이터 업데이트 진행 아닐경우 인서트 진행 
					{
						System.Windows.Forms.MessageBox.Show("Err: Count Qurey Fail - Info Insert");
						return;
					}
					else if (result >= 2)
					{
						//Updata
					}
				}

				string sql = @"INSERT INTO Data (Session,ImgUse,PopupUse,Emogi,Title,Contents,Url,ImgUrl,Category,Date,PopupTitle,PopupImgSrc,PopupContent) 
								VALUES ("+session+","+writing.Popup+","+writing.Emogi+",'"+writing.Title+"','"+writing.Contents+"','"+writing.Url+"','"+writing.Imgsrc+"','"+writing.GetDate() +"','"
								+writing.Popuptitile +"','"+writing.PopupImgSrc+"','"+writing.PopupContent +"')";
				SQLiteCommand command = new SQLiteCommand(sql, conn);
				result = command.ExecuteNonQuery();
				
				conn.Close();
			}
			//String sql = "insert into members (name, age) values ('김도현', 6)";
			//SQLiteCommand command = new SQLiteCommand(sql, conn);
			//int result = command.ExecuteNonQuery();

		}

		public void UpdateInfo() 
		{
		
		}

		public void DeleteInfo() 
		{
		}

		public void ResetDataBase() 
		{
			
		}
		 
		public int SelectCountSession(int sessiontype) 
		{
			int read = -1;
			using (SQLiteConnection conn = new SQLiteConnection(Common.DBDataPath))
			{
				conn.Open();
				string sql = "SELECT count(Session) FROM Data WHERE Session="+sessiontype;
				SQLiteCommand cmd = new SQLiteCommand(sql, conn);
				read = (int)cmd.ExecuteScalar();
				conn.Close();
			}
			return read;
		}


		#endregion



		public void SaveInfo(string path, Writing writing)
		{
			if (!File.Exists(path))
			{
				using (File.Create(path)) { }
			}

			string[] lines = File.ReadAllLines(path);

			using (StreamWriter sw = new StreamWriter(path, false))
			{
				sw.WriteLine(writing.ToString());
				foreach (string data in lines)
				{
					if (data != null)
					{
						sw.WriteLine("{0}", data);
					}
				}
			}
		}



		public void CreateHtml(string indexPath, string historyPath, string dataPath)
		{
			FixText fixText = GetFixText(Common.fixdataPath);
			//파일 생성 
			using (StreamWriter sw = new StreamWriter(indexPath, false))
			{
				sw.WriteLine("{0}", com.GetIndexHeadHtml(fixText.IndexHead));
				sw.WriteLine("{0}", @"<body>");
				sw.WriteLine("{0}", @"<div id = ""wrap"" >");
				sw.WriteLine("{0}", @"<section id = ""container"" >");
				sw.WriteLine("{0}", @"<div class=""contents"">");
				sw.WriteLine("{0}", @"<section class=""cover"">");
				sw.WriteLine("{0}", @"<h1>금요일 뉴스레터</h1>");
				sw.WriteLine("{0}", @"<p class=""desc"">매주 금요일! 주목해야 할 트렌드, IT,<br>뉴미디어 관련 전시ㆍ공연 정보 등이<br>다양하게 업데이트됩니다!</p>");
				sw.WriteLine("{0}", @"</section>");
				sw.WriteLine("{0}", @"<section class=""news"">");
				sw.WriteLine("{0}", @"<ul >");
				//
				//titile 공간

				//
				sw.WriteLine("{0}", @"</ul >");
				sw.WriteLine("{0}", @"</section >");
				sw.WriteLine("{0}", @"</div>");
				sw.WriteLine("{0}", @"<div class=""donate"">");
				sw.WriteLine("{0}", @"<div class=""marquee_bx"">");
				sw.WriteLine("{0}", @"<p class=""plz"">......................</p>");
				sw.WriteLine("{0}", @"</div>");
				sw.WriteLine("{0}", @"</div>");
				sw.WriteLine("{0}", @"</section >");
				sw.WriteLine("{0}", @"<footer id = ""footer"" >");
				sw.WriteLine("{0}", @"<strong class=""copy"">..................</strong>");
				sw.WriteLine("{0}", @"</footer>");
				sw.WriteLine("{0}", "</div>");
				//
				//Popup 공간


				//
				sw.WriteLine("{0}", @"<script>");
				sw.WriteLine("{0}", @"$('.news .noti>a').on('click', function(e){var PopBx = $(this).attr('href'); $(PopBx).fadeIn().addClass('on');	});");
				sw.WriteLine("{0}", @"$(document).mouseup(function(e){var LyPop = $("".ly_pop""); if (LyPop.has(e.target).length === 0)	{LyPop.fadeOut().removeClass('on');	}$('.ly_pop .btn_close').on('click', function(e){LyPop.fadeOut().removeClass('on');});});");
				sw.WriteLine("{0}", @"</script >");
				sw.WriteLine("{0}", @"</body >");
				sw.WriteLine("{0}", @"</html >");

			}


			using (StreamWriter sw = new StreamWriter(historyPath, false))
			{
				//sw.WriteLine("{0}", @"</html >");
			}

		}
	}
}
