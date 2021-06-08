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
		List<Writing> news;
		List<Writing> info;
		List<Writing> history;

		DataManger _dm;// DataManger 전역 호출 용  

		#region Constructor
		public MainPage(DataManger dm)
		{
			InitializeComponent();
			_dm = dm;
			_dm.InitDataBase();
		}
		#endregion

		#region Load Event
		private void MainPage_Load(object sender, EventArgs e)
		{
			DgvReLoad();
		}
		#endregion
		 
		#region Setting Button Event
		private void Btn_Setting_Click(object sender, EventArgs e)
		{
			SettingPage form = new SettingPage();
			form.FormClosed += new FormClosedEventHandler(MainPage_Load);
			form.ShowDialog();

		}
		private void Bt_Setting_Click(object sender, EventArgs e)
		{
			FixTextSttingPage form = new FixTextSttingPage(_dm);
			form.ShowDialog();
		}
		#endregion

		#region Item Button Event
		private void Bt_AddData_Click(object sender, EventArgs e)
		{
			AddItemPage form = new AddItemPage(_dm,"Add Item");
			form.FormClosed += new FormClosedEventHandler(MainPage_Load);

			form.ShowDialog();
		}
		private void BtnChange_Click(object sender, EventArgs e)
		{
			Writing writing = new Writing();

			if (Dgv_index_New.SelectedRows.Count == 1) // DGV 로우 선택 확인
			{
				int rowIndex = Dgv_index_New.CurrentRow.Index;
				int[] date = DateChange(((string)Dgv_index_New.Rows[rowIndex].Cells[9].Value));

				writing.Index = (int)Dgv_index_New.Rows[rowIndex].Cells[0].Value;
				writing.Imge = (bool)Dgv_index_New.Rows[rowIndex].Cells[1].Value;
				writing.Popup = (bool)Dgv_index_New.Rows[rowIndex].Cells[2].Value;
				writing.Emogi = Dgv_index_New.Rows[rowIndex].Cells[3].Value.ToString();
				writing.Title = Dgv_index_New.Rows[rowIndex].Cells[4].Value.ToString();
				writing.Contents = Dgv_index_New.Rows[rowIndex].Cells[5].Value.ToString();
				writing.Imgsrc = Dgv_index_New.Rows[rowIndex].Cells[6].Value.ToString();
				writing.Url = Dgv_index_New.Rows[rowIndex].Cells[7].Value.ToString();
				writing.Category = Dgv_index_New.Rows[rowIndex].Cells[8].Value.ToString();
				writing.Year = date[0];
				writing.Month = date[1];
				writing.Day = date[2];
				writing.Popuptitile = Dgv_index_New.Rows[rowIndex].Cells[10].Value.ToString();
				writing.PopupImgSrc = Dgv_index_New.Rows[rowIndex].Cells[11].Value.ToString();
				writing.PopupContent = Dgv_index_New.Rows[rowIndex].Cells[12].Value.ToString();

			}
			else if (Dgv_index_Info.SelectedRows.Count == 1) // DGV 로우 선택 확인
			{
				int rowIndex = Dgv_index_Info.CurrentRow.Index;
				int[] date = DateChange(((string)Dgv_index_Info.Rows[rowIndex].Cells[9].Value));

				writing.Index = (int)Dgv_index_Info.Rows[rowIndex].Cells[0].Value;
				writing.Imge = (bool)Dgv_index_Info.Rows[rowIndex].Cells[1].Value;
				writing.Popup = (bool)Dgv_index_Info.Rows[rowIndex].Cells[2].Value;
				writing.Emogi = Dgv_index_Info.Rows[rowIndex].Cells[3].Value.ToString();
				writing.Title = Dgv_index_Info.Rows[rowIndex].Cells[4].Value.ToString();
				writing.Contents = Dgv_index_Info.Rows[rowIndex].Cells[5].Value.ToString();
				writing.Imgsrc = Dgv_index_Info.Rows[rowIndex].Cells[6].Value.ToString();
				writing.Url = Dgv_index_Info.Rows[rowIndex].Cells[7].Value.ToString();
				writing.Category = Dgv_index_Info.Rows[rowIndex].Cells[8].Value.ToString();
				writing.Year = date[0];
				writing.Month = date[1];
				writing.Day = date[2];
				writing.Popuptitile = Dgv_index_Info.Rows[rowIndex].Cells[10].Value.ToString();
				writing.PopupImgSrc = Dgv_index_Info.Rows[rowIndex].Cells[11].Value.ToString();
				writing.PopupContent = Dgv_index_Info.Rows[rowIndex].Cells[12].Value.ToString();
			}
			else if (Dgv_History.SelectedRows.Count == 1)// DGV 로우 선택 확인
			{
				int rowIndex = Dgv_History.CurrentRow.Index;
				int[] date = DateChange(((string)Dgv_History.Rows[rowIndex].Cells[9].Value));

				writing.Index = (int)Dgv_History.Rows[rowIndex].Cells[0].Value;
				writing.Imge = (bool)Dgv_History.Rows[rowIndex].Cells[1].Value;
				writing.Popup = (bool)Dgv_History.Rows[rowIndex].Cells[2].Value;
				writing.Emogi = Dgv_History.Rows[rowIndex].Cells[3].Value.ToString();
				writing.Title = Dgv_History.Rows[rowIndex].Cells[4].Value.ToString();
				writing.Contents = Dgv_History.Rows[rowIndex].Cells[5].Value.ToString();
				writing.Imgsrc = Dgv_History.Rows[rowIndex].Cells[6].Value.ToString();
				writing.Url = Dgv_History.Rows[rowIndex].Cells[7].Value.ToString();
				writing.Category = Dgv_History.Rows[rowIndex].Cells[8].Value.ToString();
				writing.Year = date[0];
				writing.Month = date[1];
				writing.Day = date[2];
				writing.Popuptitile = Dgv_History.Rows[rowIndex].Cells[10].Value.ToString();
				writing.PopupImgSrc = Dgv_History.Rows[rowIndex].Cells[11].Value.ToString();
				writing.PopupContent = Dgv_History.Rows[rowIndex].Cells[12].Value.ToString();
			}
			else 
			{
				MessageBox.Show("Not Select Row. Check Table");
				return;
			}

			AddItemPage form = new AddItemPage(_dm,"Change Item",writing);
			form.FormClosed += new FormClosedEventHandler(MainPage_Load);

			form.ShowDialog();
		}
		private void Btn_Up_Click(object sender, EventArgs e)
		{
			if (Dgv_History.SelectedRows.Count == 1) // 로우 선택 확인
			{
				int rowIndex = Dgv_History.CurrentRow.Index;
				if ((bool)Dgv_History.Rows[rowIndex].Cells[2].Value) //팝업일경우
				{
					if (_dm.SelectCountSession(2) < 2)
					{
						_dm.UpdateSession((int)Dgv_History.Rows[rowIndex].Cells[0].Value, 3, (bool)Dgv_History.Rows[rowIndex].Cells[2].Value);
						DgvReLoad();
					}
					else 
					{
						MessageBox.Show("Info Full Count. Please Check Info Table");
					}

				}
				else 
				{
					if (_dm.SelectCountSession(1) < 5)
					{
						_dm.UpdateSession((int)Dgv_History.Rows[rowIndex].Cells[0].Value, 3, (bool)Dgv_History.Rows[rowIndex].Cells[2].Value);
						DgvReLoad();
					}
					else
					{
						MessageBox.Show("News Full Count. Please Check News Table");
					}
				}
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
				int rowIndex = Dgv_index_New.CurrentRow.Index;
				_dm.UpdateSession((int)Dgv_index_New.Rows[rowIndex].Cells[0].Value,1,false);
				DgvReLoad();
			}
			else if (Dgv_index_Info.SelectedRows.Count == 1)
			{
				int rowIndex = Dgv_index_Info.CurrentRow.Index;
				_dm.UpdateSession((int)Dgv_index_Info.Rows[rowIndex].Cells[0].Value, 2, false);
				DgvReLoad();
			}
			else
			{
				MessageBox.Show("There is no selected row. Please choose from Up Table");
			}
		}
		#endregion
		 
		#region HTML Button Event
		private void Bt_CreatHtml_Click(object sender, EventArgs e)
		{
			_dm.CreateHtml(news,info,history);
			MessageBox.Show("Complete");
		}
		private void Bt_OpenHtml_Click(object sender, EventArgs e)
		{
			string message ="";

			if (File.Exists(Common.indexPath))
			{
				File.Copy(Common.indexPath, Properties.Settings.Default.copyFoderPath + @"\Index.html", true);
				System.Diagnostics.Process.Start(Properties.Settings.Default.copyFoderPath + @"\Index.html");
			}
			else
			{
				message += "Index.html이 없습니다.\n";
			} 

			if (File.Exists(Common.historyPath))
			{
				File.Copy(Common.historyPath, Properties.Settings.Default.copyFoderPath + @"\History.html", true);
				System.Diagnostics.Process.Start(Properties.Settings.Default.copyFoderPath + @"\History.html");
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
		#endregion
		
		#region Export Excel
		private void Btn_export_Click(object sender, EventArgs e)
		{
			List<Writing> data = new List<Writing>();

			foreach (Writing item in news)
			{
				data.Add(item);
			}
			foreach (Writing item in info)
			{
				data.Add(item);
			}
			foreach (Writing item in history)
			{
				data.Add(item);
			}

			_dm.SaveInfotoCSV(data);

			MessageBox.Show("Complete");
		}

		#endregion

		#region Data Grid View Cell Event
		private void Dgv_index_Info_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			Dgv_History.ClearSelection();
			Dgv_index_New.ClearSelection();

			//delete 시
			if (e.ColumnIndex == Dgv_index_Info.Columns["Delete"].Index)
			{
				DialogResult result  = MessageBox.Show("Do you want to delete?","Delete",MessageBoxButtons.OKCancel);
				if (result == DialogResult.OK) 
				{
					int rowIndex = Dgv_index_Info.CurrentRow.Index;
					_dm.DeleteInfo((int)Dgv_index_Info.Rows[rowIndex].Cells[0].Value);
					DgvReLoad();
				}
			}
		}
		private void Dgv_index_New_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			Dgv_History.ClearSelection();
			Dgv_index_Info.ClearSelection();

			//delete 시
			
			if (e.ColumnIndex == Dgv_index_New.Columns["Delete"].Index)
			{
				DialogResult result  = MessageBox.Show("Do you want to delete?","Delete",MessageBoxButtons.OKCancel);
				if (result == DialogResult.OK)
				{
					int rowIndex = Dgv_index_New.CurrentRow.Index;
					_dm.DeleteInfo((int)Dgv_index_New.Rows[rowIndex].Cells[0].Value);
					DgvReLoad();
				}
			}
		}
		private void Dgv_History_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			Dgv_index_New.ClearSelection();
			Dgv_index_Info.ClearSelection();

			//delete 시
			if (e.ColumnIndex == Dgv_History.Columns["Delete"].Index)
			{
				DialogResult result  = MessageBox.Show("Do you want to delete?","Delete",MessageBoxButtons.OKCancel);
				if (result == DialogResult.OK)
				{
					int rowIndex = Dgv_History.CurrentRow.Index;
					_dm.DeleteInfo((int)Dgv_History.Rows[rowIndex].Cells[0].Value);
					DgvReLoad();
				}
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
			List<Writing> data = _dm.SelectData(num);

			switch (num)
			{
				case 1: news = data; break;
				case 2: info = data; break;
				case 3: history = data; break;
				default:
					break;
			}

			DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
			{
				HeaderText = "Delete",
				Name = "Delete"
			};

			dataGridView.Columns.Add("c0", "Index");
			dataGridView.Columns.Add("c1", "Img Use");
			dataGridView.Columns.Add("c2", "Popup Use");
			dataGridView.Columns.Add("c3", "Emoji");
			dataGridView.Columns.Add("c4", "Title");
			dataGridView.Columns.Add("c5", "Contents");
			dataGridView.Columns.Add("c7", "Img Src");
			dataGridView.Columns.Add("c8", "URL");
			dataGridView.Columns.Add("c9", "Category");
			dataGridView.Columns.Add("c10", "Date");
			dataGridView.Columns.Add("c11", "Pop up Title");
			dataGridView.Columns.Add("c12", "Pop up Img Src");
			dataGridView.Columns.Add("c13", "Pop up Contents");
			dataGridView.Columns.Add(buttonColumn);

			foreach (Writing item in data)
			{
				dataGridView.Rows.Add(item.Index,item.Imge, item.Popup, item.Emogi, item.Title, item.Contents, item.Imgsrc,item.Url, item.Category, item.GetDate(), item.Popuptitile, item.PopupImgSrc, item.PopupContent, "Delete");
			}

		}
		 
		private int[] DateChange(string data) 
		{
			string[] dateArray = data.Split('/');
			int[] date = new int[3];
			date[0] = int.Parse(dateArray[0]);
			date[1] = int.Parse(dateArray[1]);
			date[2] = int.Parse(dateArray[2]);
			return date;
		}

		#endregion

	}
}
