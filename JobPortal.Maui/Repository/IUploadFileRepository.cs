using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Repository
{
    public interface IUploadFileRepository
    {
        Task UploadUserImage(FileResult uploadFile, string uploadFileName);
        Task<ImageSource> ImportUserImage(string fileName);
    }
}
