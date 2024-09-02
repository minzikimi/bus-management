using System;
using System.Diagnostics.CodeAnalysis;
using System.IO.Pipes;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Bus_Project
{
    class Passenger
    {
        // Data about passenger
        private int age;
        //create properties
        public int Age 
        { 
            get { return age; }
            set { age = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string gender;
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public Passenger(int age, string name, string gender)//constructor
        {
            Age = age;
            Name = name;
            Gender = gender;
        }


        public string GenderName () //method for clarify gender name
        {
            string genderTemp = "";
             
            switch (gender) 
            {
                case "M":
                    genderTemp = "Male";
                    break;

                case "F":
                    genderTemp = "Female";
                break;

                case "X":
                    genderTemp = "Non-binary";
                    break;
            }
            return genderTemp;
        }

    }
    class Bus
    {
       
        public int passengerSeats = 25; //create this to control how many seats are in total
        public int passengersOnBoard = 0; // this will check how many passengers are added to the array
        Passenger[] person = new Passenger[25]; //instantiate array of object person..

        public void Run()
        {
            while(true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Welcome to the awesome Bus-simulator");
              
                Console.WriteLine("Please select the option.");
                Console.WriteLine("[A]Add passenger");
                Console.WriteLine("[P]Show passengers");
                Console.WriteLine("[I]Passenger Information");
                Console.WriteLine("[R]Remove passenger");
                Console.WriteLine("[S]Sort passengers");
                Console.WriteLine("[E]End the program");

                Console.Write("Type : ");

                
                ConsoleKeyInfo userChoice = Console.ReadKey(true);//use this to make user key experience more entertaining

                Console.Clear();
                Console.WriteLine("");

                switch (userChoice.Key)
                {
                    case ConsoleKey.A: // Add passenger
                        Console.Clear();
                        Console.WriteLine("============== Add passenger ==============");
                        AddPassenger();
                        break;
                    case ConsoleKey.P: // Print current passengers 
                        Console.Clear();
                        Console.WriteLine("========== Here are current passengers on board. ==========");
                        PrintBus();
                        break;
                    case ConsoleKey.I: //sub menu
                        Console.WriteLine("========== Passenger information ==========");
                        Console.WriteLine("[T]Calculate passangers total age");
                        Console.WriteLine("[A]Calculate average age");
                        Console.WriteLine("[M]Find the eldest passenger");
                        Console.WriteLine("[F]Find passenger by age group");
                        Console.WriteLine("[G]Show passenger's gender\n");
                        Console.Write("Type : ");
                        ConsoleKeyInfo userChoiceInfo = Console.ReadKey(true); 

                            switch (userChoiceInfo.Key)
                            {
                                case ConsoleKey.T: //total age
                                Console.Clear();
                                Console.WriteLine("============ Total Age ============");
                                if (passengersOnBoard <= 0)
                                {
                                    Console.WriteLine("There is no passenger yet.\n");
                                }
                                else
                                {
                                    int totalAge = CalcTotalAge();
                                    Console.WriteLine("The total age of passengers are " + totalAge + "\n");
                                }
                                    Console.WriteLine("Please press any key to continue..");
                                    Console.ReadKey();
                                    Console.Clear();
                                
                                break;
                                case ConsoleKey.A://average age
                                Console.Clear();
                                Console.WriteLine("=========== Average Age ============");
                                if (passengersOnBoard <= 0)
                                {
                                     Console.WriteLine("There is no passenger yet.\n");
                                }
                                else
                                {
                                    double averageAge = CalcAverageAge();
                                    Console.WriteLine("The average age of passengers are " + averageAge + "\n");
                                }
                                    Console.WriteLine("Please press any key to continue..");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case ConsoleKey.M:// max age
                                Console.Clear();
                                Console.WriteLine("============ Eldest passenger's age ============");
                                if (passengersOnBoard <= 0)
                                {
                                    Console.WriteLine("There is no passenger yet.\n");
                                }
                                else
                                {
                                    int maxAge = CalcMaxAge();
                                    Console.WriteLine("The oldest passenger's age is " + maxAge + "\n");
                                }
                                    Console.WriteLine("Please press any key to continue..");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case ConsoleKey.F://find age
                                    Console.Clear();
                                    Console.WriteLine("========== Find age by group ==========");
                                    FindAge();
                                    Console.WriteLine("Please press any key to continue..");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                case ConsoleKey.G://show gender
                                    Console.Clear();
                                    Console.WriteLine("========== Show passenger's gender ==========");
                                    PrintSex();
                                    Console.WriteLine("Please press any key to continue..");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("\nPlease only choose something in the options\n");
                                    break;
                            }
                        break;
               
                    case ConsoleKey.R://remove passenger
                        Console.Clear();
                        Console.WriteLine("============ Remove passenger ============");
                        Remove();
                        Console.WriteLine("\nPlease press any key to continue..");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case ConsoleKey.S://sort passenger
                        Console.Clear();
                        Console.WriteLine("=============  Sort passengers ============== ");
                        SortBus();
                        Console.WriteLine("\nPlease press any key to continue..");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case ConsoleKey.E://end program
                        Console.WriteLine("Bye See you again!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Number you typed is out of range. Please type again.");
                        Console.WriteLine("");
                        break;
                }

            }
        }


        public void AddPassenger()
        {
            //create variable to get passenger information
            int age = 0;
            string gender = null;
            string name = null;
            Console.WriteLine("[!] Age limit for passengers : 1 - 100 [!]\n");

            if (passengersOnBoard < passengerSeats)
            {
                //build the loop with condition !ageCheck (as long as ageCheck is false (!))
                while (true)
                {
                    //try this code block, if it is successful we continue and ageCheck becomes true.
                    try
                    {
                        Console.Write("Enter the age: ");
                        //person[passengersOnBoard].age = int.Parse(Console.ReadLine());
                        age = int.Parse(Console.ReadLine());
                        if(age > 0 && age < 101)
                        {
                            break;// Successful input
                        }
                        else
                        { 
                            Console.WriteLine("Age should be between 1 to 100 years old for this bus.");
                        }
                    }

                    //if we fail we end up here and loop again since ageCheck is still false.
                    catch
                    {
                        Console.WriteLine("Invalid input. Only numbers(integer) allowed. Try again . . .");
                        Console.ReadKey(true);
                    }
                }

                // Input gender 
                while (true)
                {
                    try
                    {
                        Console.Write("What is the passengers gender? Type M for male, F for female, X for other : ");
                        gender = Console.ReadLine().ToUpper(); //Convert userinput(string) to uppercase to unify  (to make it look more tidy)
                        if (gender == "M" || gender == "F" || gender == "X")
                        {
                            
                            break;// Successful input
                        }
                        else
                        {
                            Console.WriteLine("That is out of range, please try again");
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadKey(true);
                    }
                }
                
                //input name
                Console.Write("Passengers Name : ");
                try
                {
                    name = Console.ReadLine().ToUpper();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                person[passengersOnBoard] = new Passenger(age, name, gender); //create object and pass information to class Passenger

                //Add the passenger to the total number of passengers on board
                passengersOnBoard++;
                Console.WriteLine("\nPassenger is successfully added!");
            }
            else //if passengersonboard is not greater than passengerseat, the bus is full
            {
                Console.WriteLine("Sorry, The bus is full!");
                Console.ReadKey();
            }
            Console.WriteLine("\nPlease press any key to continue..");
            Console.ReadKey();
            Console.Clear();
        }


        public void PrintBus()
        {
            int seatNumber = 0; 
            if (passengersOnBoard <= 0) 
            {
                Console.WriteLine("There is no passenger yet.\n");
            }
            else
            {
                for (int i = 0; i < passengersOnBoard; i++)
                {
                    seatNumber++;//increase seatNumber to show designated number

                        Console.WriteLine("----------------------");
                        Console.WriteLine("Passenger no." + seatNumber + ":");
                        Console.WriteLine("Age: " + person[i].Age);
                        Console.WriteLine("Name: " + person[i].Name);
                        Console.WriteLine("Gender: " + person[i].Gender);
                        Console.WriteLine("----------------------");
                }
            }
            Console.WriteLine("\nPlease press any key to continue..");
            Console.ReadKey();
            Console.Clear();
        }

        public int CalcTotalAge()
        {
            int totalAge = 0;
         
            for (int i = 0; i < passengersOnBoard; i++)
            {
                totalAge += person[i].Age;
            }
            return totalAge;
            Console.ReadKey();
        }

        public double CalcAverageAge()
        {
            double totalAge = 0;
            double averageAge = 0;
          
            for (int i = 0; i < passengersOnBoard; i++)
            {
                totalAge += person[i].Age;
            }
            averageAge = totalAge / passengersOnBoard;
            averageAge = (double)Math.Round(averageAge, 2); //rounding the age to avoid long decimal number
            return averageAge;
            Console.ReadKey();
        }

        public int CalcMaxAge()
        {
            //assign first element to maxAge as a starting point for the loop/if
            int maxAge = person[0].Age;
          
            for (int i = 1; i < passengersOnBoard; i++)
            {
                // check if age[i] is bigger then maxAge (age[0])
                // if age[i] is bigger then we assign age[i] to overwrite maxAge with it
                if (person[i].Age > maxAge)
                {
                    maxAge = person[i].Age;
                }
            }
            return maxAge;
            Console.ReadKey();
        }


        public void FindAge()
        {

                Console.WriteLine("Please select an option in the menu: ");
                Console.WriteLine("1.Show age between 1-19");
                Console.WriteLine("2.Show age between 20-39");
                Console.WriteLine("3.Show age between 40-59");
                Console.WriteLine("4.Show age between 60-79");
                Console.WriteLine("5.Show age between 80-100");
                Console.WriteLine("");
                Console.Write("Type : ");
            try
            {
                var userChoiceAgeGroup = int.Parse(Console.ReadLine()); 

            Console.Clear();

                int ageCountTemp = 0;       
                switch (userChoiceAgeGroup)
                {
                    case 1:
                        ageCountTemp = 0; //Create temporary variable for counting how many passengers will be added to this section

                        for (int z = 0; z < passengersOnBoard; z++)
                            {
                                if (person[z].Age >= 1 && person[z].Age <= 19)
                                {
                                Console.WriteLine(person[z].Age + " years old : " + person[z].Name);
                                }
                                else 
                                {
                                ageCountTemp++; //if there are no passengers between designated ages, this variable will increase
                                }
                             }
                        if (ageCountTemp == passengersOnBoard) // if ageCountTemp from for loop is equal to total passengers on board, then means there is no passengers
                        {
                            Console.WriteLine("There is no passenger in this age group yet!");
                        }
                        
                        Console.WriteLine();
                        break;
                    case 2:
                        ageCountTemp = 0;

                        for (int z = 0; z < passengersOnBoard; z++)
                        {
                            if (person[z].Age >= 20 && person[z].Age <= 39)
                            {
                                Console.WriteLine(person[z].Age + " years old : " + person[z].Name);
                            }
                            else
                            {
                                ageCountTemp++;
                            }
                        }
                        if (ageCountTemp == passengersOnBoard)
                        {
                            Console.WriteLine("There is no passenger in this age group yet!");
                        }

                        Console.WriteLine();
                        break;
                    case 3:
                        ageCountTemp = 0;

                        for (int z = 0; z < passengersOnBoard; z++)
                        {
                            if (person[z].Age >= 40 && person[z].Age <= 59)
                            {
                                Console.WriteLine(person[z].Age + " years old : " + person[z].Name);
                            }
                            else
                            {
                                ageCountTemp++;
                            }
                        }
                        if (ageCountTemp == passengersOnBoard)
                        {
                            Console.WriteLine("There is no passenger in this age group yet!");
                        }

                        Console.WriteLine();
                        break;
                    case 4:
                        ageCountTemp = 0;

                        for (int z = 0; z < passengersOnBoard; z++)
                        {
                            if (person[z].Age >= 60 && person[z].Age <= 79)
                            {
                                Console.WriteLine(person[z].Age + " years old : " + person[z].Name);
                            }
                            else
                            {
                                ageCountTemp++;
                            }
                        }
                        if (ageCountTemp == passengersOnBoard)
                        {
                            Console.WriteLine("There is no passenger in this age group yet!");
                        }

                        Console.WriteLine();
                        break;
                    case 5:
                        ageCountTemp = 0;

                        for (int z = 0; z < passengersOnBoard; z++)
                        {
                            if (person[z].Age >= 80 && person[z].Age <= 100)
                            {
                                Console.WriteLine(person[z].Age + " years old : " + person[z].Name);
                            }
                            else
                            {
                                ageCountTemp++;
                            }
                        }
                        if (ageCountTemp == passengersOnBoard)
                        {
                            Console.WriteLine("There is no passenger in this age group yet!");
                        }

                        Console.WriteLine();
                        break;

                    default:
                        Console.WriteLine("\nPlease only choose something in the options\n");
                        break;
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message); // exception handling in case of incorrect type
                Console.ReadKey(false);
            }
        }
        public void SortBus()
        {
            Passenger temp = null; //prepare temp to handle passanger class objects for the sort
            
            if (passengersOnBoard <= 0)
            {
                Console.WriteLine("\nThere is no passenger yet.\n");
            }
            else
            {
                for (int i = 0; i < passengersOnBoard - 1; i++) //sort passengers by age by using bubble sort
                {
                     for (int j = 0; j < passengersOnBoard - (i + 1); j++)
                     {
                         if (person[j].Age > person[j+1].Age)
                         {
                          temp = person[j + 1];
                          person[j + 1] = person[j];
                          person[j] = temp;
                          }
                     }
                }
                Console.WriteLine("Here's the sorted passengers by age.");
                for (int k = 0; k < passengersOnBoard; k++) 
                {
                    Console.WriteLine(person[k].Age + " years old : " + person[k].Name);
                }
            }
           
            
        }

        public void PrintSex()
        {
            if (passengersOnBoard <= 0)
            {
                Console.WriteLine("There is no passenger in this age group.\n");
            }
            else
            {
                for (int j = 0; j < passengersOnBoard; j++)
                {
                    
                    Console.WriteLine("Passenger no." + (j+1) + " " + person[j].Name + " : " + person[j].GenderName());
                }
                Console.WriteLine();
            }

        }

        public void Remove()
        {
            int seatNumber = 0;
            int index = 0;   //variable to find out element user want to remove         

            for (int z = 0; z < passengersOnBoard; z++)
            {
                seatNumber++; //increase seatNumber to show designated number
                if (person == null) 
                {
                    Console.WriteLine("The seatnumber no. {0} is empty", seatNumber);   
                }
                else
                {
                    Console.WriteLine("Seatnumber no.{0} is occupied with name {1}", seatNumber , person[z].Name);
                }
            }
            
             if (passengersOnBoard > 0)
             {
                 while (true)
                 {
                     Console.Write("\nChoose a seatnumber for the passenger to be removed : ");
                     try
                     {
                        index = int.Parse(Console.ReadLine()) - 1; //index is -1 to get exact array index instead of seat number shown in the program

                        if (index < 0 || index >= passengersOnBoard) //if index is below 0 or same as passengerOnBoard or more than passengersOnBoard ask user to choose other seatnumber

                        {
                            Console.WriteLine("There is no passeger here. Please choose another seat");
                        }
                        else
                        {
                            Console.WriteLine("Passenger successfully removed.");
                            break; //succesfull input
                        }
                     }
                    catch
                     {
                        Console.WriteLine("Type only numbers!"); //incase user type invalid value
                     }
                 }

                    person[index] = null; //sets index to null
                    Passenger temp = null;//prepare temp to handle passanger class objects for the sort


                    //the magic to remove and re-arrange object array
                    for (int i = 0; i < passengersOnBoard - 1; i++)
                    {
                        for (int j = 0; j < passengersOnBoard - (i + 1); j++)
                        {
                            if (person[j] == null)
                            {
                                temp = person[j + 1]; //create another temporary object to be able to shift passengers to the left
                                person[j + 1] = person[j];
                                person[j] = temp;
                            }
                        }
                    }
                    passengersOnBoard--; //reduce passengerOnBoard after users successfull input
                    
                }
                else
                {
                    Console.WriteLine("There are currently no passengers on board.");  
                }
               
        }
          

        class Program
        {
            static void Main(string[] args)
            {
                var bus = new Bus();
                bus.Run();
                
                Console.Write("Press any key to continue . . . ");
                Console.ReadKey(true);
            }
        }
    }
}