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

        public string ReadAllTextInFile(string filePath)
        {
            return File.ReadAllText(filePath);
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

        public void KillProcess(string processName)
        {
            try
            {
                foreach (var process in Process.GetProcessesByName(processName))
                {
                    process.Kill();
                }
            }
            catch { }
        }

        public void PerformanceCounter(int processId)
        {
            var process = Process.GetProcessById(processId);
            string fileLog = processId + "log.txt";
            // Create the Performance Counters for the application
            var networkCounter = new PerformanceCounter("Process", "IO Data Bytes/sec", process.ProcessName, true);
            var upCounter = new PerformanceCounter("Process", "IO Write Bytes/sec", process.ProcessName, true);
            var downCounter = new PerformanceCounter("Process", "IO Read Bytes/sec", process.ProcessName, true);

            // Continuously monitor the network usage  
            double prevNetworkUsage = 0;
            double upUsage = 0;
            double downUsage = 0;
            WriteFileTxt(fileLog, " Process ID: " + processId);
            WriteFileTxt(fileLog, " Process Name: " + process.ProcessName);
            while (true)
            {
                // Get the network usage of the application
                double networkUsage = networkCounter.NextValue();
                if (prevNetworkUsage != networkUsage)
                {
                    upUsage = upCounter.NextValue() / 1024;
                    downUsage = downCounter.NextValue() / 1024;
                    //Console.WriteLine($"Up: {upUsage:F2}KB/s, Down: {downUsage:F2}KB/s");
                    WriteFileTxt(fileLog, $"Up: {upUsage:F2}KB/5s, Down: {downUsage:F2}KB/5s");
                    prevNetworkUsage = networkUsage;
                }
                Thread.Sleep(5000); // Wait for 1 second before checking again
            }
        }

        public void PerformanceCounter(Process process)
        {
            // Create the Performance Counters for the application
            var networkCounter = new PerformanceCounter("Process", "IO Data Bytes/sec", process.ProcessName, true);
            var upCounter = new PerformanceCounter("Process", "IO Write Bytes/sec", process.ProcessName, true);
            var downCounter = new PerformanceCounter("Process", "IO Read Bytes/sec", process.ProcessName, true);

            // Continuously monitor the network usage  
            double prevNetworkUsage = 0;
            double upUsage = 0;
            double downUsage = 0;
            while (true)
            {
                // Get the network usage of the application
                double networkUsage = networkCounter.NextValue();
                if (prevNetworkUsage != networkUsage)
                {
                    upUsage = upCounter.NextValue() / 1024;
                    downUsage = downCounter.NextValue() / 1024;
                    Console.WriteLine($"Up: {upUsage:F2}KB/s, Down: {downUsage:F2}KB/s");
                    prevNetworkUsage = networkUsage;
                }
                Thread.Sleep(5000); // Wait for 1 second before checking again
            }
        }
    }
}
