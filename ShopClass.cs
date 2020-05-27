using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ShopClass
{
    class contactClass1
    {
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Brand { get; set; }
        public string Size { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        public DataTable Secect()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM Shop1";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();

            }
            return dt;
        }
        public bool Insert(contactClass1 c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "INSERT INTO Shop1 (FirstName,LastName,ContactNo,Address,brand,Size,Number,Price) VALUES (@FirstName,@LastName,@ContactNo,@Address,@brand,@Size,@Number,@Price)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Brand", c.Brand);
                cmd.Parameters.AddWithValue("@Size", c.Size);
                cmd.Parameters.AddWithValue("@Number", c.Number);
                cmd.Parameters.AddWithValue("@Price", c.Price);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        internal DataTable Select()
        {
            throw new NotImplementedException();
        }

        public bool Update(contactClass1 c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE Shop1 SET FirstName=@FirstName,LastName=@LastName,ContactNo=@ContactNo,Address=@Address,Brand=@Brand,Size=@Size,Number=@Number,Price=@Price WHERE ContactID=@ContactID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Brand", c.Brand);
                cmd.Parameters.AddWithValue("@Size", c.Size);
                cmd.Parameters.AddWithValue("@Number", c.Number);
                cmd.Parameters.AddWithValue("@Price", c.Price);
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
        public bool Delete(contactClass1 c)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "DELETE FROM Shop1 WHERE ContactID=@ContactID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }
    }
}
