using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
namespace lab6_multithreading_
{
    public partial class Form1 : Form
    {
       
        BindingSource binding;
        Hotel hotel;
      
        Thread mythread;
        XmlSerializer serialization = new XmlSerializer(typeof(Hotel));
        Report_From_XML form2 = new Report_From_XML();
        public Form1()
        {
            binding = new BindingSource();
            // hotel = new Hotel();

            using (FileStream fs = new FileStream("hotel.xml", FileMode.OpenOrCreate))
            {
                hotel = (Hotel)serialization.Deserialize(fs);
                Console.WriteLine("Объект десериализован");

            }

            mythread = new Thread(hotel.Process_Begin);
            InitializeComponent();
            binding.DataSource = hotel.rooms;
            dataGridView1.DataSource = binding;
            button1.Click += Button1_Click;
            

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < hotel.rooms.Count; i++)
            {
                if (hotel.rooms[i].Days_Of_Living != 0)
                {
                    hotel.rooms[i].Change_Room_State();
                }
            }
            binding.ResetBindings(true);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int RoomNumber = 0;
            Random rand = new Random();
                RoomNumber = rand.Next(0, 200);
            hotel.rooms.Add(new Room(RoomNumber));
         
            binding.ResetBindings(true);
        }
        private void button2_Click(object sender, EventArgs e)
        {
           hotel.season = true;
            mythread.Start();
            timer1.Start();
            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            hotel.season = false;
            Open_Or_Close();

        }

        public void Open_Or_Close()
        {
            if (!hotel.season)
            {
                mythread.Suspend();
            }
          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        binding.ResetBindings(true);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            mythread.Resume();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mythread.IsAlive) { mythread.Suspend(); timer1.Stop(); }
            
            
            FileInfo fileInf = new FileInfo($"hotel.xml");
            if (fileInf.Exists)
            {
                fileInf.Delete();
                
            }
            using (FileStream fs = new FileStream("hotel.xml", FileMode.OpenOrCreate))
            {
                serialization.Serialize(fs, hotel);
                Console.WriteLine("Объект сериализован");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FileInfo fileInf = new FileInfo($"hotel1.xml");
            if (fileInf.Exists)
            {
                fileInf.Delete();
               
            }
            using (FileStream fs = new FileStream("hotel1.xml", FileMode.OpenOrCreate))
            {
                serialization.Serialize(fs, hotel);
                Console.WriteLine("Объект сериализован");
            }

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            form2.ShowDialog();
        }
    }
}
