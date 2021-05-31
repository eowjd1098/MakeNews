using System;
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
			//Font = Common.SetFont();
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
			dm.InsertInfo();
		}

		private void Btn_Down_Click(object sender, EventArgs e)
		{

		}

		private void MainPage_Load(object sender, EventArgs e)
		{
			 


			


			
			 //버튼 추가
 	        DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
 	          
 	        buttonColumn.HeaderText = "Button";
 	        buttonColumn.Name = "button";

			Dgv_index_Info.Columns.Add("c1","Img Use");
			Dgv_index_Info.Columns.Add("c2","Popup Use");
			Dgv_index_Info.Columns.Add("c3","Emoji");
			Dgv_index_Info.Columns.Add("c4","Title");
			Dgv_index_Info.Columns.Add("c5","Contents");
			Dgv_index_Info.Columns.Add("c6","Img Src");
			Dgv_index_Info.Columns.Add("c7","Category");
			Dgv_index_Info.Columns.Add("c8","Date");
			Dgv_index_Info.Columns.Add("c9","Pop up Title");
			Dgv_index_Info.Columns.Add("c10","Pop up Img Src");
			Dgv_index_Info.Columns.Add("c11","Pop up Contents");
			Dgv_index_Info.Columns.Add(buttonColumn);


			Dgv_index_Info.Rows.Add();

			Dgv_index_Info[0, 0].Value = false;
			Dgv_index_Info[1, 0].Value = false;
			Dgv_index_Info[2, 0].Value = "Emoji";
			Dgv_index_Info[3, 0].Value = "Title";
			Dgv_index_Info[4, 0].Value = "Contents";
			Dgv_index_Info[5, 0].Value = "Img Src";
			Dgv_index_Info[6, 0].Value = "Category";
			Dgv_index_Info[7, 0].Value = "Date";
			Dgv_index_Info[8, 0].Value = "Pop up Title";
			Dgv_index_Info[9, 0].Value = "Pop up Img Src";
			Dgv_index_Info[10, 0].Value = "Pop up Contents";
			Dgv_index_Info[11, 0].Value = "Delete";

			Dgv_index_Info.CellClick += dataGridView1_CellClick;
		}

		public void button_ClickTest() 
		{
			MessageBox.Show("Test");
		}

		void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			// 버튼 클릭 이벤트 설정  
			// - 그리드뷰를 클릭했을 때, 버튼 컬럼 인덱스와 같으면 처리를 한다.  
			// - 이런식으로 버튼 클릭 이벤트를 흉내낸다.  
			if (e.ColumnIndex == 11)
			{
				MessageBox.Show("test");
			}
		}

		 

	}
}
