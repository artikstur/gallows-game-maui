using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallowsGame.Utils
{
    internal static class ImagesLoader
    {
        public static List<ImageSource> LoadFromFolder(string path)
        {
            string[] imagePaths = System.IO.Directory.GetFiles(path, "*.png");

            List<ImageSource> imageList = new List<ImageSource>();

            foreach (string imagePath in imagePaths)
            {
                ImageSource imageSource = ImageSource.FromFile(imagePath);

                imageList.Add(imageSource);
            }
            return imageList;
        }
    }
}
