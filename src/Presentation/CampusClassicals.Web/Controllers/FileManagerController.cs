using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using CampusClassicals.Core.Extensions;
using System.Text;
using CampusClassicals.Domain;
using CampusClassicals.Core.Data;
using Microsoft.AspNetCore.Authorization;

namespace CampusClassicals.Web.Controllers
{
    [Authorize]
    public class FileManagerController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;
        private readonly IRepository<Gallery> _galleryDb;
        private readonly IRepository<Media> _mediaDb;

        public FileManagerController(IHostingEnvironment hostingEnvironment, IRepository<Media> mediaDb, IRepository<Gallery> galleryDb)
        {
            _mediaDb = mediaDb;
            _galleryDb = galleryDb;
            _hostingEnvironment = hostingEnvironment;
        }

        #region Utility methods

        private void CreateDirectoryIfNotExist(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private string InvalidFile(decimal uploadedFileSize, string fileExtension, decimal maximumFileSizeInKb)
        {
            string message = null;

            try
            {
                decimal oneKiloByte = 1024;
                decimal maximumFileSize = maximumFileSizeInKb * oneKiloByte;

                decimal actualFileSizeToUpload = Math.Round(uploadedFileSize / oneKiloByte, 1);
                if (InvalidFileType(fileExtension))
                {
                    message = "File type '" + fileExtension + "' is invalid! File type must be any of the following: .jpg, .jpeg, .png or .jif ";
                }
                else if (actualFileSizeToUpload > (maximumFileSize / oneKiloByte))
                {
                    message = "Your file size of " + actualFileSizeToUpload.ToString("0.#") + " Kb is too large, maximum allowed size is " + (maximumFileSize / oneKiloByte) + " Kb";
                }

                return message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private bool InvalidFileType(string extension)
        {
            try
            {
                
                extension = extension.ToLower();
                switch (extension)
                {
                    case ".jpg":
                    case ".png":
                    case ".gif":
                    case ".jpeg":
                    case ".mp3":
                    case ".mp4":
                        return false;

                    default:
                        return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private string GetDirectoryPath()
        {
            //Microsoft.AspNetCore.Routing.RouteValueDictionary rvd = RouteData.Values;
            //var d = rvd["m"];

            //var u = User;

            return _hostingEnvironment.WebRootPath + "\\Uploads"; 
        }

        private string GetFilePath(string filename)
        {
            return GetDirectoryPath() + "\\" + filename;
        }

        private string GetFileExtension(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            return fileInfo.Extension;
        }

        private string ConvertToString(Dictionary<string, string> messageList)
        {
            StringBuilder messages = new StringBuilder();
            foreach(KeyValuePair<string, string> message in messageList)
            {
                messages.Append(message.Key + ": " + message.Value + "\n\n");
            }

            return messages.ToString();
        }

        private string BuildResponseMessage(int noOfFilesUploaded, long fileZise, string filesUploaded, string errorMessage, Dictionary<string, string> filesWithError)
        {
            string message = "";

            if (errorMessage.IsEmpty())
            {
                message = $"Upload successful!\nFiles uploaded: {noOfFilesUploaded}\nTotal size: {fileZise}\n{filesUploaded}";
            }
            else
            {
                if (noOfFilesUploaded > 0)
                {
                    message = $"The following files uploaded successfully!\nFiles uploaded: {noOfFilesUploaded}\nTotal size: {fileZise}\n{filesUploaded}\n\n";
                }

                message += $"The following files could not be uploaded!\nFiles: {ConvertToString(filesWithError)}";
            }

            return message;
        }

        #endregion

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            List<int> mediaIds = await _galleryDb.GetAllIdsAsync(x => x.OrderByDescending(g => g.DisplayOrder));
            return View(mediaIds);
        }

        [AllowAnonymous]
        public async Task<FileContentResult> GetMedia(int id)
        {
            Gallery gallery = await _galleryDb.GetSingleByAsync(x => x.Id == id, includeProperties: "Media");
            return File(gallery.Media.File, gallery.MimeType);
            
            //return File(gallery.Media.File, gallery.Media.MimeType);
        }

        //[AllowAnonymous]
        //public async Task<List<FileContentResult>> GetMediaList()
        //{
        //    List<Media> medias = await _mediaDb.GetAllAsync();

        //    List<FileContentResult> files = new List<FileContentResult>();
        //    foreach (Media media in medias)
        //    {
        //        FileContentResult file = File(media.File, media.MimeType);
        //        files.Add(file);
        //    }

        //    return files;
        //}

        //[AllowAnonymous]
        public IActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        //[AllowAnonymous]
        public async Task<IActionResult> UploadFileAsync()
        {
            int counter = 0;
            long fileZise = 0;
            string errorMessage = "";
            string filesUploaded = "";
            string directory = GetDirectoryPath();
            Dictionary<string, string> uploadsWithError = new Dictionary<string, string>();

            CreateDirectoryIfNotExist(directory);

            foreach (IFormFile file in Request.Form.Files)
            {
                //file.OpenReadStream();

                string fileExtension = GetFileExtension(file);
                string invalidErrorMessage = InvalidFile(file.Length, fileExtension, 25000);
                if (invalidErrorMessage.HasValue())
                {
                    uploadsWithError.Add(file.FileName, invalidErrorMessage);
                    errorMessage += $"{invalidErrorMessage}\n";
                    continue;
                }

                try
                {
                    byte[] bytes = new byte[file.Length];
                    Stream stream = file.OpenReadStream();
                    await stream.ReadAsync(bytes, 0, Convert.ToInt32(file.Length));

                    Media media = new Media() { File = bytes };

                    Gallery gallery = new Gallery();
                    gallery.Media = media;
                    gallery.CreatedBy = "28c78bf4-a657-45b2-a419-a790b6050156";
                    gallery.CreatedOn = DateTime.UtcNow;
                    gallery.Published = true;
                    gallery.DisplayOrder = 0;
                    gallery.Title = "Testing!";
                    gallery.Short = "Testing short description.";
                    gallery.MimeType = file.ContentType;

                    _galleryDb.Add(gallery);
                    
                    fileZise += file.Length;
                    filesUploaded += "\n" + file.FileName;
                    ++counter;
                }
                catch (Exception)
                {
                    throw;
                }
            }

            string message = BuildResponseMessage(counter, fileZise, filesUploaded, errorMessage, uploadsWithError);

            return Json(message);
        }



        //[HttpPost]
        //public async Task<IActionResult> UploadFileAsync()
        //{
        //    int counter = 0;
        //    long fileZise = 0;
        //    string errorMessage = "";
        //    string filesUploaded = "";
        //    string directory = GetDirectoryPath();
        //    Dictionary<string, string> uploadsWithError = new Dictionary<string, string>();

        //    CreateDirectoryIfNotExist(directory);

        //    foreach (IFormFile file in Request.Form.Files)
        //    {
        //        string fileExtension = GetFileExtension(file);

        //        file.OpenReadStream();

        //        string invalidErrorMessage = InvalidFile(file.Length, fileExtension, 100);
        //        if (invalidErrorMessage.HasValue())
        //        {
        //            uploadsWithError.Add(file.FileName, invalidErrorMessage);
        //            errorMessage += $"{invalidErrorMessage}\n";
        //            continue;
        //        }

        //        try
        //        {
        //            fileZise += file.Length;
        //            filesUploaded += "\n" + file.FileName;

        //            string fileName = GetFilePath(file.FileName);
        //            using (FileStream stream = new FileStream(fileName, FileMode.Create))
        //            {
        //                await file.CopyToAsync(stream);
        //                ++counter;
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //    }

        //    string message = BuildResponseMessage(counter, fileZise, filesUploaded, errorMessage, uploadsWithError);

        //    return Json(message);
        //}









        //[HttpPost]
        //public async Task<IActionResult> UploadFile(IList<IFormFile> files)
        //{
        //    foreach (IFormFile source in files)
        //    {
        //        string filename = ContentDispositionHeaderValue.Parse(source.ContentDisposition).FileName.Trim('"');

        //        filename = this.EnsureCorrectFilename(filename);

        //        using (FileStream output = System.IO.File.Create(GetPathAndFilename(filename)))
        //        {
        //            await source.CopyToAsync(output);
        //        }
        //    }

        //    return View();
        //}



        //private string EnsureCorrectFilename(string filename)
        //{
        //    if (filename.Contains("\\"))
        //        filename = filename.Substring(filename.LastIndexOf("\\") + 1);

        //    return filename;
        //}








    }
}
