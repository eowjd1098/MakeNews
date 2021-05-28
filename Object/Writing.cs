namespace MakeNews
{
	public class Writing
	{
		public Writing(bool imge, bool popup, string emogi, string title, string contents, string url, string imgsrc, string category, string year, string month, string day, string popuptitile, string popupImgSrc, string popupContent)
		{
			Imge = imge;
			Popup = popup;
			Emogi = emogi;
			Title = title;
			Contents = contents;
			Url = url;
			Imgsrc = imgsrc;
			Category = category;
			Year = int.Parse(year);
			Month = int.Parse(month);
			Day = int.Parse(day);
			Popuptitile = popuptitile;
			PopupImgSrc = popupImgSrc;
			PopupContent = popupContent;
		}

		public bool Imge { get; set; }
		
		public bool Popup { get; set; }

		public string Emogi { get; set; }

		public string Title { get; set; }

		public string Contents { get; set; }
		
		public string Url { get; set; }

		public string Imgsrc { get; set; }
		public string Category { get; set; }
		
		public int Year { get; set; }
		public int Month { get; set; }
		public int Day { get; set; }
		public string Popuptitile { get; set; }
		public string PopupImgSrc { get; set; }
		public string PopupContent { get; set; }
		
		public override string ToString()
		{
			return Imge.ToString() + "," +	Popup.ToString() + "," +Emogi + "," +Title + "," +
			Contents + "," +Url + "," +	Imgsrc + "," +Category + "," +Year + "-" +Month + "-" +	Day + "," +	Popuptitile + "," +
			PopupImgSrc + "," +	PopupContent; ;
		}
	}
}
