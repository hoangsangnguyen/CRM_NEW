namespace Vino.Shared.Dto.Common
{
    public class TokenResponse
    {

        /// <summary>
        /// minutes
        /// </summary>
        public int ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
        public bool IsError { get; set; }
        public string AccessToken { get; set; }
    }

}