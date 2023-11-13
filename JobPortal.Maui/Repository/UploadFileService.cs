using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Repository
{
    public class UploadFileService : IUploadFileRepository
    {
        public Task<ImageSource> ImportUserImage(string fileName)
        {
            throw new NotImplementedException();
        }

        public async Task UploadUserImage(FileResult uploadFile,string uploadFileName)
        {
            // check for null
            if (uploadFile is null) return;

            // Read the file
            var httpContent = new MultipartFormDataContent();
            httpContent.Add(new StreamContent(await uploadFile.OpenReadAsync()), "file", uploadFileName);

            // Create instance of HttpClient
            var httpClient = new HttpClient();
            var result = await httpClient.PostAsync("https://localhost:7260/api/UlpoadFile", httpContent);
            var response = await result.Content.ReadAsStringAsync();
        }
    }
}
