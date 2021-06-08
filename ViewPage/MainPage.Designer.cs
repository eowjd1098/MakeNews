
namespace MakeNews
{
	/// <summary>
	/// Main 화면 UI 코드 <-- 자동생성 부분
	/// </summary>
	partial class MainPage
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Bt_Setting = new System.Windows.Forms.Button();
			this.Dgv_index_Info = new System.Windows.Forms.DataGridView();
			this.Dgv_index_New = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.Bt_OpenHtml = new System.Windows.Forms.Button();
			this.Bt_AddData = new System.Windows.Forms.Button();
			this.Bt_CreatHtml = new System.Windows.Forms.Button();
			this.Btn_Change = new System.Windows.Forms.Button();
			this.Dgv_History = new System.Windows.Forms.DataGridView();
			this.Btn_Up = new System.Windows.Forms.Button();
			this.Btn_Down = new System.Windows.Forms.Button();
			this.Btn_Setting = new System.Windows.Forms.Button();
			this.btn_export = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.Dgv_index_Info)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Dgv_index_New)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Dgv_History)).BeginInit();
			this.SuspendLayout();
			// 
			// Bt_Setting
			// 
			this.Bt_Setting.Location = new System.Drawing.Point(1245, 85);
			this.Bt_Setting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Bt_Setting.Name = "Bt_Setting";
			this.Bt_Setting.Size = new System.Drawing.Size(197, 57);
			this.Bt_Setting.TabIndex = 31;
			this.Bt_Setting.Text = "Fix Text Setting";
			this.Bt_Setting.UseVisualStyleBackColor = true;
			this.Bt_Setting.Click += new System.EventHandler(this.Bt_Setting_Click);
			// 
			// Dgv_index_Info
			// 
			this.Dgv_index_Info.AllowUserToAddRows = false;
			this.Dgv_index_Info.AllowUserToDeleteRows = false;
			this.Dgv_index_Info.AllowUserToResizeColumns = false;
			this.Dgv_index_Info.AllowUserToResizeRows = false;
			this.Dgv_index_Info.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.Dgv_index_Info.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.Dgv_index_Info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.Dgv_index_Info.Location = new System.Drawing.Point(12, 191);
			this.Dgv_index_Info.Name = "Dgv_index_Info";
			this.Dgv_index_Info.ReadOnly = true;
			this.Dgv_index_Info.RowTemplate.Height = 23;
			this.Dgv_index_Info.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.Dgv_index_Info.Size = new System.Drawing.Size(1228, 90);
			this.Dgv_index_Info.TabIndex = 32;
			this.Dgv_index_Info.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_index_Info_CellClick);
			// 
			// Dgv_index_New
			// 
			this.Dgv_index_New.AllowUserToAddRows = false;
			this.Dgv_index_New.AllowUserToDeleteRows = false;
			this.Dgv_index_New.AllowUserToResizeColumns = false;
			this.Dgv_index_New.AllowUserToResizeRows = false;
			this.Dgv_index_New.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.Dgv_index_New.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.Dgv_index_New.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.Dgv_index_New.Location = new System.Drawing.Point(12, 24);
			this.Dgv_index_New.MultiSelect = false;
			this.Dgv_index_New.Name = "Dgv_index_New";
			this.Dgv_index_New.ReadOnly = true;
			this.Dgv_index_New.RowTemplate.Height = 23;
			this.Dgv_index_New.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.Dgv_index_New.Size = new System.Drawing.Size(1228, 161);
			this.Dgv_index_New.TabIndex = 33;
			this.Dgv_index_New.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_index_New_CellClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 12);
			this.label1.TabIndex = 34;
			this.label1.Text = "Index.Html";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 319);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 12);
			this.label2.TabIndex = 35;
			this.label2.Text = "History.Html";
			// 
			// Bt_OpenHtml
			// 
			this.Bt_OpenHtml.Location = new System.Drawing.Point(1245, 395);
			this.Bt_OpenHtml.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Bt_OpenHtml.Name = "Bt_OpenHtml";
			this.Bt_OpenHtml.Size = new System.Drawing.Size(197, 57);
			this.Bt_OpenHtml.TabIndex = 37;
			this.Bt_OpenHtml.Text = "Open after Copy HTML\r\n";
			this.Bt_OpenHtml.UseVisualStyleBackColor = true;
			this.Bt_OpenHtml.Click += new System.EventHandler(this.Bt_OpenHtml_Click);
			// 
			// Bt_AddData
			// 
			this.Bt_AddData.Location = new System.Drawing.Point(1245, 191);
			this.Bt_AddData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Bt_AddData.Name = "Bt_AddData";
			this.Bt_AddData.Size = new System.Drawing.Size(194, 57);
			this.Bt_AddData.TabIndex = 36;
			this.Bt_AddData.Text = "Add Item";
			this.Bt_AddData.UseVisualStyleBackColor = true;
			this.Bt_AddData.Click += new System.EventHandler(this.Bt_AddData_Click);
			// 
			// Bt_CreatHtml
			// 
			this.Bt_CreatHtml.Location = new System.Drawing.Point(1245, 334);
			this.Bt_CreatHtml.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Bt_CreatHtml.Name = "Bt_CreatHtml";
			this.Bt_CreatHtml.Size = new System.Drawing.Size(197, 57);
			this.Bt_CreatHtml.TabIndex = 38;
			this.Bt_CreatHtml.Text = "Create HTML";
			this.Bt_CreatHtml.UseVisualStyleBackColor = true;
			this.Bt_CreatHtml.Click += new System.EventHandler(this.Bt_CreatHtml_Click);
			// 
			// Btn_Change
			// 
			this.Btn_Change.Location = new System.Drawing.Point(1245, 252);
			this.Btn_Change.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Btn_Change.Name = "Btn_Change";
			this.Btn_Change.Size = new System.Drawing.Size(194, 57);
			this.Btn_Change.TabIndex = 41;
			this.Btn_Change.Text = "Change Item";
			this.Btn_Change.UseVisualStyleBackColor = true;
			this.Btn_Change.Click += new System.EventHandler(this.BtnChange_Click);
			// 
			// Dgv_History
			// 
			this.Dgv_History.AllowUserToAddRows = false;
			this.Dgv_History.AllowUserToDeleteRows = false;
			this.Dgv_History.AllowUserToResizeColumns = false;
			this.Dgv_History.AllowUserToResizeRows = false;
			this.Dgv_History.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.Dgv_History.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.Dgv_History.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.Dgv_History.Location = new System.Drawing.Point(12, 334);
			this.Dgv_History.Name = "Dgv_History";
			this.Dgv_History.ReadOnly = true;
			this.Dgv_History.RowTemplate.Height = 23;
			this.Dgv_History.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.Dgv_History.Size = new System.Drawing.Size(1228, 348);
			this.Dgv_History.TabIndex = 42;
			this.Dgv_History.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_History_CellClick);
			// 
			// Btn_Up
			// 
			this.Btn_Up.Location = new System.Drawing.Point(583, 287);
			this.Btn_Up.Name = "Btn_Up";
			this.Btn_Up.Size = new System.Drawing.Size(42, 23);
			this.Btn_Up.TabIndex = 39;
			this.Btn_Up.Text = "↑";
			this.Btn_Up.UseVisualStyleBackColor = true;
			this.Btn_Up.Click += new System.EventHandler(this.Btn_Up_Click);
			// 
			// Btn_Down
			// 
			this.Btn_Down.Location = new System.Drawing.Point(628, 287);
			this.Btn_Down.Name = "Btn_Down";
			this.Btn_Down.Size = new System.Drawing.Size(42, 23);
			this.Btn_Down.TabIndex = 40;
			this.Btn_Down.Text = "↓";
			this.Btn_Down.UseVisualStyleBackColor = true;
			this.Btn_Down.Click += new System.EventHandler(this.Btn_Down_Click);
			// 
			// Btn_Setting
			// 
			this.Btn_Setting.Location = new System.Drawing.Point(1245, 24);
			this.Btn_Setting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Btn_Setting.Name = "Btn_Setting";
			this.Btn_Setting.Size = new System.Drawing.Size(197, 57);
			this.Btn_Setting.TabIndex = 32;
			this.Btn_Setting.Text = "Application Setting\r\n";
			this.Btn_Setting.UseVisualStyleBackColor = true;
			this.Btn_Setting.Click += new System.EventHandler(this.Btn_Setting_Click);
			// 
			// btn_export
			// 
			this.btn_export.Location = new System.Drawing.Point(1245, 624);
			this.btn_export.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btn_export.Name = "btn_export";
			this.btn_export.Size = new System.Drawing.Size(197, 57);
			this.btn_export.TabIndex = 43;
			this.btn_export.Text = "Export Data For Execel";
			this.btn_export.UseVisualStyleBackColor = true;
			this.btn_export.Click += new System.EventHandler(this.Btn_export_Click);
			// 
			// MainPage
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(1451, 692);
			this.Controls.Add(this.btn_export);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Dgv_index_New);
			this.Controls.Add(this.Dgv_index_Info);
			this.Controls.Add(this.Btn_Up);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Btn_Down);
			this.Controls.Add(this.Dgv_History);
			this.Controls.Add(this.Btn_Change);
			this.Controls.Add(this.Bt_OpenHtml);
			this.Controls.Add(this.Bt_CreatHtml);
			this.Controls.Add(this.Bt_AddData);
			this.Controls.Add(this.Bt_Setting);
			this.Controls.Add(this.Btn_Setting);
			this.Name = "MainPage";
			this.Text = "Make News";
			this.Load += new System.EventHandler(this.MainPage_Load);
			((System.ComponentModel.ISupportInitialize)(this.Dgv_index_Info)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Dgv_index_New)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Dgv_History)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Bt_Setting;
		private System.Windows.Forms.DataGridView Dgv_index_Info;
		private System.Windows.Forms.DataGridView Dgv_index_New;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button Bt_OpenHtml;
		private System.Windows.Forms.Button Bt_AddData;
		private System.Windows.Forms.Button Bt_CreatHtml;
		private System.Windows.Forms.Button Btn_Change;
		private System.Windows.Forms.DataGridView Dgv_History;
		private System.Windows.Forms.Button Btn_Up;
		private System.Windows.Forms.Button Btn_Down;
		private System.Windows.Forms.Button Btn_Setting;
		private System.Windows.Forms.Button btn_export;
	}
}