using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Collections.Concurrent;

namespace Traff_Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            settings = C.GetEachLineInFile(@"Extension\Template\settingsTemplate.json")[0];
            settings = settings.Replace("{token}", tbToken.Text);
            lstProxy = loadProxy();
        }

        #region Kai bao bien
        int status = 0;
        int maxThread = 1;
        int iThread = 0;

        double trafficUpEachMin = 0;
        double trafficUpEach24H = 0;
        double trafficUpSum = 0;
        double trafficDownEachMin = 0;
        double trafficDownEach24H = 0;
        double trafficDownSum = 0;

        string settings = "";
        string roamingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        bool isRun = false;

        List<Proxy> lstProxy = new List<Proxy>();

        ConcurrentDictionary<int, string> cdNameApp = new ConcurrentDictionary<int, string>();

        Task? Run;
        Task? countTraffEachMin;
        Control C = new Control();
        #endregion

        #region Method
        void run()
        {
            try
            {
                CloneTraff(lstProxy.Count());
                C.Wait(2);
                ProxifierManager(lstProxy);
                C.Wait(5);
                RunMain();
            }
            catch (Exception e)
            {

            }

        }

        void RunMain()
        {
            try
            {
                foreach (var app in cdNameApp)
                {
                    C.DeleteFile(roamingDirectory + @"\traffmonetizer\storage.json");
                    C.DeleteFile(roamingDirectory + @"\traffmonetizer\pid");
                    C.Wait(1);
                    while (true)
                    {
                        if (iThread < maxThread)
                        {
                            Interlocked.Increment(ref iThread);
                            new Thread(() =>
                            {
                                try
                                {
                                    start(app.Key);
                                }
                                catch { }

                            }).Start();
                            Thread.Sleep(10);
                        }
                        else
                        {
                            Application.DoEvents();
                            C.Wait(3);
                        }

                        C.Wait(Convert.ToInt32(numWait.Value));
                        if (iThread < 1)
                        {
                            break;
                        }
                    }
                    if (status == 1)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error RunMain: " + ex.ToString());
            }
        }

        int start(int row)
        {
            int status = 0;
            int index = row - 1;
            Proxy proxy = lstProxy[index];
            try
            {
                #region Add data GridViews
                Common.AddRow(dtgv, index);
                Common.SetDataGridView(dtgv, index, "gvStt", row.ToString());
                Common.SetDataGridView(dtgv, index, "gvName", "Traff" + row);
                Common.SetDataGridView(dtgv, index, "gvProxy", proxy.ipAddress + ":" + proxy.port);
                Common.SetDataGridView(dtgv, index, "gvType", !string.IsNullOrEmpty(proxy.isType) ? proxy.isType : "");
                Common.SetDataGridView(dtgv, index, "gvEarnEachMin", "0");
                Common.SetDataGridView(dtgv, index, "gvEarnEach24H", "0");
                Common.SetDataGridView(dtgv, index, "gvStatus", "0");
                #endregion

                // Start Traff App
                string pathApp = roamingDirectory + @"\traffmonetizer" + row + @"\app\traffmonetizer" + row + ".exe";
                if (Directory.Exists(roamingDirectory + @"\traffmonetizer" + row))
                {
                    Process process = Process.Start(pathApp);
                    C.Wait(1);
                    Interlocked.Decrement(ref iThread);
                    // Create the Performance Counters for the application
                    var networkCounter = new PerformanceCounter("Process", "IO Data Bytes/sec", process.ProcessName, true);
                    var upCounter = new PerformanceCounter("Process", "IO Write Bytes/sec", process.ProcessName, true);
                    var downCounter = new PerformanceCounter("Process", "IO Read Bytes/sec", process.ProcessName, true);

                    // Continuously monitor the network usage  
                    double prevNetworkUsage = 0;
                    double upUsage = 0;
                    double downUsage = 0;
                    double totalUpTraff24H = 0;
                    double totalDownTraff24H = 0;
                    List<double> traceTraffUpEachMin = new List<double>();
                    List<double> traceTraffDownEachMin = new List<double>();
                    for (int i = 0; i < 1439; i++)
                    {
                        traceTraffUpEachMin.Add(0);
                        traceTraffDownEachMin.Add(0);
                    }
                    int counter = 0;
                    while (true)
                    {
                        // Get the network usage of the application
                        counter++;
                        double networkUsage = networkCounter.NextValue();
                        if (prevNetworkUsage != networkUsage)
                        {
                            trafficUpEachMin -= upUsage;
                            trafficUpEachMin -= downUsage;
                            upUsage = upCounter.NextValue() / 1024 / 1024;
                            downUsage = downCounter.NextValue() / 1024 / 1024;
                            traceTraffUpEachMin[counter] = upUsage;
                            traceTraffDownEachMin[counter] = downUsage;

                            trafficUpEachMin += upUsage;
                            trafficDownEachMin += downUsage;
                            trafficUpSum += upUsage / 1024;
                            trafficDownSum += downUsage / 1024;
                            if ((upUsage + downUsage) * 1024 < 1)
                            {
                                Common.SetDataGridView(dtgv, index, "gvEarnEachMin", $"{(upUsage + downUsage) * 1024:F2}" + "KB/60s");
                            }
                            else
                            {
                                Common.SetDataGridView(dtgv, index, "gvEarnEachMin", $"{(upUsage + downUsage):F2}MB/60s");
                            }
                            prevNetworkUsage = networkUsage;
                        }
                        C.Wait(60);
                        // Wait for 60 second before checking again
                        int _count = 0;
                        while (_count < 60)
                        {
                            _count++;
                            C.Wait(1);
                            if (status == 1)
                            {
                                break;
                            }
                        }
                        if (status == 1)
                        {
                            break;
                        }
                        if (traceTraffUpEachMin.Count() >= 1440)
                        {
                            counter = 1;
                        }
                        // Update Traff Upload for 24H
                        trafficUpEach24H -= totalUpTraff24H;
                        totalUpTraff24H = traceTraffUpEachMin.Sum();
                        trafficUpEach24H += totalUpTraff24H;
                        // Update Traff Download for 24H
                        trafficDownEach24H -= totalDownTraff24H;
                        totalDownTraff24H = traceTraffDownEachMin.Sum();
                        trafficDownEach24H += totalDownTraff24H;
                        if ((totalUpTraff24H + totalDownTraff24H) > 1024)
                        {
                            Common.SetDataGridView(dtgv, index, "gvEarnEach24H", $"{(totalUpTraff24H + totalDownTraff24H) / 1024:F2}GB/24H");
                        }
                        else
                        {
                            Common.SetDataGridView(dtgv, index, "gvEarnEach24H", $"{(totalUpTraff24H + totalDownTraff24H):F2}MB/24H");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.SetDataGridView(dtgv, index, "gvStatus", "Error faucet: " + ex.ToString());
                if (iThread >= 1)
                {
                    Interlocked.Decrement(ref iThread);
                }
            }
            //C.RemoveDirectory(@"C:\potable\User Data\Profile " + row);
            return row;
        }

        /**
         * Manager Proxifier
         * Replate file setting Default.ppx for Proxifier
         * params List<Proxy> list proxy
         */
        void ProxifierManager(List<Proxy> lstProxis)
        {
            // Kill process Proxifier.exe
            C.KillProcess("Proxifier.exe");
            string templateDefault = "";
            string proxyTemplate = "";
            string authenTemplate = "";
            string ruleTemplate = "";
            string pathDefault = @"Extension\Proxifier PE\Profiles\Default.ppx";

            // Read form Template
            templateDefault = C.ReadAllTextInFile(@"Extension\Template\defaultTemplate.ppx");
            proxyTemplate = C.ReadAllTextInFile(@"Extension\Template\proxyTemplate.ppx");
            authenTemplate = C.ReadAllTextInFile(@"Extension\Template\authenTemplate.ppx");
            ruleTemplate = C.ReadAllTextInFile(@"Extension\Template\ruleTemplate.ppx");

            string rule = "";
            string proxy = "";
            string authen = "";
            string strDefault = "";
            StringBuilder proxyList = new StringBuilder();
            StringBuilder ruleList = new StringBuilder();

            // For create Default.ppx file
            for (int i = 1; i <= lstProxis.Count(); i++)
            {
                // check is authen
                int index = i - 1;
                if (lstProxis[index].isAuthen)
                {
                    authen = "\n" + authenTemplate.Replace("{password}", lstProxis[index].password).Replace("{username}", lstProxis[index].username);
                }
                else
                {
                    authen = "";
                }
                // Create form each proxy
                proxy = proxyTemplate.Replace("{id}", i.ToString()).Replace("{type}", lstProxis[index].isType)
                        .Replace("{ipAddress}", lstProxis[index].ipAddress).Replace("{port}", lstProxis[index].port.ToString()).Replace("{authen}", authen);
                // Create rule for app
                rule = ruleTemplate.Replace("{name}", "Rule " + i).Replace("{app}", "traffmonetizer" + i + ".exe").Replace("{action}", i.ToString());
                if (lstProxis[index].Equals(lstProxis.Last()))
                {
                    proxyList.Append(proxy);
                    ruleList.Append(rule);
                }
                else
                {
                    proxyList.Append(proxy + "\n");
                    ruleList.Append(rule + "\n");
                }

            }
            // Create form Default.ppx file with all proxies, rules
            strDefault = templateDefault.Replace("{ProxyList}", proxyList.ToString()).Replace("{RuleList}", ruleList.ToString());
            // Replate Default.ppx file
            if (File.Exists(pathDefault))
            {
                File.Delete(pathDefault);
            }
            C.WriteFileTxt(pathDefault, strDefault);

            // Start Proxifier
            Process.Start(@"Extension\Proxifier PE\Proxifier.exe");
        }

        /**
         * Clone folder traff
         * Replace file settings.json update Token
         * Rename traffmonetizer.exe, traffmonetizer.exe.config
         */
        int CloneTraff(int quantity)
        {
            int count = 0;
            try
            {
                string settingFile = "";
                string targetDirectory = "";
                string sourceDirectory = @"Extension\traffmonetizer";
                cdNameApp.Clear();
                // Clone Directory
                if (Directory.Exists(sourceDirectory))
                {
                    // Delete directory root
                    targetDirectory = roamingDirectory + @"\traffmonetizer";
                    settingFile = targetDirectory + @"\settings.json";
                    if (Directory.Exists(targetDirectory))
                    {
                        if (File.Exists(settingFile))
                        {
                            File.Delete(settingFile);
                            C.WriteFileTxt(settingFile, settings);
                        }
                        if (Directory.Exists(targetDirectory + @"\app"))
                        {
                            Directory.Delete(targetDirectory, true);
                        }
                    }
                    else
                    {
                        Directory.CreateDirectory(targetDirectory);
                        C.WriteFileTxt(settingFile, settings);
                    }

                    for (int i = 1; i <= quantity; i++)
                    {
                        targetDirectory = roamingDirectory + @"\traffmonetizer" + i;
                        settingFile = targetDirectory + @"\settings.json";
                        if (!Directory.Exists(targetDirectory))
                        {
                            // Copy directory
                            if (C.CopyDirectory(sourceDirectory, targetDirectory))
                            {
                                // Rename traff
                                if (C.RenameFile(targetDirectory + @"\app\traffmonetizer.exe", "traffmonetizer" + i + ".exe") &&
                                    C.RenameFile(targetDirectory + @"\app\traffmonetizer.exe.config", "traffmonetizer" + i + ".exe.config"))
                                {
                                    if (File.Exists(settingFile))
                                    {
                                        File.Delete(settingFile);
                                    }
                                    C.WriteFileTxt(settingFile, settings);
                                    count++;
                                    if (!cdNameApp.TryAdd(i, "traffmonetizer" + i + ".exe"))
                                    {
                                        cdNameApp[i] = "traffmonetizer" + i + ".exe";
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (File.Exists(settingFile))
                            {
                                File.Delete(settingFile);
                            }
                            C.WriteFileTxt(settingFile, settings);
                            count++;
                            if (!cdNameApp.TryAdd(i, "traffmonetizer" + i + ".exe"))
                            {
                                cdNameApp[i] = "traffmonetizer" + i + ".exe";
                            }
                        }
                    }
                }
            }
            catch (Exception e) { }
            return count;
        }

        /**
         * Load list proxy
         * Save to List<Proxy> with type, authen
         */
        List<Proxy> loadProxy()
        {
            Proxy proxy;
            List<Proxy> lstPrx = new List<Proxy>();
            foreach (string prx in File.ReadAllLines(@"Data\proxy.txt").ToList())
            {

                if (prx.Contains("|"))
                {
                    proxy = new Proxy(prx.Split('|')[1]);
                    proxy.isType = prx.Split('|')[0].ToUpper();
                }
                else
                {
                    proxy = new Proxy(prx);
                    proxy.isType = "HTTPS";
                }

                lstPrx.Add(proxy);
            }
            return lstPrx;
        }

        void MonitorTraff()
        {
            while (true)
            {
                tbUpEarnMin.Text = $"{trafficUpEachMin:F2}";
                tbUpEarn24H.Text = $"{trafficUpEach24H:F2}";
                tbUpSum.Text = $"{trafficUpSum:F2}";
                tbDownEarnMin.Text = $"{trafficDownEachMin:F2}";
                tbDownEarn24H.Text = $"{trafficDownEach24H:F2}";
                tbDownSum.Text = $"{trafficDownSum:F2}";
                C.Wait(5);
                if (isRun)
                {
                    break;
                }
            }
        }
        #endregion

        #region Active Form Button
        private void btnStart_Click(object sender, EventArgs e)
        {
            //startfaucet(0);
            if (btnStart.Text == "Start")
            {
                //StartApp StartApp = new StartApp();
                Run = new Task(() => { run(); });
                Run.Start();
                status = 0;
                btnStart.Text = "Stop";

                isRun = false;
                countTraffEachMin = new Task(() => { MonitorTraff(); });
                countTraffEachMin.Start();
            }
            else if (btnStart.Text == "Stop")
            {
                //Run.Dispose();
                status = 1;
                btnStart.Text = "Start";
                isRun = true;
            }
        }

        private void btnProxy_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", @"Data\proxy.txt");
            MessageBox.Show("Wait change proxy!");
            lstProxy.Clear();
            lstProxy = loadProxy();
            MessageBox.Show("Load all proxy: " + lstProxy.Count);
        }

        private void tbToken_TextChanged(object sender, EventArgs e)
        {
            settings = C.GetEachLineInFile(@"Extension\Template\settingsTemplate.json")[0];
            settings = settings.Replace("{token}", tbToken.Text);
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            isRun = true;
        }

        private void btnKillAll_Click(object sender, EventArgs e)
        {
            if (cdNameApp.Count > 0)
            {
                foreach (var s in cdNameApp)
                {
                    C.KillProcess(s.Value.Replace(".exe", ""));
                    Thread.Sleep(50);
                }
            }
            C.KillProcess("Proxifier");
        }
        #endregion
    }
}