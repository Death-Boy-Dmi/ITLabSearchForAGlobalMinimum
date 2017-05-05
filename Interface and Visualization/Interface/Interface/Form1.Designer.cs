namespace My_Second_Interface
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.VisualizationPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip3 = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.DataInputPanel0 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.rLabel = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.mLabel = new System.Windows.Forms.Label();
            this.lyambdaLabel = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.DataInputPanel0.SuspendLayout();
            this.SuspendLayout();
            // 
            // VisualizationPanel
            // 
            this.VisualizationPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VisualizationPanel.Location = new System.Drawing.Point(8, 243);
            this.VisualizationPanel.Name = "VisualizationPanel";
            this.VisualizationPanel.Size = new System.Drawing.Size(568, 397);
            this.VisualizationPanel.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Визуализация процесса:";
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipTitle = "Точность";
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // toolTip2
            // 
            this.toolTip2.ToolTipTitle = "Максимальное колличество итераций";
            // 
            // toolTip3
            // 
            this.toolTip3.ToolTipTitle = "Отрезок";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // DataInputPanel0
            // 
            this.DataInputPanel0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DataInputPanel0.Controls.Add(this.textBox7);
            this.DataInputPanel0.Controls.Add(this.label9);
            this.DataInputPanel0.Controls.Add(this.OK);
            this.DataInputPanel0.Controls.Add(this.lyambdaLabel);
            this.DataInputPanel0.Controls.Add(this.mLabel);
            this.DataInputPanel0.Controls.Add(this.textBox6);
            this.DataInputPanel0.Controls.Add(this.rLabel);
            this.DataInputPanel0.Controls.Add(this.comboBox2);
            this.DataInputPanel0.Controls.Add(this.label3);
            this.DataInputPanel0.Controls.Add(this.textBox5);
            this.DataInputPanel0.Controls.Add(this.label8);
            this.DataInputPanel0.Controls.Add(this.textBox4);
            this.DataInputPanel0.Controls.Add(this.label7);
            this.DataInputPanel0.Controls.Add(this.textBox3);
            this.DataInputPanel0.Controls.Add(this.label6);
            this.DataInputPanel0.Controls.Add(this.textBox2);
            this.DataInputPanel0.Controls.Add(this.label5);
            this.DataInputPanel0.Location = new System.Drawing.Point(8, 12);
            this.DataInputPanel0.Name = "DataInputPanel0";
            this.DataInputPanel0.Size = new System.Drawing.Size(568, 201);
            this.DataInputPanel0.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.label5.Location = new System.Drawing.Point(14, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 26);
            this.label5.TabIndex = 1;
            this.label5.Text = "f(x) =";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.textBox2.Location = new System.Drawing.Point(82, 11);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(481, 29);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "(x/4)*cos(x)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.label6.Location = new System.Drawing.Point(3, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 26);
            this.label6.TabIndex = 3;
            this.label6.Text = "[a,b] =";
            this.toolTip3.SetToolTip(this.label6, "Отрезок, в пределах которого\r\nбудет производиться поиск\r\nглобального минимума\r\nза" +
        "данной функции.");
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.textBox3.Location = new System.Drawing.Point(82, 46);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(162, 29);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "[ 0, 30 ]";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.label7.Location = new System.Drawing.Point(34, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 26);
            this.label7.TabIndex = 5;
            this.label7.Text = "ε =";
            this.toolTip1.SetToolTip(this.label7, "Максимальная точность, с которой будет считаться \r\nглобальный минимум заданной фу" +
        "нкции.");
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.textBox4.Location = new System.Drawing.Point(82, 81);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(162, 29);
            this.textBox4.TabIndex = 6;
            this.textBox4.Text = "0.00001";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.label8.Location = new System.Drawing.Point(34, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 26);
            this.label8.TabIndex = 7;
            this.label8.Text = "k =";
            this.toolTip2.SetToolTip(this.label8, "Максимальное колличество итераций,\r\nкоторые выполнит программа при поиске\r\nглобал" +
        "ьного минимума.\r\n\r\n(Колличество точек, в которых будет\r\nпроверяться наличие глоб" +
        "ального минимума)");
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.textBox5.Location = new System.Drawing.Point(82, 116);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(162, 29);
            this.textBox5.TabIndex = 8;
            this.textBox5.Text = "1000";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(250, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Выберете метод поиска:";
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Алгоритм глобального поиска",
            "Монотонный алгоритм глобального поиска",
            "Метод Кушнера",
            "Метод ломанных"});
            this.comboBox2.Location = new System.Drawing.Point(250, 65);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(313, 21);
            this.comboBox2.TabIndex = 10;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // rLabel
            // 
            this.rLabel.AutoSize = true;
            this.rLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.rLabel.Location = new System.Drawing.Point(262, 116);
            this.rLabel.Name = "rLabel";
            this.rLabel.Size = new System.Drawing.Size(38, 26);
            this.rLabel.TabIndex = 11;
            this.rLabel.Text = "r =";
            this.toolTip2.SetToolTip(this.rLabel, "Максимальное колличество итераций,\r\nкоторые выполнит программа при поиске\r\nглобал" +
        "ьного минимума.\r\n\r\n(Колличество точек, в которых будет\r\nпроверяться наличие глоб" +
        "ального минимума)");
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.textBox6.Location = new System.Drawing.Point(306, 116);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(73, 29);
            this.textBox6.TabIndex = 12;
            this.textBox6.Text = "3";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mLabel
            // 
            this.mLabel.AutoSize = true;
            this.mLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.mLabel.Location = new System.Drawing.Point(251, 116);
            this.mLabel.Name = "mLabel";
            this.mLabel.Size = new System.Drawing.Size(49, 26);
            this.mLabel.TabIndex = 13;
            this.mLabel.Text = "M =";
            this.toolTip2.SetToolTip(this.mLabel, "Максимальное колличество итераций,\r\nкоторые выполнит программа при поиске\r\nглобал" +
        "ьного минимума.\r\n\r\n(Колличество точек, в которых будет\r\nпроверяться наличие глоб" +
        "ального минимума)");
            this.mLabel.Click += new System.EventHandler(this.mLabel_Click);
            // 
            // lyambdaLabel
            // 
            this.lyambdaLabel.AutoSize = true;
            this.lyambdaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.lyambdaLabel.Location = new System.Drawing.Point(258, 116);
            this.lyambdaLabel.Name = "lyambdaLabel";
            this.lyambdaLabel.Size = new System.Drawing.Size(42, 26);
            this.lyambdaLabel.TabIndex = 14;
            this.lyambdaLabel.Text = "λ =";
            this.toolTip2.SetToolTip(this.lyambdaLabel, "Максимальное колличество итераций,\r\nкоторые выполнит программа при поиске\r\nглобал" +
        "ьного минимума.\r\n\r\n(Колличество точек, в которых будет\r\nпроверяться наличие глоб" +
        "ального минимума)");
            // 
            // OK
            // 
            this.OK.BackColor = System.Drawing.SystemColors.Window;
            this.OK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OK.Location = new System.Drawing.Point(39, 151);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(100, 35);
            this.OK.TabIndex = 15;
            this.OK.Text = "Начать";
            this.OK.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.label9.Location = new System.Drawing.Point(176, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 26);
            this.label9.TabIndex = 16;
            this.label9.Text = "Результат:";
            this.toolTip2.SetToolTip(this.label9, "Максимальное колличество итераций,\r\nкоторые выполнит программа при поиске\r\nглобал" +
        "ьного минимума.\r\n\r\n(Колличество точек, в которых будет\r\nпроверяться наличие глоб" +
        "ального минимума)");
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.textBox7.Location = new System.Drawing.Point(306, 160);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(162, 29);
            this.textBox7.TabIndex = 17;
            this.textBox7.Text = "[ 0, 0 ]";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox7.TextChanged += new System.EventHandler(this.textBox7_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Window;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(475, 646);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 35);
            this.button1.TabIndex = 18;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(587, 693);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DataInputPanel0);
            this.Controls.Add(this.VisualizationPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "ПГМ-1";
            this.DataInputPanel0.ResumeLayout(false);
            this.DataInputPanel0.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel VisualizationPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel DataInputPanel0;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Label lyambdaLabel;
        private System.Windows.Forms.Label mLabel;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label rLabel;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}

