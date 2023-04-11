using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traff_Manager
{
    internal class Control
    {
        public void Wait(int t)
        {
            int time = (t < 0) ? -(t * 1000) : t * 1000;
            Thread.Sleep(time);
        }

        public List<string> GetEachLineInFile(string filePath)
        {
            return File.ReadAllLines(filePath).ToList();
        }

        public void WriteFileTxt(string pathFile, string text)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(pathFile, true))
            {
                file.WriteLine(text);
            }
        }

        public bool CopyFile(string pathFile, string pathFileClone)
        {
            try
            {
                if (File.Exists(pathFile))
                {
                    File.Copy(pathFile, pathFileClone, true);
                    return true;
                }
            }catch{ }
            
            return false;
        }

        public bool CopyDirectory(string sourceDirectory, string targetDirectory)
        {
            try
            {
                // sao chép thư mục
                if (Directory.Exists(sourceDirectory))
                {
                    Directory.CreateDirectory(targetDirectory);
                    foreach (string dirPath in Directory.GetDirectories(sourceDirectory, "*", SearchOption.AllDirectories))
                    {
                        Directory.CreateDirectory(dirPath.Replace(sourceDirectory, targetDirectory));
                    }
                    foreach (string filePath in Directory.GetFiles(sourceDirectory, "*.*", SearchOption.AllDirectories))
                    {
                        File.Copy(filePath, filePath.Replace(sourceDirectory, targetDirectory), true);
                    }

                    //// lấy danh sách tệp từ thư mục nguồn
                    //string[] files = Directory.GetFiles(sourceDirectory);

                    //// sao chép từng tệp sang thư mục đích
                    //foreach (string file in files)
                    //{
                    //    string fileName = Path.GetFileName(file);
                    //    string targetPath = Path.Combine(targetDirectory, fileName);
                    //    File.Copy(file, targetPath, true);
                    //}
                    return true;
                }
            }
            catch { }

            return false;
        }

        public bool RenameFile(string? filePath, string newFileName)
        {
            try
            {
                // Kiểm tra tệp có tồn tại
                if (!string.IsNullOrEmpty(filePath) && File.Exists(filePath))
                {
                    // Đổi tên hồ sơ
                    File.Move(filePath, Path.Combine(Path.GetDirectoryName(filePath), newFileName));
                }
                return true;
            }catch { }
            return false;
        }

        public void LoadJson()
        {
            using (StreamReader r = new StreamReader("file.json"))
            {
                string json = r.ReadToEnd();
                //List<SettingsTraff> settingsTraffs = JsonConvert.DeserializeObject<List<SettingsTraff>>(json);
            }
        }
    }
}
