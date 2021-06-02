using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
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
					Emogi	TEXT,
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

		//public void InsertInfo(Writing writing)
		//{
		//	// 추가중 세션별로 꽉 차있는경우에 역으로 검색 하여 처음 들어온 값에 세션을검색 업데이트후 인서트 
		//	string sql = string.Empty;
		//	int session = 1;
		//	int result = -1;
		//	SQLiteCommand command;
		//	if (writing.Popup.Equals(false)) //팝업이없음 = 뉴스 일경우
		//	{
		//		result = (int)SelectCountSession(session);
		//		if (result < 0) //read 가 6이상일경우 마지막데이터 업데이트 진행 아닐경우 인서트 진행 
		//		{
		//			System.Windows.Forms.MessageBox.Show("Err: Count Qurey Fail - News Insert");
		//			return;
		//		} 
		//		else if (result >= 6) 
		//		{
		//			using (SQLiteConnection conn = new SQLiteConnection(Common.DBDataPath))
		//			{
		//				conn.Open();
		//				sql = "SELECT * FROM Data WHERE Session = 1 ORDER BY Num ASC LIMIT 1";
		//				command = new SQLiteCommand(sql, conn);
		//				SQLiteDataReader rdr = command.ExecuteReader();
		//				int key = (int)rdr["num"];
		//				rdr.Close();
		//
		//				//Updata
		//				sql = "UPDATE Data Set Session = 3 WHERE num = " + key;
		//				command = new SQLiteCommand(sql, conn);
		//				result = (int)command.ExecuteNonQuery();
		//				
		//				conn.Close();
		//			}
		//			
		//			if (result < 0) 
		//			{
		//				System.Windows.Forms.MessageBox.Show("Err: Count Qurey Fail - News Update");
		//				return;
		//			}
		//		}
		//	}
		//	else //팝업이있음 = 정보 일경우
		//	{
		//		result = (int)SelectCountSession(++session);
		//		if (result < 0) //read 가 6이상일경우 마지막데이터 업데이트 진행 아닐경우 인서트 진행 
		//		{
		//			System.Windows.Forms.MessageBox.Show("Err: Count Qurey Fail - Info Insert");
		//			return;
		//		}
		//		else if (result >= 2)
		//		{
		//			using (SQLiteConnection conn = new SQLiteConnection(Common.DBDataPath))
		//			{
		//				conn.Open();
		//				sql = "SELECT * FROM Data WHERE Session = 2 ORDER BY Num ASC LIMIT 1";
		//				command = new SQLiteCommand(sql, conn);
		//				SQLiteDataReader rdr = command.ExecuteReader();
		//				int key = (int)rdr["num"];
		//				rdr.Close();
		//
		//				//Updata
		//				sql = "UPDATE Data Set Session = 3 WHERE num = " + key;
		//				command = new SQLiteCommand(sql, conn);
		//				result = (int)command.ExecuteNonQuery();
		//				conn.Close();
		//			}
		//			if (result < 0)
		//			{
		//				System.Windows.Forms.MessageBox.Show("Err: Count Qurey Fail - Info Update");
		//				return;
		//			}
		//		}
		//	}
		//	
		//	using (SQLiteConnection conn = new SQLiteConnection(Common.DBDataPath))
		//	{
		//		conn.Open();
		//		sql = @"INSERT INTO Data (Session,ImgUse,PopupUse,Emogi,Title,Contents,Url,ImgUrl,Category,Date,PopupTitle,PopupImgSrc,PopupContent) 
		//					VALUES ("+session+","+writing.Imge + "," +writing.Popup+",'"+writing.Emogi+"','"+writing.Title+"','"+writing.Contents+"','"+writing.Url+"','"+writing.Imgsrc+"','" + writing.Category + "','" + writing.GetDate() +"','"
		//					+writing.Popuptitile +"','"+writing.PopupImgSrc+"','"+writing.PopupContent +"')";
		//		command = new SQLiteCommand(sql, conn);
		//		result = command.ExecuteNonQuery();
		//		conn.Close();
		//	}
		//
		//	if (result < 0)
		//	{
		//		System.Windows.Forms.MessageBox.Show("Err: Count Qurey Fail - Insert");
		//		return;
		//	}
		//	 
		//}

		public void InsertInfo(Writing writing)
		{
			int session = -1;
			
			if (writing.Popup.Equals(false)) //팝업이없음 = 뉴스 일경우
			{
				session = 1;
			}
			else //팝업이있음 = 정보 일경우
			{
				session = 2;
			}

			using (SQLiteConnection conn = new SQLiteConnection(Common.DBDataPath))
			{
				conn.Open();
				string sql = @"INSERT INTO Data (Session,ImgUse,PopupUse,Emogi,Title,Contents,Url,ImgUrl,Category,Date,PopupTitle,PopupImgSrc,PopupContent) 
							VALUES (" + session + "," + writing.Imge + "," + writing.Popup + ",'" + writing.Emogi + "','" + writing.Title + "','" + writing.Contents + "','" + writing.Url + "','" + writing.Imgsrc + "','" + writing.Category + "','" + writing.GetDate() + "','"
							+ writing.Popuptitile + "','" + writing.PopupImgSrc + "','" + writing.PopupContent + "')";
				SQLiteCommand command = new SQLiteCommand(sql, conn);
				int result = command.ExecuteNonQuery();
				conn.Close();

				if (result < 0)
				{
					System.Windows.Forms.MessageBox.Show("Err: Count Qurey Fail - Insert");
				}
			}
		}

		public List<Writing> SelectData(int num) 
		{
			List < Writing > data = new List<Writing>();
			using (SQLiteConnection conn = new SQLiteConnection(Common.DBDataPath))
			{
				conn.Open();
				string sql = string.Empty;
				switch (num)
				{
					case 1: sql = "SELECT * FROM Data WHERE Session=1 ORDER By Num DESC LIMIT 6";break;
					case 2: sql = "SELECT * FROM Data WHERE Session=2 ORDER By Num DESC LIMIT 2"; break;
					case 3: sql = "SELECT * FROM Data WHERE Num Not IN (SELECT Num FROM Data WHERE Session=1 ORDER BY Num DESC LIMIT 6) AND Num Not IN (SELECT Num FROM Data WHERE Session=2 ORDER BY Num DESC LIMIT 2)"; break;
					default:
						break;
				}
				  
				SQLiteCommand command = new SQLiteCommand(sql, conn);
				SQLiteDataReader rdr = command.ExecuteReader();

				while (rdr.Read()) 
				{ 
					data.Add(new Writing((int)((long)rdr["num"]),ChangeBoolean((long)rdr["ImgUse"]), ChangeBoolean((long)rdr["PopupUse"]),(string)rdr["Emogi"],
						(string)rdr["Title"],(string)rdr["Contents"],(string)rdr["Url"],(string)rdr["ImgUrl"],(string)rdr["Category"], ChangeDate((string)rdr["Date"])[0], ChangeDate((string)rdr["Date"])[1], ChangeDate((string)rdr["Date"])[2], 
						(string)rdr["PopupTitle"], (string)rdr["PopupImgSrc"], (string)rdr["PopupContent"]));
				}
				rdr.Close();
				conn.Close();
			}

			return data;
		}

		#region ect funtion
		public bool ChangeBoolean(long dbdata) 
		{
			if (dbdata == 0)
			{
				return false;
			}
			else 
			{
				return true;
			}
		}

		public string[] ChangeDate(string date) 
		{
			string [] da = date.Split('-');
			return da;
		}
		#endregion

		public void UpdateInfo() 
		{
		
		}

		public void DeleteInfo() 
		{
		}

		public void ResetDataBase() 
		{
			
		}
		 
		//public long SelectCountSession(int sessiontype) 
		//{
		//	long read = -1;
		//	using (SQLiteConnection conn = new SQLiteConnection(Common.DBDataPath))
		//	{
		//		conn.Open();
		//		string sql = "SELECT count(Session) FROM Data WHERE Session="+sessiontype;
		//		SQLiteCommand cmd = new SQLiteCommand(sql, conn);
		//		read = (long)cmd.ExecuteScalar();
		//		conn.Close();
		//	}
		//	return read;
		//}


		#endregion



		public void SaveInfotoCSV(string path, Writing writing)
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
