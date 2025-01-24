using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml.Serialization;
namespace lab6_multithreading_
{   [Serializable]
    public class Hotel
    {
        public bool season=true;//true-открыт для туристов (сезон отпусков),false-закрыт для туристов
        public List<Room> rooms = new List<Room>();
        public Hotel()
        { 
        }
        public void Process_Begin()
        {
            
            int Days_Of_Hotel_Working = 0;
            while (Days_Of_Hotel_Working<365) {
                for (int i = 0; i < rooms.Count; i++)
                {
                    if (rooms[i].Days_Of_Living != 0)
                    {
                        rooms[i].Change_Room_State();
                    }
                    else
                    {
                        Random rand = new Random();
                        rooms[i].Days_Of_Living = rand.Next(0, 21);
                        rooms[i].What_State_Of_Room = "Occupied";
                    }
                }
                Thread.Sleep(1000);
              
                Days_Of_Hotel_Working++;
               
            }

        }
    }
}
