using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace MakeNews
{
	public class Common
	{
		public static string fixdataPath = Application.StartupPath + @"\FixData.txt";
		public static string dataPath = Application.StartupPath + @"\Data.csv";
		public static string indexPath = Application.StartupPath + @"\Index.html";
		public static string historyPath = Application.StartupPath + @"\History.html";
		public static string DBPath = Application.StartupPath + @"\Data.db";
		public static string DBDataPath = "Data Source=" + Application.StartupPath + "\\Data.db;Version=3;";

		// 외부 폰트사용시 일정시간후 메모리 참조 거부 활성화됨 
		//public static Font SetFont()
		//{
		//	PrivateFontCollection privateFont = new PrivateFontCollection();
		//	privateFont.AddFontFile(@"ect\NanumBarunGothic.ttf");
		//	Font font = new Font(privateFont.Families[0], 10f);
		//
		//	return font;
		//}



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
		public string GetIndexBodyPopupNoImgHtml(string popupnum, string emogi, string titile, string sumry, string date, string catagory)
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
		public string GetIndexBodyPopupImgHtml(string popupnum, string emogi, string titile, string sumry, string date, string catagory)
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
		public string GetIndexPopUpContentsHtml(string Fixtitile)
		{
			string text =
@"<!-- //wrap -->
<!-- ly_pop / 첫번째 소식 팝업 -->
<div class=""ly_pop"" id=""ly_pop1"">
	<div class=""cnt_bx"">
		<strong class=""tit"">★급★ 한강에 라면 먹으러 갈 사람!!!</strong>
		<div class=""img_area""><img src=""img/tmp_pop.png"" width=""100%"" height="""" alt=""소식 이미지""></div><!-- 이미지 사이즈 1000*400 / 사이즈 안맞을 경우 상단부터 노출 하단 잘림 -->
		<div class=""txt_area"">
			<p>한강에서 먹는 라면은 정말 집에서 먹는 것보다 더 맛있나요? 아주 궁금하네요. 저는 한강에서 라면을 먹어본 적이 없어서요.생각해보니 컵라면마저도 먹어본 기억이 없네요. 친구가 없긴 없었나 봅니다. 저도 한강에서 방금 끓인 꼬들꼬들한 라면과 밥보다 야채가 더 많은 김밥을 먹고 싶어요.평일에.주말 말고요. 평일에 말이에요. 오늘 날씨도 끝내주던데.꽃가루가 미친 듯이 날리지만 평일 대낮에 한강에서 라면을 먹을 수 있다면 꽃가루쯤은 파슬리라 생각하고 즐거이 먹겠어요.</p>
		</div>
		<button type = ""button"" class=""btn_close"">소식창 닫기</button>
	</div>
</div>
<!-- //ly_pop / 첫번째 소식 팝업 -->
<!-- ly_pop / 두번째 소식 팝업 -->
<div class=""ly_pop"" id=""ly_pop2"">
	<div class=""cnt_bx"">
		<strong class=""tit"">굿-바-이 🙋🏻‍♂️</strong>
		<div class=""txt_area"">
			<p>안녕하세요, 김지수입니다. 저는 떠납니다, 여러분. 탓하하하. 부럽죠? 솔직히? 혼자 남아서 철야하던 시간들, 밤새고 다음날 또 출근해서 간현가던 기억들, 꼭 나가자마자 잊을게요. 떠나는 인사만큼은 진심으로 전할게요.그럼 모두들 안녕히. 굿바이!</p>
		</div>
		<button type = ""button"" class=""btn_close"">소식창 닫기</button>
	</div>
</div>
<!-- //ly_pop / 두번째 소식 팝업 -->";
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
						  < div class=""tit_bx"">
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


	}
}
