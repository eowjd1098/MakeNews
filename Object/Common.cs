using System.Windows.Forms;

namespace MakeNews
{
	public class Common
	{
		//Data 경로
		public static string fixdataPath = Application.StartupPath + @"\FixData.xml";
		public static string DBPath = Application.StartupPath + @"\Data.db";
		public static string DBDataPath = "Data Source=" + Application.StartupPath + "\\Data.db;Version=3;";

		//파일 경로
		public static string indexPath = Application.StartupPath + @"\Index.html";
		public static string historyPath = Application.StartupPath + @"\History.html";
		public static string exportCsvPath = Application.StartupPath + @"\Data.csv";

		#region HTML CODE
		//Index Page 순서 Head -> BodyUpper -> NewsnoImg,NewsImg,Empty(반복) -> PopupnoImg, PopupImg,Empty(반복) ->BodyDown-> PopupContents-> Script
		public string GetIndexHeadHtml(string Fixtitile)
		{
			string text =
@"<!DOCTYPE html>
<html lang=""ko"">
	<head>
	<meta charset=""UTF-8"">
	<title>"+Fixtitile+@"</title>
	<meta name=""viewport"" content=""width=device-width, initial-scale=1.0, shrink-to-fit=no"">
	<meta http-equiv=""Content-Script-Type"" content=""text/javascript"">
	<meta http-equiv=""Content-Style-Type"" content=""text/css"">
	<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
	<meta name=""apple-mobile-web-app-title"" content=""타이틀"">
	<meta name=""apple-mobile-web-app-capable"" content=""yes"">
	<meta name=""title"" content=""타이틀"">
	<meta name=""keywords"" content=""키워드"">
	<meta name=""description"" content=""데스크립션"">
	<meta itemprop=""name"" content=""타이틀"">
	<meta itemprop=""description"" content=""데스크립션"">
	<meta itemprop=""image"" content=""./img/favicons/thumb_sns.jpg"">
	<meta property=""fb:app_id"" content=""APP_ID"">
	<meta property=""og:type"" content=""Website"">
	<meta property=""og:title"" content=""타이틀"">
	<meta property=""og:url"" content=""./index.html"">
	<meta property=""og:description"" content=""데스크립션"">
	<meta property=""og: image"" content = ""이미지"">
	<link rel=""stylesheet"" href=""css/style.css"">
	<script src=""js/jquery-3.5.1.min.js""></script>
	</head>";

			return text;
		}
		public string GetIndexBodyUpperHtml(string Ptag)
		{
			string text =
@"<body>
<!-- wrap -->
<div id = ""wrap"">
	<!--header--><!--//header-->
	<!--container-->
	<section id =""container"">
		 <!--contents-->
 
		 <div class=""contents"">
			<!-- cover -->
			<section class=""cover"">
				<h1>금요일 뉴스레터</h1>
				<p class=""desc"">"+ Ptag+@"</p>
				<span class=""star star01""></span>
				<span class=""star star02""></span>
				<span class=""star star03""></span>
				<span class=""star star04""></span>
			</section>
			<!-- //cover -->
			<!-- news -->
			<section class=""news"">
				<ul>";
			return text;
		}
		public string GetIndexBodyNewsNotImgHtml(string url, string emogi, string titile, string sumry, string date, string catagory)
		{
			string text =
@"			<!-- 기사 / 이미지 없는 경우 -->
			<li class=""article"">
				<a href="""+url+@""" target=""_blank"">
					<div class=""news_wrap"">
						<span class=""emoji"">"+emogi+@"</span>
						<h3 class=""tit"">"+titile+@"</h3><!-- 이미지 없는 기사는 타이틀 두줄까지 노출, 이후 말줄임표 처리 -->
						<p class=""smry"">"+sumry+@"</p><!-- 3줄까지 노출, 이후 말줄임표 처리 -->
						<div class=""info"">
							<time class=""date"">"+date+@"</time>
							<em class=""category"">"+catagory+@"</em>
						</div>
					</div>
				</a><!-- href=""아웃링크 주소"" / 새탭 열림 -->
			</li>
			<!-- //기사 / 이미지 없는 경우 -->";
			return text;
		}
		public string GetIndexBodyNewsImgHtml(string url, string img, string titile, string date, string catagory)
		{
			string text =
@"			<!-- 기사 / 이미지 있는 경우 -->
			<li class=""article img"">
				<a href="""+url+@""" target=""_blank"">
					<div class=""thumb""><img src="""+img+@""" width=""100%"" height="""" alt=""기사 이미지""></div><!-- 이미지 사이즈 350*250 / 사이즈 안맞을 경우 상단부터 노출 하단 잘림 -->
					<div class=""news_wrap"">
						<h3 class=""tit"">"+titile+@"</h3><!-- 이미지 있는 기사는 타이틀 한줄 노출, 이후 말줄임표 처리 -->
						<div class=""info"">
							<time class=""date"">"+date+@"</time>
							<em class=""category"">"+catagory+@"</em>
						</div>
					</div>
				</a><!-- href= ""아웃링크 주소"" / 새탭 열림 -->
			</li>
			<!-- //기사 / 이미지 있는 경우 -->";
			return text;
		}
		public string GetIndexBodyPopupHtml(string popupnum, string emogi, string titile, string sumry, string date, string catagory)
		{
			string text =
@"				<!-- 소식 / 클릭시 ly_pop"+popupnum+@" 팝업 -->
				<li class=""noti"">
					<a href=""#ly_pop"+popupnum+@""">
						<div class=""news_wrap"">
							<span class=""emoji"">"+emogi+@"</span>
							<h3 class=""tit"">"+titile+@"</h3>
							<p class=""smry"">"+sumry+@"</p>
							<div class=""info"">
								<time class=""date"">"+date+@"</time>
								<em class=""category"">"+catagory+@"</em>
							</div>
						</div>
					</a>
				</li>
				<!-- //소식 / 클릭시 ly_pop"+popupnum+@" 팝업 -->";
			return text;
		} 
		public string GetIndexBodyEmptyHtml()
		{
			string text =
@"				<!-- 데이터 없는 경우 빈 li 생성 -->
				<li></li>
				<!-- //데이터 없는 경우 빈 li 생성 -->";
			return text;
		}
		public string GetIndexBodyDownHtml(string copy)
		{
			string text =
@"				<!-- 지난 뉴스 페이지 이동 -->
				<li class=""history"">
					<a href=""history.html"">
						<h3>지난 뉴스 돌아보기</h3>
						<span class=""star star01""></span>
						<span class=""star star02""></span>
						<span class=""star star03""></span>
						<span class=""star star04""></span>
					</a>
				</li>
				<!-- //지난 뉴스 페이지 이동 -->
				</ul>
			</section>
			<!-- //news -->
		</div>
		<!-- //contents -->
		<!-- aside -->
		<div class=""donate"">
			<div class=""marquee_bx"">
				<p class=""plz""><img src=""img/txt_plz_vertical.png"" width=""100%"" height="""" alt=""이미지"" class=""vrt""><img src=""img/txt_plz.png"" width=""100%"" height="""" alt="""" class=""hrz""></p>
				<p class=""plz""><img src=""img/txt_plz_vertical.png"" width=""100%"" height="""" alt=""이미지"" class=""vrt""><img src=""img/txt_plz.png"" width=""100%"" height="""" alt="""" class=""hrz""></p>
				<p class=""plz""><img src=""img/txt_plz_vertical.png"" width=""100%"" height="""" alt=""이미지"" class=""vrt""><img src=""img/txt_plz.png"" width=""100%"" height="""" alt="""" class=""hrz""></p>
			</div>
		</div>
		<!-- //aside -->
	</section>
	<!-- //container -->
	<!-- footer -->
	<footer id=""footer"">
		<strong class=""copy"">"+copy+@"</strong>
	</footer>
	<!-- //footer -->
</div>";
			return text;
		}
		public string GetIndexPopUpContentsImgeUseHtml(string popupnum, string popuptitle, string popupimg, string popupcontent)
		{
			string text =
@"<!-- //wrap --> 
<div class=""ly_pop"" id=""ly_pop"+popupnum+@""">
	<div class=""cnt_bx"">
		<strong class=""tit"">"+popuptitle+@"</strong>
		<div class=""img_area""><img src="""+popupimg+@""" width=""100%"" height="""" alt=""소식 이미지""></div><!-- 이미지 사이즈 1000*400 / 사이즈 안맞을 경우 상단부터 노출 하단 잘림 -->
		<div class=""txt_area"">
			<p>"+popupcontent+@"</p>
		</div>
		<button type = ""button"" class=""btn_close"">소식창 닫기</button>
	</div>
</div>"; 
			return text;
		}

		public string GetIndexPopUpContentsHtml(string popupnum, string popuptitle, string popupcontent)
		{
			string text =
@"<div class=""ly_pop"" id=""ly_pop"+popupnum+@""">
	<div class=""cnt_bx"">
		<strong class=""tit"">"+popuptitle+@"</strong>
		<div class=""txt_area"">
			<p>"+popupcontent+@"</p>
		</div>
		<button type = ""button"" class=""btn_close"">소식창 닫기</button>
	</div>
</div> ";
			return text;
		}
		public string GetIndexScriptHtml()
		{
			string text=
@"<script>
//history 페이지 이동
$('.news li.history a').click(function () {
			var url = $(this).attr('href');
	$('body').animate({
				'opacity':'0'
	}, 300, function() {
				document.location.href = url;
			});
			return false;
		});
//팝업 열기
$('.news .noti>a').on('click', function(e){
			var PopBx = $(this).attr('href');
	$(PopBx).fadeIn().addClass('on');
	$('body').css({ overflow: 'hidden'}).bind('touchmove', function(e){
				e.preventDefault()
	});
		});
//팝업 닫기
$(document).mouseup(function(e){
			var LyPop = $("".ly_pop"");
			if (LyPop.has(e.target).length === 0)
			{
				LyPop.fadeOut().removeClass('on');
			}
	$('.ly_pop .btn_close').on('click', function(e){
				LyPop.fadeOut().removeClass('on');
			});
	$('body').css({ overflow: 'scroll'}).unbind('touchmove');
		});
</script>
</body>
</html>";

			return text;
		}

		//Histroy Page 순서  Head -> News(반복)->Script
		public string GetIHistoryHeadHtml(string Fixtitile, string lst_wrapH2)
		{
			string text =
@"<!DOCTYPE html>
<html lang=""ko"">
	<head>
	<meta charset=""UTF-8"">
	<title>"+Fixtitile+@"</title>
	<meta name=""viewport"" content=""width=device-width, initial-scale=1.0, shrink-to-fit=no"">
	<meta http-equiv=""Content-Script-Type"" content=""text/javascript"">
	<meta http-equiv=""Content-Style-Type"" content=""text/css"">
	<meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
	<meta name=""apple-mobile-web-app-title"" content=""타이틀"">
	<meta name=""apple-mobile-web-app-capable"" content=""yes"">
	<meta name=""title"" content=""타이틀"">
	<meta name=""keywords"" content=""키워드"">
	<meta name=""description"" content=""데스크립션"">
	<meta itemprop=""name"" content=""타이틀"">
	<meta itemprop=""description"" content=""데스크립션"">
	<meta itemprop=""image"" content=""./img/favicons/thumb_sns.jpg"">
	<meta property=""fb:app_id"" content=""APP_ID"">
	<meta property=""og:type"" content=""Website"">
	<meta property=""og:title"" content=""타이틀"">
	<meta property=""og:url"" content=""./index.html"">
	<meta property=""og:description"" content=""데스크립션"">
	<meta property=""og: image"" content = ""이미지"">
	<link rel=""stylesheet"" href=""css/style.css"">
	<script src=""js/jquery-3.5.1.min.js""></script>
	</head>
	<body>
<!-- wrap -->
<div id=""wrap"" class=""history"">
	<!-- header --><!-- //header -->
	<!-- container -->
	<section id=""container"">
		<!-- contents -->
		<div class=""contents"">
			<div class=""bg_star"">
				<span class=""star star01""></span>
				<span class=""star star02""></span>
				<span class=""star star03""></span>
				<span class=""star star04""></span>
				<span class=""star star05""></span>
			</div>
			<!-- lst_wrap -->
			<section class=""lst_wrap"">
				<h2>"+lst_wrapH2+@"</h2>
				<ul>";

			return text;
		}
		public string GetHistoryNewsHtml(string url, string catagory,string titile)
		{
			string text =
@"				<li>
					<a href="""+url+@""" target=""_blank"">
						  <div class=""tit_bx"">
							<strong class=""category"">"+catagory+@"</strong>
							<h3 class=""tit"">"+titile+@"</h3><!-- 디자인상 영역보다 길어질 경우 말줄임표 처리 -->
						</div>
					</a><!-- href=""아웃링크 주소"" / 새탭 열림 -->
				</li>";

			return text;
		}
		public string GetHistoryScriptHtml()
		{
			string text =
@"				</ul>
			</section>
			<!-- //lst_wrap -->
			<!-- btn_wrap -->
			<div class=""btn_wrap"">
				<a href=""index.html"">홈으로 이동</a>
			</div>
			<!-- //btn_wrap -->
		</div>
		<!-- //contents -->
	</section>
	<!-- //container -->
	<!-- footer --><!-- //footer -->
</div>
<!-- //wrap -->
<script>
//index 페이지 이동
$('.btn_wrap a').click(function () {
	var url = $(this).attr('href');
	$(this).addClass('animate');
	setTimeout(function() {
		$('body').animate({
            'opacity': '0'
        }, function () {
            document.location.href = url;
        });
	}, 1250);
	return false;
});
</script>
</body>
</html>";

			return text;
		}
		#endregion
	}
}
