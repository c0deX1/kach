namespace Boss
{
    partial class BossForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxExe = new System.Windows.Forms.TextBox();
            this.textBoxData = new System.Windows.Forms.TextBox();
            this.buttonChooseData = new System.Windows.Forms.Button();
            this.buttonChooseExe = new System.Windows.Forms.Button();
            this.openFileDialogExe = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogData = new System.Windows.Forms.OpenFileDialog();
            this.numericUpDownWorkers = new System.Windows.Forms.NumericUpDown();
            this.labelWorkerAmmount = new System.Windows.Forms.Label();
            this.labelExe = new System.Windows.Forms.Label();
            this.labelData = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelOutput = new System.Windows.Forms.Label();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWorkers)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxExe
            // 
            this.textBoxExe.Location = new System.Drawing.Point(27, 39);
            this.textBoxExe.Name = "textBoxExe";
            this.textBoxExe.ReadOnly = true;
            this.textBoxExe.Size = new System.Drawing.Size(209, 20);
            this.textBoxExe.TabIndex = 0;
            // 
            // textBoxData
            // 
            this.textBoxData.Location = new System.Drawing.Point(27, 91);
            this.textBoxData.Name = "textBoxData";
            this.textBoxData.ReadOnly = true;
            this.textBoxData.Size = new System.Drawing.Size(209, 20);
            this.textBoxData.TabIndex = 1;
            // 
            // buttonChooseData
            // 
            this.buttonChooseData.Location = new System.Drawing.Point(253, 91);
            this.buttonChooseData.Name = "buttonChooseData";
            this.buttonChooseData.Size = new System.Drawing.Size(91, 23);
            this.buttonChooseData.TabIndex = 2;
            this.buttonChooseData.Text = "Выбрать";
            this.buttonChooseData.UseVisualStyleBackColor = true;
            this.buttonChooseData.Click += new System.EventHandler(this.buttonChooseData_Click);
            // 
            // buttonChooseExe
            // 
            this.buttonChooseExe.Location = new System.Drawing.Point(253, 35);
            this.buttonChooseExe.Name = "buttonChooseExe";
            this.buttonChooseExe.Size = new System.Drawing.Size(91, 23);
            this.buttonChooseExe.TabIndex = 3;
            this.buttonChooseExe.Text = "Выбрать";
            this.buttonChooseExe.UseVisualStyleBackColor = true;
            this.buttonChooseExe.Click += new System.EventHandler(this.buttonChooseExe_Click);
            // 
            // openFileDialogExe
            // 
            this.openFileDialogExe.Filter = "Исполняемые файлы (*.exe)|*.exe";
            // 
            // openFileDialogData
            // 
            this.openFileDialogData.Filter = "Текстовые файлы (*.txt)|*.txt";
            // 
            // numericUpDownWorkers
            // 
            this.numericUpDownWorkers.Location = new System.Drawing.Point(374, 64);
            this.numericUpDownWorkers.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownWorkers.Name = "numericUpDownWorkers";
            this.numericUpDownWorkers.Size = new System.Drawing.Size(51, 20);
            this.numericUpDownWorkers.TabIndex = 11;
            this.numericUpDownWorkers.ValueChanged += new System.EventHandler(this.numericUpDownWorkers_ValueChanged);
            // 
            // labelWorkerAmmount
            // 
            this.labelWorkerAmmount.AutoSize = true;
            this.labelWorkerAmmount.Location = new System.Drawing.Point(371, 35);
            this.labelWorkerAmmount.Name = "labelWorkerAmmount";
            this.labelWorkerAmmount.Size = new System.Drawing.Size(131, 13);
            this.labelWorkerAmmount.TabIndex = 10;
            this.labelWorkerAmmount.Text = "Количество работников:";
            // 
            // labelExe
            // 
            this.labelExe.AutoSize = true;
            this.labelExe.Location = new System.Drawing.Point(24, 23);
            this.labelExe.Name = "labelExe";
            this.labelExe.Size = new System.Drawing.Size(182, 13);
            this.labelExe.TabIndex = 12;
            this.labelExe.Text = "Исполняемый файл для отправки:";
            // 
            // labelData
            // 
            this.labelData.AutoSize = true;
            this.labelData.Location = new System.Drawing.Point(27, 72);
            this.labelData.Name = "labelData";
            this.labelData.Size = new System.Drawing.Size(51, 13);
            this.labelData.TabIndex = 13;
            this.labelData.Text = "Данные:";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(374, 312);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 19;
            this.buttonStart.Text = "Пуск";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(30, 187);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(43, 13);
            this.labelOutput.TabIndex = 18;
            this.labelOutput.Text = "Вывод:";
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(30, 206);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.Size = new System.Drawing.Size(314, 129);
            this.textBoxOutput.TabIndex = 17;
            // 
            // BossForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(526, 397);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.labelData);
            this.Controls.Add(this.labelExe);
            this.Controls.Add(this.numericUpDownWorkers);
            this.Controls.Add(this.labelWorkerAmmount);
            this.Controls.Add(this.buttonChooseExe);
            this.Controls.Add(this.buttonChooseData);
            this.Controls.Add(this.textBoxData);
            this.Controls.Add(this.textBoxExe);
            this.Name = "BossForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWorkers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxExe;
        private System.Windows.Forms.TextBox textBoxData;
        private System.Windows.Forms.Button buttonChooseData;
        private System.Windows.Forms.Button buttonChooseExe;
        private System.Windows.Forms.OpenFileDialog openFileDialogExe;
        private System.Windows.Forms.OpenFileDialog openFileDialogData;
        private System.Windows.Forms.NumericUpDown numericUpDownWorkers;
        private System.Windows.Forms.Label labelWorkerAmmount;
        private System.Windows.Forms.Label labelExe;
        private System.Windows.Forms.Label labelData;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.TextBox textBoxOutput;
    }
}

