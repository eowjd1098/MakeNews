namespace MakeNews
{
	public class FixText
	{
		public FixText(string indexHead, string indexCoverP, string indexCopy, string historyHead, string historyH2)
		{
			IndexHead = indexHead;
			IndexCoverP = indexCoverP;
			IndexCopy = indexCopy;
			HistoryHead = historyHead;
			HistoryH2 = historyH2;
		}

		public string IndexHead { get; set; }
		public string IndexCoverP { get; set; }
		public string IndexCopy { get; set; }
		public string HistoryHead { get; set; }
		public string HistoryH2 { get; set; }
		public override string ToString()
		{
			return IndexHead + "," + IndexCoverP + "," + IndexCopy + "," + HistoryHead + "," + HistoryH2;
		}
	}
}
