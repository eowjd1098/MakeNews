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
