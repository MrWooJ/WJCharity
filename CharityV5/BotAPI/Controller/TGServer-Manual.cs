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
using TGEventHandler;

public enum KEYBOARDTYPE
{
	REPLAYKEYBOARDMARKUP = 1,
	REPLAYKEYBOARDHIDE = 2,
	FORCEREPLAY = 3
}

namespace TGServer
{
	public class TGServer
	{
		public static string apiToken 	= "214009380:AAFbJf3NaHKRZyKVW3qC6QLDDB4ivTlyveM";
		public static string baseURL	= "https://api.telegram.org/bot";

		public static void Main(string[] args)
		{
			if (args.Length < 1)
			{
				Console.WriteLine("Error in Input Arguments! " + args.Length + " are Entered!");
				System.Environment.Exit(1);
			}

			CONSTANTS.TempFilePath = args[0] + CONSTANTS.TempFilePath;
			CONSTANTS.ToysProgramAlbumPhotoPath = args[0] + CONSTANTS.ToysProgramAlbumPhotoPath;
			CONSTANTS.HealthCareProgramAlbumPhotoPath = args[0] + CONSTANTS.HealthCareProgramAlbumPhotoPath;
			CONSTANTS.OtherProgramAlbumPhotoPath = args[0] + CONSTANTS.OtherProgramAlbumPhotoPath;
			CONSTANTS.SendGiftAlbumPhotoPath = args[0] + CONSTANTS.SendGiftAlbumPhotoPath;
			
			//TGEventHandlerClass.SendInvitation();
			GetUpdatesManually();
		}

		public static void GetUpdatesResponseHandler(RESPONSEUPDATE res)
		{
			TGEventHandlerClass.HandleResponse(res);
		}

		public static void GetUpdatesManually()
		{
			while (true)
			{
				WebRequest req = null;
				try
				{
					string lastOffset = FileManager.ReadFromTempFile(CONSTANTS.TempFilePath);
					if (lastOffset.Length == 0)
					{
						req = WebRequest.Create(baseURL + apiToken + "/getUpdates");
					}

					else
					{
						decimal decimalVal = 0;
						decimalVal = System.Convert.ToDecimal(lastOffset) + 1;
						string offset = decimalVal.ToString();
						req = WebRequest.Create(baseURL + apiToken + "/getUpdates?offset=" + offset);
					}

					req.UseDefaultCredentials = true;

					var result = req.GetResponse();
					Stream stream = result.GetResponseStream();
					StreamReader reader = new StreamReader(stream);

					RESPONSEUPDATE res = JsonConvert.DeserializeObject<RESPONSEUPDATE>(reader.ReadToEnd());

					GetUpdatesResponseHandler(res);

					req.Abort();
				}
				catch (WebException wex) {
					if (wex.Response != null) {
						using (var errorResponse = (HttpWebResponse)wex.Response) {
							using (var reader = new StreamReader(errorResponse.GetResponseStream())) {
								string error = reader.ReadToEnd();
								Console.WriteLine("URL RESP: " + error);
							}
						}
					}
				}
				catch (Exception ex)
				{
					//Console.WriteLine("Error Getting Updates " + ex.ToString());
					req.Abort();
				} 
				finally
				{
					req.Abort();
				}
			}
		}
	}
}
