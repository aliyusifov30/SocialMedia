using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Abstractions.Services
{
    public interface IFileService
    {
        string Upload(IFormFile file, string path);
        //void Delete();
        //void Check();
    }
}
