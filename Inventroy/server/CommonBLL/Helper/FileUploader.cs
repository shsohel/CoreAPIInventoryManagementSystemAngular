using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CommonBLL.Helper
{
    public class FileUploader
    {
        public static string Upload(string Base64File, string FolderName, string FileName, IHostingEnvironment hostingEnvironment)
        {
            string fileType = FileName.Substring(FileName.IndexOf(".") + 1);
            string generatedFileName = Guid.NewGuid().ToString() + "." + fileType;
            string rootPath = Path.Combine(hostingEnvironment.WebRootPath, "Images");
            string targetPath = Path.Combine(rootPath, FolderName);
            string fullPath = Path.Combine(targetPath, generatedFileName);
            if (Base64File.Contains(","))
            {
                string base64FileWithoutType = Base64File.Substring(Base64File.IndexOf(",") + 1);
                byte[] fileInByteArray = Convert.FromBase64String(base64FileWithoutType);
                using (FileStream fileStream = new FileStream(fullPath, FileMode.CreateNew))
                {
                    fileStream.Write(fileInByteArray, 0, fileInByteArray.Length);
                }
            }
            return generatedFileName;
        }
    }
}
