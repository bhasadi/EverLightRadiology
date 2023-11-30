using Newtonsoft.Json;

namespace EverLightApi
{
    public class OrdersApiMain
    {
        [JsonProperty("id")]
        public required string id;

        [JsonProperty("accessionNumber")]
        public required string accessionNumber;

        [JsonProperty("orgCode")]
        public required string orgCode;

        [JsonProperty("siteName")]
        public required string siteName;

        [JsonProperty("patientMrn")]
        public required string patientMrn;

        [JsonProperty("patientName")]
        public required string patientName;

        [JsonProperty("modality")]
        public required string modality;

        [JsonProperty("status")]
        public required string status;


    }//class
}//namespace
