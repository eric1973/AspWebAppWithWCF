using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleUIEFCodeFirst.Models;
using System.Data.SqlClient;

namespace ConsoleUIEFCodeFirst
{
    class Program
    {
        static string ConnectionString = "Data Source=.\\SQLEXPRESS2012;Initial Catalog=wcfsample;Integrated Security=SSPI";

        static void Main(string[] args)
        {
            SelectWithEF();


            SelectCount();
            Insert();

            var persons = SelectPersons();
            
            foreach(var person in persons) {
                Console.WriteLine(string.Format("person {{id={0}, name={1}}}", person.id, person.name));
            }

            Console.ReadKey();
        }

        private static void SelectWithEF()
        {
            var dbContext = new wcfsampleContext();
            var data = dbContext.People.Where(person => person.name.Contains("eric"));

            var list = data.ToList();
            list.Sort();


            Console.WriteLine(string.Format("Found {0} items containing \"eric\"", data.Count()));
            dbContext.Dispose();
        }

        static void SelectCount()
        {
            SqlConnection con = new SqlConnection(ConnectionString);

            try {

                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = "select count(*) from Person where name='eric'";

                int count = (int)command.ExecuteScalar();

            } catch (Exception e) {
                Console.WriteLine("Expection in Select: " + e.Message);
            } finally {

                if (con != null) {
                    con.Close();
                }
            }
        }

        static int GetMaxId()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            int maxId = -1;
            try
            {
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = "select MAX(id) from Person";

                maxId = (int)command.ExecuteScalar();

            }
            catch (Exception e) { 
                Console.WriteLine("Expection: " + e.Message);

            } finally {

                if (con != null) {
                    con.Close();
                }
            }

            return maxId;
        }

        static void Insert()
        {
            SqlConnection con = new SqlConnection(ConnectionString);

            try
            {
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = "insert into Person values(@id, @name, @address)";

                int nextId = GetMaxId() + 1;
                command.Parameters.AddWithValue("@id", nextId);
                command.Parameters.AddWithValue("@name", "eric");
                command.Parameters.AddWithValue("@address", "fourniergasse");

                command.ExecuteNonQuery();
            }
            catch (Exception e) {
                Console.WriteLine("Expection: " + e.Message);

            }
            finally
            {

                if (con != null)
                {
                    con.Close();
                }
            }
        }

        static List<Person> SelectPersons()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            List<Person> persons = new List<Person>();

            try
            {
                con.Open();

                SqlCommand command = con.CreateCommand();
                command.CommandText = "select * from Person";

                SqlDataReader datareader = command.ExecuteReader();

                while (datareader.Read())
                {
                    Person person = new Person { 
                        id = Convert.ToInt32(datareader["id"]), 
                        name = datareader["name"] as string, 
                        address = datareader["address"] as string 
                    };
                    persons.Add(person);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Expception: " + e.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

            return persons;
        }
    }
}
