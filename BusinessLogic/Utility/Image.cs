using BusinessObject.DataModel;
using Microsoft.AspNetCore.Http;
using System.IO;
namespace CV_Maker.Utility
{
    public class Image
    {
        string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
        public  bool Check(string extension)
        {
            if(string.IsNullOrEmpty(extension))return false;
            extension = extension.ToLower();
            return imageExtensions.Contains(extension);
        }
        public  string GetPath(IFormFile image, string extension)
        {
            var imageName = Guid.NewGuid().ToString() + extension;
            var imagePath = Path.Combine("images", imageName);
            var absoluteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imagePath);
            using (var fileStream = new FileStream(absoluteImagePath, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }
            return imagePath;
        }
        public static void Delete(string path)
        {
          
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);

                }
                else
                {
                    throw new Exception("Picture not found");
                }
        }
    }
}
