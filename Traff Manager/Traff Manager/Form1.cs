using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;

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
        int maxThread = 3;

        string settings = "";
        string roamingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        List<Proxy> lstProxy = new List<Proxy>();


        Task Run;
        Control C = new Control();
        #endregion

        #region Method
        void run()
        {
            try
            {
                RunMain();
            }
            catch
            {
                C.Wait(10);
            }

        }

        void RunMain()
        {
            try
            {
                int iThread = 0;
                int inLine = 0;
                List<int> test = new List<int> { 12304, 15444, 16356 };
                while (inLine < test.Count)
                {
                    if (iThread < maxThread)
                    {
                        Interlocked.Increment(ref iThread);
                        new Thread(() =>
                        {
                            try
                            {
                                //startfaucet(inLine);
                                C.PerformanceCounter(test[inLine]);

                            }
                            catch { }
                            Interlocked.Decrement(ref iThread);
                        }).Start();
                        Thread.Sleep(10);
                        inLine++;
                    }
                    else
                    {
                        Application.DoEvents();
                        C.Wait(3);
                    }

                    if (status == 1)
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
            string address = "";
            string proxy = "";
            string proxyUse = "";
            string urlExtention = "";
            string IdExtension = "";
            int prxType = 0;
            int status = 0;
            try
            {
                #region Add data GridViews
                Common.AddRow(dtgv, row);
                Common.SetDataGridView(dtgv, row, "gvStt", row.ToString());
                Common.SetDataGridView(dtgv, row, "gvName", "");
                Common.SetDataGridView(dtgv, row, "gvProxy", "");
                Common.SetDataGridView(dtgv, row, "gvType", "");
                Common.SetDataGridView(dtgv, row, "gvEarnEachMin", "0");
                Common.SetDataGridView(dtgv, row, "gvEarnEach24H", "0");
                Common.SetDataGridView(dtgv, row, "gvActive", "0");
                #endregion

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

            int count = 0;
            string rule = "";
            string proxy = "";
            string authen = "";
            string strDefault = "";
            StringBuilder proxyList = new StringBuilder();
            StringBuilder ruleList = new StringBuilder();

            // For create Default.ppx file
            foreach (Proxy prx in lstProxis)
            {
                count++;
                // check is authen
                if (prx.isAuthen)
                {
                    authen = "\n" + authenTemplate.Replace("{password}", prx.password).Replace("{username}", prx.username);
                }
                else
                {
                    authen = "";
                }
                // Create form each proxy
                proxy = proxyTemplate.Replace("{id}", count.ToString()).Replace("{type}", prx.isType)
                        .Replace("{ipAddress}", prx.ipAddress).Replace("{port}", prx.port.ToString()).Replace("{authen}", authen);
                // Create rule for app
                rule = ruleTemplate.Replace("{name}", "Rule " + count).Replace("{app}", "Traffmonetizer" + count + ".exe").Replace("{action}", count.ToString());
                if (prx.Equals(lstProxis.Last()))
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
                string sourceDirectory = @"Extension\traffmonetizer";
                string targetDirectory = "";
                string settingFile = "";
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
    }
}