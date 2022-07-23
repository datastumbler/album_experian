using System.Collections.Generic;

namespace AlbumPhotoAPI.Models
{
    public class AlbumPhoto
    {
        public AlbumPhoto()
        {
            Photos = new List<Photo>();
        }

        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public List<Photo> Photos { get; set; }
    }

}
