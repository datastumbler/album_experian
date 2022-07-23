using System.Net.Http;
using System.Net;

namespace AlbumPhotoAPI.Helpers
{
    public static class Data
    {
        public static string GetData(string url)
        {
            var httpClient = new HttpClient();

            try
            {
                return new WebClient().DownloadString(url);
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }
    }
}