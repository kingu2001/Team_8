using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Linq;
 
namespace Persistens
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Person person = new Person("Anders Andersen", new DateTime(1975, 8, 24), 175.9, true, 3);


            DataHandler handler = new();

            // Create database table
            //handler.CreateTable();

            // Save person to database
            //handler.SavePerson(person);

            // Load person from database
            Person person = handler.LoadPerson("\"Anders Andersen\"; DROP TABLE Persons;");
            Console.WriteLine(person.MakeTitle());
            Console.Read();
        }
    }
}