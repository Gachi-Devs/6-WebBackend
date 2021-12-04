
namespace RaspClient
{
    partial class Form1
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
            this.radioAPI = new System.Windows.Forms.RadioButton();
            this.radioLocal = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.facultyBox = new System.Windows.Forms.ComboBox();
            this.foeBox = new System.Windows.Forms.ComboBox();
            this.courceBox = new System.Windows.Forms.ComboBox();
            this.groupBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.weekBox = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.timetableView = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioAPI
            // 
            this.radioAPI.AutoSize = true;
            this.radioAPI.Location = new System.Drawing.Point(9, 9);
            this.radioAPI.Name = "radioAPI";
            this.radioAPI.Size = new System.Drawing.Size(77, 17);
            this.radioAPI.TabIndex = 0;
            this.radioAPI.TabStop = true;
            this.radioAPI.Text = "Через API";
            this.radioAPI.UseVisualStyleBackColor = true;
            this.radioAPI.CheckedChanged += new System.EventHandler(this.radioAPI_CheckedChanged);
            // 
            // radioLocal
            // 
            this.radioLocal.AutoSize = true;
            this.radioLocal.Location = new System.Drawing.Point(9, 33);
            this.radioLocal.Name = "radioLocal";
            this.radioLocal.Size = new System.Drawing.Size(75, 17);
            this.radioLocal.TabIndex = 1;
            this.radioLocal.TabStop = true;
            this.radioLocal.Text = "Локально";
            this.radioLocal.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioLocal);
            this.panel1.Controls.Add(this.radioAPI);
            this.panel1.Location = new System.Drawing.Point(9, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(123, 61);
            this.panel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 473);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 49);
            this.button1.TabIndex = 3;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // facultyBox
            // 
            this.facultyBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.facultyBox.FormattingEnabled = true;
            this.facultyBox.Items.AddRange(new object[] {
            "Факультет информационных технологий",
            "Факультет управления",
            "Факультет экономики и финансов",
            "Факультет юридический"});
            this.facultyBox.Location = new System.Drawing.Point(9, 169);
            this.facultyBox.Name = "facultyBox";
            this.facultyBox.Size = new System.Drawing.Size(215, 21);
            this.facultyBox.TabIndex = 4;
            this.facultyBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // foeBox
            // 
            this.foeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.foeBox.FormattingEnabled = true;
            this.foeBox.Items.AddRange(new object[] {
            "Очная",
            "Заочная (выходного дня) на базе СПО",
            "Очно-заочная (выходного дня)"});
            this.foeBox.Location = new System.Drawing.Point(9, 237);
            this.foeBox.Name = "foeBox";
            this.foeBox.Size = new System.Drawing.Size(215, 21);
            this.foeBox.TabIndex = 5;
            this.foeBox.SelectedIndexChanged += new System.EventHandler(this.foeBox_SelectedIndexChanged);
            // 
            // courceBox
            // 
            this.courceBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.courceBox.FormattingEnabled = true;
            this.courceBox.Items.AddRange(new object[] {
            "1 курс",
            "1 курс СПО",
            "2 курс",
            "2 курс СПО",
            "3 курс",
            "3 курс СПО",
            "4 курс",
            "4 курс СПО"});
            this.courceBox.Location = new System.Drawing.Point(9, 294);
            this.courceBox.Name = "courceBox";
            this.courceBox.Size = new System.Drawing.Size(215, 21);
            this.courceBox.TabIndex = 6;
            this.courceBox.SelectedIndexChanged += new System.EventHandler(this.courceBox_SelectedIndexChanged);
            // 
            // groupBox
            // 
            this.groupBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupBox.FormattingEnabled = true;
            this.groupBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBox.Location = new System.Drawing.Point(9, 356);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(215, 21);
            this.groupBox.TabIndex = 7;
            this.groupBox.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Факультет";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 221);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Форма обучения";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Курс";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Группа\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 400);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Неделя";
            // 
            // weekBox
            // 
            this.weekBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.weekBox.FormattingEnabled = true;
            this.weekBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.weekBox.Location = new System.Drawing.Point(9, 416);
            this.weekBox.Name = "weekBox";
            this.weekBox.Size = new System.Drawing.Size(215, 21);
            this.weekBox.TabIndex = 12;
            this.weekBox.SelectedIndexChanged += new System.EventHandler(this.weekBox_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 551);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 49);
            this.button2.TabIndex = 15;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(124, 78);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 16;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(124, 99);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBox2.Size = new System.Drawing.Size(100, 64);
            this.textBox2.TabIndex = 0;
            // 
            // timetableView
            // 
            this.timetableView.HideSelection = false;
            this.timetableView.Location = new System.Drawing.Point(312, 12);
            this.timetableView.Name = "timetableView";
            this.timetableView.Size = new System.Drawing.Size(620, 620);
            this.timetableView.TabIndex = 17;
            this.timetableView.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.timetableView);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.weekBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.courceBox);
            this.Controls.Add(this.foeBox);
            this.Controls.Add(this.facultyBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioAPI;
        private System.Windows.Forms.RadioButton radioLocal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox facultyBox;
        private System.Windows.Forms.ComboBox foeBox;
        private System.Windows.Forms.ComboBox courceBox;
        private System.Windows.Forms.ComboBox groupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox weekBox;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListView timetableView;
    }
}

