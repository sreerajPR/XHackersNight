using System;
using Xamarin.Auth;
using System.Net;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace TeamEferns.Shared
{
	public class MeetupAPI
	{
		public static string APIKEY ="355e1d1b4d205f20173611562c7f1c34";
		public static async Task<List<EventViewModel> >GetJson(List<int> IDs,string lat, string lon)
		{
			string IdList = "";
			foreach(var item in IDs)
				IdList+=item+",";
			IdList=IdList.TrimEnd (',');
			var eventViewModelList = new List<EventViewModel> ();
			var Uri = new Uri ("https://api.meetup.com/2/open_events?key="+MeetupAPI.APIKEY+"&sign=true&category="+IdList+"&time=,1w&lat="+lat+"&lon="+lon+"&radius=100");
			HttpWebRequest request= new HttpWebRequest(Uri);
			request.Method="GET";
			var response = await request.GetResponseAsync ();
			using (StreamReader reader = new StreamReader (response.GetResponseStream ())) {
				var content = reader.ReadToEnd ();
				if (!string.IsNullOrWhiteSpace (content)) {
					JObject o = JObject.Parse(content);
					var JsonResult= o["results"].ToString();
					var eventList = JsonConvert.DeserializeObject<List<JObject>> (JsonResult);
					foreach (var item in eventList) {
						var eventViewModel = new EventViewModel ();
						eventViewModel.EventLocation = "";
						if (item ["name"] != null) {
							eventViewModel.EventName = item ["name"].ToString ();
						}
						if (item ["time"] != null) {
							eventViewModel.EventDate = TimeSpan.FromMilliseconds(double.Parse(item ["time"].ToString ())).ToString();
						}
						if (item ["venue"] != null) {
							JObject venue= JObject.Parse(item ["venue"].ToString ());
							if (venue ["address_1"] != null) {
								eventViewModel.EventLocation += venue ["address_1"].ToString ()+" , ";
							}
							if (venue ["city"] != null) {
								eventViewModel.EventLocation += venue ["city"].ToString ()+" , ";
							}
							if (venue ["country"] != null) {
								eventViewModel.EventLocation += venue ["country"].ToString ();
							}
						}

						eventViewModelList.Add (eventViewModel);
					}
				}
			}
			return eventViewModelList;
		}
	}
}

