using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Principal;
using System.Text;

namespace PetParadise
{
    public class TreatmentRepo
    {
        private List<Treatment> treatments = new List<Treatment>();
        string connectionString = DatabaseHelper.conn;

        public TreatmentRepo()
        {
            // Load all treatment data from database via SQL statements and populate treatment repository

            // IMPLEMENT THIS!
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Treatment", con);// WHERE Name = '@Name'", con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Treatment treatment = new Treatment();
                        treatment.TreatId = int.Parse(dr["TreatId"].ToString());
                        treatment.Service = (dr["TreatService"].ToString());
                        treatment.Charge = double.Parse(dr["TreatCharge"].ToString());
                        treatment.Date = DateTime.Parse(dr["TreatDate"].ToString());
                        treatments.Add(treatment);
                    }

                }

            }
        }

        public int Add(Treatment treatment)
        {
            // Add new treatment to database and to repository
            // Return the database id of the treatment

            int result = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Treatment (TreatService, TreatDate, TreatCharge) VALUES (@TreatService, @TreatDate, @TreatCharge)", con);
                cmd.Parameters.Add("@TreatService", SqlDbType.NVarChar).Value = treatment.Service;
                cmd.Parameters.Add("@TreatDate", SqlDbType.DateTime2).Value = treatment.Date;
                cmd.Parameters.Add("@TreatCharge", SqlDbType.Float).Value = treatment.Charge;
                result = int.Parse(cmd.ExecuteScalar().ToString());
            }

            // IMPLEMENT THIS!

            return result;
        }

        public List<Treatment> GetAll()
        {
            // Retrieve all treatments from database

            //List<Treatment> result = new List<Treatment>();

            // IMPLEMENT THIS!

            return treatments;
        }
        public Treatment GetById(int id)
        {
            // Get treatment by id from database

            Treatment treatment = treatments.Find(treat => treat.TreatId == id);

            // IMPLEMENT THIS!

            return treatment;
        }
        public void Update(Treatment treatment)
        {
            // Update existing treatment on database

            // IMPLEMENT THIS!
            Treatment newTreatment = treatments.Find(newNewTreatment => newNewTreatment.TreatId == treatment.TreatId);
            treatments.Remove(newTreatment);
            treatments.Add(treatment);
        }
        public void Remove(Treatment treatment)
        {
            // Delete existing treatment in database

            // IMPLEMENT THIS!
            treatments.Remove(treatment);
        }
    }
}
