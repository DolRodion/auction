namespace Auction.Application.Common.Responces
{
    public class Response : IResponse
    {
        public Response()
        {
            IsSuccess = true;
        }

        public Response(string errors)
        {
            IsSuccess = false;
            Errors = errors;
        }

        /// <inheritdoc/>
        public string Errors { get; set; } = string.Empty;

        /// <inheritdoc/>
        public bool IsSuccess { get; set; }
    }
}
