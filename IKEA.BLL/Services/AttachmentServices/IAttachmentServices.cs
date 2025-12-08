using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.AttachmentServices
{
    public interface IAttachmentServices
    {
        public string UploadImage(IFormFile File, string folderName);
        public string DeleteImage(string FilePath);

        


    }
}
