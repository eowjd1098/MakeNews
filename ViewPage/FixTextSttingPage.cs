﻿using System;
using System.Windows.Forms;

namespace MakeNews
{
	public partial class FixTextSttingPage: Form
	{
		DataManger dm;
		public FixTextSttingPage(DataManger _dm)
		{
			InitializeComponent();
			Font = Common.GetFont();
			dm = _dm;

			FixText text = dm.GetFixText(Common.fixdataPath);

			Tb_IndexHeadTitile.Text = text.IndexHead;
			Tb_IndexCoverPTag.Text= text.IndexCoverP;
			Tb_IndexCopy.Text = text.IndexCopy;
			Tb_HistoryTitle.Text = text.HistoryHead;
			Tb_Lst_wrapH2.Text = text.HistoryH2;
		}

		private void Bt_Change_Click(object sender, EventArgs e)
		{
			FixText text = new FixText(Tb_IndexHeadTitile.Text,Tb_IndexCoverPTag.Text,Tb_IndexCopy.Text,Tb_HistoryTitle.Text,Tb_Lst_wrapH2.Text);
			dm.SetFixText(Common.fixdataPath, text);

			this.Close();
		}

		private void Bt_Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
