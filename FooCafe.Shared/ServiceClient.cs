using System;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace FooCafe.Shared
{
	public class ServiceClient<T> where T : class
	{
		public ServiceClient (string url)
		{ 
			_url = url; 
		}

		private readonly string _url;

		public async Task<T> GetResult ()
		{ 
			var response = await MakeAsyncRequest (_url); 
			var result = JsonConvert.DeserializeObject<T> (response); 
			return result; 
		}

		public static Task<string> MakeAsyncRequest (string url)
		{ 
			var request = (HttpWebRequest)WebRequest.Create (url); 
			request.ContentType = "application/json"; 
			Task<WebResponse> task = Task.Factory.FromAsync (
				                                     request.BeginGetResponse, 
				                                     asyncResult => request.EndGetResponse (asyncResult), 
				                                     null); 
			return task.ContinueWith (t => ReadStreamFromResponse (t.Result)); 
		}

		private static string ReadStreamFromResponse (WebResponse response)
		{ 
			using (var responseStream = response.GetResponseStream ())
			using (var reader = new StreamReader (responseStream)) { 
				var content = reader.ReadToEnd (); 
				return content; 
			} 
		}
	}
}

