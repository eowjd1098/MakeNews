using System;
using System.Windows.Forms;

namespace MakeNews
{
	static class Program
	{
		/// <summary>
		/// 프로그램 시작점 
		/// </summary>
		[STAThread]
		static void Main()
		{
			DataManger dm = DataManger.Instance();                  // 데이터 관리용 클래스 싱글인스턴스 화(SingelTone 패턴 -> 객체를 1개만 만들어서 사용) 
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainPage(dm));                      // Page Open ex) new AdditemPage 시 Addtiem Page 를 시작페이지로 프로그램실행
		
		
		}
	}
}
