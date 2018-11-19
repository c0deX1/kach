using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace Boss
{
    public partial class BossForm : Form
    {
        private List<TextBox> workerIpTextBoxes = new List<TextBox>();
        private List<Label> workerIpLabels = new List<Label>();

        private const int workerIpOffset = 40;
        private const int workerIpSectionHeight = 60;
        private const int workerIpTextBoxOffset = 20;

        public BossForm()
        {
            InitializeComponent();
        }

        private void buttonChooseExe_Click(object sender, EventArgs e)
        {
            if (openFileDialogExe.ShowDialog() == DialogResult.OK)
            {
                textBoxExe.Text = openFileDialogExe.FileName;
            }
        }

        private void buttonChooseData_Click(object sender, EventArgs e)
        {
            if (openFileDialogData.ShowDialog() == DialogResult.OK)
            {
                textBoxData.Text = openFileDialogData.FileName;
            }
        }

        private void numericUpDownWorkers_ValueChanged(object sender, EventArgs e)
        {
            int amm = Decimal.ToInt32(numericUpDownWorkers.Value);
            int curAmm = workerIpTextBoxes.Count;

            int diff = amm - curAmm;
            if (diff > 0)
            {
                for (int i = 0; i < diff; i++)
                {

                    int workerNum = curAmm + i;

                    Label label = new Label();
                    label.Text = "Ip работника №" + (workerNum + 1).ToString();
                    label.AutoSize = true;
                    label.Location = new System.Drawing.Point(numericUpDownWorkers.Location.X, numericUpDownWorkers.Location.Y +
                                                            workerIpOffset + workerNum * workerIpSectionHeight);
                    label.Name = "labelWorkerIp" + workerNum.ToString();
                    this.Controls.Add(label);
                    workerIpLabels.Add(label);

                    TextBox textBox = new TextBox();
                    textBox.Location = new System.Drawing.Point(label.Location.X, label.Location.Y + workerIpTextBoxOffset);
                    textBox.Name = "textBoxWorkerIp" + workerNum.ToString();

                    this.Controls.Add(textBox);
                    workerIpTextBoxes.Add(textBox);
                }
            }
            else if (diff < 0)
            {
                for (int i = 0; i < -diff; i++)
                {
                    int index = workerIpLabels.Count - 1;

                    this.Controls.Remove(workerIpLabels[index]);
                    workerIpLabels[index].Dispose();
                    workerIpLabels.RemoveAt(index);

                    this.Controls.Remove(workerIpTextBoxes[index]);
                    workerIpTextBoxes[index].Dispose();
                    workerIpTextBoxes.RemoveAt(index);
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            List<string> workersIps = new List<string>();
            for (int i = 0; i < workerIpTextBoxes.Count; i++)
            {
                workersIps.Add(workerIpTextBoxes[i].Text);
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            
            Processor processor = new Processor(workersIps, textBoxExe.Text, textBoxData.Text);
            textBoxOutput.Text = "Результат работы программы (работников - " + workersIps.Count + "): " + processor.Start() + Environment.NewLine + textBoxOutput.Text;

            stopWatch.Stop();
            textBoxOutput.Text = "Время работы программы (работников - " + workersIps.Count + "): " + (float)stopWatch.ElapsedMilliseconds / 1000 + " сек" + Environment.NewLine + textBoxOutput.Text;
        }
    }
}
