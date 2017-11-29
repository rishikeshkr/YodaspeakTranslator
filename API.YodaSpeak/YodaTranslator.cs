using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace API.YodaSpeak
{
    public static class YodaTranslator
    {
        public static string YodaSpeak(string inputString)
        {
            string result = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(inputString))
                {
                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(YodaSpeakRes.YodaSpeakEndPointURL);
                    client.DefaultRequestHeaders.Add(YodaSpeakRes.MashapeKey,YodaSpeakRes.YodaSpeakAPI);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(YodaSpeakRes.EnpointHeader));
                    HttpResponseMessage response = client.GetAsync(YodaSpeakRes.MashapeParam + inputString.ToString()).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var clientresult = response.Content.ReadAsStringAsync().Result;
                        return result = clientresult;
                    }
                    else
                    {
                        return result;
                    }

                }
                else
                {
                    return result;
                }

            }
            catch (Exception ex)
            {
                return result;
            }
        }
    }
}
