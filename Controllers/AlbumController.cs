using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace AlbumPhotoAPI.Controllers
{

    [ApiController]

    [Route("[controller]/getalbum")]
    public class getalbum : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            // Data Source
            string endpointAlbum = "http://jsonplaceholder.typicode.com/albums";
            string endpointPhotos = "https://jsonplaceholder.typicode.com/photos";

            // Get data
            string albumData = Helpers.Data.GetData(endpointAlbum);
            string photoData = Helpers.Data.GetData(endpointPhotos);

            // Load into objects
            var albumList = JsonSerializer.Deserialize<IList<Models.Album>>(albumData);
            var photoList = JsonSerializer.Deserialize<IList<Models.Photo>>(photoData);
            List<Models.AlbumPhoto> albumPhotoList = new List<Models.AlbumPhoto>();

            // Merge
            foreach (Models.Album album in albumList)
            {
                Models.AlbumPhoto albumPhoto = new Models.AlbumPhoto();

                albumPhoto.id = album.id;
                albumPhoto.userId = album.userId;
                albumPhoto.title = album.title;

                // Get photos for album
                var albumPhotos = from photo in photoList where photo.albumId == album.id select new { AlbumID = photo.albumId, ID = photo.id, Title = photo.title, ThumbnailURL = photo.thumbnailUrl, URL = photo.url };

                foreach (var photo in albumPhotos)
                {
                    Models.Photo photograph = new Models.Photo(photo.AlbumID, photo.ID, photo.Title, photo.URL, photo.ThumbnailURL);
                    albumPhoto.Photos.Add(photograph); 
                }

                albumPhotoList.Add(albumPhoto);
            }

            // Deserialize
            return JsonSerializer.Serialize(albumPhotoList);
        }
    }

    [ApiController]

    [Route("[controller]/getalbum/{id}")]
    public class getalbumbyid : ControllerBase
    {
        [HttpGet]
        public string Get(string id)
        {
            // Data Source
            string endpointAlbum = string.Format("http://jsonplaceholder.typicode.com/albums/{0}",id);
            string endpointPhotos = "https://jsonplaceholder.typicode.com/photos";

            // Get data
            string albumData = Helpers.Data.GetData(endpointAlbum);
            string photoData = Helpers.Data.GetData(endpointPhotos);

            // Load into objects
            var album = JsonSerializer.Deserialize<Models.Album>(albumData);
            var photoList = JsonSerializer.Deserialize<IList<Models.Photo>>(photoData);
            List<Models.AlbumPhoto> albumPhotoList = new List<Models.AlbumPhoto>();

            // Merge
            Models.AlbumPhoto albumPhoto = new Models.AlbumPhoto();

            albumPhoto.id = album.id;
            albumPhoto.userId = album.userId;
            albumPhoto.title = album.title;

            // Get photos for album
            var albumPhotos = from photo in photoList where photo.albumId == album.id select new { AlbumID = photo.albumId, ID = photo.id, Title = photo.title, ThumbnailURL = photo.thumbnailUrl, URL = photo.url };

            foreach (var photo in albumPhotos)
            {
                Models.Photo photograph = new Models.Photo(photo.AlbumID, photo.ID, photo.Title, photo.URL, photo.ThumbnailURL);
                albumPhoto.Photos.Add(photograph);
            }

                albumPhotoList.Add(albumPhoto);

            // Deserialize
            return JsonSerializer.Serialize(albumPhotoList);
        }
    }
}
