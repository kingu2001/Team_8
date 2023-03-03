using LærerVikaren.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LærerVikaren.Persistence
{
    public class CourseRepo
    {
        private List<Course> courses = new List<Course>();
        string connectionString = "Server=10.56.8.36; database=DB_2023_37; user id=STUDENT_37; password=OPENDB_37;";
        public CourseRepo()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM COURSE");
                
                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Course course = new Course();
                        Enum.GetValues(typeof(Course)).Cast<Course>().ToList().Add(course);
                          
                    }
                }

            }
        }
        
        public string Add(Course course)
        {
            string result;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO COURSE(CourseName)");
                cmd.Parameters.Add("@CourseName", SqlDbType.NVarChar).Value = course;
                result = cmd.ExecuteScalar().ToString();
            }
            return result; 
        }

        public List<Course> GetAll()
        {
            List<Course> result = courses;
            return result; 
        }

        public Course GetByName(string course)
        {
            Course c = courses.Find(c => c.CourseName == course);
            return c;
        }

        public void Update(Course course)
        {
            Course newCourse = courses.Find(newNewCourse => newNewCourse.CourseName == course.CourseName);
            courses.Remove(newCourse);
            courses.Add(newCourse);
        }

        public void Remove(Course course)
        {
            courses.Remove(course);
        }

    }
}
