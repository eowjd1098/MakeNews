using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MakeNews
{
	public partial class SettingPage: Form
	{
		public SettingPage()
		{
			InitializeComponent();
		}

		private void Bt_Change_Click(object sender, EventArgs e)
		{
			Properties.Settings.Default.copyFoderPath = Btn_SelectPath.Text;

			if (Rb_Fix_Close.Checked)
			{
				Properties.Settings.Default.fixPageClose = true;
			}
			else 
			{
				Properties.Settings.Default.fixPageClose = false;
			}

			if (Rb_Add_Close.Checked)
			{
				Properties.Settings.Default.addPageClose = true;
			}
			else
			{
				Properties.Settings.Default.addPageClose = false;
			}

			if (Rb_Change_Close.Checked)
			{
				Properties.Settings.Default.changePageClose = true;
			}
			else
			{
				Properties.Settings.Default.changePageClose = false;
			}

			Properties.Settings.Default.Save();

			MessageBox.Show("Setting Save");
			Close();
		}

		private void Bt_Cancel_Click(object sender, EventArgs e)
		{
			Close();
		}
		
		private void Btn_SelectPath_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
			{
				ShowNewFolderButton = false
			};
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK) 
			{
				Btn_SelectPath.Text = folderBrowserDialog.SelectedPath;
			}
		}

		private void SettingPage_Load(object sender, EventArgs e)
		{
			Btn_SelectPath.Text = Properties.Settings.Default.copyFoderPath;

			if (Properties.Settings.Default.fixPageClose)
			{
				Rb_Fix_Close.Checked = true;
				Rb_Fix_Noting.Checked = false;
			}
			else
			{
				Rb_Fix_Close.Checked = false;
				Rb_Fix_Noting.Checked = true;
			}
			if (Properties.Settings.Default.addPageClose)
			{
				Rb_Add_Close.Checked = true;
				Rb_Add_Noting.Checked = false;
			}
			else
			{
				Rb_Add_Close.Checked = false;
				Rb_Add_Noting.Checked = true;
			}
			if (Properties.Settings.Default.changePageClose)
			{
				Rb_Change_Close.Checked = true;
				Rb_Change_Noting.Checked = false;
			}
			else
			{
				Rb_Change_Close.Checked = false;
				Rb_Change_Noting.Checked = true;
			}
		}

		//OpenFileDialog openFileDialog = new OpenFileDialog();
		//openFileDialog.DefaultExt = "html";
		//openFileDialog.Filter = "html(*.html)|*.html";
		//openFileDialog.ShowDialog();
		//
		//if (openFileDialog.FileName.Length > 0) 
		//{
		//	Btn_SelectPath.Text = openFileDialog.FileName;
		//}
	}
}
