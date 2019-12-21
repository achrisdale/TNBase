using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using TNBase.Objects;
using TNBase.DataStorage;
using System.IO;
using System.Threading;
using TNBase.Forms;

namespace TNBase
{
	public partial class FormTest
	{
        private NLog.Logger log = NLog.LogManager.GetCurrentClassLogger();
        IServiceLayer serviceLayer = new ServiceLayer(ModuleGeneric.GetDatabasePath());

		private void btnCleanDatabase_Click(object sender, EventArgs e)
		{
			serviceLayer.ClearListeners();
		}

		private void btnClearWeekStats_Click(object sender, EventArgs e)
		{
            serviceLayer.ClearWeeklyStats();
		}

		private void btnClearYearlyStats_Click(object sender, EventArgs e)
		{
            serviceLayer.ClearYearlyStats();
		}

		private void btnAddListener_Click(object sender, EventArgs e)
		{
			Listener newListener = new Listener();
			newListener.Wallet = 0;
			newListener.Title = "Mr";
			newListener.Forename = "Test";
			newListener.Surname = "Tester";
			newListener.Addr1 = "1 Test Street";
			newListener.Addr2 = "Test Place";
			newListener.Town = "Testington";
			newListener.County = "Testlegham";
			newListener.Postcode = "TE5T1NG";
			newListener.MemStickPlayer = true;
			newListener.Magazine = true;
			newListener.Info = "Test Account";
			newListener.Telephone = "0800 TEST";

			newListener.Birthday = DateTime.Now;
			newListener.Status = ListenerStates.ACTIVE;
			newListener.StatusInfo = "";
			newListener.Joined = DateTime.Now;

			InOutRecords temp = new InOutRecords();
			temp.In1 = 0;
			temp.In2 = 0;
			temp.In3 = 0;
			temp.In4 = 0;
			temp.In5 = 0;
			temp.In6 = 0;
			temp.In7 = 0;
			temp.In8 = 0;
			temp.Out1 = 0;
			temp.Out2 = 0;
			temp.Out3 = 0;
			temp.Out4 = 0;
			temp.Out5 = 0;
			temp.Out6 = 0;
			temp.Out7 = 0;
			temp.Out8 = 0;

            newListener.inOutRecords = temp;

			MessageBox.Show(serviceLayer.AddListener(newListener).ToString(), ModuleGeneric.getAppShortName());
		}

		private void btnGetFreeIndex_Click(object sender, EventArgs e)
		{
			MessageBox.Show(serviceLayer.CalculateNextFreeIndex().ToString(), ModuleGeneric.getAppShortName());
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			YearStats tempStats = serviceLayer.GetYearStats(2013);
			MessageBox.Show(tempStats.EndListeners.ToString(), ModuleGeneric.getAppShortName());
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Button2_Click(object sender, EventArgs e)
		{
			string myWallet = new FormInput().ShowDialog("Please enter a wallet number!");
			var myWalletInt = int.Parse(myWallet);
			var form = new FormPrintCollectionForm();
			form.Show();
			form.setupForm(serviceLayer.GetListenerById(myWalletInt), true);
		}

		private void formTest_Load(object sender, EventArgs e)
		{
			log.Info("Test form opened!");
		}

		private void btnThrowException_Click(object sender, EventArgs e)
		{
			throw new Exception("Noooooo...");
		}

		private void Button3_Click(object sender, EventArgs e)
		{
			MessageBox.Show(serviceLayer.GetCurrentWeekNumber().ToString(), ModuleGeneric.getAppShortName());
		}

		private void Button4_Click(object sender, EventArgs e)
		{
			DateTime mydate = default(DateTime);
			mydate = new DateTime(DateTimePicker1.Value.Year, DateTimePicker1.Value.Month, DateTimePicker1.Value.Day);
		}

		private void Button4_Click_1(object sender, EventArgs e)
		{
			new FormPrintBirthdays().Show();
		}

		public FormTest()
		{
			Load += formTest_Load;
			InitializeComponent();
		}

        /// <summary>
        /// Function for some latest development test!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDevTest_Click(object sender, EventArgs e)
        {
            FormPrintWarnings formPrintWarnings = new FormPrintWarnings();
            formPrintWarnings.Show();
            formPrintWarnings.setupForm(new List<String> { "No upcoming Listener birthdays for next week.", "No upcoming Listener birthdays for next week.", "No upcoming Listener birthdays for next week." });
        }

        private void txtConvertLog_DragDrop(object sender, DragEventArgs e)
        {
            string[] FileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            if (FileList.Length == 1)
            {
                String fileName = FileList[0];

                log.Debug("Convert log2sql: " + fileName);

                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;

                    using (StreamReader sr = File.OpenText(fileName))
                    {
                        string s = String.Empty;
                        int count = 0;
                        string final = String.Empty;
                        while ((s = sr.ReadLine()) != null)
                        {
                            if (s.Length > 50)
                            {
                                String sub = s.Substring(27);

                                // Look for the database logs
                                if (sub.StartsWith("DEBUG: QUERY: "))
                                {
                                    String newLine = sub.Substring(41-27);

                                    // Ignore the SELECT queries.
                                    if (newLine.StartsWith("SELECT "))
                                    {
                                        continue;
                                    }

                                    if (!newLine.EndsWith(";")) { newLine = newLine + ";"; }
                                    newLine = newLine + Environment.NewLine;

                                    final = final + newLine;
                                }
                            }
                            count++;
                            lblLinesRead.Invoke((MethodInvoker)(() => lblLinesRead.Text = "" + count));
                        }
                        txtConvertLog.Invoke((MethodInvoker)(() => txtConvertLog.Text = final));
                        MessageBox.Show("DONE!", ModuleGeneric.getAppShortName());
                    }

                }).Start();

                
            }
        }

        private void txtConvertLog_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void btnRunCommands_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtConvertLog.Text))
                {
                    btnRunCommands.Enabled = false;

                    List<String> lines = txtConvertLog.Lines.ToList();
                    foreach (String line in lines)
                    {
                        serviceLayer.RunCommand(line);
                    }

                    // Empty text
                    txtConvertLog.Text = "";
                    btnRunCommands.Enabled = true;
                    MessageBox.Show("DONE!", ModuleGeneric.getAppShortName());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed, please review logs: " + ex.Message, ModuleGeneric.getAppShortName());
            }
        }
	}
}
