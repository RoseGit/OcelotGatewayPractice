namespace OcelotPractice.Handlers
{
    /// <summary>
    /// Allows you to configure the response of the services.
    /// </summary>
    public class RemoveEncodingDelegatingHandler : DelegatingHandler
    {
        /// <summary>
        /// Add a header to properly code an aggregator.
        /// </summary>
        /// <param name="request"><see cref="HttpRequestMessage"/></param>
        /// <param name="cancellationToken"><see cref="CancellationToken"/></param>
        /// <returns><see cref="HttpResponseMessage"/></returns>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.AcceptEncoding.Clear();
            return await base.SendAsync(request, cancellationToken);
        }

    }
}
