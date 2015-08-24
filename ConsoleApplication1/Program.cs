using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person();

            //We used to have to do lots of nested if statements:
            if(p.Child == null)
                Console.WriteLine(0);
            else
                Console.WriteLine(p.Child.NumberOfArms);

            //Now we can do this:
            Console.WriteLine(p.Child?.NumberOfArms);

            //We can also use ??
            Console.WriteLine(p.Child?.Address?.Address1??"No Address");

            //This is one of my favourite features - string interpolation! So much cleaner than using string.Format
            string name = "Bob";
            int age = 25;
            decimal money = 42.6M;

            string output = $"{name} is {age} years old and has {money:C} in his pocket.";

            Console.WriteLine(output);
            Console.ReadKey();


        }

        static int ConvertToInt(string someValue)
        {
            try
            {
                return int.Parse(someValue);
            }
            catch (Exception)
            {
                //Now we can refer to the name of a variable, not always useful but it give compile ttime checking on the error message
                throw new ArgumentException("The value for " + nameof(someValue) + " was not a number");
            }
        }

        //How about expression–Bodied methods? Cleaner than writing a full method when you only have a single line inside it
        private static string GetTime() => DateTime.Now.ToString("yyyy-MM-dd hh:mm");

        private static int Add(int a, int b) => a + b;
    }

    public class Person
    {
        public int Id { get; set; }

        //Auto property initialiser, no need to make a constructor just to do this:
        public string Name { get; set; } = "Bob";

        public Child Child { get; set; }
    }

    public class Child
    {
        public int Id { get; set; }
        public string NumberOfArms { get; set; }

        public Address Address { get; set; }
    }

    public class Address
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
    }
}
