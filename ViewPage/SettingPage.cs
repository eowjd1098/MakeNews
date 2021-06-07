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
		DataManger _dm;
		public SettingPage(DataManger dm)
		{
			InitializeComponent();
			_dm = dm;
		}

		private void Bt_Change_Click(object sender, EventArgs e)
		{

		}

		private void Bt_Cancel_Click(object sender, EventArgs e)
		{

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
		private void Btn_SelectPath_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog =new FolderBrowserDialog();
			folderBrowserDialog.ShowNewFolderButton = false;
			if (folderBrowserDialog.ShowDialog() == DialogResult.OK) 
			{
				Btn_SelectPath.Text = folderBrowserDialog.SelectedPath;
			}
		}

		private void SettingPage_Load(object sender, EventArgs e)
		{

		}
	}

}
