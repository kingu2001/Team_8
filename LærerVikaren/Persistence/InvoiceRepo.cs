using LærerVikaren.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LærerVikaren.Persistence
{
    internal class InvoiceRepo
    {
        private List<Invoice> invoices = new List<Invoice>();

        string connectionString = "Server=10.56.8.36; database=DB_2023_37; user id=STUDENT_37; password=OPENDB_37;";
        public InvoiceRepo()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM LS", con);// WHERE Name = '@Name'", con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Invoice invoice = new Invoice();
                        invoice.Number = int.Parse(dr["InvoiceNumber"].ToString());
                        invoice.InvoiceDate = DateTime.Parse(dr["InvoiceDate"].ToString());
                        invoice.Fk_TempHour = int.Parse(dr["FK_TEMPHOUR"].ToString());
                        invoices.Add(invoice);
                    }

                }

            }

            // Load all owner data from database via SQL statements and populate owner repository

            // IMPLEMENT THIS!
        }
        public int Add(Invoice invoice)
        {
            // Add new owner to database and to repository
            // Return the database id of the owner
            int result = 0;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Invoice (Number, InvoiceDate, FK_TEMPHOUR) VALUES (@Number, @InvoiceDate, @Fk_TempHour)", con);
                cmd.Parameters.Add("@Number", SqlDbType.Int).Value = invoice.Number;
                cmd.Parameters.Add("@InvoiceDate", SqlDbType.NVarChar).Value = invoice.InvoiceDate;
                cmd.Parameters.Add("Fk_TempHour", SqlDbType.Int).Value = invoice.Fk_TempHour;
                result = int.Parse(cmd.ExecuteScalar().ToString());
            }


            // IMPLEMENT THIS!

            return result;
        }
        public Invoice GetByInoviceNo(int id)
        {
            // Get owner by id from database
            Invoice invoice = invoices.Find(invoice => invoice.Number == id);



            // IMPLEMENT THIS!

            return invoice;
        }
    }
}
