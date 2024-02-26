namespace BooksApi.Core.Shared
{
    public class AuthWithTokensModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}