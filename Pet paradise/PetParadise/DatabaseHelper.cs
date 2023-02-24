using System;
using System.Collections.Generic;
using System.Text;

namespace PetParadise
{
    
    public class DatabaseHelper
    {
        public static string con = "Server=10.56.8.36; database=P1_DB_2023_08; user id=PROJECT_USER_08; password=OPENDB_08;";
        public static List<string> GetAllPetNamesOwnedByOwner(string firstName, string lastName)
        {
            List<string> result = new List<string>();

            // IMPLEMENT THIS!
            //  ... using SQL statement on the database

            return result;
        }
        public static List<Treatment> GetAllTreatmentsPaidByOwner(string firstName, string lastName)
        {
            List<Treatment> result = new List<Treatment>();

            // IMPLEMENT THIS!
            //  ... using SQL statement on the database

            return result;
        }
    }
}
