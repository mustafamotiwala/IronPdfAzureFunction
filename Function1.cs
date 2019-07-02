using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace IronPdfAzureFunctionDemo
{
    public static class Function1
    {
        [FunctionName("DownloadPdf")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var pdfDocument = IronPdf.HtmlToPdf.StaticRenderHtmlAsPdf("<h1>Hello World!</h1>");
            return new FileContentResult(pdfDocument.BinaryData, "application/pdf")
            {
                FileDownloadName = "sample-report.pdf"
            };
        }
    }
}
