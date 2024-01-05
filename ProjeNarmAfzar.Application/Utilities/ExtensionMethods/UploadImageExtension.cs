using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using CampEshop.Application.ExtensionMethods;
using Microsoft.AspNetCore.Http;

namespace ProjeNarmAfzar.Application.Utilities.ExtensionMethods

{
    public static class UploadImageExtension
    {
        public static void AddImageToServer(this IFormFile image, string fileName, string orginalPath, string deletefileName = null)
        {
            if (image != null && image.IsImage())
            {
                if (!Directory.Exists(orginalPath))
                    Directory.CreateDirectory(orginalPath);

                if (!string.IsNullOrEmpty(deletefileName))
                {
                    if (File.Exists(orginalPath + deletefileName))
                        File.Delete(orginalPath + deletefileName);

                }

                string OriginPath = orginalPath + fileName;

                using (var stream = new FileStream(OriginPath, FileMode.Create))
                {
                    if (!Directory.Exists(OriginPath)) image.CopyTo(stream);
                }


            }
        }

        public static void DeleteImage(this string imageName, string OriginPath)
        {
            if (!string.IsNullOrEmpty(imageName))
            {
                if (File.Exists(OriginPath + imageName))
                    File.Delete(OriginPath + imageName);

            }
        }

        public static List<string> FetchLinksFromSource(this string htmlSource)
        {
            List<string> links = new List<string>();

            string regexImgSrc = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";

            MatchCollection matchesImgSrc = Regex.Matches(htmlSource, regexImgSrc, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            foreach (Match m in matchesImgSrc)
            {
                string href = m.Groups[1].Value;

                links.Add(href);
            }

            return links;
        }

        public static void EditEditorImages(this List<string> NewImages, List<string> PreviousImages)
        {
            foreach (var pre in PreviousImages)
            {
                var path = NewImages.Find(p => p == pre);

                if (path == null)
                    File.Delete("wwwroot/" + pre);
            }
        }
    }
}
