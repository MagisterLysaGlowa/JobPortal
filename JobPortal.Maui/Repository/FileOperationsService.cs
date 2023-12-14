using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Maui.Repository
{
    public class FileOperationsService : IFileOperationRepository
    {
        private string apiUrl = $"{App.apiDevTunnel}/api/UlpoadFile";
        public async Task<ImageSource> ImportUserImage(string fileName)
        {
            // Create instance of HttpClient
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{apiUrl}/GetImage/{fileName}");
            if(response.IsSuccessStatusCode)
            {
                byte[] imageData = await response.Content.ReadAsByteArrayAsync();
                ImageSource imageSource = ImageSource.FromStream(() => new MemoryStream(imageData));
                return imageSource;
            }
            else
            {
                return null;
            }
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
