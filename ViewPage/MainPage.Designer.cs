
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
			this.button1 = new System.Windows.Forms.Button();
			this.Dgv_History = new System.Windows.Forms.DataGridView();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.Btn_Down = new System.Windows.Forms.Button();
			this.Btn_Up = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.Dgv_index_Info)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Dgv_index_New)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Dgv_History)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// Bt_Setting
			// 
			this.Bt_Setting.Location = new System.Drawing.Point(3, 3);
			this.Bt_Setting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Bt_Setting.Name = "Bt_Setting";
			this.Bt_Setting.Size = new System.Drawing.Size(131, 57);
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
			this.Dgv_index_Info.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Dgv_index_Info.Location = new System.Drawing.Point(3, 200);
			this.Dgv_index_Info.Name = "Dgv_index_Info";
			this.Dgv_index_Info.ReadOnly = true;
			this.Dgv_index_Info.RowTemplate.Height = 23;
			this.Dgv_index_Info.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.Dgv_index_Info.Size = new System.Drawing.Size(1289, 191);
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
			this.Dgv_index_New.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Dgv_index_New.Location = new System.Drawing.Point(0, 0);
			this.Dgv_index_New.MultiSelect = false;
			this.Dgv_index_New.Name = "Dgv_index_New";
			this.Dgv_index_New.ReadOnly = true;
			this.Dgv_index_New.RowTemplate.Height = 23;
			this.Dgv_index_New.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.Dgv_index_New.Size = new System.Drawing.Size(1289, 161);
			this.Dgv_index_New.TabIndex = 33;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 12);
			this.label1.TabIndex = 34;
			this.label1.Text = "Index.Html";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 12);
			this.label2.TabIndex = 35;
			this.label2.Text = "History.Html";
			// 
			// Bt_OpenHtml
			// 
			this.Bt_OpenHtml.Location = new System.Drawing.Point(3, 63);
			this.Bt_OpenHtml.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Bt_OpenHtml.Name = "Bt_OpenHtml";
			this.Bt_OpenHtml.Size = new System.Drawing.Size(131, 57);
			this.Bt_OpenHtml.TabIndex = 37;
			this.Bt_OpenHtml.Text = "Open HTML";
			this.Bt_OpenHtml.UseVisualStyleBackColor = true;
			this.Bt_OpenHtml.Click += new System.EventHandler(this.Bt_OpenHtml_Click);
			// 
			// Bt_AddData
			// 
			this.Bt_AddData.Location = new System.Drawing.Point(3, 2);
			this.Bt_AddData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Bt_AddData.Name = "Bt_AddData";
			this.Bt_AddData.Size = new System.Drawing.Size(131, 57);
			this.Bt_AddData.TabIndex = 36;
			this.Bt_AddData.Text = "Add Item";
			this.Bt_AddData.UseVisualStyleBackColor = true;
			this.Bt_AddData.Click += new System.EventHandler(this.Bt_AddData_Click);
			// 
			// Bt_CreatHtml
			// 
			this.Bt_CreatHtml.Location = new System.Drawing.Point(3, 2);
			this.Bt_CreatHtml.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Bt_CreatHtml.Name = "Bt_CreatHtml";
			this.Bt_CreatHtml.Size = new System.Drawing.Size(131, 57);
			this.Bt_CreatHtml.TabIndex = 38;
			this.Bt_CreatHtml.Text = "Create HTML";
			this.Bt_CreatHtml.UseVisualStyleBackColor = true;
			this.Bt_CreatHtml.Click += new System.EventHandler(this.Bt_CreatHtml_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(3, 63);
			this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(131, 57);
			this.button1.TabIndex = 41;
			this.button1.Text = "Change Item";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
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
			this.Dgv_History.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Dgv_History.Location = new System.Drawing.Point(0, 0);
			this.Dgv_History.Name = "Dgv_History";
			this.Dgv_History.ReadOnly = true;
			this.Dgv_History.RowTemplate.Height = 23;
			this.Dgv_History.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.Dgv_History.Size = new System.Drawing.Size(1289, 320);
			this.Dgv_History.TabIndex = 42;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.Dgv_index_Info, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.splitContainer2, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 3);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1501, 788);
			this.tableLayoutPanel1.TabIndex = 43;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(3, 3);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.Dgv_index_New);
			this.splitContainer1.Size = new System.Drawing.Size(1289, 191);
			this.splitContainer1.SplitterDistance = 26;
			this.splitContainer1.TabIndex = 35;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(3, 436);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.label2);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.Dgv_History);
			this.splitContainer2.Size = new System.Drawing.Size(1289, 349);
			this.splitContainer2.SplitterDistance = 25;
			this.splitContainer2.TabIndex = 36;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.Btn_Up);
			this.panel1.Controls.Add(this.Btn_Down);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 397);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1289, 33);
			this.panel1.TabIndex = 37;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.Bt_Setting);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(1298, 3);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(200, 191);
			this.panel2.TabIndex = 38;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.Bt_AddData);
			this.panel3.Controls.Add(this.button1);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(1298, 200);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(200, 191);
			this.panel3.TabIndex = 39;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.Bt_CreatHtml);
			this.panel4.Controls.Add(this.Bt_OpenHtml);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(1298, 436);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(200, 349);
			this.panel4.TabIndex = 40;
			// 
			// Btn_Down
			// 
			this.Btn_Down.Location = new System.Drawing.Point(555, 3);
			this.Btn_Down.Name = "Btn_Down";
			this.Btn_Down.Size = new System.Drawing.Size(42, 23);
			this.Btn_Down.TabIndex = 40;
			this.Btn_Down.Text = "↓";
			this.Btn_Down.UseVisualStyleBackColor = true;
			this.Btn_Down.Click += new System.EventHandler(this.Btn_Down_Click);
			// 
			// Btn_Up
			// 
			this.Btn_Up.Location = new System.Drawing.Point(512, 3);
			this.Btn_Up.Name = "Btn_Up";
			this.Btn_Up.Size = new System.Drawing.Size(42, 23);
			this.Btn_Up.TabIndex = 39;
			this.Btn_Up.Text = "↑";
			this.Btn_Up.UseVisualStyleBackColor = true;
			this.Btn_Up.Click += new System.EventHandler(this.Btn_Up_Click);
			// 
			// MainPage
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(1505, 793);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "MainPage";
			this.Text = "Make News";
			this.Load += new System.EventHandler(this.MainPage_Load);
			((System.ComponentModel.ISupportInitialize)(this.Dgv_index_Info)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Dgv_index_New)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Dgv_History)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel1.PerformLayout();
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.ResumeLayout(false);

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
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridView Dgv_History;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Button Btn_Up;
		private System.Windows.Forms.Button Btn_Down;
	}
}