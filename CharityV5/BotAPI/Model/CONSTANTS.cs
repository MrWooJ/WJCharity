using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;
using TGModels;

namespace TGModels
{
	public class CONSTANTS
	{
		public static string TempFilePath = "/Meta-Data/temp.txt" ;
		public static string AlbumPhotoPath = "/Album/" ;
		public static string Markdown = "Markdown" ;
		public static string Start = "/start" ;
		public static string Help = "/help" ;
		public static string BotName = "NazreShadi_Bot";

		/* <--- START ALBUM PATH ---> */
		public static string ToysProgramAlbumPhotoPath = "/Album/ToysProgram/Pic-" ;
		public static string HealthCareProgramAlbumPhotoPath = "/Album/HealthCareProgram/Pic-" ;
		public static string OtherProgramAlbumPhotoPath = "/Album/OtherProgram/Pic-" ;
		public static string SendGiftAlbumPhotoPath = "/Album/Pic-" ;
		/* <--- START ALBUM PATH ---> */

		/* <--- START BUTTONS ---> */
		public static string NazreShadiBaseButton = "ستاد مرکزی نذر شادی";
		public static string NazreShadiOtherCitiesButton = "ستادهای استانی نذر شادی";

		public static string HelpButton = "راهنما";
		public static string HowToEnterInfo_HelpButton = "نحوه وارد کردن اطلاعات";
		public static string MainMenu_HelpButton = "بازکشت به منوی اصلی";

		public static string InvitationButton = "دعوت به همکاری";
		public static string MainMenu_InvitationButton = "بازکشت به منوی اصلی";
		
		public static string Always_InvitationButton =  "همکاری همیشگی در نذر شادی";
		public static string PublicRelations_AlwaysInvitationButton = "روابط عمومی";
		public static string FinancialManagement_AlwaysInvitationButton = "مدیریت مالی و حسابداری";
		public static string Media_AlwaysInvitationButton = "رسانه";
		public static string IT_AlwaysInvitationButton = "فناوی اطلاعات";
		public static string Management_AlwaysInvitationButton = "مدیریت";
		public static string MainMenu_AlwaysInvitatioButton = "بازگشت به منوی دعوت به همکاری";
		
		public static string Execution_AlwaysInvitationButton = "اجرایی";
		public static string Civilization_Execution_AlwaysInvitationButton = "عمرانی";
		public static string Medical_Execution_AlwaysInvitationButton = "درمانی";
		public static string Psychology_Execution_AlwaysInvitationButton = "روانشناسی و مددکاری";
		public static string Support_Execution_AlwaysInvitationButton = "پشتیبانی";
		public static string JobCoordination_Execution_AlwaysInvitationButton = "هماهنگی و پیگیری کار ها";
		public static string Teaching_Execution_AlwaysInvitationButton = "آموزشی";
		public static string Other_Execution_AlwaysInvitationButton = "دیگر برنامه های اجرایی";
		public static string MainMenu_Execution_AlwaysInvitatioButton = "بازکشت به منوی دعوت به همکاری در همه طرح ها";
		
		public static string NonAlways_InvitationButton = "همکاری صرفا در یک طرح نذر شادی";
		public static string KindWall_NonAlwaysInvitationButton = "همکاری در شهر مهربانی";
		public static string MainMenu_NonAlwaysInvitation = "بازگشت به منوی دعوت به همکاری";
		public static string HealthProgram_NonAlwaysInvitationButton = "همکاری در نذر سلامت";
		public static string RedirectToHealthVolunteerBot_HealthProgram_NonAlwaysInvitationButton = "ارجاع به ربات درمانی";
		public static string RedirectToHealthVolunteerChannel_HealthProgram_NonAlwaysInvitationButton = "ارجاع به کانال درمانی";
		public static string MainMenu_HealthProgram_NonAlwaysInvitationButton = "بازکشت به منوی دعوت به همکاری در یک طرح";

		public static string ToysProgram_NonAlwaysInvitationButton = "همکاری در نذر اسباب بازی";
		public static string MainMenu_ToysProgram_NonAlwaysInvitationButton = "بازکشت به منوی دعوت به همکاری در یک طرح";

		public static string InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton = "بخش اطلاع رسانی و تبلیغات";
		public static string MainMenu_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton = "بازکشت به منوی نذر اسباب بازی";
		
		public static string ReadMeFirst_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton = "اول من رو بخون";
		public static string GetHardcodeTextForAdsAndLinks_ReadMeFirst_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton = "دریافت متن تبلیغ ها و لینک ها";
		public static string InformationAndJobDescription_ReadMeFirst_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton = "توضیحات و شرح وظایف";
		public static string MainMenu_ReadMeFirst_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton = "بازگشت به منوی اطلاع رسانی و تبلیغات";
		
		public static string SignUp_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton = "ثبت نام در بخش اطلاع رسانی و تبلیغات";
		public static string TelegramUsers_SignUp_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton = "ارسال تبلیغات به کاربران تلگرام";
		public static string TelegramGroup_SignUp_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton = "ارسال تبلیغات به گروه های تلگرام";
		public static string Instagram_SignUp_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton = "دریافت پوستر برای اینستاگرام";
		public static string MainMenu_SignUp_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton = "بازکشت به منوی اطلاع رسانی و تبلیغات";

		public static string CollectingGiftsPart_ToysProgram_NonAlwaysInvitationButton = "بخش جمع آوری هدایا";
		public static string MainMenu_CollectingGiftsPart_ToysProgram_NonAlwaysInvitationButton = "بازکشت به منوی نذر اسباب بازی";
		
		public static string SignUp_CollectingGiftsPart_ToysProgram_NonAlwaysInvitationButton = "ثبت نام در بخش جمع آوری هدایا";
		public static string NonTehran_SignUp_CollectingGiftsPart_ToysProgram_NonAlwaysInvitationButton = "استان های دیگر";
		public static string Tehran_SignUp_CollectingGiftsPart_ToysProgram_NonAlwaysInvitationButton = "استان تهران";
		public static string MainMenu_SignUp_CollectingGiftsPart_ToysProgram_NonAlwaysInvitationButton = "بازکشت به منوی جمع آوری هدایا";

		public static string PackagingAndSegregatingGiftsPart_ToysProgram_NonAlwaysInvitationButton = "بخش بسته بندی و تفکیک هدایا";
		public static string MainMenu_PackagingAndSegregatingGiftsPart_ToysProgram_NonAlwaysInvitationButton = "بازکشت به منوی نذر اسباب بازی";
		public static string SignUp_PackagingAndSegregatingGiftsPart_ToysProgram_NonAlwaysInvitationButton = "ثبت نام در بخش بسته بندی و تفکیک هدایا";

		public static string DistributingGiftsPart_ToysProgram_NonAlwaysInvitationButton = "بخش توزیع هدایا";
		public static string MainMenu_DistributingGiftsPart_ToysProgram_NonAlwaysInvitationButton = "بازکشت به منوی نذر اسباب بازی";
		
		public static string SignUp_DistributingGiftsPart_ToysProgram_NonAlwaysInvitationButton = "ثبت نام در بخش توزیع هدایا";
		public static string JahadiGroup_SignUp_DistributingGiftsPart_ToysProgram_NonAlwaysInvitationButton = "گروه جهادی";
		public static string CharityCenter_SignUp_DistributingGiftsPart_ToysProgram_NonAlwaysInvitationButton = "مرکز خیریه";
		public static string Individual_SignUp_DistributingGiftsPart_ToysProgram_NonAlwaysInvitationButton = "انفرادی";
		public static string MainMenu_SignUp_DistributingGiftsPart_ToysProgram_NonAlwaysInvitationButton = "بازکشت به بخش توزیع هدایا";

		public static string Kindwall_NonAlwaysInvitationButton = "همکاری در شهر مهربانی";
		public static string Help_Kindwall_NonAlwaysInvitationButton = "کمک رسانی در طرح شهر مهربانی";
		public static string Corporation_Kindwall_NonAlwaysInvitationButton = "همکاری در طرح شهر مهربانی";
		public static string MainMenu_KindWall_NonAlwaysInvitationButton = "بازکشت به منوی دعوت به همکاری در یک طرح";

		public static string GalleryButton = "گالری عکس ها";
		public static string ToysProgram_GalleryButton = "گالری نذر اسباب بازی";
		public static string HealthProgram_GalleryButton = "گالری درمان بیماران نیازمند";
		public static string OtherProgram_GalleryButton = "گالری سایر برنامه ها";
		public static string MainMenu_GalleryButton = "بازگشت به منوی اصلی";

		public static string ScheduleButton = "برنامه ها";
		public static string MainMenu_ScheduleButton = "بازگشت به منوی اصلی";

		public static string ToysProgram_ScheduleButton = "طرح های نذر اسباب بازی";
		public static string MainMenu_ToysProgram_ScheduleButton = "بازگشت به منوی طرح ها";

		public static string SendingGifts_ToysProgram_ScheduleButton = "ارسال هدایا";
		public static string InDoorDelivery_SendingGifts_ToysProgram_ScheduleButton = "تحویل درب منزل";
		public static string OutDoorDelivery_SendingGifts_ToysProgram_ScheduleButton = "ارسال مستقیم به مرکز";
		public static string MainMenu_SendingGifts_ToysProgram_ScheduleButton = "بازگشت به منوی ارسال هدایا";

		public static string HealthProgram_ScheduleButton = "طرح های نذر سلامت";		
		public static string RedirectToHealthVolunteerBot_HealthProgram_ScheduleButton = "ارجاع به ربات درمانی";
		public static string RedirectToHealthVolunteerChannel_HealthProgram_ScheduleButton = "ارجاع به کانال درمانی";
		public static string MainMenu_HealthProgram_ScheduleButton = "بازگشت به منوی طرح های نذر سلامت";

		public static string KindWall_ScheduleButton = "طرح های شهر مهربانی";
		public static string Help_KindWall_NonAlwaysInvitationButton = "برنامه های شهر مهربانی";
		public static string Corporation_KindWall_NonAlwaysInvitationButton = "برنامه های شهر مهربانی";
		public static string MainMenu_OtherProgram_ScheduleButton = "بازگشت به منوی برنامه ها";

		public static string AboutUsButton = "درباره ی ما";
		public static string ImamRezaHealthCenterGroup_AboutUsButton = "گروه درمانی امام رضا (ع)";
		public static string ToysProgramGroup_AboutUsButton = "گروه نذر شادی";
		public static string MainMenu_AboutUsButton = "بازگشت به منوی اصلی";

		public static string MainMenuButton = "بازگشت به منوی اصلی";
		/* <--- END BUTTONS ---> */

		/* <--- START CAPTIONS ---> */
		public static string ToysProgram_Caption = "یه سری از هدایای شما که برای بچه های مناطق محروم قراره فرستاده بشه.";
		public static string HealthProgram_Caption = "فعالیت های گروه درمانی امام رضا (ع)";
		public static string OtherProgram_Caption = "مدرسه صبح رویش اولین مدرسه ی کودکان کار و مرکز نگه داری از کودکان بی سرپرست که با همت دوستان جهادی احداث کردیم.";
		public static string SendGift_Caption = "برای اطلاعات بیشتر:\nآدرس: میدان امام حسین (ع) - خیابان انقلاب - قبل از پل  چوبی - تقاطع نامجو (گرگان) - مجتمع فرهنگی امام رضا (ع) - گروه درمانی امام رضا (ع)\nکدپستی:\n۱۶۱۸۹۱۳۴۱۱";
		/* <--- END CAPTIONS ---> */

		/* <--- START HARDCODE TEXTS ---> */
		public static string Start_HText1 = "از مهربونیت ممنونم که همت کردی و یک قدم جلو گذشتی.\nبه دنیای جدیدی که قصد داری برای خودت بسازی خوش آمدی.";
		public static string Start_HText = "از مهربونیت ممنونم که همت کردی و یک قدم جلو گذاشتی.\nبه دنیای جدید و قشنگی که قصد داری برای خودت و دیگران بسازی خوش آمدی.";
		public static string HowToEnterInfo_HText = "ممنون از وقتی که برای خوندن میگذاری.\nاینجا نکات مورد نیاز برای امر ثبت نام و نحوه ی وارد کردن اطلاعات رو برات نوشتم.\n\n۱- وارد کردن اطلاعات برای تمام فیلد ها ضروری میباشد.\n۲- اطلاعات هر فیلد باید در یک خط نوشته شود.\n۳- اعداد ورودی مثل شماره تماس و منطقه شهرداری باید حتما به فارسی وارد بشن.\n۴- نام هر فیلد رو در هر فیلد نباید بنویسی و فقط همینکه اطلاعات ورودی رو به ترتیب وارد کنی ما تشخیص میدیم و ثبتش میکنیم.\n۵- در صورت بروز هر گونه مشکلی که با این راهنما حل نشد ٬ میتونی با ادمین @LogicalMind و یا مسئول فنی @MrWooJ پیام بدی تا در اولین فرصت مشکلت رو حل کنند.";
		public static string RedirectToHealthVolunteerBot_HText = "همکار عزیز ما در حوزه علوم پزشکی مثل دندانپزشکی و پزشکی و دامپزشکی و داروسازی و ... در صورتی که تمایل به همکاری و کمک به ما تو بخش درمان بیماران نیازمند مناطق محروم تهران و سایر شهرستان ها رو داری به کانالما در لینک زیر یک سر بزن.\n\n @MedHelp \n\nمیتونی از لینک ربات ما که در کانال ذکر شده برای ثبت نام استفاده کنی.";
		public static string RedirectToHealthVolunteerChannel_HText = "عزیز جان اگر علاقه مند به دنبال کردن اخبار درمان بیماران نیازمند و Workshop های پزشکی و دندانپزشکی و ... هستی لطفا یه نگاه به شبکه اطلاع رسانی درمان و آموزش جهادی @MedHelp بنداز.";
		public static string TelegramUsers_InformationAndAdvertismentPart_HText = "از این طریق میتونی پیام و هدف نذر اسباب بازی و در آینده کار های بزرگتر رو که قراره با هم انجام بدیم رو به تعداد زیادی کاربر ایرانی و فعال توی تلگرام بفرستی. و مهم تر از همه به خاطر اسپم مشکلی برای تلگرامت پیش نیاد.\nمعیار این سایت تو محاسبه ی مبلغ تبلیغات بر حسب تعداد کاربرانی هستند که پیام به درستی به دستشون رسیده.\nلطفا برای سفارش تبلیغات روی لینک زیر کلیک کن. \n\nhttps://createyourbot.net/auth/56c74b27161ab/telegram/request/advertise_for_users";
		public static string TelegramChannels_InformationAndAdvertismentPart_HText = "از این طریق میتونی پیام و هدف نذر اسباب بازی و در آینده کار های بزرگتر رو که قراره با هم انجام بدیم رو به تعداد زیادی گروه ایرانی و فعال توی تلگرام بفرستی. و مهم تر از همه به خاطر اسپم مشکلی برای تلگرامت پیش نیاد.\nمعیار این سایت تو محاسبه ی مبلغ تبلیغات بر حسب تعداد کاربرانی هستند که پیام به درستی به دستشون رسیده.\nلطفا برای سفارش تبلیغات روی لینک زیر کلیک کن. \n\nhttps://createyourbot.net/auth/56cb4af4101f9/telegram/request/advertise_for_channels";
		public static string Instagram_InformationAndAdvertismentPart_HText = "عزیز جان بعد از طراحی پوستر رو برات ارسال میکنیم. ولی اگر علاقه و سلیقه ی خوبی تو طراحی پوستر داری بسم الله...\nاگر زحمتی نیست به سلیقه ی خودت کار رو شروع کن.";
				
		public static string SoonWillBeNotified_HText = "به زودی راه اندازی خواهد شد.";
		public static string SoonWillBeNotifiedSetadOstani_HText = "به زودی راه اندازی خواهد شد.\nستاد های استانی موقتا با ستاد مرکزی نذر شادی همکاری میکنند.";
		public static string AlwaysCorporation_HText = "در این بخش با توجه به تخصص خودتون و حوزه ای که علاقه مند به فعالیت هستید، بخش مورد نظر را انتخاب کنید.";

		public static string GetHardcodeTextForAdsAndLinks_HText = "خیلی کوتاه بگم که ما طرح نذر اسباب بازی برای ایتام و بچه های مناطق محروم رو شروع کردیم نه به این خاطر که بگیم با یه اسباب بازی ساده یا دست دوم تموم درد و رنج این بچه ها رفع میشه. این طرح رو شروع کردیم که بگیم: شاید توان انجام کار های خیلی بزرگ رو نداریم ولی دلخوشیم به این که بجای شعار دادن تونستیم با همدیگه لحظه ای ... تنها لحظه ای دل اون هارو شاد کنیم و لبخند به روی لب هاشون بیاریم.\n----------\nگروه نذر اسباب بازی در صورتی که از ما سوال داری یا علاقه مند هستی تو همفکری ها برای بهتر شدن کار و گسترش اون کمک کنی.\nhttps://telegram.me/joinchat/BdS1CDzOd87acskllE8XvA\n----------\nو این هم ربات ما که از این کانال @IranianCharity میتونید لینکش رو در صورتی که علاقه مند به همکاری با ما و یا ارسال هدیه بودی دریافت کنی.";
		public static string InformationAndJobDescription_HText = "عزیز جان  ...\nازت بی نهایت ممنوم که تو این بخش قصد داری به من کمک کنی.\nارسال تبلیغات به گروه های تلگرام و کاربرانی که برات توی منو گذاشتم با صرف هزینه هستش و قطعا تاثیرگذاری بیشتری خواهد داشت و امنیت بیشتری نسبت به ارسال پیغام توسط خودت به شکل گسترده که خدایی نکرده اسپم نشی.\nولی اصلا ناراحت نباش...\nاگر امکان صرف هزینه برای تبلیغ و ترویج این کار رو نداری مشکلی نیست تنها متن تبلیغ را که برات گذاشتم به دوستان و آشنایانی که میشناسیشون بفرست و از اون ها هم بخواه همین کار روانجام بدن و همین کافیه که بیشتر از این بهت زحمت ندم.\nباز هم ازت بخاطر مهربونت ممنونم.";

		public static string NonTehran_CollectingGiftsPart_HText = "یه خبر خوش که به زودی این بخش تو همه ی شهر های بزرگ کشور راه اندازی میشه ...";
		public static string Tehran_CollectingGiftsPart_HText = "عزیز جان ...\nازت بی نهایت ممنونم که تو این بخش قصد داری به من کمک کنی.\nاعضای داوطلب این بخش بعد از ثبت نام و ملاقات حضوری با هم زمان های خالی خودشون و محدوده هایی که امکان تحویل گرفتن هدایا رو دارن مشخص میکنن و زحمت جمع آوری هدایا را تو روز ها و محدوده هایی که خودشون مشخص کردند میکشن.\nدر نهایت اون هارو به آدرس میدان امام حسین - خیابان انقلاب - قبل از پل چوبی - تقاطع نامجو (گرگان) - مجتمع فرهنگی امام رضا (ع) - گروه درمانی امام رضا (ع) تحویل میدند.";
		
		public static string PackagingAndSegregatingGiftsPart_HText = "عزیز جان ...\nازت بی نهایت ممنونم که تو این بخش قصد داری به من کمک کنی.\nاعضای داوطلب این بخش بعد از ثبت نام و بعد از اطلاع رسانی هایی که صورت گرفت قدم به روی چشم ما میگذارند و به مرکز گروه درمانی امام رضا (ع) میان تا از اونجایی که هدف اول ما اسباب بازی های دست دوم هستش تا به کسی فشار مالی نیاد اون هارو کمی تمیز و مرتب کنیم و با توجه به سن و جنسیتی که قراره اون هدیه رو دریافت کنه اون هارو تفکیک کنه.";
		public static string DistributingGiftsPart_HText = "این بخش با توجه به نیاز به حضور میدانی و عملیاتی به طور آزمایشی و محدود توسط گروه درمانی امام رضا (ع) که متشکل از ۷۰ دندانپزشک و ۳۰ پزشک که در دو بازه ی زمانی نوروز و تابستان و همچنین مناطق محروم تهران به صورت هفته ای فعالیت میکنند و همچنین با توجه به اینکه اولین جامعه ی هدف درمانی این گروه ایتام هستش صورت خواهد گرفت.\nدر صورت پیشرفت و تثبیت این طرح سایر گروه های جهای فعال در ایران در این بخش فعالیت خواهند کرد.";
		public static string SoonWillBeAdded_HText1 = "عزیز جان ...\nبه زودی برنامه های خیریه ی دیگر ما اعلام خواهد شد. از همکاریت ممنونم.";
		public static string SoonWillBeAdded_HText = "عزیز جان...\nبه زودی جزئیات طرح شهر مهربانی به ربات اضافه خواهد شد. ";
		public static string ImamRezaHealthCenterGroup_HText = "گروه درمانی امام رضا (ع) یکی از بزرگترین گروه های جهاد پزشکی در مناطق محروم میباشد که به صورت تخصصی به مدت ۲ سال در مناطق محروم استان خوزستان و کرمانشاه و یا تهران مشغول به ارائه خدمات تخصصی پزشکی و دندانپزشکی و مامایی و ... میباشد.\nدر صورت تمایل به همکاری و یا کسب اطلاعات بیشتر از فعالیت های این گروه درمانی لطفا به شبکه اطلاع رسانی درمان و آموزش جهادی @MedHelp و یا برای ثبت نام در فعالیت های این گروه به ربات ما که در کانال معرفی شده مراجعه فرمائید.";
		
		public static string ToysProgramGroup_HText = "به نام خدا\nهدف از تشکیل این طرح:\nیکی از مهم ترین علت هایی ایده ی نذر اسباب بازی به ذهنم رسید این بود که خیلی ها دوست دارن برای مناطق محروم کاری انجام بدند که در حال حاضر به دو طریق این کمک رسانی صورت میگیره:\n۱-حضور میدانی\n۲-فراهم کردن بستری در شهر های بزرگ برای بالا رفتن سطح کیفیت کار گروه های میدانی.\nبا توجه به شرایط زندگی هر یک از ما ممکنه حضور میدانی در مناطق محروم امکان پذیر نباشه. در صورتی که تنها با صرف چند ساعت از زمان های آزاد خودمون میتونیم در خصوص بالا رفتن و تجویز گروه های میدنی اقدام کنیم.\nاز این رو طرح نذر اسباب بازی همچین بستر کمک رسانی رو با هدف نقش بستن لبخند به روی لب کودکان نیازمند به وجود میاره.\n\nچرایی انتخاب اسم نذر اسباب بازی:\nدر کشور ما به خاطر وجود یک سری باور غلط خدمت رسانی به مناطق محروم محجور و مظلوم واقع میشه: باور هایی مثل:\n-بعضی هافکر میکنند که کار تو مناطق محروم صرفا توسط گروه هایی خاص با خط فکری خاصی با عنوان اردو های جهادی صورت میگیره و امکان کار کردن با همچین سیستمی وجود نداره در صورتی که حقیقت امر این طور نیست.\nحرکت های جهادی یه فرهنگ هستش یا یه خط فکری. فرهنگی که کاری به دین و مذهب و خط فکری و ... نداره و تنها و تنها به این مهم تاکید داره که با هر رنگ و قوم و نژادی که هستی بیا و به مردم کشورت خدمت کن. خدمتی که نه صرفا به کاری های عمرانی و سازندگی محدود میشه نه پزشکی نه آموزشی و نه ... کار جهادی میتونه تنها آوردن لبخند رو صورت کودکی باشه که وسیله ی بازیش تنها چوب و سنگه و هیچ پس زمینه ی فکری نسبت به یه عروسک یا ماشین و یا یه اسباب بازی ساده نداره و اثر وضعی که شادی اون کودک تو سرنوشت و زندگی اون.\n-یا باور اشتباه دیگه ای بین هموطنان ما مرسوم شده که زمانی که اسم نذر رو میاریم به اشتباه همه یاد پخش کردن غذا و خرما و شیرینی و ... میفتیم و فراموش کردیم که چه نذری بهتر از شاد کردن دل کودکی نیازمند یا یتیم؟ اون هم تنها با اهدای اسباب بازی هایی باشه که گوشه ی خونه های ما داره خاک میخوره ولی میتونه برای کودک یتیمی حکم قویترین دارو های ضد افسردگی رو داشته باشه و مایه ی شیرینی و سیر شدن روح و جانش.";
		/* <--- END HARDCODE TEXTS ---> */

		/* <--- START INTERACTION TEXTS ---> */
		public static string WrongInput_HText = "اطلاعات وارد شده با فرمت خواسته شده سازگاری ندارد.";
		public static string NowPermitted_HText = "";
		public static string EmptyList_HText = "متاسفانه لیست اهدایی های این منطقه خالی میباشد.";
		public static string NotPermitted_HText = "متاسفانه شما اجازه ی دسترسی به این بخش را ندارید.\nهمکاران ما برای تایید اجازه ی شما با شما هماهنگی های لازم را انجام میدهند.";
		public static string AlreadySignedUp_HText = "شما قبلا در این بخش ثبت نام کردید.\nمیتوانید ادامه دهید ...";
		public static string SuccessfulSignUp_HText = "ثبت نام شما با موفقیت انجام شد.";
		public static string AddedSuccessfuly_HText = "با توجه به اینکه قبلا ثبت نام کردید ٬ با موفقیت به این گروه اضافه شدید.\nمیتوانید ادامه دهید ...";
		public static string SelectOne_HText = "لطفا شماره ی شناسایی بسته ای که قصد تحویل گرفتنش رو داری وارد کن.\nیادت باشه که باید به صورت اعداد فارسی وارد کنی ...";
		public static string DeliveredStatus_HText = "خدا قوت عزیز جان ...\nاز اینکه بسته ی اهدایی رو تحویل گرفتی ممنونم.\nالان میتونی مجددا لیست اهدایی هارو ببینی و اگر تونستی برای جمع آوری اقدام کنی...";
		public static string AlreadyAskDelivery_HText = "شما در حال حاضر یک درخواست تحویل حضوری داده اید.\nتا همکاران ما بسته ی کنونی شما را تحویل نگیرند متاسفانه نمیتوانید درخواست دیگری ثبت کنید.";
		public static string DeliveryStatus_HText = "شما در حال حاضر بسته ای که در گذشته برای تحویل مشخص کردید را تحویل نگرفتید.\nلذا نمیتوانید درخواست تحویل جدیدی ثبت کنید.\nلطفا هر چه سریع تر نسبت به تکیمل فرآیند تحویل بسته کنونی خود اقدام فرمایید.";
		public static string SuspendedStatus_HText = "بسته ای که قصد تحویل آن را داشتید با موفقیت لغو تحویل شد.";
		public static string SuspendedReason_HText = "لطفا دلیل تعلیق بسته ی کنونی خود رو توی یک خط توضیح بده ...";
		public static string CancelDelivery_HText = "درخواست شما مبنی بر تحویل با موفقیت لغو گردید.";
		public static string CantCancelDelivery_HText = "شما نمیتوانید بسته ای را لغو کنید.\n- شاید بسته ی شما در حالت تحویل توسط همکاران ما است.\n- یا شاید بسته ای برای تحویل حضوری هنوز ثبت نکردید.";
		public static string ShouldSignUp_HText = "شما در این بخش هنوز ثبت نام نکردید.\nبرای این منظور ابتدا ثبت نام کنید.";
		/* <--- END INTERACTION TEXTS ---> */

		/* <--- START SIGNUP BUTTONS & TEXTS ---> */
		public static string General_Invitation_SignUp1 = "لطفا اطلاعات ثبت نامی خودت رو کامل و دقیق وارد کن.\nنام:\nنام خانوادگی:\nشماره تماس:\nمیزان تحصیلا ت:\n----------\n/Help\nیادت باشه باید همه ی فیلد هارو دقیق تر وارد کنی و هرکدومشون رو توی یک خط بنویسی و مهم تر از همه شماره تلفنت رو ترجیحا به انگلیسی وارد کنی.\nیک نمونه مثال:\nعلیرضا\nعربی\n۰۹۱۲۱۵۱۳۹۶۲\nمهندسی کامپیوتر نرم افزار شهید بهشتی";
		public static string General_Invitation_SignUp = "لطفا اطلاعات ثبت نامی خودت رو کامل و دقیق وارد کن.\nنام:\nنام خانوادگی:\nشماره تماس:\nمیزان تحصیلات:\nمیزان ساعت همکاری در هفته:\n----------\n/Help\nیادت باشه باید همه ی فیلد هارو دقیق تر وارد کنی و هرکدومشون رو توی یک خط بنویسی و مهم تر از همه شماره تلفنت رو ترجیحا به انگلیسی وارد کنی.\nیک نمونه مثال:\nعلیرضا\nعربی\n۰۹۱۲۱۵۱۳۹۶۲\nمهندسی کامپیوتر نرم افزار شهید بهشتی\n۱۰ ساعت";
        	public static string General_SendGifts_SignUp = "برای اینکه درخواست تحویل حضوریت ثبت بشه و ما بتونیم اطلاعات مکان شمارو با همکاران مورد اعتماد مجموعه جهت تحویل همگام سازی کنیم ٬ لازمه که یه سری اطلاعاتت رو در سیستم ثبت کنیم.\nبرای ثبت اطلاعاتت در این بخش لطفا ابتدا نحوه ی وارد کردن اطلاعات ثبت نامی رو در قسمت /help بخون.\nحالا اطلاعات ثبت درخواست تحویلت رو کامل و دقیق وارد کن.\n----------\nنام\nنام خانوادگی\nشماره تماس\nآدرس کامل\nمنطقه ی شهرداری در شهر (بسیار مهم)\nتوضیحات بیشتر\n----------\nیادت باشه که همه ی فیلد هارو باید وارد کنی و هر کدومشون رو توی یک خط بنویسی و مهم تر از همه شماره منطقه و شماره تماست رو به فارسی وارد کنی.\nیک نمونه مثال:\n\nعلیرضا\nعربی\n۰۹۱۲۱۵۱۳۹۶۲\nتهران - خیابان گیشا - و ادامه ی آدرس\n۲\nلطفا قبل از اینکه برای تحویل مراجعه کنید اول تماس بگیرید تا حضور داشته باشم. مرسی\n----------\nمطمئن باش که اطلاعاتت تحت پروتکل امن مستقیما فقط روی سرور ما ذخیره میشه و زمانی که تحویل گیرنده ی شما مشخص بشه اطلاعاتش رو برات ارسال میکنیم.";
        
		public static string Invitation_PR_SignUp_HText = "ثبت نام در بخش روابط عمومی\n\n" + General_Invitation_SignUp;
		public static string Invitation_FM_SignUp_HText = "ثبت نام در بخش مدیریت مالی و حسابداری\n\n" + General_Invitation_SignUp;
		public static string Invitation_MD_SignUp_HText = "ثبت نام در بخش رسانه\n\n" + General_Invitation_SignUp;
		public static string Invitation_IT_SignUp_HText = "ثبت نام در بخش فناوری اطلاعات\n\n" + General_Invitation_SignUp;
		public static string Invitation_MG_SignUp_HText = "ثبت نام در بخش مدیریت\n\n" + General_Invitation_SignUp;
		public static string Invitation_EXCV_SignUp_HText = "ثبت نام در بخش عمرانی\n\n" + General_Invitation_SignUp;
		public static string Invitation_EXMD_SignUp_HText = "ثبت نام در بخش درمانی\n\n" + General_Invitation_SignUp;
		public static string Invitation_EXPS_SignUp_HText = "ثبت نام در بخش روانشناسی و مددکاری\n\n" + General_Invitation_SignUp;
		public static string Invitation_EXSP_SignUp_HText = "ثبت نام در بخش پشتیبانی\n\n" + General_Invitation_SignUp;
		public static string Invitation_EXJC_SignUp_HText = "ثبت نام در بخش هماهنگی و پیگیری امور\n\n" + General_Invitation_SignUp;
		public static string Invitation_EXTC_SignUp_HText = "ثبت نام در بخش آموزشی\n\n" + General_Invitation_SignUp;
		public static string Invitation_EXOT_SignUp_HText = "ثبت نام در بخش سایر موارد\n\n" + General_Invitation_SignUp;

		public static string Invitation_IAG_SignUp_HText = "ثبت نام در بخش اطلاع رسانی و تبلیغات\n\n" + General_Invitation_SignUp;
		public static string Invitation_CG_SignUp_HText = "ثبت نام در بخش جمع آوری هدایا\n\n" + General_Invitation_SignUp;
		public static string Invitation_PSG_SignUp_HText = "ثبت نام در بخش بسته بندی و تفکیک هدایا\n\n" + General_Invitation_SignUp;
		public static string Invitation_DG_SignUp_HText = "ثبت نام در بخش توزیع هدایا\n\n" + General_Invitation_SignUp;
		public static string SendGifts_SignUp_HText = "ثبت اطلاعات اهدا کننده ی عزیز\n\n" + General_SendGifts_SignUp;

		public static string SendGift_HText = "به منظور سهولت در روند جمع آوری و همچنین درج آدرس نیکوکاران به جهت تحویل هدایا از درب منزل، به جهت دسترسی سریع تر این بخش در اولین منو قرار داده شده است.";
		public static string SendingGifts_Button = "ارسال هدایای طرح نذر اسباب بازی";

		/* <--- END HARDCODE TEXTS ---> */

		/* <--- START SIGNUP CITIES ---> */
		public static string Inv = "همکاری در ";
		public static string InvTehran = Inv + "تهران";
		public static string InvIsfahan = Inv + "اصفهان";
		public static string InvMazandaran = Inv + "مازندران";
		public static string InvGilan = Inv + "گیلان";
		public static string InvKhorasanRazavi = Inv + "خراسان رضوی";
		public static string InvAzarbayejanGharbi = Inv + "آذربایجان غربی";
		public static string InvOtherCities = Inv + "سایر شهر ها";

		public static string Snd = "ارسال از ";
		public static string SndTehran = Snd + "تهران";
		public static string SndIsfahan = Snd + "اصفهان";
		public static string SndMazandaran = Snd + "مازندران";
		public static string SndGilan = Snd + "گیلان";
		public static string SndKhorasanRazavi = Snd + "خراسان رضوی";
		public static string SndAzarbayejanGharbi = Snd + "آذربایجان غربی";
		public static string SndOtherCities = Snd + "سایر شهر ها";

		public static string AskForCity = "لطفا نام استان محل سکونت خود را وارد نمایید.\nلیست شهر های تحت پشتیبانی در زیر آمده است و در آینده تمام استان های کشور را تحت پوشش خواهیم گرفت.";
		/* <--- END HARDCODE CITIES ---> */

		public static string InvitationQuote = "دوستان سلام\nیه موضوع مهم:\nبه لطف خدا از اواخر اسفند ۹۴ تا به همین امروز تمام تلاشم به این بود که تمام زیرساخت هایی که برای به وجود اومدن هسته ی اولیه ی نذر شادی نیازه بوجود بیارم تا یه بستری برای خیلی از عزیزانی که دوست دارند در حد توان کاری برای نیازمندان انجام بدن و نمیدونن از کجا شروع کنند فراهم کنم.\nحالا مهم نیست به کدوم اعتقاد و آیین و خط و مشی و قوم و ملیت و مذهبید...\nمهم اینه که دوست دارید گره از زندگی انسانی باز کنید و همین کافیه برای من که قدم روی چشمم بذارید و خوشحال باشم که در کنارم برای انجام این هدف هستید.\n\n-----------\n\nآدرس دفتر نذر شادی و جلسه ی چهارشنبه ساعت ۱۷\nمیدان امام حسین (ع) - خیابان انقلاب - قبل از پل چوبی - تقاطع نامجو (گرگان) - مجتمع فرهنگی امام رضا (ع). \nدوستانی هم که مایل هستند تشریف بیارن یه اطلاع بهم بدن لطفا\n@Logicalmind";
		public static string PictureCaption = "آدرس دفتر نذر شادی و جلسه ی چهارشنبه ساعت ۱۷\nمیدان امام حسین (ع) - خیابان انقلاب - قبل از پل چوبی - تقاطع نامجو (گرگان) - مجتمع فرهنگی امام رضا (ع)";

	}
}
