using BallastLaneTest.Data;
using BallastLaneTest.Data.Interfaces;
using Microsoft.Data.SqlClient;
using BallastLaneTest.Models;
using System.Data;

namespace BallastLaneTest.DataAccess
{
    internal class DataBook : IDataBook
    {
        //Singleton
        private static DataBook instance = null;

        private DataBook() { }

        public static DataBook getInstance()
        {
            if (instance == null)
                instance = new DataBook();
            return instance;
        }

        //Operations
        public Result CreateBook(Book book)
        {
            Result result = new Result();

            try
            {
                using (SqlConnection connection = new SqlConnection(Connection.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("CreateBook", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Title", book.Title);
                        command.Parameters.AddWithValue("@Author", book.Author);
                        command.Parameters.AddWithValue("@PublicationYear", book.PublicationYear);
                        command.Parameters.AddWithValue("@ISBN", book.ISBN);
                        command.Parameters.AddWithValue("@Publisher", book.Publisher);

                        connection.Open();
                        command.ExecuteNonQuery();
                        result.IsSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public Result<IEnumerable<Book>> GetAllBooks()
        {
            Result<IEnumerable<Book>> result = new Result<IEnumerable<Book>>();
            var books = new List<Book>();

            try
            {
                using (SqlConnection connection = new SqlConnection(Connection.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetAllBooks", connection))
                    {
                        DataTable dataTable = new DataTable();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);

                        adapter.Fill(dataTable);


                        foreach (DataRow row in dataTable.Rows)
                        {
                            var book = new Book
                            {
                                Id = (int)row["Id"],
                                Title = (string)row["Title"],
                                Author = (string)row["Author"],
                                PublicationYear = (int)row["PublicationYear"],
                                ISBN = (string)row["ISBN"],
                                Publisher = (string)row["Publisher"]
                            };
                            books.Add(book);
                        }
                    }
                }
                result.IsSuccess = true;
                result.Data = books;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public Result<Book> GetBookById(int id)
        {
            Result<Book> result = new Result<Book>();
            var book = new Book();

            try
            {

                using (SqlConnection connection = new SqlConnection(Connection.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("GetBookById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", id);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataSet dataSet = new DataSet();
                            adapter.Fill(dataSet);

                            if (dataSet.Tables[0].Rows.Count > 0)
                            {
                                DataRow row = dataSet.Tables[0].Rows[0];
                                book = new Book
                                {
                                    Id = (int)row["Id"],
                                    Title = (string)row["Title"],
                                    Author = (string)row["Author"],
                                    PublicationYear = (int)row["PublicationYear"],
                                    ISBN = (string)row["ISBN"],
                                    Publisher = (string)row["Publisher"]
                                };
                                result.IsSuccess = true;
                                result.Data = book;
                            }
                            else
                            {
                                result.IsSuccess = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public Result UpdateBook(Book book)
        {
            Result result = new Result();

            try
            {
                using (SqlConnection connection = new SqlConnection(Connection.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("UpdateBook", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", book.Id);
                        command.Parameters.AddWithValue("@Title", book.Title);
                        command.Parameters.AddWithValue("@Author", book.Author);
                        command.Parameters.AddWithValue("@PublicationYear", book.PublicationYear);
                        command.Parameters.AddWithValue("@ISBN", book.ISBN);
                        command.Parameters.AddWithValue("@Publisher", book.Publisher);

                        connection.Open();
                        command.ExecuteNonQuery();
                        result.IsSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public Result DeleteBook(int id)
        {
            Result result = new Result();

            try
            {
                using (SqlConnection connection = new SqlConnection(Connection.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("DeleteBook", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", id);

                        connection.Open();
                        command.ExecuteNonQuery();
                        result.IsSuccess = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}
