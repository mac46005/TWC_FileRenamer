using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TWC_FR_ClassLib.Classes
{
    public class IOHelper
    {
        public static (string, bool) GetFolderPath()
        {
            using (var folder = new FolderBrowserDialog())
            {
                string path = "";
                bool doesExist = false;
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    path = folder.SelectedPath;
                    doesExist = true;
                }
            }
        }


        public static string[] GetAllFilesFromFolder(string directory)
        {
            try
            {
                return Directory.GetFiles(directory);
            }
            catch (IOException ex)
            {

                throw ex;
            }
        }

        public static string[] GetCertainFilesFromFolder(string directory, string searchPattern)
        {
            try
            {
                var files = Directory.GetFiles(directory, searchPattern);
                string[] fileNames = new string[files.Length - 1];

                for (int i = 0; i < files.Length - 1; i++)
                {
                    FileInfo fileInfo = new FileInfo(files[i]);
                    fileNames[i] = fileInfo.Name;
                }
            }
            catch (IOException)
            {

                throw;
            }
            catch (ArithmeticException)
            {
                throw;
            }

        }

        public static string[] FolderContentShortName(string directory, string searchPattern)
        {
            try
            {
                string[] fileNames = { };
                var filePaths = Directory.GetFiles(directory, searchPattern);
                for (int i = 0; i < filePaths.Length; i++)
                {
                    FileInfo fileInfo = new FileInfo(filePaths[i]);
                    fileNames[i] = fileInfo?.Name;
                }
                return fileNames;
            }
            catch (IOException)
            {

                throw;
            }
        }

    }
}
