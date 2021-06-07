using System;
using System.Drawing;
using System.Windows.Forms;


namespace MakeNews
{
	public partial class FixTextSttingPage: Form
	{
		DataManger _dm;
		
		#region Constructor
		public FixTextSttingPage(DataManger dm)
		{
			InitializeComponent();			
			_dm = dm;

			//FixText text = dm.GetFixText(Common.fixdataPath);
			FixText text = this._dm.GetFixTextForXML();
			Tb_IndexHeadTitile.Text = text.IndexHead;
			Tb_IndexCoverPTag.Text = text.IndexCoverP;
			Tb_IndexCopy.Text = text.IndexCopy;
			Tb_HistoryTitle.Text = text.HistoryHead;
			Tb_Lst_wrapH2.Text = text.HistoryH2;
		}
		#endregion

		#region Button Evnet
		private void Bt_Change_Click(object sender, EventArgs e)
		{
			FixText text = new FixText(Tb_IndexHeadTitile.Text,Tb_IndexCoverPTag.Text,Tb_IndexCopy.Text,Tb_HistoryTitle.Text,Tb_Lst_wrapH2.Text);
			_dm.SetFixTextForXML(text);
			
			if (true)//setting
			{
				this.Close();
			} 
		}

		private void Bt_Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion
	}
}
