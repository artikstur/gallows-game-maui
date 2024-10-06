using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GallowsGame.Utils
{
    public static class PathMaker
    {
        public static string GetFolderPath(string folder)
        {
            var baseDirectory = GetProjectRootDirectory();

            var folderPath = Path.Combine(baseDirectory, "Resources", "Images", folder);

            return folderPath;
        }

        public static string GetProjectRootDirectory()
        {
            string currentDirectory = AppContext.BaseDirectory;

            string projectRootFolderName = "GallowsGame";

            DirectoryInfo directoryInfo = new DirectoryInfo(currentDirectory);

            while (directoryInfo != null && directoryInfo.Name != projectRootFolderName)
            {
                directoryInfo = directoryInfo.Parent;
            }

            if (directoryInfo == null)
            {
                throw new Exception("Project root directory not found");
            }

            return directoryInfo.FullName;
        }
    }
}
