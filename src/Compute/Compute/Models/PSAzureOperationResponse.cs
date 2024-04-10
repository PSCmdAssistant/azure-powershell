csharp
using System.Net;

namespace Microsoft.Azure.Commands.Compute.Models
{
    public class PSAzureOperationResponse
    {
        public string RequestId { get; set; }

        public bool IsSuccessStatusCode { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string ReasonPhrase { get; set; }
    }
}
