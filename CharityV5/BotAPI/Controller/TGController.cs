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
using TGFileManager;
using TGServerFileUploader;

namespace TGController
{
	public class Controller
	{
		public static string apiToken 	= "214009380:AAFbJf3NaHKRZyKVW3qC6QLDDB4ivTlyveM";
		public static string baseURL	= "https://api.telegram.org/bot";

		public static void FillBotAPI(string baseURL, string apiToken)
		{
			apiToken = apiToken;
			baseURL = baseURL;
		}

		public static void GetMe()
		{
			WebRequest req = WebRequest.Create(baseURL + apiToken + "/getMe");
			req.UseDefaultCredentials = true;

			var result = req.GetResponse();
			req.Abort();
		}

		public static void SendMessage(string chat_id, string text, string parse_mode, bool disable_web_page_preview, int reply_to_message_id, string reply_markup)
		{
			string query = "/sendMessage?";
			if(!string.IsNullOrEmpty(chat_id))
			query = query + "chat_id=" + chat_id + "&";
			if(!string.IsNullOrEmpty(text))
			query = query + "text=" + text + "&";
			if(!string.IsNullOrEmpty(parse_mode))
			query = query + "parse_mode=" + parse_mode + "&";
			if(!string.IsNullOrEmpty(parse_mode))
			query = query + "reply_markup=" + reply_markup + "&";

			if(reply_to_message_id != 0)
			query = query + "reply_to_message_id=" + reply_to_message_id + "&";
			query = query + "disable_web_page_preview=" + disable_web_page_preview + "&";
			query = query.Remove(query.Length - 1);

			WebRequest req = null;
			try
			{
				req = WebRequest.Create(baseURL + apiToken + query);
				req.UseDefaultCredentials = true;

				var result = req.GetResponse();
				req.Abort();
			}
			catch (WebException wex) {
				if (wex.Response != null) {
					using (var errorResponse = (HttpWebResponse)wex.Response) {
						using (var reader = new StreamReader(errorResponse.GetResponseStream())) {
							string error = reader.ReadToEnd();
							Console.WriteLine("ErrorInSendMessage: " + error);
						}
					}
				}
				if (req != null)
				{
					req.Abort();
					req = null;
				}
			}
			catch(Exception ex) 
			{
				Console.WriteLine("ErrorInSendMessage: " + ex);
				if (req != null)
				{
					req.Abort();
					req = null;
				}
			}
			finally 
			{
				req = null;
			}
		}

		public static void ForwardMessage(string chat_id, string from_chat_id, string message_id)
		{
			string query = "/forwardMessage?";
			if(!string.IsNullOrEmpty(chat_id))
			query = query + "chat_id=" + chat_id + "&";
			if(!string.IsNullOrEmpty(from_chat_id))
			query = query + "from_chat_id=" + from_chat_id + "&";
			if(!string.IsNullOrEmpty(message_id))
			query = query + "message_id=" + message_id + "&";
			query = query.Remove(query.Length - 1);

			WebRequest req = WebRequest.Create(baseURL + apiToken + query);
			req.UseDefaultCredentials = true;

			var result = req.GetResponse();
			req.Abort();
		}

		public static void SendPhoto(string chat_id, string album_path, int numberOfPhotos, string caption, int reply_to_message_id, string reply_markup)
		{
			NameValueCollection nvc = new NameValueCollection();
			string query = "/sendPhoto?";

			if(!string.IsNullOrEmpty(chat_id))
			nvc.Add("chat_id", chat_id);
			if(!string.IsNullOrEmpty(caption))
			nvc.Add("caption", caption);
			if(!string.IsNullOrEmpty(reply_markup))
			nvc.Add("reply_markup", reply_markup);

			if(reply_to_message_id != 0)
			nvc.Add("reply_to_message_id", reply_to_message_id.ToString());
			
			string randomPicPath = album_path + "1.jpg";;
			if (numberOfPhotos != 1)
			{
				Random rnd = new Random();
				int num = rnd.Next(1, numberOfPhotos);
				randomPicPath = album_path + num.ToString() + ".jpg";
			}

			TGServerFileUploaderClass.HttpUploadFile(baseURL + apiToken + query, randomPicPath, "photo", "multipart/form-data", nvc);
		}

	}
}
