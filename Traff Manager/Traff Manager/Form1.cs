using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System;
using System.Threading;

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
            countTraffEachMin = new Task(() => { MonitorTraff(); });
            countTraffEachMin.Start();
        }

        #region Kai bao bien
        int status = 0;
        int maxThread = 0;

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
        List<string> lstNameApp = new List<string>();

        Task Run;
        Task countTraffEachMin;
        Control C = new Control();
        #endregion

        #region Method
        void run()
        {
            try
            {
                maxThread = CloneTraff(lstProxy.Count());
                ProxifierManager(lstProxy);
                RunMain();
            }
            catch
            {
                
            }

        }

        void RunMain()
        {
            try
            {
                int iThread = 0;
                int inLine = 0;
                while (true)
                {
                    if (iThread < maxThread)
                    {
                        inLine++;
                        Interlocked.Increment(ref iThread);
                        new Thread(() =>
                        {
                            try
                            {
                                startfaucet(inLine);
                                //C.PerformanceCounter(test[inLine]);
                            }
                            catch { }
                            Interlocked.Decrement(ref iThread);
                        }).Start();
                        Thread.Sleep(10);
                    }
                    else
                    {
                        Application.DoEvents();
                        C.Wait(3);
                    }

                    if (status == 1 || inLine >= lstNameApp.Count())
                    {
                        break;
                    }
                    C.Wait(Convert.ToInt32(numWait.Value));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error RunMain: " + ex.ToString());
            }
        }

        int startfaucet(int row)
        {
            int status = 0;
            Proxy proxy = lstProxy[row];
            try
            {
                #region Add data GridViews
                Common.AddRow(dtgv, row);
                Common.SetDataGridView(dtgv, row, "gvStt", row.ToString());
                Common.SetDataGridView(dtgv, row, "gvName", "Traff" + row);
                Common.SetDataGridView(dtgv, row, "gvProxy", proxy.ipAddress + ":" + proxy.port);
                Common.SetDataGridView(dtgv, row, "gvType", !string.IsNullOrEmpty(proxy.isType)? proxy.isType:"");
                Common.SetDataGridView(dtgv, row, "gvEarnEachMin", "0");
                Common.SetDataGridView(dtgv, row, "gvEarnEach24H", "0");
                Common.SetDataGridView(dtgv, row, "gvActive", "0");
                #endregion

                // Start Traff App
                string pathApp = roamingDirectory + @"\traffmonetizer" + row + @"\app\Traffmonetizer" + row + ".exe";
                if (Directory.Exists(roamingDirectory + @"\traffmonetizer" + row))
                {
                    Process process = Process.Start(pathApp);
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
                    int counter = 0;
                    while (true)
                    {
                        // Get the network usage of the application
                        counter++;
                        double networkUsage = networkCounter.NextValue();
                        if (prevNetworkUsage != networkUsage)
                        {
                            upUsage = upCounter.NextValue() / 1024 / 1024;
                            downUsage = downCounter.NextValue() / 1024 / 1024;
                            traceTraffUpEachMin.Insert(counter, upUsage);
                            trafficUpEachMin += upUsage;
                            trafficDownEachMin += downUsage;
                            Common.SetDataGridView(dtgv, row, "gvEarnEachMin", $"{(upUsage + downUsage):F2}");
                            prevNetworkUsage = networkUsage;
                        }
                        C.Wait(60); // Wait for 60 second before checking again
                        if(traceTraffUpEachMin.Count() >= 1440)
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
                        Common.SetDataGridView(dtgv, row, "gvEarnEach24H", $"{(totalUpTraff24H + totalDownTraff24H):F2}");
                    }
                }
            }
            catch (Exception ex)
            {
                Common.SetDataGridView(dtgv, row, "gvStatus", "Error faucet: " + ex.ToString());
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
            C.killProcess("Proxifier.exe");
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
            for (int i=1; i<= lstProxis.Count(); i++)
            {
                // check is authen
                if (lstProxis[i].isAuthen)
                {
                    authen = "\n" + authenTemplate.Replace("{password}", lstProxis[i].password).Replace("{username}", lstProxis[i].username);
                }
                else
                {
                    authen = "";
                }
                // Create form each proxy
                proxy = proxyTemplate.Replace("{id}", i.ToString()).Replace("{type}", lstProxis[i].isType)
                        .Replace("{ipAddress}", lstProxis[i].ipAddress).Replace("{port}", lstProxis[i].port.ToString()).Replace("{authen}", authen);
                // Create rule for app
                rule = ruleTemplate.Replace("{name}", "Rule " + i).Replace("{app}", "Traffmonetizer" + i + ".exe").Replace("{action}", i.ToString());
                if (lstProxis[i].Equals(lstProxis.Last()))
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
         * Rename Traffmonetizer.exe, Traffmonetizer.exe.config
         */
        int CloneTraff(int quantity)
        {
            int count = 0;
            try
            {
                string settingFile = "";
                string targetDirectory = "";
                string sourceDirectory = @"Extension\traffmonetizer";
                lstNameApp.Clear();                
                // Clone Directory
                if (Directory.Exists(sourceDirectory))
                {
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
                                if (C.RenameFile(targetDirectory + @"\app\Traffmonetizer.exe", "Traffmonetizer" + i + ".exe") &&
                                    C.RenameFile(targetDirectory + @"\app\Traffmonetizer.exe.config", "Traffmonetizer" + i + ".exe.config"))
                                {
                                    if (File.Exists(settingFile))
                                    {
                                        File.Delete(settingFile);
                                    }
                                    C.WriteFileTxt(settingFile, settings);
                                    count++;
                                    lstNameApp.Insert(i, "Traffmonetizer" + i + ".exe");
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
                            lstNameApp.Insert(i, "Traffmonetizer" + i + ".exe");
                        }
                    }
                }
            }
            catch { }
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
                tbUpEarnMin.Text = trafficUpEachMin.ToString();
                tbUpEarn24H.Text = trafficUpEach24H.ToString();
                tbUpSum.Text = trafficUpSum.ToString();
                tbDownEarnMin.Text = trafficDownEachMin.ToString();
                tbDownEarn24H.Text = trafficDownEach24H.ToString();
                tbDownSum.Text = trafficDownSum.ToString();
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
            //CloneTraff(2);
            //ProxifierManager(lstProxy);

            //startfaucet(0);
            if (btnStart.Text == "Start")
            {
                //StartApp StartApp = new StartApp();
                Run = new Task(() => { run(); });
                Run.Start();
                status = 0;
                btnStart.Text = "Stop";
            }
            else if (btnStart.Text == "Stop")
            {
                //Run.Dispose();
                status = 1;
                btnStart.Text = "Start";
            }
        }

        private void btnProxy_Click(object sender, EventArgs e)
        {
            Process.Start(@"Data\proxy.txt");
            lstProxy.Clear();
            lstProxy = loadProxy();
            MessageBox.Show("Load all proxy: " + lstProxy.Count);
        }

        private void tbToken_TextChanged(object sender, EventArgs e)
        {
            settings = C.GetEachLineInFile(@"Extension\settings.json")[0];
            settings = settings.Replace("{token}", tbToken.Text);
        }
        #endregion

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            isRun = true;
        }
    }
}