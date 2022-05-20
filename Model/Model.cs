using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MiniTotalCommander.Model
{
    internal class Model
    {
        public string[] GetDrives()
        {
            return Directory.GetLogicalDrives();
        }

        public string[] GetFiles(string path)
        {
            List<string> allFiles = new List<string>();

            try
            {
                if (Directory.GetParent(path) != null)
                    allFiles.Add("..");

                string[] files = Directory.GetFiles(path);
                string[] dirs = Directory.GetDirectories(path);

                foreach (string dir in dirs)
                    allFiles.Add($"<D> {Path.GetFileName(dir)}");

                foreach (string file in files)
                    allFiles.Add(Path.GetFileName(file));
            }
            catch
            {
            }

            return allFiles.ToArray();
        }

        public string ChangePath(string path, string selectedPath)
        {
            if (selectedPath != null && selectedPath != ".." && selectedPath.StartsWith("<D>"))
            {
                selectedPath = selectedPath.Replace("<D> ", "");
                string newPath = Path.Combine(path, selectedPath);
                return newPath;
            }
            else if (selectedPath == "..")
                path = Directory.GetParent(path).FullName;

            return path;
        }

        public void CopyFile(string source, string destination)
        {
            try
            {
                File.Copy(source, destination, true);
            }
            catch { }
        }
    }
}
