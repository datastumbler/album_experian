namespace AlbumPhotoAPI.Models
{
    public class Photo
    {
        public Photo(int AlbumID, int ID, string Title, string Url, string ThumbnailUrl)
        {
            albumId = AlbumID;
            id = ID;    
            title = Title;
            url = Url;
            thumbnailUrl = ThumbnailUrl;
        }

        public int albumId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }
    }
}