using Newtonsoft.Json;
using RaspClient.Models;
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

        private MRaspisanie jsonTimeTable = new MRaspisanie();

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
            timetableView.FullRowSelect = true;

            timetableView.Columns.Add("День недели", 100, HorizontalAlignment.Center);
            timetableView.Columns.Add("Дата", 100, HorizontalAlignment.Center);
            timetableView.Columns.Add("Время", 100, HorizontalAlignment.Center);
            timetableView.Columns.Add("Пара", 300, HorizontalAlignment.Center);
            timetableView.Columns.Add("Доп. инф.", 200, HorizontalAlignment.Center);

            string url = $"http://18.185.249.19/api/commands/weeks";
            string weeks = "";
            using (var webClient = new WebClient())
            {

                weeks = webClient.DownloadString(url);
            }
            string[] weeksArray = weeks.Split(',');
            for (int iterator = 0; iterator < weeksArray.Length; iterator++) 
            {
                weekBox.Items.Add(weeksArray[iterator]);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.jsonTimeTable = jsonTimeTable;

            for (int iterator = 0; iterator < jsonTimeTable.group.Length; iterator++)
            {
                

                for (int jterator = 0; jterator < jsonTimeTable.group[iterator].week.Length; jterator++) 

                {
                    ListViewItem row = new ListViewItem(jsonTimeTable.group[groupBox.SelectedIndex].week[iterator].dayName);

                    ListViewItem.ListViewSubItem date = new ListViewItem.ListViewSubItem(row, 
                        jsonTimeTable.group[groupBox.SelectedIndex].week[iterator].date);

                    ListViewItem.ListViewSubItem time = new ListViewItem.ListViewSubItem(row,
                        jsonTimeTable.group[groupBox.SelectedIndex].week[iterator].couples[jterator].time);

                    ListViewItem.ListViewSubItem discipline = new ListViewItem.ListViewSubItem(row,
                        jsonTimeTable.group[groupBox.SelectedIndex].week[iterator].couples[jterator].discipline);

                    ListViewItem.ListViewSubItem other = new ListViewItem.ListViewSubItem(row,
                       jsonTimeTable.group[groupBox.SelectedIndex].week[iterator].couples[jterator].otherInfo);


                    row.SubItems.Add(date);
                    row.SubItems.Add(time);
                    row.SubItems.Add(discipline);
                    row.SubItems.Add(other);
                    timetableView.Items.Add(row);
                }
                
            }
          

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = $"http://18.185.249.19/api/commands/{this.id.getId()}";

           
            using (var webClient = new WebClient())
            {
                // Выполняем запрос по адресу и получаем ответ в виде строки
                byte[] bytes = Encoding.Default.GetBytes(webClient.DownloadString(url));
                var response = Encoding.UTF8.GetString(bytes);
                textBox2.Text = response;//
                this.jsonTimeTable = JsonConvert.DeserializeObject<MRaspisanie>(response);
            }
            textBox1.Text = this.id.getId();

            groupBox.Items.Clear();
            for (int iterator = 0; iterator < jsonTimeTable.group.Length; iterator++)
            {
                groupBox.Items.Add(jsonTimeTable.group[iterator].groupName);
            }

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
            this.id.week = int.Parse(weekBox.SelectedItem.ToString());
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
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

    public class TimeTableContext
    {

        public string context { get; set; }

        public TimeTableContext(string context)
        {
            this.context = context;
        }

    }

    
}
