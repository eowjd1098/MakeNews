using System;
using System.Drawing;
using System.Windows.Forms;

namespace MakeNews
{
	public partial class AddItemPage: Form
	{
		DataManger dm;

		#region Form Event 부
		public AddItemPage(DataManger _dm)
		{
			InitializeComponent();
			dm = _dm;

			Tb_Emogi.Enabled = true;
			Tb_imgsrc.Enabled = false;
			Tb_PoupTitle.Enabled = false;
			Tb_PoupContent.Enabled = false;
			Tb_PoupImgPath.Enabled = false;
			Bt_CopyContent.Enabled = false;

		}


		private void Bt_CopyContent_Click(object sender, EventArgs e)
		{
			Tb_PoupContent.Text = Tb_Content.Text;
		}

		#region 사용자화
		private void Cb_ImageUse_CheckedChanged(object sender, EventArgs e)
		{
			if (Cb_ImageUse.CheckState == CheckState.Unchecked)
			{
				Tb_Emogi.Enabled = true;
				Tb_imgsrc.Enabled = false;
				Tb_imgsrc.Text = string.Empty;
			}
			else if (Cb_ImageUse.CheckState == CheckState.Checked)
			{
				Tb_Emogi.Enabled = false;
				Tb_imgsrc.Enabled = true;

				Tb_Emogi.Text = string.Empty;
			}
			else
			{

			}

		}

		private void Cb_PopupUse_CheckedChanged(object sender, EventArgs e)
		{
			if (Cb_PopupUse.CheckState == CheckState.Unchecked)
			{
				Tb_PoupTitle.Enabled = false;
				Tb_PoupContent.Enabled = false;
				Tb_PoupImgPath.Enabled = false;
				Bt_CopyContent.Enabled = false;

				Tb_PoupTitle.Text = string.Empty;
				Tb_PoupContent.Text = string.Empty;
				Tb_PoupImgPath.Text = string.Empty;
			}
			else if (Cb_PopupUse.CheckState == CheckState.Checked)
			{
				Tb_PoupTitle.Enabled = true;
				Tb_PoupContent.Enabled = true;
				Tb_PoupImgPath.Enabled = true;
				Bt_CopyContent.Enabled = true;
			}
			else
			{

			}
		}

		public string TextEmtyCheck(bool emogi, bool titile, bool content, bool url, bool imgsrc, bool catagory, bool year, bool mount, bool day, bool popuptitile, bool popupImgSrc, bool popupContent)
		{
			string message = "";

			if (emogi)
			{
				if (Tb_Emogi.Text == string.Empty)
				{
					message += "이모지 항목 X\n";
				}

				//if (Tb_Emogi.Text.Length != 1)
				//{
				//	message += "이모지 너무김 X\n";
				//}
			}

			if (titile)
			{
				if (Tb_Title.Text == string.Empty)
				{
					message += "제목 항목 X\n";
				}
			}

			if (content)
			{
				if (Tb_Content.Text == string.Empty)
				{
					message += "내용 항목 X\n";
				}
			}

			if (url)
			{
				if (Tb_Url.Text == string.Empty)
				{
					message += "Url 항목 X\n";
				}
			}
			if (imgsrc)
			{
				if (Tb_imgsrc.Text == string.Empty)
				{
					message += "image 경로 항목 X\n";
				}
			}
			if (catagory)
			{
				if (Tb_Catagory.Text == string.Empty)
				{
					message += "카테고리 항목 X\n";
				}
			}
			if (year)
			{
				if (Tb_year.Text == string.Empty)
				{
					message += "년 항목 X\n";
				}

				if (!int.TryParse(Tb_year.Text, out int a))
				{
					message += "년 항목 숫자입력\n";
				}

			}
			if (mount)
			{
				if (Tb_mount.Text == string.Empty)
				{
					message += "월 항목 X\n";
				}
				if (!int.TryParse(Tb_mount.Text, out int a))
				{
					message += "월 항목 숫자입력\n";
				}
			}
			if (day)
			{
				if (Tb_Day.Text == string.Empty)
				{
					message += "일 항목 X\n";
				}
				if (!int.TryParse(Tb_Day.Text, out int a))
				{
					message += "일 항목 숫자입력\n";
				}
			}

			if (popuptitile)
			{
				if (Tb_PoupTitle.Text == string.Empty)
				{
					message += "팝업 제목 항목 X\n";
				}
			}

			if (popupImgSrc)
			{
				if (Tb_PoupImgPath.Text == string.Empty)
				{
					message += "팝업 이미지 항목 X\n";
				}
			}

			if (popupContent)
			{
				if (Tb_PoupContent.Text == string.Empty)
				{
					message += "팝업 내용 항목 X\n";
				}
			}

			return message;
		}
		#endregion

		#endregion

		private void Bt_Change_Click(object sender, EventArgs e)
		{
			bool ImgUse =false;
			bool popupUse =false;
			string message;

			#region 빈칸 체크
			if (Cb_ImageUse.CheckState == CheckState.Unchecked)
			{
				if (Cb_PopupUse.CheckState == CheckState.Unchecked)
				{
					message = TextEmtyCheck(true, true, true, true, false, true, true, true, true, false, false, false);
					if (message != "")
					{
						MessageBox.Show(message);
						return;
					}
					ImgUse = false;
					popupUse = false;

				}
				else if (Cb_PopupUse.CheckState == CheckState.Checked)
				{
					message = TextEmtyCheck(true, true, true, true, false, true, true, true, true, true, true, true);
					if (message != "")
					{
						MessageBox.Show(message);
						return;
					}
					ImgUse = false;
					popupUse = true;
				}
				else
				{

				}
			}
			else if (Cb_ImageUse.CheckState == CheckState.Checked)
			{
				if (Cb_PopupUse.CheckState == CheckState.Unchecked)
				{
					message = TextEmtyCheck(false, true, true, true, true, true, true, true, true, false, false, false);
					if (message != "")
					{
						MessageBox.Show(message);
						return;
					}
					ImgUse = true;
					popupUse = false;
				}
				else if (Cb_PopupUse.CheckState == CheckState.Checked)
				{
					message = TextEmtyCheck(false, true, true, true, true, true, true, true, true, true, true, true);
					if (message != "")
					{
						MessageBox.Show(message);
						return;
					}
					ImgUse = true;
					popupUse = true;
				}
				else
				{

				}
			}
			#endregion

			dm.InsertInfo( new Writing(ImgUse, popupUse, Tb_Emogi.Text, Tb_Title.Text, Tb_Content.Text, Tb_Url.Text, Tb_imgsrc.Text, Tb_Catagory.Text, Tb_year.Text, Tb_mount.Text, Tb_Day.Text, Tb_PoupTitle.Text, Tb_PoupImgPath.Text, Tb_PoupContent.Text));
			MessageBox.Show("Complete");
		}

		private void Bt_Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
