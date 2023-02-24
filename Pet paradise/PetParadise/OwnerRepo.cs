using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Xml.Linq;

namespace PetParadise
{
    public class OwnerRepo
    {
        private List<Owner> owners = new List<Owner>();

        public OwnerRepo()
        {
            string connectionString = DatabaseHelper.con;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Owner", con);// WHERE Name = '@Name'", con);
               
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Owner owner = new Owner();
                        owner.OwnerId = int.Parse(dr["OwnerId"].ToString());
                        owner.FirstName = (dr["OwnerFirstName"].ToString());
                        owner.LastName = (dr["OwnerLastName"].ToString());
                        owner.Phone = (dr["OwnerPhone"].ToString());
                        owner.Email = (dr["OwnerEmail"].ToString());
                        owners.Add(owner);
                    }
                    
                }
                
            }
        
            // Load all owner data from database via SQL statements and populate owner repository

                // IMPLEMENT THIS!
        }

        public int Add(Owner owner)
        {
            // Add new owner to database and to repository
            // Return the database id of the owner

            int result = -1;

            // IMPLEMENT THIS!

            return result;
        }
        public List<Owner> GetAll()
        {
            // Retrieve all owners from database

            List<Owner> result = owners;

            // IMPLEMENT THIS!

            return result;
        }
        public Owner GetById(int id)
        {
            // Get owner by id from database

            Owner result = null;

            // IMPLEMENT THIS!

            return result;
        }
        public void Update(Owner owner)
        {
            // Update existing owner on database

            // IMPLEMENT THIS!
        }
        public void Remove(Owner owner)
        {
            // Delete existing owner in database

            // IMPLEMENT THIS!
        }

    }
}
