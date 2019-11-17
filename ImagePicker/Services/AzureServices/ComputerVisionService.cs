using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

namespace ImagePicker.Services.AzureServices
{
    public class ComputerVisionService : IComputerVisionService
    {
        public static readonly string _cvEndpoint = "";
        public static readonly string _cvKey = "";

        public static ComputerVisionClient GetCVClient()
        {
            ComputerVisionClient client = new ComputerVisionClient
               (new ApiKeyServiceClientCredentials(_cvKey))
            { Endpoint = _cvEndpoint };

             return client;
        }

        public static async Task<string> ExtractUrlLocal(ComputerVisionClient client, string localImage)
        {

            const int numberOfCharsInOperationId = 36;
            using (Stream imageStream = File.OpenRead(localImage))
            {
                BatchReadFileInStreamHeaders localFileTextHeaders = await client.BatchReadFileInStreamAsync(imageStream);
                string operationLocation = localFileTextHeaders.OperationLocation;
                string operationId = operationLocation.Substring
                    (operationLocation.Length - numberOfCharsInOperationId);
                int i = 0;
                int maxRetries = 10;
                ReadOperationResult results;
                do
                {
                    results = await client.GetReadOperationResultAsync(operationId);
                    await Task.Delay(1000);
                }
                while ((results.Status == TextOperationStatusCodes.Running ||
                results.Status == TextOperationStatusCodes.NotStarted) && i++ < maxRetries);
                StringBuilder sb = new StringBuilder();
                var recognitionResults = results.RecognitionResults;
                foreach (TextRecognitionResult result in recognitionResults)
                {
                    foreach (Line line in result.Lines)
                    {
                        sb.Append(line.Text);
                    }
                }
                return sb.ToString();
            }
        }
    }
}
