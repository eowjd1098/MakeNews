using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace MakeNews
{
	public class DataManger
	{
		Common _com =new Common();

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

		#region 고정형 텍스트 관리 
		public FixText GetFixTextForXML() 
		{
			FixText text = new FixText();
			if (!File.Exists(Common.fixdataPath))
			{
				using (File.Create(Common.fixdataPath)) { }
				return new FixText("","","","","");
			}
			XmlDocument doc = new XmlDocument();

			doc.Load(Common.fixdataPath);

			foreach (XmlNode item in doc.ChildNodes)
			{
				foreach (XmlNode xmlNode in item)
				{
					if (xmlNode.Name == "IndexHead")
					{
						text.IndexHead = xmlNode.InnerText;
					}
					else if (xmlNode.Name == "IndexCoverP") 
					{
						text.IndexCoverP = xmlNode.InnerText;
					}
					else if (xmlNode.Name == "IndexCopy")
					{
						text.IndexCopy = xmlNode.InnerText;
					}
					else if (xmlNode.Name == "HistoryHead")
					{
						text.HistoryHead = xmlNode.InnerText;
					}
					else if (xmlNode.Name == "HistoryH2")
					{
						text.HistoryH2 = xmlNode.InnerText;
					}
				}
			}
			return text;
		}
		public void SetFixTextForXML(FixText text) 
		{
			if ( File.Exists(Common.fixdataPath)) 
			{
				File.Delete(Common.fixdataPath); 
			}
			
			XmlDocument doc = new XmlDocument();
			XmlElement fixtext = doc.CreateElement("Config");

			List<PropertyInfo> p_List = new List<PropertyInfo>();
			p_List.AddRange(text.GetType().GetProperties());

			for (int i = 0; i < p_List.Count; i++) 
			{
				XmlElement tmp_eml = doc.CreateElement(p_List[i].Name);
				string[] columnNames = text.GetArray();
				tmp_eml.InnerText = columnNames[i].ToString();
				fixtext.AppendChild(tmp_eml);
			}
			doc.AppendChild(fixtext);

			doc.Save(Common.fixdataPath);

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

		public void InsertInfo(Writing writing)
		{
			// 추가중 세션별로 꽉 차있는경우에 역으로 검색 하여 처음 들어온 값에 세션을검색 업데이트후 인서트 
			string sql = string.Empty;
			int session = 1;
			int result = -1;
			SQLiteCommand command;
			if (writing.Popup.Equals(false)) //팝업이없음 = 뉴스 일경우
			{
				result = (int)SelectCountSession(session);
				if (result < 0) //read 가 5이상일경우 마지막데이터 업데이트 진행 아닐경우 인서트 진행 
				{
					System.Windows.Forms.MessageBox.Show("Err: Count Qurey Fail - News Insert");
					return;
				} 
				else if (result >= 5) 
				{
					using (SQLiteConnection conn = new SQLiteConnection(Common.DBDataPath))
					{
						conn.Open();
						sql = "SELECT Num FROM Data WHERE Session = 1 ORDER BY Num ASC LIMIT 1";
						command = new SQLiteCommand(sql, conn);
						int key = (int)((long)command.ExecuteScalar());

						//Updata
						sql = "UPDATE Data Set Session = 3 WHERE num = " + key;
						command = new SQLiteCommand(sql, conn);
						result = (int)command.ExecuteNonQuery();
						
						conn.Close();
					}
					
					if (result < 0) 
					{
						System.Windows.Forms.MessageBox.Show("Err: Count Qurey Fail - News Update");
						return;
					}
				}
			}
			else //팝업이있음 = 정보 일경우
			{
				result = (int)SelectCountSession(++session);
				if (result < 0) //read 가 5이 상일경우 마지막데이터 업데이트 진행 아닐경우 인서트 진행 
				{
					System.Windows.Forms.MessageBox.Show("Err: Count Qurey Fail - Info Insert");
					return;
				}
				else if (result >= 2)
				{
					using (SQLiteConnection conn = new SQLiteConnection(Common.DBDataPath))
					{
						conn.Open();
						sql = "SELECT Num FROM Data WHERE Session = 1 ORDER BY Num ASC LIMIT 1";
						command = new SQLiteCommand(sql, conn);
						int key = (int)((long)command.ExecuteScalar());
					 
		
						//Updata
						sql = "UPDATE Data Set Session = 3 WHERE num = " + key;
						command = new SQLiteCommand(sql, conn);
						result = (int)command.ExecuteNonQuery();
						conn.Close();
					}
					if (result < 0)
					{
						System.Windows.Forms.MessageBox.Show("Err: Count Qurey Fail - Info Update");
						return;
					}
				}
			}
			
			using (SQLiteConnection conn = new SQLiteConnection(Common.DBDataPath))
			{
				conn.Open();
				sql = @"INSERT INTO Data (Session,ImgUse,PopupUse,Emogi,Title,Contents,Url,ImgUrl,Category,Date,PopupTitle,PopupImgSrc,PopupContent) 
							VALUES ("+session+","+writing.Imge + "," +writing.Popup+",'"+writing.Emogi+"','"+writing.Title+"','"+writing.Contents+"','"+writing.Url+"','"+writing.Imgsrc+"','" + writing.Category + "','" + writing.GetDate() +"','"
							+writing.Popuptitile +"','"+writing.PopupImgSrc+"','"+writing.PopupContent +"')";
				command = new SQLiteCommand(sql, conn);
				result = command.ExecuteNonQuery();
				conn.Close();
			}
		
			if (result < 0)
			{
				System.Windows.Forms.MessageBox.Show("Err: Count Qurey Fail - Insert");
				return;
			}
			 
		}
		//public void InsertInfo(Writing writing)
		//{
		//	int session = -1;
		//	
		//	if (writing.Popup.Equals(false)) //팝업이없음 = 뉴스 일경우
		//	{
		//		session = 1;
		//	}
		//	else //팝업이있음 = 정보 일경우
		//	{
		//		session = 2;
		//	}
		//
		//	using (SQLiteConnection conn = new SQLiteConnection(Common.DBDataPath))
		//	{
		//		conn.Open();
		//		string sql = @"INSERT INTO Data (Session,ImgUse,PopupUse,Emogi,Title,Contents,Url,ImgUrl,Category,Date,PopupTitle,PopupImgSrc,PopupContent) 
		//					VALUES (" + session + "," + writing.Imge + "," + writing.Popup + ",'" + writing.Emogi + "','" + writing.Title + "','" + writing.Contents + "','" + writing.Url + "','" + writing.Imgsrc + "','" + writing.Category + "','" + writing.GetDate() + "','"
		//					+ writing.Popuptitile + "','" + writing.PopupImgSrc + "','" + writing.PopupContent + "')";
		//		SQLiteCommand command = new SQLiteCommand(sql, conn);
		//		int result = command.ExecuteNonQuery();
		//		conn.Close();
		//
		//		if (result < 0)
		//		{
		//			System.Windows.Forms.MessageBox.Show("Err: Count Qurey Fail - Insert");
		//		}
		//	}
		//}
		public void UpdateInfo(Writing writing,int beforeSession) 
		{
			int ChangeSession = 3;

			if (beforeSession == 1) // 기존 1번인데
			{
				if (writing.Popup.Equals(true))// 2번으로 변경하는경우
				{
					if (SelectCountSession(2) < 2)//체크후 2개이상이면 3으로 변경
					{
						ChangeSession = 2;
					}
				}
				else
				{
					ChangeSession = beforeSession;
				}
			}
			else if (beforeSession == 2) 
			{
				if (writing.Popup.Equals(false)) //팝업이없음 = 뉴스 일경우
				{
					// Session 이 2-> 1 으로 변경 되는 경우 = 체크후 5개이상이면 3으로 변경 
					if (SelectCountSession(1) < 5)
					{
						ChangeSession = 1;
					}
				} 
				else
				{
					ChangeSession = beforeSession;
				}
			}
			else //Session 이 3 이면 그대로 사용
			{
				ChangeSession = 3;
			}

			using (SQLiteConnection conn = new SQLiteConnection(Common.DBDataPath))
			{
				conn.Open();
				string sql = @"UPDATE Data SET  Session = "+ChangeSession+",ImgUse = "+writing.Imge+",PopupUse ="+writing.Popup+",Emogi ='"+writing.Emogi+"',Title='"+ writing.Title +"',Contents='"+writing.Contents+"',Url='"+writing.Url+"',ImgUrl='"+writing.Imgsrc+"',Category='"+ writing.Category
					+"',Date='"+writing.GetDate()+"',PopupTitle='"+writing.Popuptitile+"',PopupImgSrc='"+writing.PopupImgSrc+"',PopupContent='"+writing.PopupContent+"' where Num="+writing.Index;
				SQLiteCommand command = new SQLiteCommand(sql, conn);
				int result = command.ExecuteNonQuery();
				conn.Close();

				if (result < 0)
				{
					System.Windows.Forms.MessageBox.Show("Err: Count Qurey Fail - Update");
				}
			}
		}
		public void DeleteInfo(int num) 
		{
			using (SQLiteConnection conn = new SQLiteConnection(Common.DBDataPath))
			{
				conn.Open();
				string sql = "DELETE FROM Data WHERE Num ="+num;
				SQLiteCommand command = new SQLiteCommand(sql, conn);
				int result = command.ExecuteNonQuery();
				conn.Close();

				if (result < 0)
				{
					System.Windows.Forms.MessageBox.Show("Err: Count Qurey Fail - Delete");
				}
			}
			
		}
		public void UpdateSession(int num ,int beforsession,bool popupUse) 
		{
			string sql = string.Empty;
			switch (beforsession)
			{
				case 1: sql = "UPDATE Data SET Session = 3 where num=" + num; break;
				case 2: sql = "UPDATE Data SET Session = 3 where num=" + num; break;
				case 3://변경할 Session Type 확인
					{
						if (popupUse)
						{
							sql = "UPDATE Data SET Session = 2 where num=" + num;
						}
						else
						{
							sql = "UPDATE Data SET Session = 1 where num=" + num;
						}
					
					}
					break;

				default:
					break;
			}
			
			//쿼리 실행
			using (SQLiteConnection conn = new SQLiteConnection(Common.DBDataPath))
			{
				conn.Open();
				SQLiteCommand command = new SQLiteCommand(sql, conn);
				int result = command.ExecuteNonQuery();
				conn.Close();

				if (result < 0)
				{
					System.Windows.Forms.MessageBox.Show("Err: Count Qurey Fail - Update");
				}
			}
		}
		public int SelectSession(int index) 
		{
			int beforSession =3;
			using (SQLiteConnection conn = new SQLiteConnection(Common.DBDataPath))
			{
				conn.Open();
				string sql = "SELECT Session FROM Data WHERE Num="+index;
				SQLiteCommand command = new SQLiteCommand(sql, conn);

				beforSession = (int)((long)command.ExecuteScalar());
				conn.Close();
			}
			return beforSession;
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
					case 1: sql = "SELECT * FROM Data WHERE Session=1 ORDER By Num DESC LIMIT 5";break;
					case 2: sql = "SELECT * FROM Data WHERE Session=2 ORDER By Num DESC LIMIT 2"; break;
					case 3: sql = "SELECT * FROM Data WHERE Session=3 ORDER By Num DESC"; break;
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
		public int SelectCountSession(int sessiontype) 
		{
			long read = -1;
			using (SQLiteConnection conn = new SQLiteConnection(Common.DBDataPath))
			{
				conn.Open();
				string sql = "SELECT count(Session) FROM Data WHERE Session="+sessiontype;
				SQLiteCommand cmd = new SQLiteCommand(sql, conn);
				read = (long)cmd.ExecuteScalar();
				conn.Close();
			}
			return (int)read;
		}

		public void ResetDataBase()
		{

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
			string [] da = date.Split('/');
			return da;
		}
		#endregion

		#endregion

		#region CSV 관리
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
		#endregion

		#region Html 관리
		public void CreateHtml(List<Writing> news, List<Writing> info, List<Writing> history )
		{
			FixText fixText = GetFixTextForXML();
			
			//파일 생성 
			using (StreamWriter sw = new StreamWriter(Common.indexPath, false))
			{
				//Index Page 순서 Head -> BodyUpper -> NewsnoImg,NewsImg,Empty(반복) -> PopupnoImg, PopupImg,Empty(반복) ->BodyDown-> PopupContents-> Script
				sw.WriteLine("{0}", _com.GetIndexHeadHtml(fixText.IndexHead));
				sw.WriteLine("{0}", _com.GetIndexBodyUpperHtml(fixText.IndexCoverP));

				//news
				int count=0;
				foreach (Writing item in news)
				{
					if (item.Imge)
					{
						sw.WriteLine("{0}", _com.GetIndexBodyNewsImgHtml(item.Url,item.Imgsrc,item.Title,item.GetDate(),item.Category));
					}
					else
					{
						sw.WriteLine("{0}", _com.GetIndexBodyNewsNotImgHtml(item.Url, item.Emogi, item.Title,item.Contents, item.GetDate(), item.Category));
					}
					count++;
				}
				for (; count < 5; count++) 
				{
					sw.WriteLine("{0}", _com.GetIndexBodyEmptyHtml());
				}

				//info 
				count=0;
				foreach (Writing item in info)
				{
					sw.WriteLine("{0}", _com.GetIndexBodyPopupHtml((count+1).ToString(),item.Emogi,item.Title,item.Contents,item.GetDate(),item.Category));
					count++;
				}
				for (; count < 2; count++)
				{
					sw.WriteLine("{0}", _com.GetIndexBodyEmptyHtml());
				}
				sw.WriteLine("{0}", _com.GetIndexBodyDownHtml(fixText.IndexCopy));
				
				//info_contents
				count = 0;
				foreach (Writing item in info)
				{
					if (item.PopupImgSrc.Length>0)
					{
						sw.WriteLine("{0}", _com.GetIndexPopUpContentsImgeUseHtml((count + 1).ToString(),  item.Popuptitile,item.PopupImgSrc,item.PopupContent));
					}
					else
					{
						sw.WriteLine("{0}", _com.GetIndexPopUpContentsHtml((count + 1).ToString(), item.Popuptitile, item.PopupContent));
					} 
					count++;
				}
				for (; count < 2; count++)
				{
					sw.WriteLine("{0}", _com.GetIndexBodyEmptyHtml());
				}
				sw.WriteLine("{0}", _com.GetIndexScriptHtml());
			}


			using (StreamWriter sw = new StreamWriter(Common.historyPath, false))
			{
				sw.WriteLine("{0}", _com.GetIHistoryHeadHtml(fixText.HistoryHead,fixText.HistoryH2));

				foreach (Writing item in history)
				{
					sw.WriteLine("{0}", _com.GetHistoryNewsHtml(item.Url, item.Category,item.Title));
				}

				sw.WriteLine("{0}", _com.GetHistoryScriptHtml());
			}

		}
		#endregion
	}
}
