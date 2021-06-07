
namespace MakeNews
{
	partial class SettingPage
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
			this.Bt_Cancel = new System.Windows.Forms.Button();
			this.Bt_Change = new System.Windows.Forms.Button();
			this.Btn_SelectPath = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Bt_Cancel
			// 
			this.Bt_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Bt_Cancel.Location = new System.Drawing.Point(638, 379);
			this.Bt_Cancel.Name = "Bt_Cancel";
			this.Bt_Cancel.Size = new System.Drawing.Size(80, 49);
			this.Bt_Cancel.TabIndex = 19;
			this.Bt_Cancel.Text = "Cancel";
			this.Bt_Cancel.UseVisualStyleBackColor = true;
			this.Bt_Cancel.Click += new System.EventHandler(this.Bt_Cancel_Click);
			// 
			// Bt_Change
			// 
			this.Bt_Change.Location = new System.Drawing.Point(552, 379);
			this.Bt_Change.Name = "Bt_Change";
			this.Bt_Change.Size = new System.Drawing.Size(80, 49);
			this.Bt_Change.TabIndex = 18;
			this.Bt_Change.Text = "Change";
			this.Bt_Change.UseVisualStyleBackColor = true;
			this.Bt_Change.Click += new System.EventHandler(this.Bt_Change_Click);
			// 
			// Btn_SelectPath
			// 
			this.Btn_SelectPath.BackColor = System.Drawing.Color.White;
			this.Btn_SelectPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.Btn_SelectPath.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.Btn_SelectPath.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.Btn_SelectPath.Location = new System.Drawing.Point(88, 54);
			this.Btn_SelectPath.Name = "Btn_SelectPath";
			this.Btn_SelectPath.Size = new System.Drawing.Size(380, 23);
			this.Btn_SelectPath.TabIndex = 20;
			this.Btn_SelectPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Btn_SelectPath.UseVisualStyleBackColor = false;
			this.Btn_SelectPath.Click += new System.EventHandler(this.Btn_SelectPath_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(32, 59);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 12);
			this.label1.TabIndex = 21;
			this.label1.Text = "label1";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(32, 93);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 12);
			this.label2.TabIndex = 22;
			this.label2.Text = "label2";
			// 
			// SettingPage
			// 
			this.AcceptButton = this.Bt_Change;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.CancelButton = this.Bt_Cancel;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.ControlBox = false;
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Btn_SelectPath);
			this.Controls.Add(this.Bt_Cancel);
			this.Controls.Add(this.Bt_Change);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingPage";
			this.Text = "Setting Page";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.SettingPage_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Bt_Cancel;
		private System.Windows.Forms.Button Bt_Change;
		private System.Windows.Forms.Button Btn_SelectPath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}