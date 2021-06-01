using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MakeNews
{
	/// <summary>
	/// Main 화면 코드 
	/// </summary>
	public partial class MainPage: Form
	{
		DataManger dm;// DataManger 전역 호출 용 

		DataTable index;
		DataTable history;
		public MainPage(DataManger _dm)
		{
			InitializeComponent();
			dm = _dm;
			dm.InitDataBase();
		}
		 

		private void Bt_Setting_Click(object sender, EventArgs e)
		{
			FixTextSttingPage form = new FixTextSttingPage(dm);
			form.ShowDialog();
		}
		private void Bt_AddData_Click(object sender, EventArgs e)
		{
			AddItemPage form = new AddItemPage(dm);
			form.ShowDialog();
		}

		private void Bt_OpenHtml_Click(object sender, EventArgs e)
		{
			string message ="";

			if (File.Exists(Common.indexPath))
			{
				System.Diagnostics.Process.Start(Common.indexPath);
			}
			else
			{
				message += "Index.html이 없습니다.\n";
			}

			if (File.Exists(Common.historyPath))
			{
				System.Diagnostics.Process.Start(Common.historyPath);
			}
			else
			{
				message += "Histroy.html이 없습니다.";
			}

			if (message != "")
			{
				MessageBox.Show(message);
			}

		}

		private void Bt_CreatHtml_Click(object sender, EventArgs e)
		{
			dm.CreateHtml(Common.indexPath, Common.historyPath, Common.dataPath);
		}

		private void Btn_Up_Click(object sender, EventArgs e)
		{
			
		}

		private void Btn_Down_Click(object sender, EventArgs e)
		{

		}

		private void MainPage_Load(object sender, EventArgs e)
		{
			DgvloadData(Dgv_index_New,1);
			DgvloadData(Dgv_index_Info,2);
			DgvloadData(Dgv_History,3);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			
			
		}

		private void Dgv_index_Info_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 11)
			{
				MessageBox.Show("test");
			}
		}

		private void DgvloadData(DataGridView dataGridView,int num) 
		{
			dataGridView.Columns.Clear();
			List<Writing> data = dm.SelectData(num);

			DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
			buttonColumn.HeaderText = "Delete";
			buttonColumn.Name = "Delete";

			dataGridView.Columns.Add("c1", "Img Use");
			dataGridView.Columns.Add("c2", "Popup Use");
			dataGridView.Columns.Add("c3", "Emoji");
			dataGridView.Columns.Add("c4", "Title");
			dataGridView.Columns.Add("c5", "Contents");
			dataGridView.Columns.Add("c6", "Img Src");
			dataGridView.Columns.Add("c7", "Category");
			dataGridView.Columns.Add("c8", "Date");
			dataGridView.Columns.Add("c9", "Pop up Title");
			dataGridView.Columns.Add("c10", "Pop up Img Src");
			dataGridView.Columns.Add("c11", "Pop up Contents");
			dataGridView.Columns.Add(buttonColumn);

			foreach (Writing item in data)
			{
				dataGridView.Rows.Add(item.Imge, item.Popup, item.Emogi, item.Title, item.Contents, item.Imgsrc, item.Category, item.GetDate(), item.Popuptitile, item.PopupImgSrc, item.PopupContent, "Delete");
			}

		}
	}
}
