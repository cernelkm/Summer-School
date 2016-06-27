using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        /* functions 
        **We will need a function to calculate a given students tuition rate. 
        We will need a function to determine whether a student will be admitted or not
       ** We will need a function that will retrieve a list of currently enrolled students 
        We will need a function that will check on @mcgonagall on slack
       ** Print out a list of enrolled students
       ** We will need a function that will enroll students 
       ** We will need a  function that will unenroll students
          We will need a function for special tuition cases
        */

        //variables 
        static int Tuition = 200;
        static int NumberOfStudents = 15;
        static string[] Students = new string[NumberOfStudents];
        static int[] Fees = new int[NumberOfStudents];

        static void Main(string[] args)
        {
            int userInput = 0;
            // do {displaymenu()}while(userinput!= 3 or 4)
            do
            {
                userInput = DisplayMenu();

                if (userInput == 1)
                {
                    // enrollStudent(); // prompt user for name and store in list
                    Enroll();

                }

                if (userInput == 2)
                {
                    UnenrollStudent();
                }

                if (userInput == 3)
                {
                    PrintStudents();
                }

            } while (userInput != 4);


        }


        static public int DisplayMenu()
        {
            // creating the menu display
            Console.WriteLine();
            Console.WriteLine("Main Menu");
            Console.WriteLine();
            if (CountStudents() < Students.Length)
            {
                Console.WriteLine("1.Enroll New Student");

            }

            if (CountStudents() > 0)
            {
                Console.WriteLine("2. Uneroll Student");

            }

            Console.WriteLine("3. Display enrolled students");
            Console.WriteLine("4.Exit");

            Console.WriteLine();
            Console.Write("Please Enter a Number");

            var input = Console.ReadLine();

            return Convert.ToInt32(input);

        }

        static void Enroll()
        {
            Console.WriteLine("What is the student's name?");
            string student = Console.ReadLine();
            int spot = GetNextAvailableSpot();

            if ((spot != -1) && (CanEnroll(student)) && (CheckWithMcGonagall(student) == "no response"))
            {
                Students[spot] = student;

                Console.WriteLine("{0} is enrolled and will need to pay ${1}.00", student, CalculateTuition(student));
            }
            else if ((spot != -1) && (CanEnroll(student)) && (CheckWithMcGonagall(student) == "canEnroll"))
            {
                Students[spot] = student;

                Console.WriteLine("McGonagall has given permission for {0} to be enrolled and will need to pay ${1}.00", student, CalculateTuition(student));
            }
            else if ((spot != -1) && (CanEnroll(student)) && (CheckWithMcGonagall(student) == "Cannot Enroll"))
            {
                Console.WriteLine("McGonagall has not given permission for the student to enroll. Do not proceed.");
            }

            else
            {
                Console.WriteLine("Student Cannot Be Enrolled");

            }
        }

        static int GetNextAvailableSpot()
        {
            for (int i = 0; i < Students.Length; i++)
            {
                if (Students[i] == null)
                {
                    return i;

                }

            }
            return -1;

        }

        /// <summary>
        /// 
        /// </summary>
        static void PrintStudents()

        {
            int TotalTuition = 0;

            for (int i = 0; i < Students.Length; i++)
            {

                Console.WriteLine("{0}. {1} (${2}.00)", i, Students[i], CalculateTuition(Students[i]));
                TotalTuition = TotalTuition + CalculateTuition(Students[i]);

            }

            Console.WriteLine("Total Tuition is ${0}.00", TotalTuition);
        }

        static void UnenrollStudent()
        {
            PrintStudents();
            Console.WriteLine("Which student would you like to unenroll?");
            int input = Convert.ToInt32(Console.ReadLine());

            if (input < Students.Length)
            {
                string studentName = Students[input];

                Students[input] = null;

                Console.WriteLine("{0} has been unenrolled successfully", studentName);


            }


        }

        static bool CanEnroll(string Student)
        {
            string ForbiddenStudent = "Malfoy";

            if (Student.IndexOf(ForbiddenStudent) == -1)
            {
                return true;


            } else
            {
                return false;
            }
        }

        static int CountStudents()
        {
            int count = 0;
            for (int i = 0; i < Students.Length; i++)
            {
                if (Students[i] != null)
                {
                    count++;

                }

            }

            return count;

        }

        static int CalculateTuition(string Student)

        {
            string FirstName = "";
            string LastName = "";
            int CalculatedTuition = Tuition;

            if (Student != null)
            {
                FirstName = Student.Split(' ')[0];

                LastName = Student.Split(' ')[1];

                if (Student.IndexOf("Potter") != -1)
                {
                    CalculatedTuition = 100;

                }

                if ((Student.IndexOf("Longbottom") != -1) && (CountStudents() < 10))
                {
                    CalculatedTuition = 0;
                }

                if (FirstName[0] == LastName[0])

                {
                    CalculatedTuition = 180;
                }
            }
        

            

            if (Student == null)
            {
                CalculatedTuition = 0;
            }

            
            return CalculatedTuition;

        }

        static string CheckWithMcGonagall(string Student)
        {
           

            if ((Student.IndexOf("Tom") != -1))
            {
                
            
                return "canEnroll";
            }

            else if ((Student.IndexOf("Riddle") != -1) || (Student.IndexOf("Voldemort") != -1))
            {
                return "Cannot Enroll";
            }

            else
            {
                return "no response";
            }
            





        }

    }
}


                 
                     
                
                   
              
     



       

   
