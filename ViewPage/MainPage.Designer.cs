
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
			this.Dgv_index = new System.Windows.Forms.DataGridView();
			this.Dgv_History = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.Bt_OpenHtml = new System.Windows.Forms.Button();
			this.Bt_AddData = new System.Windows.Forms.Button();
			this.Bt_CreatHtml = new System.Windows.Forms.Button();
			this.Btn_Up = new System.Windows.Forms.Button();
			this.Btn_Down = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.Dgv_index)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Dgv_History)).BeginInit();
			this.SuspendLayout();
			// 
			// Bt_Setting
			// 
			this.Bt_Setting.Location = new System.Drawing.Point(1211, 42);
			this.Bt_Setting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Bt_Setting.Name = "Bt_Setting";
			this.Bt_Setting.Size = new System.Drawing.Size(131, 55);
			this.Bt_Setting.TabIndex = 31;
			this.Bt_Setting.Text = "Fix Text Setting";
			this.Bt_Setting.UseVisualStyleBackColor = true;
			this.Bt_Setting.Click += new System.EventHandler(this.Bt_Setting_Click);
			// 
			// Dgv_index
			// 
			this.Dgv_index.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.Dgv_index.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.Dgv_index.Location = new System.Drawing.Point(12, 42);
			this.Dgv_index.Name = "Dgv_index";
			this.Dgv_index.RowTemplate.Height = 23;
			this.Dgv_index.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.Dgv_index.Size = new System.Drawing.Size(1164, 193);
			this.Dgv_index.TabIndex = 32;
			// 
			// Dgv_History
			// 
			this.Dgv_History.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.Dgv_History.Location = new System.Drawing.Point(12, 293);
			this.Dgv_History.Name = "Dgv_History";
			this.Dgv_History.RowTemplate.Height = 23;
			this.Dgv_History.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.Dgv_History.Size = new System.Drawing.Size(1164, 245);
			this.Dgv_History.TabIndex = 33;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(10, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 12);
			this.label1.TabIndex = 34;
			this.label1.Text = "Index.Html";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 271);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 12);
			this.label2.TabIndex = 35;
			this.label2.Text = "History.Html";
			// 
			// Bt_OpenHtml
			// 
			this.Bt_OpenHtml.Location = new System.Drawing.Point(1211, 483);
			this.Bt_OpenHtml.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Bt_OpenHtml.Name = "Bt_OpenHtml";
			this.Bt_OpenHtml.Size = new System.Drawing.Size(131, 55);
			this.Bt_OpenHtml.TabIndex = 37;
			this.Bt_OpenHtml.Text = "Open HTML";
			this.Bt_OpenHtml.UseVisualStyleBackColor = true;
			this.Bt_OpenHtml.Click += new System.EventHandler(this.Bt_OpenHtml_Click);
			// 
			// Bt_AddData
			// 
			this.Bt_AddData.Location = new System.Drawing.Point(1211, 103);
			this.Bt_AddData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Bt_AddData.Name = "Bt_AddData";
			this.Bt_AddData.Size = new System.Drawing.Size(131, 55);
			this.Bt_AddData.TabIndex = 36;
			this.Bt_AddData.Text = "Add Item";
			this.Bt_AddData.UseVisualStyleBackColor = true;
			this.Bt_AddData.Click += new System.EventHandler(this.Bt_AddData_Click);
			// 
			// Bt_CreatHtml
			// 
			this.Bt_CreatHtml.Location = new System.Drawing.Point(1211, 422);
			this.Bt_CreatHtml.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Bt_CreatHtml.Name = "Bt_CreatHtml";
			this.Bt_CreatHtml.Size = new System.Drawing.Size(131, 55);
			this.Bt_CreatHtml.TabIndex = 38;
			this.Bt_CreatHtml.Text = "Create HTML";
			this.Bt_CreatHtml.UseVisualStyleBackColor = true;
			this.Bt_CreatHtml.Click += new System.EventHandler(this.Bt_CreatHtml_Click);
			// 
			// Btn_Up
			// 
			this.Btn_Up.Location = new System.Drawing.Point(605, 249);
			this.Btn_Up.Name = "Btn_Up";
			this.Btn_Up.Size = new System.Drawing.Size(42, 21);
			this.Btn_Up.TabIndex = 39;
			this.Btn_Up.Text = "↑";
			this.Btn_Up.UseVisualStyleBackColor = true;
			this.Btn_Up.Click += new System.EventHandler(this.Btn_Up_Click);
			// 
			// Btn_Down
			// 
			this.Btn_Down.Location = new System.Drawing.Point(653, 249);
			this.Btn_Down.Name = "Btn_Down";
			this.Btn_Down.Size = new System.Drawing.Size(42, 21);
			this.Btn_Down.TabIndex = 40;
			this.Btn_Down.Text = "↓";
			this.Btn_Down.UseVisualStyleBackColor = true;
			this.Btn_Down.Click += new System.EventHandler(this.Btn_Down_Click);
			// 
			// MainPage
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(1458, 561);
			this.Controls.Add(this.Btn_Down);
			this.Controls.Add(this.Btn_Up);
			this.Controls.Add(this.Bt_CreatHtml);
			this.Controls.Add(this.Bt_OpenHtml);
			this.Controls.Add(this.Bt_AddData);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Dgv_History);
			this.Controls.Add(this.Dgv_index);
			this.Controls.Add(this.Bt_Setting);
			this.Name = "MainPage";
			this.Text = "Make News";
			this.Load += new System.EventHandler(this.MainPage_Load);
			((System.ComponentModel.ISupportInitialize)(this.Dgv_index)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Dgv_History)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Bt_Setting;
		private System.Windows.Forms.DataGridView Dgv_index;
		private System.Windows.Forms.DataGridView Dgv_History;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button Bt_OpenHtml;
		private System.Windows.Forms.Button Bt_AddData;
		private System.Windows.Forms.Button Bt_CreatHtml;
		private System.Windows.Forms.Button Btn_Up;
		private System.Windows.Forms.Button Btn_Down;
	}
}