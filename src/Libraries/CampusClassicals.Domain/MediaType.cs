using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusClassicals.Domain
{
    //public class MediaType : BaseEntity
    //{
    //    public string Name { get; set; }
    //    public string Description { get; set; }
    //}

    public class MediaType 
    {
        public const string JPEG = "image/jpeg";
        public const string JPG = "image/jpg";
        public const string PNG = "image/png";
        public const string GIF = "image/gif";

        public const string MP3 = "audio/mp3";
        public const string MP4 = "video/mp4";

        public const string YOUTUBE = "video/youtube";
    }



}
