using System;
using System.Data;
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
			Font = Common.GetFont();
			
			dm = _dm;
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
			index = new DataTable();

			index.Columns.Add("Img Use", typeof(bool));
			index.Columns.Add("Popup Use", typeof(bool));
			index.Columns.Add("Emoji", typeof(string));
			index.Columns.Add("Title", typeof(string));
			index.Columns.Add("Contents", typeof(string));
			index.Columns.Add("Img Src", typeof(string));
			index.Columns.Add("Category", typeof(string));
			index.Columns.Add("Date", typeof(string));
			index.Columns.Add("Pop up Title", typeof(string));
			index.Columns.Add("Pop up Img Src", typeof(string));
			index.Columns.Add("Pop up Contents", typeof(string));

			
				
			// 각각의 행에 내용을 입력합니다.
			index.Rows.Add();
			

			// 값들이 입력된 테이블을 DataGridView에 입력합니다.
			Dgv_index.DataSource = index;


		}
	}
}
