namespace MakeNews
{
	public class FixText
	{
		#region Constructor
		public FixText(string indexHead, string indexCoverP, string indexCopy, string historyHead, string historyH2)
		{
			IndexHead = indexHead;
			IndexCoverP = indexCoverP;
			IndexCopy = indexCopy;
			HistoryHead = historyHead;
			HistoryH2 = historyH2;
		}
		#endregion

		#region Properti
		public string IndexHead { get; set; }
		public string IndexCoverP { get; set; }
		public string IndexCopy { get; set; }
		public string HistoryHead { get; set; }
		public string HistoryH2 { get; set; }
		#endregion

		#region Sub Function
		public override string ToString()
		{
			return IndexHead + "," + IndexCoverP + "," + IndexCopy + "," + HistoryHead + "," + HistoryH2;
		}
		#endregion
	}
}
