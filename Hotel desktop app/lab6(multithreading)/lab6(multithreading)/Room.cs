using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Serialization;
namespace lab6_multithreading_
{
    [Serializable]
    public class Room
    {
        
        public int Room_Number { get; set; }
        private bool state = false;//true когда занято, false когда свободно 
        private double cost { get; set; }
        public int Days_Of_Living { get; set; } = 0;
        public string What_State_Of_Room { get; set; }
        private int Num_Of_Beds { get; set; }
        public Room() { }
        public Room(int _room_num)
        {
            Room_Number = _room_num;
            Random Rand = new Random();
            Days_Of_Living = Rand.Next(0, 21);
            if (!state && Days_Of_Living!=0)
                What_State_Of_Room = "Occupied";
            else
                What_State_Of_Room = "Free";
        }
        public void Change_Room_State()
        {
            Days_Of_Living--;
            if (Days_Of_Living == 0)
            {
                What_State_Of_Room = "Free";
                
            }
            

        }
    }
}
