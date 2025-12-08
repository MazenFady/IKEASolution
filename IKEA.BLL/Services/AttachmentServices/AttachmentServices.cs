using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.AttachmentServices
{
    public class AttachmentServices : IAttachmentServices
    {   private readonly List<string> AllowedExtensions = new List<string>() { ".jpg", ".jpeg", ".png"};
        private readonly long maxAllowedSize = 10485760; //10 MB
        public string UploadImage(IFormFile File, string folderName)
        {
           

                var extention = Path.GetExtension(File.FileName);
                if (!AllowedExtensions.Contains(extention.ToLower()))
                {
                    throw new Exception("This extention is not allowed");
                }
                if (File.Length > maxAllowedSize)
                {
                    throw new Exception("File size is too large");
                }
                var folderpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName);
                if (!Directory.Exists(folderpath))
                {
                    Directory.CreateDirectory(folderpath);
                }
                var filename = $"{Guid.NewGuid()}_{File.FileName}";
                var filepath = Path.Combine(folderpath, filename);
                using var fs = new FileStream(filepath, FileMode.Create);
                File.CopyTo(fs);

                return filename;
            
        }


        public string DeleteImage(string FilePath)
        {
            if (File.Exists(FilePath))
            { 
                File.Delete(FilePath);
                return "File deleted successfully";
            }
            return "File not found";
        }

      
    }
}
