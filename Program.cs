using System;
using System.Windows.Forms;

namespace MakeNews
{
	static class Program
	{
		/// <summary>
		/// ���α׷� ������ 
		/// </summary>
		[STAThread]
		static void Main()
		{
			DataManger dm = DataManger.Instance();                  // ������ ������ Ŭ���� �̱��ν��Ͻ� ȭ(SingelTone ���� -> ��ü�� 1���� ���� ���) 
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainPage(dm));                      // Page Open ex) new AdditemPage �� Addtiem Page �� ������������ ���α׷�����
		
		
		}
	}
}
