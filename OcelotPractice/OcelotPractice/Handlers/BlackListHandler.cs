namespace OcelotPractice.Handlers
{
    /// <summary>
    /// Create a kind of filter for requests
    /// </summary>
    public class BlackListHandler : DelegatingHandler
    {
        /// <summary>
        /// Validates that the request has a particular header to return the information.
        /// </summary>
        /// <param name="request"><see cref="HttpRequestMessage"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns></returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {

            var myHeader = request.Headers.FirstOrDefault(c => c.Key == "MyHeader");
            if (myHeader.Value != null && myHeader.Value.Any()) {
                return await base.SendAsync(request, cancellationToken);
            }

            var response = new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
            response.ReasonPhrase = "Your header is not valid";
            return await Task.FromResult<HttpResponseMessage>(response);
        }
    }
}
