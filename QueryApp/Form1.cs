using System;
using System.Configuration;
using System.Diagnostics;

namespace QueryApp
{
    public partial class Form1 : Form
    {
        private readonly DemoMethods _demoMethods;
        public Form1()
        {
            InitializeComponent();
            _demoMethods = new DemoMethods();
        }

        private async void btn_startProcess_Click(object sender, EventArgs e)
        {
            //API'a request atacak
            tb_processState.Clear();
            progressBar.Value = 0;
            Guid id = _demoMethods.StartProcess();
            ProcessState processState = _demoMethods.GetProcessState(id);
            int progress = 0;

            while (processState == ProcessState.Active)
            {
                await Task.Delay(1000);

                /*Progress simulation*/
                if (progress <= 5) progress++;
                /*-------------------*/

                AddLog(ProcessMessages.QueryActive, progress);

                processState = _demoMethods.GetProcessState(id);
            }
            switch (processState)
            {
                case ProcessState.None:
                    AddLog(ProcessMessages.QueryInactive, 0);
                    break;
                case ProcessState.Success:
                    AddLog(ProcessMessages.QuerySucceeded);
                    break;
                case ProcessState.Failed:
                    AddLog(ProcessMessages.QueryFailed, 0);
                    throw new InvalidOperationException(ProcessMessages.QueryFailed);
                default:
                    throw new NotSupportedException();
            }

        }
        private void btn_startProcess2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("dddd");
        }
        private void AddLog(string processMessage = "", int progress = 5)
        {
            if (tb_processState.InvokeRequired)
            {
                tb_processState.Invoke(new Action(() => AddLog(processMessage, progress)));
                return;
            }
            if (!string.IsNullOrEmpty(processMessage))
            {
                tb_processState.Text += $"{processMessage}{Environment.NewLine}";
                progressBar.Value = progress * 100 / 5;
            }
        }
        private void AddLog2(string processMessage = "", int progress2 = 5)
        {
            if (tb_processState.InvokeRequired)
            {
                tb_processState2.Invoke(new Action(() => AddLog2(processMessage, progress2)));
                return;
            }
            if (!string.IsNullOrEmpty(processMessage))
            {
                tb_processState2.Text += $"{""}{Environment.NewLine}";
                progressBar2.Value = progress2 * 100 / 5;
            }
        }

    }
}