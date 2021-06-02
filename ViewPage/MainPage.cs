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

		//Class Constructor
		public MainPage(DataManger _dm)
		{
			InitializeComponent();
			dm = _dm;
			dm.InitDataBase();
		}
		//Form Load Evnet
		private void MainPage_Load(object sender, EventArgs e)
		{
			DgvReLoad();
		}

		// TODO : Btn_Setting_Click Event 추가 필요
		// TODO : Bt_Setting_Click Property 화 할지 고민 -> 현재 파일입출력
		#region Setting Button Event
		private void Btn_Setting_Click(object sender, EventArgs e)
		{
			// 세팅 창 추가 
			//세팅창 추가할것 -> Add,Change 시 From Close 할지 안할지?

			//복사할 HTML 위치

		}
		private void Bt_Setting_Click(object sender, EventArgs e)
		{
			FixTextSttingPage form = new FixTextSttingPage(dm);
			form.ShowDialog();
		}
		#endregion

		// TODO : BtnChange_Click : Cell 확인 및 조건 파라매터 추가
		// TODO : Btn_Up_Click,Btn_Down_Click :DM쪽에 쿼리 호출 함수 추가필요 및 조건 파라매터 추가
		#region Item Button Event
		private void Bt_AddData_Click(object sender, EventArgs e)
		{
			AddItemPage form = new AddItemPage(dm,"ADD Item");
			form.FormClosed += new FormClosedEventHandler(MainPage_Load);

			form.ShowDialog();
		}
		private void BtnChange_Click(object sender, EventArgs e)
		{
			if (true) // 셀조건 걸어야함
			{
				AddItemPage form = new AddItemPage(dm,"Change Item");
				form.FormClosed += new FormClosedEventHandler(MainPage_Load);

				form.ShowDialog();
			}
		}
		private void Btn_Up_Click(object sender, EventArgs e)
		{
			if (Dgv_History.SelectedRows.Count == 1) // 로우 선택 확인
			{
				MessageBox.Show("test up click");
			}
			else
			{
				MessageBox.Show("There is no selected row. Please choose from Down Table");
			}
		}
		private void Btn_Down_Click(object sender, EventArgs e)
		{
			if (Dgv_index_New.SelectedRows.Count == 1) // 로우 선택 확인
			{
				MessageBox.Show("test Down1 click");
			}
			else if (Dgv_index_Info.SelectedRows.Count == 1)
			{
				MessageBox.Show("test Down2 click");
			}
			else
			{
				MessageBox.Show("There is no selected row. Please choose from Up Table");
			}
		}
		#endregion

		// TODO : Bt_CreatHtml_Click: Create HTML 로직 수정 필요,경로수정 로직 필요
		// TODO : Bt_OpenHtml_Click: 경로수정 로직 필요
		// TODO : btn_CopyHtml_Click: 경로수정 로직 필요
		#region HTML Button Event
		private void Bt_CreatHtml_Click(object sender, EventArgs e)
		{
			dm.CreateHtml(Common.indexPath, Common.historyPath, Common.dataPath);
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
		private void btn_CopyHtml_Click(object sender, EventArgs e)
		{

		}
		#endregion

		// TODO : Delet 기능 추가 필요
		#region Data Grid View Cell Event
		private void Dgv_index_Info_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			Dgv_History.ClearSelection();
			Dgv_index_New.ClearSelection();

			//delete 시
			if (e.ColumnIndex == Dgv_index_Info.Columns["Delete"].Index)
			{
				DeleteRow(1);
				DgvReLoad();
			}
		}
		private void Dgv_index_New_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			Dgv_History.ClearSelection();
			Dgv_index_Info.ClearSelection();

			//delete 시
			if (e.ColumnIndex == Dgv_index_New.Columns["Delete"].Index)
			{
				DeleteRow(2);
				DgvReLoad();
			}
		}
		private void Dgv_History_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			Dgv_index_New.ClearSelection();
			Dgv_index_Info.ClearSelection();


			
			//delete 시
			if (e.ColumnIndex == Dgv_History.Columns["Delete"].Index)
			{
				//Dgv_History[e.RowIndex];
				DeleteRow(3);
				DgvReLoad();
			}
		}
		#endregion

		#region Data Gride View Sub Function
		private void DgvReLoad()
		{
			DgvloadData(Dgv_index_New, 1);
			DgvloadData(Dgv_index_Info, 2);
			DgvloadData(Dgv_History, 3);

			Dgv_History.Columns[0].Visible = false;
			Dgv_index_New.Columns[0].Visible = false;
			Dgv_index_Info.Columns[0].Visible = false;

			Dgv_index_New.ClearSelection();
			Dgv_index_Info.ClearSelection();
			Dgv_History.ClearSelection();
		}
		private void DgvloadData(DataGridView dataGridView, int num)
		{
			dataGridView.Columns.Clear();
			List<Writing> data = dm.SelectData(num);

			DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
			buttonColumn.HeaderText = "Delete";
			buttonColumn.Name = "Delete";

			dataGridView.Columns.Add("c0", "Index");
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
				dataGridView.Rows.Add(item.Index,item.Imge, item.Popup, item.Emogi, item.Title, item.Contents, item.Imgsrc, item.Category, item.GetDate(), item.Popuptitile, item.PopupImgSrc, item.PopupContent, "Delete");
			}

		}
		private void DeleteRow(int num)
		{
		
		}
		#endregion
		
	}
}
