using System.Net;
using System.Xml;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serialization.Json;

namespace RestSharpApi
{
    public class JsonApi
    {       
        public RestClient restClient;
        public RestRequest restRequest;

        public HttpStatusCode restStatusCode;
        public string restStatusDescription;

        public string encoding;
        public string jsonVersion;
        
                       
        public string jsonEndPoint;
        public string jsonEndPointDnsSafeHost;

        public string jsonActionUri = null;
        public string jsonActionName = null;
        public string jsonQualActionUri = null;
        
        public int contentLength = 0;

        //=================================================================================
        //=================================================================================
        public JsonApi(string apiEndPoint)
        {
            jsonEndPoint = apiEndPoint;
            jsonEndPointDnsSafeHost = new Uri(jsonEndPoint).DnsSafeHost;
        }


        //=================================================================================
        /// <summary>
        /// //      
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="apiVerb"></param>
        /// <param name="qualAction"></param>
        /// <param name="dctParams"></param>
        /// <returns></returns>
        public T GetServiceResponse<T>(string apiVerb, string qualAction, Dictionary<string, string> dctParams)
        {
            IRestResponse restResponse = GetWebResponse(apiVerb, qualAction, dctParams);

            restStatusCode = restResponse.StatusCode;
            restStatusDescription = restResponse.StatusDescription;

            var apiResponse = restResponse.Content; // raw content as string
            var obDeserializer = new JsonDeserializer();

            // ================================================================
            // if the response to be returned as Deserialized JSON
            // ================================================================
            if (typeof(T) == typeof(Dictionary<string, string>))
            {
                var rtnObject = obDeserializer.Deserialize<Dictionary<string, string>>(restResponse);
                return (T)Convert.ChangeType(rtnObject, typeof(T));
            }

            // ================================================================
            // if the response to be returned as XmlDocument
            // ================================================================
            if (typeof(T) == typeof(XmlDocument))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(apiResponse);
                return (T)Convert.ChangeType(xmlDoc, typeof(T));
            }

            // ================================================================
            // else if the response to be returned as JObject
            // ================================================================
            if (typeof(T) == typeof(JObject))
            {
                JObject jobject = JObject.Parse(apiResponse);
                //JObject jobject = JsonConvert.DeserializeObject<JObject>(apiResponse);
                return (T)Convert.ChangeType(jobject, typeof(T));
            }

            // ================================================================
            // else if the response to be returned as JObject
            // ================================================================
            if (typeof(T) == typeof(JArray))
            {
                JArray jobject = JArray.Parse(apiResponse);
                return (T)Convert.ChangeType(jobject, typeof(T));
            }

            // ================================================================
            // by default response will be returned as a string
            // ================================================================
            return (T)Convert.ChangeType(apiResponse, typeof(T));

        }// GetServiceResponse

        //=================================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="qualAction"></param>
        /// <param name="apiVerb"></param>
        /// <param name="dctParams"></param>
        /// <returns></returns>
        private IRestResponse GetWebResponse(string apiVerb, string qualAction, Dictionary<string, string> dctParams)
        {
            // *****************************************************************************
            //      Set the class props derived from the qual action name provided 
            // *****************************************************************************            
            Uri baseUri = new Uri(jsonEndPoint);
            jsonQualActionUri = new Uri(baseUri, qualAction).ToString();

            jsonActionUri = new Uri(jsonQualActionUri).GetLeftPart(UriPartial.Authority);
            var arrTmp = new Uri(jsonQualActionUri).Segments.ToArray();
            jsonActionName = arrTmp.Last();
            // *****************************************************************************            

            CreateHttpWebRequest(apiVerb, dctParams);

            var response = restClient.Execute(restRequest);

            return response;
        }// GetWebResponse

        //=================================================================================        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="apiVerb"></param>
        private void CreateHttpWebRequest(string apiVerb, Dictionary<string, string> dctParams)
        {
            restClient = new RestClient(jsonQualActionUri);
            restRequest = new RestRequest();
            restRequest.Parameters.Clear();
            restRequest.RequestFormat = DataFormat.Json;
            restRequest.Method = GetRestMethodType(apiVerb);

            foreach (string paramKey in dctParams.Keys)
                restRequest.AddParameter(paramKey, dctParams[paramKey]);

        }// fCeateHttpWebRequest

        //=================================================================================
        ///
        private static Method GetRestMethodType(string apiVerb)
        {
            Method rtnValue = Method.GET;
            switch (apiVerb.ToLower())
            {
                case "get":
                    rtnValue = Method.GET;
                    break;
                case "put":
                    rtnValue = Method.PUT;
                    break;
                case "post":
                    rtnValue = Method.POST;
                    break;
                case "delete":
                    rtnValue = Method.DELETE;
                    break;
                case "options":
                    rtnValue = Method.OPTIONS;
                    break;

                case "copy":
                    rtnValue = Method.COPY;
                    break;
                case "head":
                    rtnValue = Method.HEAD;
                    break;
                case "merge":
                    rtnValue = Method.MERGE;
                    break;
                case "patch":
                    rtnValue = Method.PATCH;
                    break;
            }

            return rtnValue;
        }//GetRestMethodType

    }//class
}//namespace

