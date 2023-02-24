using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PetParadise
{
    
    public class DatabaseHelper
    {
        public static string conn = "Server=10.56.8.36; database=P1_DB_2023_08; user id=PROJECT_USER_08; password=OPENDB_08;";
        public static List<string> GetAllPetNamesOwnedByOwner(string firstName, string lastName)
        {
            List<string> result = new List<string>();

            // IMPLEMENT THIS!
            //  ... using SQL statement on the database
            int id = 0;
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Owner WHERE OwnerFirstName = @FirstName AND OwnerLastName = @LastName", con);
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = firstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lastName;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        id = int.Parse(dr["OwnerId"].ToString());
                    }
                }

                cmd = new SqlCommand("SELECT * FROM Pet WHERE OwnerId = @OwnerId", con);
                cmd.Parameters.Add("@OwnerId", SqlDbType.NVarChar).Value = id;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        result.Add(dr["PetName"].ToString());
                    }
                }

            }


            return result;
        }
        public static List<Treatment> GetAllTreatmentsPaidByOwner(string firstName, string lastName)
        {
            List<Treatment> result = new List<Treatment>();

            // IMPLEMENT THIS!
            //  ... using SQL statement on the database
            int id = 0;
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Owner WHERE OwnerFirstName = @FirstName AND OwnerLastName = @LastName", con);
                cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = firstName;
                cmd.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = lastName;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        id = int.Parse(dr["OwnerId"].ToString());
                    }
                }

                cmd = new SqlCommand("SELECT * FROM Pet WHERE OwnerId = @OwnerId", con);
                cmd.Parameters.Add("@OwnerId", SqlDbType.Int).Value = id;
                List<int> petIds = new();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        petIds.Add(int.Parse(dr["PetId"].ToString()));
                    }
                }

                cmd = new SqlCommand("SELECT * FROM Treatment", con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Treatment treatment = new Treatment();
                        treatment.TreatId = int.Parse(dr["TreatId"].ToString());
                        treatment.Service = (dr["TreatService"].ToString());
                        treatment.Charge = double.Parse(dr["TreatCharge"].ToString());
                        treatment.Date = DateTime.Parse(dr["TreatDate"].ToString());
                        int petId = int.Parse(dr["PetId"].ToString());
                        if (petIds.Contains(petId))
                        {
                            result.Add(treatment);
                        }
                    }

                }

            }

            return result;
        }
    }
}
