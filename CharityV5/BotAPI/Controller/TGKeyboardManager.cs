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
using Newtonsoft.Json;
using TGModels;
using TGController;
using TGFileManager;

namespace TGKeyboardManager
{
	public class TGKeyboardManagerClass
	{
		public static string QAKeyboard()
		{
			FORCEREPLAY keyInterface = new FORCEREPLAY();
			keyInterface.force_reply = true;
			keyInterface.selective = false;
			string json = JsonConvert.SerializeObject(keyInterface);
			return json;
		}

		public static string StartKeyboard()	//Used
		{
			REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
			keyInterface.keyboard = new string[3, 1] {{CONSTANTS.NazreShadiBaseButton}, {CONSTANTS.NazreShadiOtherCitiesButton}, {CONSTANTS.SendingGifts_Button}};
			keyInterface.resize_keyboard = true;
			keyInterface.one_time_keyboard = false;
			keyInterface.selective = false;
			string json = JsonConvert.SerializeObject(keyInterface);
			return json;
		}

		public static string MainKeyboard() //Used
		{
			REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
			keyInterface.keyboard = new string[5, 1] {{CONSTANTS.InvitationButton}, {CONSTANTS.ScheduleButton}, {CONSTANTS.GalleryButton}, {CONSTANTS.HelpButton}, {CONSTANTS.AboutUsButton}};
			keyInterface.resize_keyboard = true;
			keyInterface.one_time_keyboard = false;
			keyInterface.selective = false;
			string json = JsonConvert.SerializeObject(keyInterface);
			return json;
		}

		public static string InvitationKeyboard() //Used
		{
			REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
			keyInterface.keyboard = new string[3, 1] {{CONSTANTS.Always_InvitationButton}, {CONSTANTS.NonAlways_InvitationButton}, {CONSTANTS.MainMenu_InvitationButton}};
			keyInterface.resize_keyboard = true;
			keyInterface.one_time_keyboard = false;
			keyInterface.selective = false;
			string json = JsonConvert.SerializeObject(keyInterface);
			return json;
		}

		public static string NonAlwaysInvitationKeyboard()	//Used
		{
			REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
			keyInterface.keyboard = new string[4, 1] {{CONSTANTS.ToysProgram_NonAlwaysInvitationButton}, {CONSTANTS.HealthProgram_NonAlwaysInvitationButton}, {CONSTANTS.KindWall_NonAlwaysInvitationButton} , {CONSTANTS.MainMenu_NonAlwaysInvitation}};
			keyInterface.resize_keyboard = true;
			keyInterface.one_time_keyboard = false;
			keyInterface.selective = false;
			string json = JsonConvert.SerializeObject(keyInterface);
			return json;
		}

		public static string HealthCareProgramKeyboard()	//Used
		{
			REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
			keyInterface.keyboard = new string[3, 1] {{CONSTANTS.RedirectToHealthVolunteerBot_HealthProgram_NonAlwaysInvitationButton}, {CONSTANTS.RedirectToHealthVolunteerChannel_HealthProgram_NonAlwaysInvitationButton}, {CONSTANTS.MainMenu_HealthProgram_NonAlwaysInvitationButton}};
			keyInterface.resize_keyboard = true;
			keyInterface.one_time_keyboard = false;
			keyInterface.selective = false;
			string json = JsonConvert.SerializeObject(keyInterface);
			return json;
		}

		public static string ToysProgramKeyboard()	//Used
		{
			REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
			keyInterface.keyboard = new string[5, 1] {{CONSTANTS.InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton}, {CONSTANTS.CollectingGiftsPart_ToysProgram_NonAlwaysInvitationButton} , {CONSTANTS.PackagingAndSegregatingGiftsPart_ToysProgram_NonAlwaysInvitationButton} , {CONSTANTS.DistributingGiftsPart_ToysProgram_NonAlwaysInvitationButton} ,{CONSTANTS.MainMenu_ToysProgram_NonAlwaysInvitationButton}};
			keyInterface.resize_keyboard = true;
			keyInterface.one_time_keyboard = false;
			keyInterface.selective = false;
			string json = JsonConvert.SerializeObject(keyInterface);
			return json;
		}

		public static string InformationAndAdvertisementToysProgramKeyboard()	//Used
		{
			REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
			keyInterface.keyboard = new string[3, 1] {{CONSTANTS.ReadMeFirst_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton}, {CONSTANTS.SignUp_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton}, {CONSTANTS.MainMenu_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton}};
			keyInterface.resize_keyboard = true;
			keyInterface.one_time_keyboard = false;
			keyInterface.selective = false;
			string json = JsonConvert.SerializeObject(keyInterface);
			return json;
		}

		public static string SignUpInformationAndAdvertisementToysProgramKeyboard()	//Used
		{
			REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
			keyInterface.keyboard = new string[4, 1] {{CONSTANTS.TelegramUsers_SignUp_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton}, {CONSTANTS.TelegramGroup_SignUp_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton}, {CONSTANTS.Instagram_SignUp_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton} ,{CONSTANTS.MainMenu_SignUp_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton}};
			keyInterface.resize_keyboard = true;
			keyInterface.one_time_keyboard = false;
			keyInterface.selective = false;
			string json = JsonConvert.SerializeObject(keyInterface);
			return json;
		}

		public static string ReadMeFirstInformationAndAdvertisementToysProgramKeyboard()	//Used
		{
			REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
			keyInterface.keyboard = new string[3, 1] {{CONSTANTS.GetHardcodeTextForAdsAndLinks_ReadMeFirst_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton}, {CONSTANTS.InformationAndJobDescription_ReadMeFirst_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton}, {CONSTANTS.MainMenu_ReadMeFirst_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton}};
			keyInterface.resize_keyboard = true;
			keyInterface.one_time_keyboard = false;
			keyInterface.selective = false;
			string json = JsonConvert.SerializeObject(keyInterface);
			return json;
		}

		public static string CollectingGiftsToysProgramKeyboard()	//Used
		{
			REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
			keyInterface.keyboard = new string[2, 1] {{CONSTANTS.SignUp_CollectingGiftsPart_ToysProgram_NonAlwaysInvitationButton}, {CONSTANTS.MainMenu_CollectingGiftsPart_ToysProgram_NonAlwaysInvitationButton}};
			keyInterface.resize_keyboard = true;
			keyInterface.one_time_keyboard = false;
			keyInterface.selective = false;
			string json = JsonConvert.SerializeObject(keyInterface);
			return json;
		}

		public static string SignUpCollectingGiftsToysProgramKeyboard()	//Used
		{
			REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
			keyInterface.keyboard = new string[3, 1] {{CONSTANTS.Tehran_SignUp_CollectingGiftsPart_ToysProgram_NonAlwaysInvitationButton}, {CONSTANTS.NonTehran_SignUp_CollectingGiftsPart_ToysProgram_NonAlwaysInvitationButton}, {CONSTANTS.MainMenu_SignUp_CollectingGiftsPart_ToysProgram_NonAlwaysInvitationButton}};
			keyInterface.resize_keyboard = true;
			keyInterface.one_time_keyboard = false;
			keyInterface.selective = false;
			string json = JsonConvert.SerializeObject(keyInterface);
			return json;
		}

		public static string PackagingAndSegregatingGiftsToysProgramKeyboard()	//Used
		{
			REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
			keyInterface.keyboard = new string[2, 1] {{CONSTANTS.SignUp_PackagingAndSegregatingGiftsPart_ToysProgram_NonAlwaysInvitationButton}, {CONSTANTS.MainMenu_PackagingAndSegregatingGiftsPart_ToysProgram_NonAlwaysInvitationButton}};
			keyInterface.resize_keyboard = true;
			keyInterface.one_time_keyboard = false;
			keyInterface.selective = false;
			string json = JsonConvert.SerializeObject(keyInterface);
			return json;
		}

		public static string DistributingGiftsToysProgramKeyboard()	//Used
		{
			REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
			keyInterface.keyboard = new string[2, 1] {{CONSTANTS.SignUp_DistributingGiftsPart_ToysProgram_NonAlwaysInvitationButton}, {CONSTANTS.MainMenu_DistributingGiftsPart_ToysProgram_NonAlwaysInvitationButton}};
			keyInterface.resize_keyboard = true;
			keyInterface.one_time_keyboard = false;
			keyInterface.selective = false;
			string json = JsonConvert.SerializeObject(keyInterface);
			return json;
		}

		public static string SignUpDistributingGiftsToysProgramKeyboard()	//Used
		{
			REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
			keyInterface.keyboard = new string[4, 1] {{CONSTANTS.JahadiGroup_SignUp_DistributingGiftsPart_ToysProgram_NonAlwaysInvitationButton}, {CONSTANTS.CharityCenter_SignUp_DistributingGiftsPart_ToysProgram_NonAlwaysInvitationButton}, {CONSTANTS.Individual_SignUp_DistributingGiftsPart_ToysProgram_NonAlwaysInvitationButton}, {CONSTANTS.MainMenu_SignUp_DistributingGiftsPart_ToysProgram_NonAlwaysInvitationButton}};
			keyInterface.resize_keyboard = true;
			keyInterface.one_time_keyboard = false;
			keyInterface.selective = false;
			string json = JsonConvert.SerializeObject(keyInterface);
			return json;
		}

		public static string AlwaysInvitationKeyboard()	//Used
		{
			REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
			keyInterface.keyboard = new string[7, 1] {{CONSTANTS.PublicRelations_AlwaysInvitationButton}, {CONSTANTS.Execution_AlwaysInvitationButton}, {CONSTANTS.FinancialManagement_AlwaysInvitationButton}, {CONSTANTS.Media_AlwaysInvitationButton}, {CONSTANTS.IT_AlwaysInvitationButton} , {CONSTANTS.Management_AlwaysInvitationButton}, {CONSTANTS.MainMenu_AlwaysInvitatioButton}};
			keyInterface.resize_keyboard = true;
			keyInterface.one_time_keyboard = false;
			keyInterface.selective = false;
			string json = JsonConvert.SerializeObject(keyInterface);
			return json;
		}

		public static string ExecutionInvitationKeyboard()	//Used
		{
			REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
			keyInterface.keyboard = new string[8, 1] {{CONSTANTS.Civilization_Execution_AlwaysInvitationButton}, {CONSTANTS.Medical_Execution_AlwaysInvitationButton}, {CONSTANTS.Psychology_Execution_AlwaysInvitationButton}, {CONSTANTS.Support_Execution_AlwaysInvitationButton}, {CONSTANTS.JobCoordination_Execution_AlwaysInvitationButton} , {CONSTANTS.Teaching_Execution_AlwaysInvitationButton}, {CONSTANTS.Other_Execution_AlwaysInvitationButton}, {CONSTANTS.MainMenu_Execution_AlwaysInvitatioButton}};
			keyInterface.resize_keyboard = true;
			keyInterface.one_time_keyboard = false;
			keyInterface.selective = false;
			string json = JsonConvert.SerializeObject(keyInterface);
			return json;
		}

		public static string GalleryKeyboard()	//Used
		{
			REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
			keyInterface.keyboard = new string[4, 1] {{CONSTANTS.ToysProgram_GalleryButton}, {CONSTANTS.HealthProgram_GalleryButton}, {CONSTANTS.OtherProgram_GalleryButton} , {CONSTANTS.MainMenuButton}};
			keyInterface.resize_keyboard = true;
			keyInterface.one_time_keyboard = false;
			keyInterface.selective = false;
			string json = JsonConvert.SerializeObject(keyInterface);
			return json;
		}

		public static string ScheduleKeyboard()	//Used
		{
			REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
			keyInterface.keyboard = new string[4, 1] {{CONSTANTS.ToysProgram_ScheduleButton}, {CONSTANTS.HealthProgram_ScheduleButton}, {CONSTANTS.KindWall_ScheduleButton} , {CONSTANTS.MainMenuButton}};
			keyInterface.resize_keyboard = true;
			keyInterface.one_time_keyboard = false;
			keyInterface.selective = false;
			string json = JsonConvert.SerializeObject(keyInterface);
			return json;
		}

		public static string HealthProgramScheduleKeyboard()	//Used
		{
			REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
			keyInterface.keyboard = new string[3, 1] {{CONSTANTS.RedirectToHealthVolunteerBot_HealthProgram_ScheduleButton}, {CONSTANTS.RedirectToHealthVolunteerChannel_HealthProgram_ScheduleButton}, {CONSTANTS.MainMenu_HealthProgram_ScheduleButton}};
			keyInterface.resize_keyboard = true;
			keyInterface.one_time_keyboard = false;
			keyInterface.selective = false;
			string json = JsonConvert.SerializeObject(keyInterface);
			return json;
		}

		public static string HelpToysProgramScheduleKeyboard()
		{
			REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
			keyInterface.keyboard = new string[2, 1] {{CONSTANTS.SendingGifts_ToysProgram_ScheduleButton}, {CONSTANTS.MainMenu_ToysProgram_ScheduleButton}};
			keyInterface.resize_keyboard = true;
			keyInterface.one_time_keyboard = false;
			keyInterface.selective = false;
			string json = JsonConvert.SerializeObject(keyInterface);
			return json;
		}

		public static string SendGiftToysProgramScheduleKeyboard()
		{
			REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
			keyInterface.keyboard = new string[3, 1] {{CONSTANTS.InDoorDelivery_SendingGifts_ToysProgram_ScheduleButton} ,{CONSTANTS.OutDoorDelivery_SendingGifts_ToysProgram_ScheduleButton}, {CONSTANTS.MainMenu_SendingGifts_ToysProgram_ScheduleButton}};
			keyInterface.resize_keyboard = true;
			keyInterface.one_time_keyboard = false;
			keyInterface.selective = false;
			string json = JsonConvert.SerializeObject(keyInterface);
			return json;
		}

		public static string AboutUsKeyboard()
		{
			REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
			keyInterface.keyboard = new string[3, 1] {{CONSTANTS.ImamRezaHealthCenterGroup_AboutUsButton}, {CONSTANTS.ToysProgramGroup_AboutUsButton}, {CONSTANTS.MainMenuButton}};
			keyInterface.resize_keyboard = true;
			keyInterface.one_time_keyboard = false;
			keyInterface.selective = false;
			string json = JsonConvert.SerializeObject(keyInterface);
			return json;
		}

		public static string HelpKeyboard()
		{
			REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
			keyInterface.keyboard = new string[2, 1] {{CONSTANTS.HowToEnterInfo_HelpButton}, {CONSTANTS.MainMenuButton}};
			keyInterface.resize_keyboard = true;
			keyInterface.one_time_keyboard = false;
			keyInterface.selective = false;
			string json = JsonConvert.SerializeObject(keyInterface);
			return json;
		}

		public static string InvitationCityKeyboard()
		{
				REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
				keyInterface.keyboard = new string[7, 1] {{CONSTANTS.InvTehran},{CONSTANTS.InvIsfahan},{CONSTANTS.InvMazandaran},{CONSTANTS.InvGilan},{CONSTANTS.InvKhorasanRazavi},{CONSTANTS.InvAzarbayejanGharbi},{CONSTANTS.InvOtherCities}};
				keyInterface.resize_keyboard = true;
				keyInterface.one_time_keyboard = false;
				keyInterface.selective = false;
				string json = JsonConvert.SerializeObject(keyInterface);
				return json;
		}

		public static string SendersCityKeyboard()
		{
				REPLAYKEYBOARDMARKUP keyInterface = new REPLAYKEYBOARDMARKUP();
				keyInterface.keyboard = new string[7, 1] {{CONSTANTS.SndTehran},{CONSTANTS.SndIsfahan},{CONSTANTS.SndMazandaran},{CONSTANTS.SndGilan},{CONSTANTS.SndKhorasanRazavi},{CONSTANTS.SndAzarbayejanGharbi},{CONSTANTS.SndOtherCities}};
				keyInterface.resize_keyboard = true;
				keyInterface.one_time_keyboard = false;
				keyInterface.selective = false;
				string json = JsonConvert.SerializeObject(keyInterface);
				return json;
		}

	}
}
