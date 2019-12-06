using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ImagePicker.Services.AzureServices
{
    public class AzureCompVisionProj
    {
        public async Task<string> ConvertImage(string localImage)
        {
            var endpoint = "";
            try
            {
                var bytes = File.ReadAllBytes(localImage);
                var requestBody = JsonConvert.SerializeObject(bytes);

                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage())
                {
                    // Build the request.
                    // Set the method to Post.
                    request.Method = HttpMethod.Post;
                    // Construct the URI and add headers.
                    request.RequestUri = new Uri(endpoint);
                    request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                    //request.Headers.Add("Ocp-Apim-Subscription-Key", key_var);

                    HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);

                    string result = await response.Content.ReadAsStringAsync();
                    StringBuilder sb = new StringBuilder();
                    var deserializedOutput = JsonConvert.DeserializeObject<string>(result);
                    foreach (var number in deserializedOutput)
                    {
                        sb.Append(number);
                    }
                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
