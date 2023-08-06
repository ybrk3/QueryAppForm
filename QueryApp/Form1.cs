using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace QueryApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btn_startProcess_Click(object sender, EventArgs e)
        {
            tb_processState.Clear();
            progressBar.Value = 0;
            btn_startProcess.Enabled = false;

            Guid id = DemoMethods.StartProcess();
            ProcessState processState = DemoMethods.GetProcessState(id);
            int progress = 0;

            while (processState == ProcessState.Active)
            {
                await Task.Delay(1000);

                /*Progress simulation*/
                if (progress <= 5) progress++;
                /*-------------------*/

                AddLog(ProcessMessages.QueryActive, progress);

                processState = DemoMethods.GetProcessState(id);
            }
            btn_startProcess.Enabled = true;
            switch (processState)
            {
                case ProcessState.None:
                    AddLog(ProcessMessages.QueryInactive);
                    break;
                case ProcessState.Success:
                    AddLog(ProcessMessages.QuerySucceeded);
                    break;
                case ProcessState.Failed:
                    AddLog(ProcessMessages.QueryFailed);
                    throw new InvalidOperationException(ProcessMessages.QueryFailed);
                default:
                    throw new NotSupportedException();
            }

        }

        /*From API*/
        private async void btn_startProcess2_Click(object sender, EventArgs e)
        {
            tb_processState2.Clear();
            progressBar2.Value = 0;
            btn_startProcess2.Enabled = false;

            HttpClient client = new()
            {
                BaseAddress = new Uri("http://localhost:5185/")
            };

            /*Get Guid id*/
            HttpResponseMessage response = await client.GetAsync("api/Query/startprocess");
            response.EnsureSuccessStatusCode();
            Guid id = await response.Content.ReadFromJsonAsync<Guid>();

            /*Get Process State*/
            HttpResponseMessage stateResponse = await client.GetAsync($"api/Query/getprocessstate?id={id}");
            stateResponse.EnsureSuccessStatusCode();
            Result? result = await stateResponse.Content.ReadFromJsonAsync<Result>();


            int progress = 0;

            while (result?.ProcessState == ProcessState.Active)
            {
                AddLog2(result.Message, progress);
                await Task.Delay(1000);

                /*Progress simulation*/
                if (progress <= 5) progress++;
                /*-------------------*/

                stateResponse = await client.GetAsync($"api/Query/getprocessstate?id={id}");
                stateResponse.EnsureSuccessStatusCode();
                result = await stateResponse.Content.ReadFromJsonAsync<Result>();
            }
            btn_startProcess2.Enabled=true;
            switch (result?.ProcessState)
            {
                case ProcessState.None:
                    AddLog2(result.Message);
                    break;
                case ProcessState.Success:
                    AddLog2(result.Message);
                    break;
                case ProcessState.Failed:
                    AddLog2(result.Message);
                    throw new InvalidOperationException(ProcessMessages.QueryFailed);
                default:
                    throw new NotSupportedException();
            }
        }

        private void AddLog(string processMessage = "", int progress = 0)
        {
            if (tb_processState.InvokeRequired || progressBar.InvokeRequired)
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

        private void AddLog2(string processMessage = "", int progress2 = 0)
        {
            if (tb_processState2.InvokeRequired || progressBar2.InvokeRequired)
            {
                tb_processState2.Invoke(new Action(() => AddLog2(processMessage, progress2)));
                return;
            }
            if (!string.IsNullOrEmpty(processMessage))
            {
                tb_processState2.Text += $"{processMessage}{Environment.NewLine}";
                progressBar2.Value = progress2 * 100 / 5;
            }
        }

    }
}