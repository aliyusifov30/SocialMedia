using Microsoft.AspNetCore.Http;
using SocialMedia.Application.Abstractions.Services.LocalServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Persistence.Concretes.Services.LocalServices
{
    public class LocalFileService : ILocalFileService
    {
        private readonly IWebHostEnvironment _env;
        public LocalFileService(IWebHostEnvironment env)
        {
            _env = env;
        }
        
        public string Upload(IFormFile file, string path)
        {
            if(file.FileName.Length > 64)
            {
                file.FileName.Substring(0, 64);
            }

            string fileName = file.FileName + Guid.NewGuid();
            path =  _env.WebRootPath + path + fileName;

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return fileName;
        }
    }
}
