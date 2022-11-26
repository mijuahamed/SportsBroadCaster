using Newtonsoft.Json;

namespace BroadcasterApi.ViewModel.Football
{
    public class Football
    {
        [JsonProperty("title")]
        public string title { get; set; }
        [JsonProperty("embed")]
        public string embed { get; set; }
        [JsonProperty("date")]
        public string date { get; set; }
        [JsonProperty("competition")]
        public Competition Competition { set; get; }
    }
   
}
public class Competition
{
    [JsonProperty("name")]
    public string Name { set; get; }
}

/*competition
name: "WORLD CUP: Group F"
id: 980
url: "https://www.scorebat.com/world-cup-group-f-live-scores/"
*/
