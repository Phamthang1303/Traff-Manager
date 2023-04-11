using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;

namespace Traff_Manager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            settings = C.GetEachLineInFile(@"Extension\settings.json")[0];
            settings = settings.Replace("{token}", tbToken.Text);
        }

        #region Kai bao bien
        int status = 0;
        int maxThread = 0;

        string settings = "";
        string roamingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

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
                while (true)
                {
                    if (iThread < maxThread)
                    {
                        Interlocked.Increment(ref iThread);
                        new Thread(() =>
                        {
                            try
                            {
                                startfaucet(inLine);
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

        // Control Proxifier
        void ProxifierAction()
        {

        }

        // Clone folder traff
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

        #endregion

        #region Active Form Button
        private void btnStart_Click(object sender, EventArgs e)
        {
            CloneTraff(2);

            ////startfaucet(0);
            //if (btnStart.Text == "Start")
            //{
            //    //StartApp StartApp = new StartApp();
            //    Run = new Task(() => { run(); });
            //    Run.Start();
            //    status = 0;
            //    btnStart.Text = "Stop";
            //}
            //else if (btnStart.Text == "Stop")
            //{
            //    status = 1;
            //    btnStart.Text = "Start";
            //}
        }

        private void btnProxy_Click(object sender, EventArgs e)
        {

        }

        private void tbToken_TextChanged(object sender, EventArgs e)
        {
            settings = C.GetEachLineInFile(@"Extension\settings.json")[0];
            settings = settings.Replace("{token}", tbToken.Text);
        }
        #endregion
    }
}