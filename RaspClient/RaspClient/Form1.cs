using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaspClient
{
    public partial class Form1 : Form
    {

        private idFromBoxes id = new idFromBoxes();

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.id.faculty = facultyBox.SelectedIndex;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioAPI_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radioAPI.Checked = true;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.id.faculty = facultyBox.SelectedIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = $"http://18.185.249.19/api/commands/{this.id.getId()}";

           
            using (var webClient = new WebClient())
            {
                // Выполняем запрос по адресу и получаем ответ в виде строки
                var response = webClient.DownloadString(url);
                textBox2.Text = response;
            }
            textBox1.Text = this.id.getId();
            
           
        }

        private void foeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.id.foe = foeBox.SelectedIndex;
        }

        private void courceBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.id.cource = courceBox.SelectedIndex;
        }

        private void weekBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.id.week = int.Parse(weekBox.Text);
        }
    }

    public class idFromBoxes
    {
        public int faculty { get; set; }
        public int foe { get; set; }
        public int cource { get; set; }
        public string group { get; set; }
        public int week { get; set; }

        public string getId()
        {
            try
            {
                return $"{faculty+1}{foe+1}{cource+1}{week}";
            }
            catch(Exception e)
            {
                MessageBox.Show("Один из элементов списка указан не верно","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }
    }
}
