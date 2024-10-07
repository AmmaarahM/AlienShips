
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AlienShips
{
    internal class Program
    {
        static void Main(string[] args)
        {
            alien_ship[] ships = new alien_ship[10];//array of 10 ships

            StreamReader file = new StreamReader("C:\\Users\\m_amm\\Downloads\\ships.txt");//open streamreader
            {
                for (int i = 0; i < ships.Length; i++) //loop through the file storing groups to temp
                {
                    string tempName = file.ReadLine();
                    int tempHP = Convert.ToInt32(file.ReadLine());
                    int tempSpeed = Convert.ToInt32(file.ReadLine());
                    int tempDamage = Convert.ToInt32(file.ReadLine());
                    bool tempFriendly = Convert.ToBoolean(file.ReadLine());
                    ships[i] = new alien_ship(tempName, tempHP, tempSpeed, tempDamage, tempFriendly);//instantiate new alienship from temp
                }
            }
            file.Close();//close the file

            Console.WriteLine(find_ships(ships, 150, 0, 100, true));
            Console.WriteLine(find_ships(ships, 150, 0, 0, false));
            Console.WriteLine(find_ships(ships, 150, 0, 100, false));
            Console.WriteLine(find_ships(ships, 20, 90, 5, false));

            Console.ReadKey();
        }
         public static String find_ships(alien_ship[] ship, int HP, int speed, int damage, bool isfriendly)
        {

            for (int i = 0;i < ship.Length;i++)
            {
                if (ship[i].getHP() >= HP){
                    if (ship[i].getspeed() >= speed)
                    {
                        if (ship[i].getdamage() >= damage)
                        {
                            if (ship[i].getisfriendly() == isfriendly){
                                return ship[i].getname();
                            }
                        }
                    }
                }
            }
            return "No ships found";

        }
    }
    class space_object
    {
        private string name;
        private int HP;
        public space_object(string new_name, int new_HP) 
        {
            this.name = new_name;
            this.HP = new_HP;
        }
        public string getname()
        { return name; }
        public int getHP() 
        { return HP; }
    }
    class alien_ship : space_object
    {
        private int speed;
        private int damage;
        private bool isfriendly;
        public alien_ship(string name, int HP,int speed, int damage, bool isfriendly) : base(name, HP)
        {
            this.speed = speed;
            this.damage = damage;
            this.isfriendly = isfriendly;
            
        }
        public int getspeed()
        { return speed; }
        public int getdamage()
        { return damage; }
        public bool getisfriendly()
        { return isfriendly; }
    }

}
