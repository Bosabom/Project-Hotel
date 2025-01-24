using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
namespace lab6_multithreading_
{
    public partial class Report_From_XML : Form
    {
        Hotel hotel;
        XmlSerializer serialization = new XmlSerializer(typeof(Hotel));
        BindingSource bind2;
        public Report_From_XML()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bind2 = new BindingSource();
            using (FileStream fs = new FileStream("hotel1.xml", FileMode.OpenOrCreate))
            {
                hotel = (Hotel)serialization.Deserialize(fs);
                Console.WriteLine("Объект десериализован");

            }
            bind2.DataSource = hotel.rooms;
            dataGridView1.DataSource = bind2;

        }
    }
}
