using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace WebManarApplication.Helpers
{
    public class DocumentSettings
    {
        public static string UploadImage(IFormFile file,string ForlderName)
        {
            // get located folder path
            string FolderPath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot\\files",ForlderName);
            // get file name and make it uniqe
            string fileName = $"{Guid.NewGuid()}{file.FileName}";
            // get file path
            string FilePath = Path.Combine(FolderPath, fileName);
            var fs = new FileStream(FilePath, FileMode.Create);
            file.CopyTo(fs);
            return fileName;
        }

        public static void DeleteFile(string fileName,string FolderName)
        {
            if (fileName is not null && FolderName is not null)
            {
             string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files",FolderName ,fileName );
               if (File.Exists(FolderPath))
               {
                 File.Delete(FolderPath);
                }
            }
           
        }
    }
}
