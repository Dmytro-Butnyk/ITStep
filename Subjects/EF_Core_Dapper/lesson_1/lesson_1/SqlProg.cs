using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace lesson_1
{
    public class SqlProg
    {
        SqlConnection conn = new();
        SqlDataReader rdr = null;

        public SqlProg()
        {
            string connStr = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Stock; Integrated Security = SSPI;";
            conn.ConnectionString = connStr;
        }

        // insert data
        #region
        public void InsertData()
        {
            try
            {
                //string TextCom = @"insert into Authors (FirstName,LastName)  values ('Marko','Vovchok')";
                WriteLine("Введіть ім'я:");
                string? FN = ReadLine();
                WriteLine("Введіть прізвище:");
                string? LN = ReadLine();
                string TextCom = "insert into Authors (FirstName,LastName)  values ('" + FN + "','" + LN + "')";
                // string TextCom = @"insert into Books (AuthID,Title,Price)  values (1,'I , robot',300)";

                SqlCommand cmd = new SqlCommand(TextCom, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message + "  Ok");
                if (conn != null) conn.Close();
            }
        }
        #endregion

        public void OpenConnection()
        {
            try
            {
                conn.Open();
                WriteLine("Connection is successfull!");
            }
            catch (Exception ex)
            {
                WriteLine($"Connection error: {ex.Message}");
            }
        }
        public void CloseConnection()
        {
            try
            {
                conn.Close();
                WriteLine("DB disconnected.");
            }
            catch (Exception ex)
            {
                WriteLine($"Disconnection error: {ex.Message}");
            }
        }
        public void ShowProduct(string productName)
        {
            try
            {
                string command = $@"select * from Product where Name = N'{productName}'";
                SqlCommand cmd = new SqlCommand(command, conn);
                conn.Open();

                rdr = cmd.ExecuteReader();
                do
                {
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        SetCursorPosition(i * 15, CursorTop);
                        Write(rdr.GetName(i) + "\t");
                    }
                    WriteLine();
                    while (rdr.Read())
                    {
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            SetCursorPosition(i * 15, CursorTop);
                            Write(rdr[i].ToString() + "\t");
                        }
                        WriteLine();
                    }
                    WriteLine();
                }
                while (rdr.NextResult());

            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
            finally
            {
                if (rdr != null) rdr.Close();
                if (conn != null) conn.Close();
            }
        }
        public void ShowProductTypes()
        {
            try
            {
                string command = $@"select * from ProductType";
                SqlCommand cmd = new SqlCommand(command, conn);
                conn.Open();

                rdr = cmd.ExecuteReader();
                do
                {
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        SetCursorPosition(i * 25, CursorTop);
                        Write(rdr.GetName(i) + "\t");
                    }
                    WriteLine();
                    while (rdr.Read())
                    {
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            SetCursorPosition(i * 25, CursorTop);
                            Write(rdr[i].ToString() + "\t");
                        }
                        WriteLine();
                    }
                    WriteLine();
                }
                while (rdr.NextResult());

            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
            finally
            {
                if (rdr != null) rdr.Close();
                if (conn != null) conn.Close();
            }
        }
    }
}
