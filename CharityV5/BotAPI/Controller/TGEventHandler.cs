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
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using TGModels;
using TGController;
using TGFileManager;
using TGServerFileUploader;
using TGDataBaseManager;
using TGKeyboardManager;
using TGUtility;

namespace TGEventHandler
{
	public class TGEventHandlerClass
	{
		public static string apiToken   = "214009380:AAFbJf3NaHKRZyKVW3qC6QLDDB4ivTlyveM";
		public static string baseURL    = "https://api.telegram.org/bot";

		public static void HandleResponse(RESPONSEUPDATE res)
		{
			if (!res.ok.ToLower().Equals("true"))
			{
				Console.WriteLine("Error in Response Object");
			}
			else
			{       
				if (res.result.Length == 0)
				return;

				foreach (UPDATE update in res.result)
				{
					Console.WriteLine("Request From User: " + update.update_id.ToString());
					FileManager.WriteInTempFile(CONSTANTS.TempFilePath, update.update_id.ToString());
					MESSAGE msg = update.message;

					string userIdentifier = msg.from.id.ToString();

					if (!DBManager.CheckIfUserExistsInInteractTable(userIdentifier))
						DBManager.InsertUserToInteractTable(userIdentifier);

					if (msg.text.ToLower().StartsWith(CONSTANTS.Start))
					{
						string keyboardType = TGKeyboardManagerClass.StartKeyboard();
						Controller.SendMessage(userIdentifier, CONSTANTS.Start_HText, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.SendingGifts_Button))
					{
						string keyboardType = TGKeyboardManagerClass.SendGiftToysProgramScheduleKeyboard();
						Controller.SendMessage(userIdentifier, CONSTANTS.SendGift_HText, CONSTANTS.Markdown, true, 0, keyboardType);
					}					
                                        else if (msg.text.ToLower().Equals(CONSTANTS.NazreShadiBaseButton))
                                        {
                                                string keyboardType = TGKeyboardManagerClass.MainKeyboard();
                                                string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.NazreShadiBaseButton);
                                                Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
                                        }
					else if (msg.text.ToLower().Equals(CONSTANTS.NazreShadiOtherCitiesButton))
					{
						string keyboardType = TGKeyboardManagerClass.MainKeyboard();
						Controller.SendMessage(userIdentifier, CONSTANTS.SoonWillBeNotifiedSetadOstani_HText, CONSTANTS.Markdown, true, 0, keyboardType);
					}					

					else if (msg.text.ToLower().Equals(CONSTANTS.HelpButton))
					{
						string keyboardType = TGKeyboardManagerClass.HelpKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.HelpButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.HowToEnterInfo_HelpButton) || msg.text.ToLower().Equals(CONSTANTS.Help))
					{
						string keyboardType = TGKeyboardManagerClass.MainKeyboard();
						Controller.SendMessage(userIdentifier, CONSTANTS.HowToEnterInfo_HText, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.MainMenu_HelpButton))
					{
						string keyboardType = TGKeyboardManagerClass.MainKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.MainMenu_HelpButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.InvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.InvitationKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.InvitationButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.Always_InvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.AlwaysInvitationKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.Always_InvitationButton);
						Controller.SendMessage(userIdentifier, CONSTANTS.AlwaysCorporation_HText, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.MainMenu_Execution_AlwaysInvitatioButton))
					{
						string keyboardType = TGKeyboardManagerClass.AlwaysInvitationKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.MainMenu_HelpButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.PublicRelations_AlwaysInvitationButton))
					{
						//Fix Needed
						bool check1 = DBManager.CheckIfAlreadySignedUp(userIdentifier, "InvUserTableV1", "PR");
						if (check1)
						{
							string keyboardType = TGKeyboardManagerClass.MainKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadySignedUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else
						{
							bool check2 = DBManager.CheckIfUserExistsInInvUserTable(userIdentifier);
							if (check2)
							{
								//Update
								DBManager.AddUserToAlwaysInvGroup(userIdentifier, "PR");
								string keyboardType = TGKeyboardManagerClass.MainKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AddedSuccessfuly_HText, CONSTANTS.Markdown, true, 0, keyboardType);
							}
							else
							{
								//SignUp
								Controller.SendMessage(userIdentifier, CONSTANTS.ShouldSignUp_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_PR_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
							}
						}
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.FinancialManagement_AlwaysInvitationButton))
					{
						//Fix Needed
						bool check1 = DBManager.CheckIfAlreadySignedUp(userIdentifier, "InvUserTableV1", "FM");
						if (check1)
						{
							string keyboardType = TGKeyboardManagerClass.MainKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadySignedUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else
						{
							bool check2 = DBManager.CheckIfUserExistsInInvUserTable(userIdentifier);
							if (check2)
							{
								//Update
								DBManager.AddUserToAlwaysInvGroup(userIdentifier, "FM");
								string keyboardType = TGKeyboardManagerClass.MainKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AddedSuccessfuly_HText, CONSTANTS.Markdown, true, 0, keyboardType);

							}
							else
							{
								//SignUp
								Controller.SendMessage(userIdentifier, CONSTANTS.ShouldSignUp_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_FM_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
							}
						}
					}
					else if (msg.text.ToLower().Equals(CONSTANTS.Media_AlwaysInvitationButton))
					{
						//Fix Needed
						bool check1 = DBManager.CheckIfAlreadySignedUp(userIdentifier, "AlwaysInvitationTableV1", "MD");
						if (check1)
						{
							string keyboardType = TGKeyboardManagerClass.MainKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadySignedUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else
						{
							bool check2 = DBManager.CheckIfUserExistsInInvUserTable(userIdentifier);
							if (check2)
							{
								//Update
								DBManager.AddUserToAlwaysInvGroup(userIdentifier, "MD");
								string keyboardType = TGKeyboardManagerClass.MainKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AddedSuccessfuly_HText, CONSTANTS.Markdown, true, 0, keyboardType);

							}
							else
							{
								//SignUp
								Controller.SendMessage(userIdentifier, CONSTANTS.ShouldSignUp_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_MD_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
							}
						}
					}
					else if (msg.text.ToLower().Equals(CONSTANTS.IT_AlwaysInvitationButton))
					{
						//Fix Needed
						bool check1 = DBManager.CheckIfAlreadySignedUp(userIdentifier, "AlwaysInvitationTableV1", "IT");
						if (check1)
						{
							string keyboardType = TGKeyboardManagerClass.MainKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadySignedUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else
						{
							bool check2 = DBManager.CheckIfUserExistsInInvUserTable(userIdentifier);
							if (check2)
							{
								//Update
								DBManager.AddUserToAlwaysInvGroup(userIdentifier, "IT");
								string keyboardType = TGKeyboardManagerClass.MainKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AddedSuccessfuly_HText, CONSTANTS.Markdown, true, 0, keyboardType);

							}
							else
							{
								//SignUp
								Controller.SendMessage(userIdentifier, CONSTANTS.ShouldSignUp_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_IT_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);								
							}
						}
					}
					else if (msg.text.ToLower().Equals(CONSTANTS.Management_AlwaysInvitationButton))
					{
						//Fix Needed
						bool check1 = DBManager.CheckIfAlreadySignedUp(userIdentifier, "AlwaysInvitationTableV1", "MG");
						if (check1)
						{
							string keyboardType = TGKeyboardManagerClass.MainKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadySignedUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else
						{
							bool check2 = DBManager.CheckIfUserExistsInInvUserTable(userIdentifier);
							if (check2)
							{
								//Update
								DBManager.AddUserToAlwaysInvGroup(userIdentifier, "MG");
								string keyboardType = TGKeyboardManagerClass.MainKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AddedSuccessfuly_HText, CONSTANTS.Markdown, true, 0, keyboardType);

							}
							else
							{
								//SignUp
								Controller.SendMessage(userIdentifier, CONSTANTS.ShouldSignUp_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_MG_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
							}
						}
					}
					else if (msg.text.ToLower().Equals(CONSTANTS.Execution_AlwaysInvitationButton))
					{
						//Fix Needed
						string keyboardType = TGKeyboardManagerClass.ExecutionInvitationKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.Execution_AlwaysInvitationButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}
					else if (msg.text.ToLower().Equals(CONSTANTS.Civilization_Execution_AlwaysInvitationButton))
					{
						//Fix Needed
						bool check1 = DBManager.CheckIfAlreadySignedUp(userIdentifier, "AlwaysInvitationTableV1", "EXCV");
						if (check1)
						{
							string keyboardType = TGKeyboardManagerClass.MainKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadySignedUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else
						{
							bool check2 = DBManager.CheckIfUserExistsInInvUserTable(userIdentifier);
							if (check2)
							{
								//Update
								DBManager.AddUserToAlwaysInvGroup(userIdentifier, "EXCV");
								string keyboardType = TGKeyboardManagerClass.MainKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AddedSuccessfuly_HText, CONSTANTS.Markdown, true, 0, keyboardType);

							}
							else
							{
								//SignUp
								Controller.SendMessage(userIdentifier, CONSTANTS.ShouldSignUp_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_EXCV_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);

							}
						}
					}
					else if (msg.text.ToLower().Equals(CONSTANTS.Medical_Execution_AlwaysInvitationButton))
					{
						//Fix Needed
						bool check1 = DBManager.CheckIfAlreadySignedUp(userIdentifier, "AlwaysInvitationTableV1", "EXMD");
						if (check1)
						{
							string keyboardType = TGKeyboardManagerClass.MainKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadySignedUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else
						{
							bool check2 = DBManager.CheckIfUserExistsInInvUserTable(userIdentifier);
							if (check2)
							{
								//Update
								DBManager.AddUserToAlwaysInvGroup(userIdentifier, "EXMD");
								string keyboardType = TGKeyboardManagerClass.MainKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AddedSuccessfuly_HText, CONSTANTS.Markdown, true, 0, keyboardType);

							}
							else
							{
								//SignUp
								Controller.SendMessage(userIdentifier, CONSTANTS.ShouldSignUp_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_EXMD_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);

							}
						}
					}
					else if (msg.text.ToLower().Equals(CONSTANTS.Psychology_Execution_AlwaysInvitationButton))
					{
						//Fix Needed
						bool check1 = DBManager.CheckIfAlreadySignedUp(userIdentifier, "AlwaysInvitationTableV1", "EXPS");
						if (check1)
						{
							string keyboardType = TGKeyboardManagerClass.MainKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadySignedUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else
						{
							bool check2 = DBManager.CheckIfUserExistsInInvUserTable(userIdentifier);
							if (check2)
							{
								//Update
								DBManager.AddUserToAlwaysInvGroup(userIdentifier, "EXPS");
								string keyboardType = TGKeyboardManagerClass.MainKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AddedSuccessfuly_HText, CONSTANTS.Markdown, true, 0, keyboardType);

							}
							else
							{
								//SignUp
								Controller.SendMessage(userIdentifier, CONSTANTS.ShouldSignUp_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_EXPS_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);								
							}
						}
					}
					else if (msg.text.ToLower().Equals(CONSTANTS.Support_Execution_AlwaysInvitationButton))
					{
						//Fix Needed
						bool check1 = DBManager.CheckIfAlreadySignedUp(userIdentifier, "AlwaysInvitationTableV1", "EXSP");
						if (check1)
						{
							string keyboardType = TGKeyboardManagerClass.MainKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadySignedUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else
						{
							bool check2 = DBManager.CheckIfUserExistsInInvUserTable(userIdentifier);
							if (check2)
							{
								//Update
								DBManager.AddUserToAlwaysInvGroup(userIdentifier, "EXSP");
								string keyboardType = TGKeyboardManagerClass.MainKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AddedSuccessfuly_HText, CONSTANTS.Markdown, true, 0, keyboardType);

							}
							else
							{
								//SignUp
								Controller.SendMessage(userIdentifier, CONSTANTS.ShouldSignUp_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_EXSP_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);								
							}
						}
					}
					else if (msg.text.ToLower().Equals(CONSTANTS.JobCoordination_Execution_AlwaysInvitationButton))
					{
						//Fix Needed
						bool check1 = DBManager.CheckIfAlreadySignedUp(userIdentifier, "AlwaysInvitationTableV1", "EXJC");
						if (check1)
						{
							string keyboardType = TGKeyboardManagerClass.MainKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadySignedUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else
						{
							bool check2 = DBManager.CheckIfUserExistsInInvUserTable(userIdentifier);
							if (check2)
							{
								//Update
								DBManager.AddUserToAlwaysInvGroup(userIdentifier, "EXJC");
								string keyboardType = TGKeyboardManagerClass.MainKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AddedSuccessfuly_HText, CONSTANTS.Markdown, true, 0, keyboardType);

							}
							else
							{
								//SignUp
								Controller.SendMessage(userIdentifier, CONSTANTS.ShouldSignUp_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_EXJC_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);								
							}
						}
					}
					else if (msg.text.ToLower().Equals(CONSTANTS.Teaching_Execution_AlwaysInvitationButton))
					{
						//Fix Needed
						bool check1 = DBManager.CheckIfAlreadySignedUp(userIdentifier, "AlwaysInvitationTableV1", "EXTC");
						if (check1)
						{
							string keyboardType = TGKeyboardManagerClass.MainKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadySignedUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else
						{
							bool check2 = DBManager.CheckIfUserExistsInInvUserTable(userIdentifier);
							if (check2)
							{
								//Update
								DBManager.AddUserToAlwaysInvGroup(userIdentifier, "EXTC");
								string keyboardType = TGKeyboardManagerClass.MainKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AddedSuccessfuly_HText, CONSTANTS.Markdown, true, 0, keyboardType);

							}
							else
							{
								//SignUp
								Controller.SendMessage(userIdentifier, CONSTANTS.ShouldSignUp_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_EXTC_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);								
							}
						}
					}
					else if (msg.text.ToLower().Equals(CONSTANTS.Other_Execution_AlwaysInvitationButton))
					{
						//Fix Needed
						bool check1 = DBManager.CheckIfAlreadySignedUp(userIdentifier, "AlwaysInvitationTableV1", "EXOT");
						if (check1)
						{
							string keyboardType = TGKeyboardManagerClass.MainKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadySignedUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else
						{
							bool check2 = DBManager.CheckIfUserExistsInInvUserTable(userIdentifier);
							if (check2)
							{
								//Update
								DBManager.AddUserToAlwaysInvGroup(userIdentifier, "EXOT");
								string keyboardType = TGKeyboardManagerClass.MainKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AddedSuccessfuly_HText, CONSTANTS.Markdown, true, 0, keyboardType);

							}
							else
							{
								//SignUp
								Controller.SendMessage(userIdentifier, CONSTANTS.ShouldSignUp_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_EXOT_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);								
							}
						}
					}
					else if (msg.text.ToLower().Equals(CONSTANTS.MainMenu_Execution_AlwaysInvitatioButton))
					{
						string keyboardType = TGKeyboardManagerClass.AlwaysInvitationKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.MainMenu_Execution_AlwaysInvitatioButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}
					else if (msg.text.ToLower().Equals(CONSTANTS.MainMenu_AlwaysInvitatioButton))
					{
						string keyboardType = TGKeyboardManagerClass.InvitationKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.MainMenu_AlwaysInvitatioButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.NonAlways_InvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.NonAlwaysInvitationKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.NonAlways_InvitationButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.MainMenu_InvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.NonAlwaysInvitationKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.MainMenu_InvitationButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.HealthProgram_NonAlwaysInvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.HealthCareProgramKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.HealthProgram_NonAlwaysInvitationButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.RedirectToHealthVolunteerBot_HealthProgram_NonAlwaysInvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.MainKeyboard();
						Controller.SendMessage(userIdentifier, CONSTANTS.RedirectToHealthVolunteerBot_HText, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.RedirectToHealthVolunteerChannel_HealthProgram_NonAlwaysInvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.MainKeyboard();
						Controller.SendMessage(userIdentifier, CONSTANTS.RedirectToHealthVolunteerChannel_HText, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.MainMenu_HealthProgram_NonAlwaysInvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.InvitationKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.MainMenu_HealthProgram_NonAlwaysInvitationButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.ToysProgram_NonAlwaysInvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.ToysProgramKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.ToysProgram_NonAlwaysInvitationButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.InformationAndAdvertisementToysProgramKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.ReadMeFirst_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.ReadMeFirstInformationAndAdvertisementToysProgramKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.ReadMeFirst_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.GetHardcodeTextForAdsAndLinks_ReadMeFirst_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.MainKeyboard();
						Controller.SendMessage(userIdentifier, CONSTANTS.GetHardcodeTextForAdsAndLinks_HText, CONSTANTS.Markdown, false, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.InformationAndJobDescription_ReadMeFirst_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.MainKeyboard();
						Controller.SendMessage(userIdentifier, CONSTANTS.InformationAndJobDescription_HText, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.MainMenu_ReadMeFirst_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.InformationAndAdvertisementToysProgramKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.MainMenu_ReadMeFirst_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.SignUp_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton))
					{
						//Fix Needed
						bool check1 = DBManager.CheckIfAlreadySignedUp(userIdentifier, "NonAlwaysInvitationTableV1", "IAG");
						if (check1)
						{
							string keyboardType = TGKeyboardManagerClass.SignUpInformationAndAdvertisementToysProgramKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadySignedUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else 
						{
							bool check2 = DBManager.CheckIfUserExistsInInvUserTable(userIdentifier);
							if (check2)
							{
								//update
								DBManager.AddUserToAnotherGroup(userIdentifier, "IAG");
								string keyboardType = TGKeyboardManagerClass.SignUpInformationAndAdvertisementToysProgramKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AddedSuccessfuly_HText, CONSTANTS.Markdown, false, 0, keyboardType);
							}
							else
							{
								//signup
								Controller.SendMessage(userIdentifier, CONSTANTS.ShouldSignUp_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_IAG_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
							}
						}
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.TelegramUsers_SignUp_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton))
					{
						//Fix Needed
						bool check1 = DBManager.CheckIfAlreadySignedUp(userIdentifier, "NonAlwaysInvitationTableV1", "IAG");
						if (check1)
						{
							string keyboardType = TGKeyboardManagerClass.SignUpInformationAndAdvertisementToysProgramKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadySignedUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else 
						{
							bool check2 = DBManager.CheckIfUserExistsInInvUserTable(userIdentifier);
							if (check2)
							{
								//update
								DBManager.AddUserToAnotherGroup(userIdentifier, "IAG");
								string keyboardType = TGKeyboardManagerClass.SignUpInformationAndAdvertisementToysProgramKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AddedSuccessfuly_HText, CONSTANTS.Markdown, false, 0, keyboardType);
							}
							else
							{
								//signup
								Controller.SendMessage(userIdentifier, CONSTANTS.ShouldSignUp_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_IAG_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
							}
						}
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.TelegramGroup_SignUp_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton))
					{
						//Fix Needed
						bool check1 = DBManager.CheckIfAlreadySignedUp(userIdentifier, "NonAlwaysInvitationTableV1", "IAG");
						if (check1)
						{
							string keyboardType = TGKeyboardManagerClass.SignUpInformationAndAdvertisementToysProgramKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadySignedUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else 
						{
							bool check2 = DBManager.CheckIfUserExistsInInvUserTable(userIdentifier);
							if (check2)
							{
								//update
								DBManager.AddUserToAnotherGroup(userIdentifier, "IAG");
								string keyboardType = TGKeyboardManagerClass.SignUpInformationAndAdvertisementToysProgramKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AddedSuccessfuly_HText, CONSTANTS.Markdown, false, 0, keyboardType);
							}
							else
							{
								//signup
								Controller.SendMessage(userIdentifier, CONSTANTS.ShouldSignUp_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_IAG_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
							}
						}
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.Instagram_SignUp_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton))
					{
						//Fix Needed
						bool check1 = DBManager.CheckIfAlreadySignedUp(userIdentifier, "NonAlwaysInvitationTableV1", "IAG");
						if (check1)
						{
							string keyboardType = TGKeyboardManagerClass.SignUpInformationAndAdvertisementToysProgramKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadySignedUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else 
						{
							bool check2 = DBManager.CheckIfUserExistsInInvUserTable(userIdentifier);
							if (check2)
							{
								//update
								DBManager.AddUserToAnotherGroup(userIdentifier, "IAG");
								string keyboardType = TGKeyboardManagerClass.SignUpInformationAndAdvertisementToysProgramKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AddedSuccessfuly_HText, CONSTANTS.Markdown, false, 0, keyboardType);
							}
							else
							{
								//signup
								Controller.SendMessage(userIdentifier, CONSTANTS.ShouldSignUp_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_IAG_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
							}
						}
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.MainMenu_SignUp_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.InformationAndAdvertisementToysProgramKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.MainMenu_SignUp_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.MainMenu_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.ToysProgramKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.MainMenu_InformationAndAdvertismentPart_ToysProgram_NonAlwaysInvitationButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.CollectingGiftsPart_ToysProgram_NonAlwaysInvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.CollectingGiftsToysProgramKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.CollectingGiftsPart_ToysProgram_NonAlwaysInvitationButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.SignUp_CollectingGiftsPart_ToysProgram_NonAlwaysInvitationButton))
					{
						//Fix Needed
						bool check1 = DBManager.CheckIfAlreadySignedUp(userIdentifier, "NonAlwaysInvitationTableV1", "CG");
						if (check1)
						{
							string keyboardType = TGKeyboardManagerClass.SignUpInformationAndAdvertisementToysProgramKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadySignedUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else 
						{
							bool check2 = DBManager.CheckIfUserExistsInInvUserTable(userIdentifier);
							if (check2)
							{
								//update
								DBManager.AddUserToAnotherGroup(userIdentifier, "CG");
								string keyboardType = TGKeyboardManagerClass.SignUpInformationAndAdvertisementToysProgramKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AddedSuccessfuly_HText, CONSTANTS.Markdown, false, 0, keyboardType);
							}
							else
							{
								//signup
								Controller.SendMessage(userIdentifier, CONSTANTS.ShouldSignUp_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_IAG_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
							}
						}
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.NonTehran_SignUp_CollectingGiftsPart_ToysProgram_NonAlwaysInvitationButton))
					{
						//Fix Needed
						bool check1 = DBManager.CheckIfAlreadySignedUp(userIdentifier, "NonAlwaysInvitationTableV1", "CG");
						if (check1)
						{
							string keyboardType = TGKeyboardManagerClass.SignUpInformationAndAdvertisementToysProgramKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadySignedUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else 
						{
							bool check2 = DBManager.CheckIfUserExistsInInvUserTable(userIdentifier);
							if (check2)
							{
								//update
								DBManager.AddUserToAnotherGroup(userIdentifier, "CG");
								string keyboardType = TGKeyboardManagerClass.SignUpInformationAndAdvertisementToysProgramKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AddedSuccessfuly_HText, CONSTANTS.Markdown, false, 0, keyboardType);
							}
							else
							{
								//signup
								Controller.SendMessage(userIdentifier, CONSTANTS.ShouldSignUp_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_IAG_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
							}
						}
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.Tehran_SignUp_CollectingGiftsPart_ToysProgram_NonAlwaysInvitationButton))
					{
						//Fix Needed
						bool check1 = DBManager.CheckIfAlreadySignedUp(userIdentifier, "NonAlwaysInvitationTableV1", "CG");
						if (check1)
						{
							string keyboardType = TGKeyboardManagerClass.SignUpInformationAndAdvertisementToysProgramKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadySignedUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else 
						{
							bool check2 = DBManager.CheckIfUserExistsInInvUserTable(userIdentifier);
							if (check2)
							{
								//update
								DBManager.AddUserToAnotherGroup(userIdentifier, "CG");
								string keyboardType = TGKeyboardManagerClass.SignUpInformationAndAdvertisementToysProgramKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AddedSuccessfuly_HText, CONSTANTS.Markdown, false, 0, keyboardType);
							}
							else
							{
								//signup
								Controller.SendMessage(userIdentifier, CONSTANTS.ShouldSignUp_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_IAG_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
							}
						}
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.MainMenu_SignUp_CollectingGiftsPart_ToysProgram_NonAlwaysInvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.CollectingGiftsToysProgramKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.MainMenu_SignUp_CollectingGiftsPart_ToysProgram_NonAlwaysInvitationButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.MainMenu_CollectingGiftsPart_ToysProgram_NonAlwaysInvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.ToysProgramKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.MainMenu_CollectingGiftsPart_ToysProgram_NonAlwaysInvitationButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.PackagingAndSegregatingGiftsPart_ToysProgram_NonAlwaysInvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.PackagingAndSegregatingGiftsToysProgramKeyboard();
						Controller.SendMessage(userIdentifier, CONSTANTS.PackagingAndSegregatingGiftsPart_HText, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.SignUp_PackagingAndSegregatingGiftsPart_ToysProgram_NonAlwaysInvitationButton))
					{
						//Fix Needed
						bool check1 = DBManager.CheckIfAlreadySignedUp(userIdentifier, "NonAlwaysInvitationTableV1", "PSG");
						if (check1)
						{
							string keyboardType = TGKeyboardManagerClass.SignUpInformationAndAdvertisementToysProgramKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadySignedUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else 
						{
							bool check2 = DBManager.CheckIfUserExistsInInvUserTable(userIdentifier);
							if (check2)
							{
								//update
								DBManager.AddUserToAnotherGroup(userIdentifier, "PSG");
								string keyboardType = TGKeyboardManagerClass.SignUpInformationAndAdvertisementToysProgramKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AddedSuccessfuly_HText, CONSTANTS.Markdown, false, 0, keyboardType);
							}
							else
							{
								//signup
								Controller.SendMessage(userIdentifier, CONSTANTS.ShouldSignUp_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_IAG_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
							}
						}
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.MainMenu_PackagingAndSegregatingGiftsPart_ToysProgram_NonAlwaysInvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.ToysProgramKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.MainMenu_PackagingAndSegregatingGiftsPart_ToysProgram_NonAlwaysInvitationButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.DistributingGiftsPart_ToysProgram_NonAlwaysInvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.DistributingGiftsToysProgramKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.DistributingGiftsPart_ToysProgram_NonAlwaysInvitationButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.SignUp_DistributingGiftsPart_ToysProgram_NonAlwaysInvitationButton))
					{
						//Fix Needed
						bool check1 = DBManager.CheckIfAlreadySignedUp(userIdentifier, "NonAlwaysInvitationTableV1", "DG");
						if (check1)
						{
							string keyboardType = TGKeyboardManagerClass.SignUpInformationAndAdvertisementToysProgramKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadySignedUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else 
						{
							bool check2 = DBManager.CheckIfUserExistsInInvUserTable(userIdentifier);
							if (check2)
							{
								//update
								DBManager.AddUserToAnotherGroup(userIdentifier, "DG");
								string keyboardType = TGKeyboardManagerClass.SignUpInformationAndAdvertisementToysProgramKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AddedSuccessfuly_HText, CONSTANTS.Markdown, false, 0, keyboardType);
							}
							else
							{
								//signup
								Controller.SendMessage(userIdentifier, CONSTANTS.ShouldSignUp_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_IAG_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
							}
						}
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.JahadiGroup_SignUp_DistributingGiftsPart_ToysProgram_NonAlwaysInvitationButton))
					{
						//Fix Needed
						bool check1 = DBManager.CheckIfAlreadySignedUp(userIdentifier, "NonAlwaysInvitationTableV1", "DG");
						if (check1)
						{
							string keyboardType = TGKeyboardManagerClass.SignUpInformationAndAdvertisementToysProgramKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadySignedUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else 
						{
							bool check2 = DBManager.CheckIfUserExistsInInvUserTable(userIdentifier);
							if (check2)
							{
								//update
								DBManager.AddUserToAnotherGroup(userIdentifier, "DG");
								string keyboardType = TGKeyboardManagerClass.SignUpInformationAndAdvertisementToysProgramKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AddedSuccessfuly_HText, CONSTANTS.Markdown, false, 0, keyboardType);
							}
							else
							{
								//signup
								Controller.SendMessage(userIdentifier, CONSTANTS.ShouldSignUp_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_IAG_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
							}
						}
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.CharityCenter_SignUp_DistributingGiftsPart_ToysProgram_NonAlwaysInvitationButton))
					{
						//Fix Needed
						bool check1 = DBManager.CheckIfAlreadySignedUp(userIdentifier, "NonAlwaysInvitationTableV1", "DG");
						if (check1)
						{
							string keyboardType = TGKeyboardManagerClass.SignUpInformationAndAdvertisementToysProgramKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadySignedUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else 
						{
							bool check2 = DBManager.CheckIfUserExistsInInvUserTable(userIdentifier);
							if (check2)
							{
								//update
								DBManager.AddUserToAnotherGroup(userIdentifier, "DG");
								string keyboardType = TGKeyboardManagerClass.SignUpInformationAndAdvertisementToysProgramKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AddedSuccessfuly_HText, CONSTANTS.Markdown, false, 0, keyboardType);
							}
							else
							{
								//signup
								Controller.SendMessage(userIdentifier, CONSTANTS.ShouldSignUp_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_IAG_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
							}
						}
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.Individual_SignUp_DistributingGiftsPart_ToysProgram_NonAlwaysInvitationButton))
					{
						//Fix Needed
						bool check1 = DBManager.CheckIfAlreadySignedUp(userIdentifier, "NonAlwaysInvitationTableV1", "DG");
						if (check1)
						{
							string keyboardType = TGKeyboardManagerClass.SignUpInformationAndAdvertisementToysProgramKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadySignedUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else 
						{
							bool check2 = DBManager.CheckIfUserExistsInInvUserTable(userIdentifier);
							if (check2)
							{
								//update
								DBManager.AddUserToAnotherGroup(userIdentifier, "DG");
								string keyboardType = TGKeyboardManagerClass.SignUpInformationAndAdvertisementToysProgramKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AddedSuccessfuly_HText, CONSTANTS.Markdown, false, 0, keyboardType);
							}
							else
							{
								//signup
								Controller.SendMessage(userIdentifier, CONSTANTS.ShouldSignUp_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_IAG_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
							}
						}
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.MainMenu_SignUp_DistributingGiftsPart_ToysProgram_NonAlwaysInvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.DistributingGiftsToysProgramKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.MainMenu_SignUp_DistributingGiftsPart_ToysProgram_NonAlwaysInvitationButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.MainMenu_DistributingGiftsPart_ToysProgram_NonAlwaysInvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.ToysProgramKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.MainMenu_DistributingGiftsPart_ToysProgram_NonAlwaysInvitationButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.MainMenu_ToysProgram_NonAlwaysInvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.InvitationKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.MainMenu_ToysProgram_NonAlwaysInvitationButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.KindWall_NonAlwaysInvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.MainKeyboard();
						Controller.SendMessage(userIdentifier, CONSTANTS.SoonWillBeNotified_HText , CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.Help_KindWall_NonAlwaysInvitationButton))
					{
						//Fix Later
						string keyboardType = TGKeyboardManagerClass.MainKeyboard();
						Controller.SendMessage(userIdentifier, CONSTANTS.SoonWillBeAdded_HText, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.Corporation_KindWall_NonAlwaysInvitationButton))
					{
						//Fix Later
						string keyboardType = TGKeyboardManagerClass.MainKeyboard();
						Controller.SendMessage(userIdentifier, CONSTANTS.SoonWillBeAdded_HText, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.MainMenu_KindWall_NonAlwaysInvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.InvitationKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.MainMenu_KindWall_NonAlwaysInvitationButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.MainMenu_InvitationButton))
					{
						string keyboardType = TGKeyboardManagerClass.MainKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.MainMenu_InvitationButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.GalleryButton))
					{
						string keyboardType = TGKeyboardManagerClass.GalleryKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.GalleryButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.ToysProgram_GalleryButton))
					{
						string keyboardType = TGKeyboardManagerClass.MainKeyboard();
						Controller.SendPhoto(userIdentifier, CONSTANTS.ToysProgramAlbumPhotoPath, 5, CONSTANTS.ToysProgram_Caption, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.HealthProgram_GalleryButton))
					{
						string keyboardType = TGKeyboardManagerClass.MainKeyboard();
						Controller.SendPhoto(userIdentifier, CONSTANTS.HealthCareProgramAlbumPhotoPath, 8, CONSTANTS.HealthProgram_Caption, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.OtherProgram_GalleryButton))
					{
						string keyboardType = TGKeyboardManagerClass.MainKeyboard();
						Controller.SendPhoto(userIdentifier, CONSTANTS.OtherProgramAlbumPhotoPath, 2, CONSTANTS.OtherProgram_Caption, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.MainMenu_GalleryButton))
					{
						string keyboardType = TGKeyboardManagerClass.MainKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.MainMenu_GalleryButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.ScheduleButton))
					{
						string keyboardType = TGKeyboardManagerClass.ScheduleKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.ScheduleButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.ToysProgram_ScheduleButton))
					{
						string keyboardType = TGKeyboardManagerClass.HelpToysProgramScheduleKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.ToysProgram_ScheduleButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.SendingGifts_ToysProgram_ScheduleButton))
					{
						string keyboardType = TGKeyboardManagerClass.SendGiftToysProgramScheduleKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.SendingGifts_ToysProgram_ScheduleButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.InDoorDelivery_SendingGifts_ToysProgram_ScheduleButton))
					{
						//Fix Needed
						bool status = DBManager.CheckIfAlreadySignedUpInSenders(userIdentifier);
						if (status)
						{
							string keyboardType = TGKeyboardManagerClass.MainKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AlreadyAskDelivery_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else 
						{
							string keyboardType = TGKeyboardManagerClass.QAKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.SendGifts_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.OutDoorDelivery_SendingGifts_ToysProgram_ScheduleButton))
					{
						string keyboardType = TGKeyboardManagerClass.MainKeyboard();
						Controller.SendPhoto(userIdentifier, CONSTANTS.SendGiftAlbumPhotoPath, 1, CONSTANTS.SendGift_Caption, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.MainMenu_SendingGifts_ToysProgram_ScheduleButton))
					{
						string keyboardType = TGKeyboardManagerClass.HelpToysProgramScheduleKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.MainMenu_SendingGifts_ToysProgram_ScheduleButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.MainMenu_ToysProgram_ScheduleButton))
					{
						string keyboardType = TGKeyboardManagerClass.ScheduleKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.MainMenu_ToysProgram_ScheduleButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.HealthProgram_ScheduleButton))
					{
						string keyboardType = TGKeyboardManagerClass.HealthProgramScheduleKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.HealthProgram_ScheduleButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.RedirectToHealthVolunteerBot_HealthProgram_ScheduleButton))
					{
						string keyboardType = TGKeyboardManagerClass.MainKeyboard();
						Controller.SendMessage(userIdentifier, CONSTANTS.RedirectToHealthVolunteerBot_HealthProgram_NonAlwaysInvitationButton, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.RedirectToHealthVolunteerChannel_HealthProgram_ScheduleButton))
					{
						string keyboardType = TGKeyboardManagerClass.MainKeyboard();
						Controller.SendMessage(userIdentifier, CONSTANTS.RedirectToHealthVolunteerChannel_HealthProgram_NonAlwaysInvitationButton, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.MainMenu_HealthProgram_ScheduleButton))
					{
						string keyboardType = TGKeyboardManagerClass.ScheduleKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.MainMenu_HealthProgram_ScheduleButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.KindWall_ScheduleButton))
					{
						string keyboardType = TGKeyboardManagerClass.NonAlwaysInvitationKeyboard();
						Controller.SendMessage(userIdentifier, CONSTANTS.SoonWillBeNotified_HText, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.MainMenu_ScheduleButton))
					{
						string keyboardType = TGKeyboardManagerClass.MainKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.MainMenu_ScheduleButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.AboutUsButton))
					{
						string keyboardType = TGKeyboardManagerClass.AboutUsKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.AboutUsButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.ImamRezaHealthCenterGroup_AboutUsButton))
					{
						string keyboardType = TGKeyboardManagerClass.MainKeyboard();
						Controller.SendMessage(userIdentifier, CONSTANTS.ImamRezaHealthCenterGroup_HText, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.ToysProgramGroup_AboutUsButton))
					{
						string keyboardType = TGKeyboardManagerClass.MainKeyboard();
						Controller.SendMessage(userIdentifier, CONSTANTS.ToysProgramGroup_HText, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Equals(CONSTANTS.MainMenu_AboutUsButton))
					{
						string keyboardType = TGKeyboardManagerClass.MainKeyboard();
						string tempmsg = String.Format("به {0} منتقل شدید.", CONSTANTS.MainMenu_AboutUsButton);
						Controller.SendMessage(userIdentifier, tempmsg, CONSTANTS.Markdown, true, 0, keyboardType);
					}

					else if (msg.text.ToLower().Contains(CONSTANTS.Inv))
					{
						bool check = DBManager.CheckIfUserExistsInDB(userIdentifier, "InvUserTableV1");
						if(check)
						{
							string city = TGUtilityClass.StringOfCity(msg.text);
							DBManager.SetUserCity(userIdentifier, city, "InvUserTableV1");
							string keyboardType = TGKeyboardManagerClass.MainKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.SuccessfulSignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else
						{
							Controller.SendMessage(userIdentifier, CONSTANTS.WrongInput_HText, CONSTANTS.Markdown, true, 0, null);
							string keyboardType = TGKeyboardManagerClass.InvitationCityKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AskForCity, CONSTANTS.Markdown, false, 0, keyboardType);
						}
					}

					else if (msg.text.ToLower().Contains(CONSTANTS.Snd))
					{
						bool check = DBManager.CheckIfUserExistsInDB(userIdentifier, "SndUserTableV1");
						if(check)
						{
							string city = TGUtilityClass.StringOfCity(msg.text);
							DBManager.SetUserCity(userIdentifier, city, "SndUserTableV1");
							string keyboardType = TGKeyboardManagerClass.MainKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.SuccessfulSignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
						}
						else
						{
							Controller.SendMessage(userIdentifier, CONSTANTS.WrongInput_HText, CONSTANTS.Markdown, true, 0, null);
							string keyboardType = TGKeyboardManagerClass.SendersCityKeyboard();
							Controller.SendMessage(userIdentifier, CONSTANTS.AskForCity, CONSTANTS.Markdown, false, 0, keyboardType);
						}
					}

					if (msg.reply_to_message.from.username.Equals(CONSTANTS.BotName))
					{
						if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_IAG_SignUp_HText) ||
							msg.reply_to_message.text.Contains(CONSTANTS.Invitation_CG_SignUp_HText)  ||
							msg.reply_to_message.text.Contains(CONSTANTS.Invitation_PSG_SignUp_HText) ||
							msg.reply_to_message.text.Contains(CONSTANTS.Invitation_DG_SignUp_HText) ||
							msg.reply_to_message.text.Contains(CONSTANTS.Invitation_PR_SignUp_HText) ||
							msg.reply_to_message.text.Contains(CONSTANTS.Invitation_FM_SignUp_HText) ||
							msg.reply_to_message.text.Contains(CONSTANTS.Invitation_MD_SignUp_HText) ||
							msg.reply_to_message.text.Contains(CONSTANTS.Invitation_IT_SignUp_HText) ||
							msg.reply_to_message.text.Contains(CONSTANTS.Invitation_MG_SignUp_HText) ||
							msg.reply_to_message.text.Contains(CONSTANTS.Invitation_EXCV_SignUp_HText) ||
							msg.reply_to_message.text.Contains(CONSTANTS.Invitation_EXMD_SignUp_HText) ||
							msg.reply_to_message.text.Contains(CONSTANTS.Invitation_EXPS_SignUp_HText) ||
							msg.reply_to_message.text.Contains(CONSTANTS.Invitation_EXSP_SignUp_HText) ||
							msg.reply_to_message.text.Contains(CONSTANTS.Invitation_EXJC_SignUp_HText) ||
							msg.reply_to_message.text.Contains(CONSTANTS.Invitation_EXTC_SignUp_HText) ||
							msg.reply_to_message.text.Contains(CONSTANTS.Invitation_EXOT_SignUp_HText)
							)
						{
							string[] separators = {"\n"};
							string[] words = msg.text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

							bool check2 = (words.Length == 5); 

							if (check2)
							{
                                				bool check1 = Regex.IsMatch(words[2],@"^[آ-ی]*$");
								string phoneNumber = null;
								if (check1)
								phoneNumber = TGUtilityClass.StringOfArabicNumbers(words[2]);
								else
								phoneNumber = words[2];

								String Field = null;
								string keyboardType = null;
								if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_IAG_SignUp_HText))
									Field = "IAG";
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_CG_SignUp_HText))
									Field = "CG";
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_PSG_SignUp_HText))
									Field = "PSG";
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_DG_SignUp_HText))
									Field = "DG";
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_PR_SignUp_HText))
									Field = "PR";
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_FM_SignUp_HText))
									Field = "FM";
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_MD_SignUp_HText))
									Field = "MD";
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_IT_SignUp_HText))
									Field = "IT";
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_MG_SignUp_HText))
									Field = "MG";
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_EXCV_SignUp_HText))
									Field = "EXCV";
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_EXMD_SignUp_HText))
									Field = "EXMD";
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_EXPS_SignUp_HText))
									Field = "EXPS";
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_EXSP_SignUp_HText))
									Field = "EXSP";
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_EXJC_SignUp_HText))
									Field = "EXJC";
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_EXTC_SignUp_HText))
									Field = "EXTC";
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_EXOT_SignUp_HText))
									Field = "EXOT";

								DBManager.InsertUserToInvitationTable(userIdentifier, words[0], words[1], phoneNumber, words[3], words[4]);
								DBManager.AddUserToAlwaysInvGroup(userIdentifier, Field);
								keyboardType = TGKeyboardManagerClass.InvitationCityKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AskForCity, CONSTANTS.Markdown, false, 0, keyboardType);
							}
							else
							{
								Controller.SendMessage(userIdentifier, CONSTANTS.WrongInput_HText, CONSTANTS.Markdown, true, 0, null);
								Controller.SendMessage(userIdentifier, CONSTANTS.HowToEnterInfo_HText, CONSTANTS.Markdown, true, 0, null);
								
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_IAG_SignUp_HText))
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_IAG_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_CG_SignUp_HText))
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_CG_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_PSG_SignUp_HText))
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_PSG_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_DG_SignUp_HText))
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_DG_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);

								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_PR_SignUp_HText))
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_PR_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_FM_SignUp_HText))
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_FM_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_MD_SignUp_HText))
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_MD_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_IT_SignUp_HText))
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_IT_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_MG_SignUp_HText))
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_MG_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);

								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_EXCV_SignUp_HText))
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_EXCV_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_EXMD_SignUp_HText))
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_EXMD_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_EXPS_SignUp_HText))
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_EXPS_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_EXSP_SignUp_HText))
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_EXSP_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_EXJC_SignUp_HText))
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_EXJC_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_EXTC_SignUp_HText))
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_EXTC_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
								else if (msg.reply_to_message.text.Contains(CONSTANTS.Invitation_EXOT_SignUp_HText))
								Controller.SendMessage(userIdentifier, CONSTANTS.Invitation_EXOT_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);

							}
						}
						else if (msg.reply_to_message.text.Contains(CONSTANTS.SendGifts_SignUp_HText))
						{
							string[] separators = {"\n"};
							string[] words = msg.text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

							bool check3 = (words.Length == 6); 

							if (check3)
							{
								bool check1 = Regex.IsMatch(words[2],@"^[آ-ی]*$");
								bool check2 = Regex.IsMatch(words[4],@"^[آ-ی]*$");
								string phoneNumber = null;
								string area = null;
								if (check1)
								phoneNumber = TGUtilityClass.StringOfArabicNumbers(words[2]);
								else
								phoneNumber = words[2];

								if (check2)
								area = TGUtilityClass.StringOfArabicNumbers(words[4]);
								else
								area = words[4];

								DBManager.InsertUserToSendersTable(userIdentifier, words[0], words[1], phoneNumber, words[3], words[5]);
								string keyboardType = TGKeyboardManagerClass.SendersCityKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.AskForCity, CONSTANTS.Markdown, false, 0, keyboardType);
							}
							else
							{
								Controller.SendMessage(userIdentifier, CONSTANTS.WrongInput_HText, CONSTANTS.Markdown, true, 0, null);
								Controller.SendMessage(userIdentifier, CONSTANTS.HowToEnterInfo_HText, CONSTANTS.Markdown, true, 0, null);
								string keyboardType = TGKeyboardManagerClass.QAKeyboard();
								Controller.SendMessage(userIdentifier, CONSTANTS.SendGifts_SignUp_HText, CONSTANTS.Markdown, true, 0, keyboardType);
							}
						}
					}
				}
			}
		}

		public static void SendInvitation()
		{
			List<string> list = DBManager.TehranCorporations();
			//List<string> list = new List<string>();
			//list.Add("63199862");
			foreach (string str in list)
			{
				Controller.SendMessage(str, CONSTANTS.InvitationQuote, CONSTANTS.Markdown, true, 0, null);
				Controller.SendPhoto(str, CONSTANTS.SendGiftAlbumPhotoPath, 1, CONSTANTS.PictureCaption, 0, null);				
			}
		}

	}
}
