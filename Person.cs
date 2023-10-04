using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SecondOOP
{
    public class Person
    {
        public List<int[]> coords_of_persons = new List<int[]>();
        private static int counter_of_instance = 0;
        private int num_of_person;
        private string name;
        private string fracture;
        private float max_health;
        private float health;
        private int x;
        private int y;
        public Person(string name, string fracture, float health, int x, int y)
        {
            this.name = name;
            this.fracture = fracture;
            this.health = health;
            this.max_health = health;
            this.x = x;
            this.y = y;
            coords_of_persons.Add(new int[] { x, y });
            num_of_person = counter_of_instance;
            counter_of_instance++;
        }

        public void movex(int dx)
        {
            x += dx;
            coords_of_persons[num_of_person][0] = x;
        }

        public void movey(int dy)
        {
            y += dy;
            coords_of_persons[num_of_person][1] = y;
        }

        public void del() 
        {
            health = 0;
        }

        public void uron(int uron)
        {
            health -= uron;
            if (health <= 0)
            {
                Console.WriteLine($"Person {num_of_person} dead! Press any key to continue");
                Console.ReadKey();
            }
        }

        public void doc(int du)
        {
            if (health + du > max_health)
            {
                health = max_health;
            } else
            {
                health += du;
            }
        }

        public void vost()
        {
            health = max_health;
        }

        public bool check_fracture(string frac)
        {
            return fracture == frac;
        }

        public void print()
        {
            Console.WriteLine($"name - {name}\nfracture - {fracture}\nhealth - {health}\nx - {x}\ny - {y}");
        }

        public float getHealth()
        {
            return health;
        }

        public int[] getCoords()
        {
            return new int[] {x, y };
        }

        public string getFracture()
        {
            return fracture;
        }
    }
}
