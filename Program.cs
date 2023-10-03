using SecondOOP;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter now many persons you'll have: ");
        int number_of_persons = int.Parse(Console.ReadLine());
        if (number_of_persons <= 0)
        {
            Console.WriteLine("OK, BYE!");
            return;
        }
        List<Person> persons = new List<Person>();
        int selected_person = 0;
        for (int i = 0; i < number_of_persons; i++)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine($"Enter name of person №{i+1}: ");
                    string name = Console.ReadLine();
                    Console.WriteLine($"Enter fracture of person №{i+1}(viking or tori): ");
                    string fracture = Console.ReadLine();
                    Console.WriteLine($"Enter health of person №{i+1}: ");
                    float health = float.Parse(Console.ReadLine());
                    Console.WriteLine($"Enter x coord of person №{i+1}: ");
                    int x = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Enter y coord of person №{i+1}: ");
                    int y = int.Parse(Console.ReadLine());
                    if (name.Length > 0 && (fracture == "viking" || fracture == "tori") && health > 0)
                    {
                        persons.Add(new Person(name, fracture, health, x, y));
                        break;
                    } else
                    {
                        Console.WriteLine("Something went wrong! Try again");
                        continue;
                    }
                    
                }
                catch
                {
                    Console.WriteLine("Something went wrong! Try again");
                    continue;
                }
                break;
            }
        }

        while (true)
        {
            Console.Clear();
            Console.Write($"{selected_person} selected || ");
            for (int i = 0; i < persons.Count; i++)
            {
                if (persons[i].getHealth() > 50)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                } else if (persons[i].getHealth() > 25)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                } else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                int[] coords = persons[i].getCoords();
                Console.Write($"Pers№{i}:{{{coords[0]}, {coords[1]}}}");
                Console.ForegroundColor = ConsoleColor.White;
                if (i != persons.Count - 1)
                {
                    Console.Write(" | ");
                }
            }
            Console.WriteLine("\nQ - Show info\nW - change selected pers number\nE - hit\nR - regen health\nT - regen full health\nY - is assign to fracture");
            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.Q:
                    persons[selected_person].print();
                    Console.ReadKey();
                    break;

                case ConsoleKey.W:
                    while(true)
                    {
                        try
                        {
                            Console.WriteLine($"Enter number of new selected person(1-{persons.Count}): ");
                            int new_sel_pers = int.Parse(Console.ReadLine())-1;
                            if (new_sel_pers < 0 || new_sel_pers >= persons.Count) {
                                Console.WriteLine($"Incorrect number, you have only {persons.Count} persons. Try again");
                                continue;
                            } else if (persons[new_sel_pers].getHealth() <= 0) 
                            {
                                Console.WriteLine("Sorry, but this person is already dead :-(. Try again");
                                continue;
                            } else
                            {
                                selected_person = new_sel_pers;
                                break;
                            }
                        } catch
                        {
                            Console.WriteLine("Something went wrong! Try again.");
                        }
                    }
                    break;

                case ConsoleKey.E:
                    Console.WriteLine("Enter which number of person you want to hit(10% chance to crit and kill): ");
                    int n_of_atacked_person;
                    try
                    {
                        n_of_atacked_person = int.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Something went wrong! Press any key to continue: ");
                        Console.ReadKey();
                        continue;
                    }
                    if (n_of_atacked_person < 0 || n_of_atacked_person >= persons.Count)
                    {
                        Console.WriteLine($"Incorrect number, you have only {persons.Count} persons. Press any key to continue: ");
                        Console.ReadKey();
                        Console.Clear();
                    } else if (!(persons[n_of_atacked_person].getCoords()[0] == persons[selected_person].getCoords()[0]
                        && persons[n_of_atacked_person].getCoords()[1] == persons[selected_person].getCoords()[1]))
                    {
                        Console.WriteLine($"This person is too far away from selected person. Press any key to continue: ");
                        Console.ReadKey();
                        Console.Clear();
                    } else if (persons[n_of_atacked_person].getHealth() <= 0)
                    {
                        Console.WriteLine($"This person have 0 hp, he's already dead. Press any key to continue: ");
                        Console.ReadKey();
                        Console.Clear();
                    } else if (persons[n_of_atacked_person].getFracture() == persons[selected_person].getFracture()) 
                    { 
                        Console.WriteLine("This person in your fracture, you can't hit him! Press any key to continue: ");
                        Console.ReadKey();
                        Console.Clear();
                    } else
                    {
                        Random random = new Random();
                        if (random.Next(10) == 5)
                        {
                            Console.WriteLine($"You have CRIT!!! Person №{n_of_atacked_person} is dead! Press any key to continue: ");
                            Console.ReadKey();
                        } else
                        {
                            int dmg = random.Next(5, 15);
                            persons[n_of_atacked_person].uron(dmg);
                            Console.WriteLine($"You hited person №{n_of_atacked_person} on {dmg} damage! Press any key to continue: ");
                            Console.ReadKey();
                        }
                        Console.Clear();
                    }
                    break;

                case ConsoleKey.R:
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Enter now many health you want to regen: ");
                            int regen_health = int.Parse(Console.ReadLine());
                            persons[selected_person].doc(regen_health);
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Something went wrong! Try again.");
                        }
                    }
                    break;

                case ConsoleKey.T:
                    persons[selected_person].vost();
                    break;

                case ConsoleKey.Y:
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Enter fracture: ");
                            string checked_fracture = Console.ReadLine();
                            Console.WriteLine(persons[selected_person].check_fracture(checked_fracture));
                            Console.WriteLine("Press any key to continue: ");
                            Console.ReadKey();
                            break;
                        } catch
                        {
                            Console.WriteLine("Something went wrong! Try again.");
                            continue;
                        }
                    }
                    break;
            }
        }
    }
}