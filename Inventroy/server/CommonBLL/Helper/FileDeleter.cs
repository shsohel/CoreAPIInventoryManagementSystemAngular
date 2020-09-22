using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CommonBLL.Helper
{
    public class FileDeleter
    {
        public static void Delete(string ImageName, string FolderName, IHostingEnvironment hostingEnvironment)
        {
            if (ImageName != null)
            {
                string imageFolderPath = Path.Combine(hostingEnvironment.WebRootPath, "Images");
                string targetPath = Path.Combine(imageFolderPath, FolderName);
                string fullPath = Path.Combine(targetPath, ImageName);
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }
        }
    }
}
