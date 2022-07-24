using System.Net.Http;
using System.Net;

namespace AlbumPhotoAPI.Helpers
{
    public class Data : IData
    {
        public Data()
        {
        }

        public string GetData(string url)
        {

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