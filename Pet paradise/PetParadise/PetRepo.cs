using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PetParadise
{
    public class PetRepo
    {
        private List<Pet> pets = new List<Pet>();
        string connectionString = DatabaseHelper.conn;

        public PetRepo()
        {
            // Load all pet data from database via SQL statements and populate pet repository

            // IMPLEMENT THIS!
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Pet", con);// WHERE Name = '@Name'", con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Pet pet = new Pet(); 
                        pet.PetId= int.Parse(dr["PetId"].ToString());
                        pet.Name = ((dr["PetName"].ToString()));
                        pet.PetType = (PetTypes)Enum.Parse(typeof(PetTypes),(dr["PetType"].ToString()));
                        pet.Breed = (dr["PetBreed"].ToString());
                        if (dr["PetDOB"].ToString() != "")
                        {
                            pet.DOB = DateTime.Parse(dr["PetDOB"].ToString());
                        }
                        pet.Weight = double.Parse((dr["PetWeight"].ToString()));
                        pets.Add(pet);
                    }

                }

            }
        }

        public int Add(Pet pet)
        {
            // Add new pet to database and to repository
            // Return the database id of the pet

            int result = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Pet (PetName, PetType, PetBreed, PetWeight) VALUES (@PetName, @PetType, @PetBreed, @PetWeight)", con);

                cmd.Parameters.Add("@PetName", SqlDbType.NVarChar).Value = pet.Name;
                cmd.Parameters.Add("@PetType", SqlDbType.NVarChar).Value = pet.PetType;
                cmd.Parameters.Add("@PetBreed", SqlDbType.NVarChar).Value = pet.Breed;
                cmd.Parameters.Add("@PetDOB", SqlDbType.DateTime2).Value = pet.Breed;
                cmd.Parameters.Add("@PetWeight", SqlDbType.NVarChar).Value = pet.Weight;
                result = int.Parse(cmd.ExecuteScalar().ToString());
            }


            // IMPLEMENT THIS!

            return result;
        }
        public List<Pet> GetAll()
        {
            // Retrieve all pets from database

            List<Pet> result = pets;

            // IMPLEMENT THIS!

            return result;
        }
        public Pet GetById(int id)
        {
            // Get pet by id from database

            Pet pet = pets.Find(pet => pet.PetId == id);

            // IMPLEMENT THIS!

            return pet;
        }
        public void Update(Pet pet)
        {
            // Update existing pet on database

            // IMPLEMENT THIS!
            Pet newPet = pets.Find(newNewPet => newNewPet.PetId == pet.PetId);
            pets.Remove(newPet);
            pets.Add(pet);
        }
        public void Remove(Pet pet)
        {
            // Delete existing pet in database

            // IMPLEMENT THIS!
            pets.Remove(pet); 
        }
    }
}
