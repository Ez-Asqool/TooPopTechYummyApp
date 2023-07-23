using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YummyApp.app.Services.FileUploadService
{
    public class ImageService
    {
        public static string uploadImage(string FolderName, IFormFile  Image, IWebHostEnvironment _hostingEnvironment)
        {
            var uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, FolderName);
            var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
            var filePath = Path.Combine(uploadFolder, uniqueName);
            // {serverlocation}\EventImages\0f8fad5b-d9cb-469f-a165-70867728950e.jpg

            FileStream fileStream = new FileStream(filePath, FileMode.Create);
            Image.CopyTo(fileStream);
            fileStream.Close();
            return uniqueName;
        }


        public static void deleteImage(string FolderName, string OldFileName, IWebHostEnvironment _hostingEnvironment)
        {
            var uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, FolderName);

            //Delete Old File
            string fulloldpath = Path.Combine(uploadFolder, OldFileName);
            System.IO.File.Delete(fulloldpath);
        }

        public static string updateImage(string FolderName, IFormFile Image, string OldFileName, IWebHostEnvironment _hostingEnvironment)
        {
            var uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, FolderName);
            var uniqueName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
            var filePath = Path.Combine(uploadFolder, uniqueName);
            // {serverlocation}\Images\0f8fad5b-d9cb-469f-a165-70867728950e.jpg

            //Delete Old File
            string fulloldpath = Path.Combine(uploadFolder, OldFileName);
            System.IO.File.Delete(fulloldpath);
            //System.IO.File.Move(sourse,destination);

            //Save New File
            FileStream fileStream = new FileStream(filePath, FileMode.Create);
            Image.CopyTo(fileStream);
            fileStream.Close();

            return uniqueName;

        }

    }
}
