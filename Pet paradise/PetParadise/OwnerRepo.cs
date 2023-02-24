using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Linq;

namespace PetParadise
{
    public class OwnerRepo
    {
        private List<Owner> owners = new List<Owner>();
        string connectionString = DatabaseHelper.conn;
        public OwnerRepo()
        {
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
            int result = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Owner (OwnerFirstName, OwnerLastName, OwnerPhone, OwnerEmail) VALUES (@OwnerFirstName, @OwnerLastName, @OwnerPhone, @OwnerEmail)", con);

                cmd.Parameters.Add("@OwnerFirstName", SqlDbType.NVarChar).Value = owner.FirstName;
                cmd.Parameters.Add("@OwnerLastName", SqlDbType.NVarChar).Value = owner.LastName;
                cmd.Parameters.Add("@OwnerPhone", SqlDbType.NVarChar).Value = owner.Phone;
                cmd.Parameters.Add("@OwnerEmail", SqlDbType.NVarChar).Value = owner.Email;
                result = int.Parse(cmd.ExecuteScalar().ToString());
            }


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
           Owner owner = owners.Find(owner => owner.OwnerId == id);

       

            // IMPLEMENT THIS!

            return owner;
        }
        public void Update(Owner owner)
        {
            // Update existing owner on database

            // IMPLEMENT THIS!
            Owner newOwner = owners.Find(newNewOwner => newNewOwner.OwnerId == owner.OwnerId);
            owners.Remove(newOwner);
            owners.Add(owner);
        }
        public void Remove(Owner owner)
        {
            // Delete existing owner in database

            // IMPLEMENT THIS!
            owners.Remove(owner); 
        }

    }
}
