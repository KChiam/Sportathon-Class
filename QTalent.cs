using System;
using static System.Console;


namespace AssignmentB
{
    internal class QTalent
    {
        static void Main(string[] args)
        {
            string pname;
            string pnationality;
            char peventcode;
            int loopcount = 0;
            int inputnum;

            //task a
            inputnum = CheckInput();
            
            //task b
            double revenue = CalcCost(inputnum);
            WriteLine("The expected revenue with {0} participants is : {1}", inputnum, revenue.ToString("C"));
            
            //task c
            Sportathon[] participant = new Sportathon[inputnum];

            while (loopcount < inputnum)
            {
                GetInfo(out pname, out pnationality);
                peventcode = EnterCode();
                participant[loopcount] = new Sportathon(pname, pnationality, peventcode);
                loopcount++;

            }

            //task d
            DisplayInfo(participant);
            
            //task e
            DisplayCode(participant);


        }
        //task a method
        public static int CheckInput()
        {
            const int MIN = 0;
            const int MAX = 20;
            int enterednum;
            Write("Enter the number of participants between 0-20(inclusive): ");
            string input = ReadLine();

            if (int.TryParse(input, out enterednum) && (enterednum > MIN && enterednum < MAX))
            {
                return enterednum;

            }

            else
            {
                while (!int.TryParse(input, out enterednum) || (enterednum <= MIN || enterednum > MAX))
                {
                    Write("Please re-enter the number of Participants 0-20(inclusive): ");
                    input = ReadLine();

                }

                return enterednum;
            }
        }
        //task b method
        public static double CalcCost(int inputnum)
        {
            WriteLine("------------------------------------------------------------------------------------");
            double cost = 20.00;
            double revenue = inputnum * cost;
           
            return revenue;

        }
        //task c methods
        public static void GetInfo(out string pname, out string pnationality)
        {

            WriteLine("------------------------------------------------------------------------------------");
            
            Write("Please enter Participant's Name: ");
            pname = ReadLine();


            Write("Please enter Participant's Nationality: ");
            pnationality = ReadLine();


        }

        public static char EnterCode()
        {
            char enteredchar;

            WriteLine("Here are the Event Codes and the corresponding Event Description: ");

            for (int i = 0; i < Sportathon.eventcodes.Length; i++)
            {
                WriteLine(Sportathon.eventcodes[i] + " for " + Sportathon.eventdescriptions[i]);
            }

            WriteLine();

            Write("Please enter a valid Event Code: ");
            string input = ReadLine();

            while ((!char.TryParse(input, out enteredchar)) || (enteredchar != Sportathon.eventcodes[0] && enteredchar != Sportathon.eventcodes[1] && enteredchar != Sportathon.eventcodes[2] && enteredchar != Sportathon.eventcodes[3] && enteredchar != Sportathon.eventcodes[4] && enteredchar != Sportathon.eventcodes[5] && enteredchar != Sportathon.eventcodes[6] && enteredchar != Sportathon.eventcodes[7]))
            {
                Write("Invalid code. Please re-enter Event Code: ");
                input = ReadLine();

            }

            return enteredchar;

        }
        //task d method
        public static void DisplayInfo(Sportathon[] participant)
        {
            WriteLine("------------------------------------------------------------------------------------");

            WriteLine("{0,15} {1,20} {2, 20} {3, 20}", "Name", "Nationality", "Event Code", "Event Description");

            for (int i = 0; i < participant.Length; i++)
            {
                WriteLine("{0,15}  {1,20} {2, 15} {3, 20}", participant[i].Name, participant[i].Nationality, participant[i].Eventcode, participant[i].Eventdescription);
            }

           

        }

        //task e method
        public static void DisplayCode(Sportathon[] participant)
        {
            WriteLine("------------------------------------------------------------------------------------");

            const char QUIT = 'X';

            WriteLine("Here are the Event Codes and the corresponding Event Description: ");

            for (int i = 0; i < Sportathon.eventcodes.Length; i++)
            {
                WriteLine(Sportathon.eventcodes[i] + " for " + Sportathon.eventdescriptions[i]);
            }

            WriteLine("Please enter an eventcode to see the participant's details or 'X' to quit: ");
            char enteredcode = Convert.ToChar(ReadLine());


            while (enteredcode != QUIT)
            {

                WriteLine();
                WriteLine("The details of the participants with that event code are: ");
                    
                for (int i = 0; i < participant.Length; i++)
                {
                    if (enteredcode == participant[i].Eventcode)
                    {
                        WriteLine("Name: " + participant[i].Name + " Nationality: " + participant[i].Nationality);

                        
                    }
                }
                
                WriteLine();
                WriteLine("Please enter another event code or enter 'X' to quit: ");
                enteredcode = Convert.ToChar(ReadLine());
            }

        }
        //class ends here

        //Class Sportathon
        public class Sportathon
        {
            //declare variable for participant's name and nationality
            //fields
            char eventcode;
            string eventdescription;


            //declaring public static array for event codes and eventcategories
            public static char[] eventcodes = new char[8] { 'C', 'P', 'T', 'B', 'S', 'R', 'W', 'O' };
            public static string[] eventdescriptions = new string[8] { "Cricket", "Pole-Jumping", "Tennis", "Badminton", "Swimming", "Running", "Weight-Lifting", "Other" };

            //constructors
            public Sportathon() { } //default
            public Sportathon(string aname, string aNationality, char aneventcode)
            {
                Name = aname;
                Nationality = aNationality;
                Eventcode = aneventcode;
            }


            //properties
            //auto-implemented Properties for Participant's Name and Nationality
            public string Name { get; set; }

            public string Nationality { get; set; }

            //property with method at set to check eventcode
            public char Eventcode
            {
                get { return eventcode; }
                set
                {
                    eventcode = value;
                    CheckCode(); //check if eventcode received is valid
                }
            }
            //read-only property
            public string Eventdescription
            {
                get
                {
                    return eventdescription;
                    //No set as the property is read-only
                }
            }

            //methods
            public void CheckCode()
            {

                for (int i = 0; i < eventcodes.Length; ++i)
                {

                    if (eventcode != eventcodes[0] && eventcode != eventcodes[1] && eventcode != eventcodes[2] && eventcode != eventcodes[3] && eventcode != eventcodes[4] && eventcode != eventcodes[5] && eventcode != eventcodes[6] && eventcode != eventcodes[7])
                    {
                        eventcode = 'N';
                        eventdescription = "Not valid";
                    }
                    else if (eventcode == eventcodes[i])
                    {
                        eventcode = eventcodes[i];
                        eventdescription = eventdescriptions[i]; //setting eventdescription only where there is a valid corresponding eventcode
                    }
                }
            }
        }
    }
}


      


        



