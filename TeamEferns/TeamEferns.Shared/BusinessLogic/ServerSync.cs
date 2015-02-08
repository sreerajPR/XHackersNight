using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using Tasky.BL.Managers;
using Newtonsoft.Json.Linq;


namespace TeamEferns.Shared
{
	public class ServerSync
	{
		public ServerSync ()
		{
		}
		public async static void SyncCategories()
		{
			var Uri = new Uri ("https://api.meetup.com/2/categories?key="+MeetupAPI.APIKEY+"&sign=true");
			HttpWebRequest request= new HttpWebRequest(Uri);
			request.Method="GET";
			var response = await request.GetResponseAsync ();
			using (StreamReader reader = new StreamReader (response.GetResponseStream ())) {
				var content = reader.ReadToEnd ();
				if (!string.IsNullOrWhiteSpace (content)) {
					JObject o = JObject.Parse(content);
					var JsonResult= o["results"].ToString();
					var categoryList = JsonConvert.DeserializeObject<List<CategoryViewModel>> (JsonResult);
					foreach (var item in categoryList) {
						Manager.SaveCategory (new Categories (){ 
							ServerID=item.id,
							Name=item.name,
							ShortName=item.shortname
						});
					}
				}
			}
		}
	}
}

