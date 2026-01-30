using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.Data.SqlClient;
using static System.Reflection.Metadata.BlobBuilder;

namespace LMS
{
    class Library
    {
        private List<Book> books;


        public Library()
        {

            books = new List<Book>();
        }

        public void AddMembers()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMs;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    Console.Write("Enter the Member Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter the Member Cnic: ");
                    string cnic = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(cnic))
                    {
                        Console.WriteLine("Book title and author name cannot be empty.");
                        return;
                    }

                    string query = "INSERT INTO Member (name, cnic) VALUES (@name, @cnic)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Cnic", cnic);


                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Member added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add Member.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding book: " + ex.Message);
                }
            }
        }

        public void DeleteMembers()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMs;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    Console.Write("Enter Member Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Member Cnic: ");
                    string cnic = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(cnic))
                    {
                        Console.WriteLine("Book title and author cannot be empty.");
                        return;
                    }
                    string query = "DELETE FROM Member WHERE cnic = @cnic";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Cnic", cnic);


                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Member Delete successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to Delete Member.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding book: " + ex.Message);
                }
            }
        }

        public void UpdateMembers()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMs;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    Console.Write("Enter the Old CNIC: ");
                    string oldCnic = Console.ReadLine();
                    Console.Write("Enter the New CNIC: ");
                    string newCnic = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(oldCnic) || string.IsNullOrWhiteSpace(newCnic))
                    {
                        Console.WriteLine("the CNIC is cannot be empty.");
                        return;
                    }

                    string query = "UPDATE Member SET cnic = @NewCnic WHERE cnic = @OldCnic";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@NewCnic", newCnic);
                        cmd.Parameters.AddWithValue("@OldCnic", oldCnic);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("the Member is updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No member is present  with this CNIC.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while updating member: " + ex.Message);
                }
            }
        }

        public void DisplayMembers()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMs;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT name, cnic FROM Member";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No Member available.");
                            return;
                        }

                        Console.WriteLine("Available Members:");
                        Console.WriteLine("----------------------------");

                        while (reader.Read())
                        {
                            string name = reader["name"].ToString();
                            string cnic = reader["cnic"].ToString();

                            Console.WriteLine($"Name: {name}, CNIC: {cnic}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching Members: " + ex.Message);
                }
            }
        }


        public void AddBook()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMs;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    Console.Write("Enter Book Title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter Book Author: ");
                    string author = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
                    {
                        Console.WriteLine("Book title and author cannot be empty.");
                        return;
                    }

                    string query = "INSERT INTO Book (Title, Author, IsIssued) VALUES (@Title, @Author, @IsIssued)";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Title", title);
                        cmd.Parameters.AddWithValue("@Author", author);
                        cmd.Parameters.AddWithValue("@IsIssued", false);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Book added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add book.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error adding book: " + ex.Message);
                }
            }
        }

        public void UpdateBook()
        {

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMs;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    Console.Write("Enter Book Title: ");
                    string title = Console.ReadLine();
                    Console.Write("Enter New Book Author: ");
                    string author = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
                    {
                        Console.WriteLine("Book title and author cannot be empty.");
                        return;
                    }

                    string checkQuery = "SELECT COUNT(*) FROM Book WHERE Title = @Title";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("@Title", title);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            string updateQuery = "UPDATE Book SET Author = @Author WHERE Title = @Title";
                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                            {
                                updateCmd.Parameters.AddWithValue("@Title", title);
                                updateCmd.Parameters.AddWithValue("@Author", author);

                                int rowsAffected = updateCmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    Console.WriteLine("Book details updated successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Failed to update book details.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("No book found with this title. Please enter a valid book title.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error updating book: " + ex.Message);
                }
            }
        }


        public void DeleteBook()
        {
            Console.Write("Enter Book Title to Delete: ");
            string title = Console.ReadLine();
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMs;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "DELETE FROM Book WHERE Title = @title";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@title", title);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Book deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No book found with the given title.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error deleting book: " + ex.Message);
                }
            }
        }



        public void DisplayBooks()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMs;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT Title, Author, IsIssued FROM Book";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("No books available.");
                            return;
                        }

                        Console.WriteLine("Available Books:");
                        Console.WriteLine("----------------------------");

                        while (reader.Read())
                        {
                            string title = reader["Title"].ToString();
                            string author = reader["Author"].ToString();
                            bool isIssued = reader.GetBoolean(reader.GetOrdinal("IsIssued"));

                            Console.WriteLine($"Title: {title}, Author: {author}, Issued: {(isIssued ? "Yes" : "No")}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error fetching books: " + ex.Message);
                }
            }
        }


        private List<Book> Books = new List<Book>();

        public void IssueBook(int bookID, string cnic)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMs;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // Step 1: Check if the book is available and issue it
                    string query = "UPDATE Book SET IsIssued = 1 WHERE BookID = @BookID AND IsIssued = 0";
                    using (SqlCommand cmd = new SqlCommand(query, con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@BookID", bookID);
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {

                            string query1 = "INSERT INTO BorrowedBooks (MemberCNIC, BookID) VALUES (@CNIC, @BookID)";
                            using (SqlCommand cmd1 = new SqlCommand(query1, con, transaction))
                            {
                                cmd1.Parameters.AddWithValue("@CNIC", cnic);
                                cmd1.Parameters.AddWithValue("@BookID", bookID);
                                cmd1.ExecuteNonQuery();
                            }


                            foreach (Book book in books)
                            {
                                if (book.BookID == bookID)
                                {
                                    book.IsIssued = true;
                                    break;
                                }
                            }

                            transaction.Commit();
                            Console.WriteLine("Book issued successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Book is either already issued or does not exist.");
                            transaction.Rollback();
                        }
                    }
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Console.WriteLine("Exception while issuing book: " + e.Message);
                }
            }
        }

        public void returnBooks(int bookID, string cnic)



        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMs;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    // Step 1: Check if the book is available and issue it
                    string query = "UPDATE Book SET IsIssued = 0 WHERE BookID = @BookID AND IsIssued = 1";
                    using (SqlCommand cmd = new SqlCommand(query, con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@BookID", bookID);
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {



                            foreach (Book book in books)
                            {
                                if (book.BookID == bookID)
                                {
                                    book.IsIssued = false;
                                    break;
                                }
                            }

                            transaction.Commit();
                            Console.WriteLine("Book return successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Book does not exist.");
                            transaction.Rollback();
                        }
                    }
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Console.WriteLine("Exception while issuing book: " + e.Message);
                }
            }
        }



public void DeclareMostBorrowedBook()
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LMs;Integrated Security=True";

        string query = @"
    SELECT TOP 1 Book.BookID, Book.Title, Book.Author, COUNT(BorrowedBooks.BookID) AS BorrowCount
    FROM Book
    LEFT JOIN BorrowedBooks ON Book.BookID = BorrowedBooks.BookID
    GROUP BY Book.BookID, Book.Title, Book.Author
    ORDER BY BorrowCount DESC";

        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(query, conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string title = reader.GetString(1);
                        string author = reader.GetString(2);
                        int borrowCount = reader.GetInt32(3);

                        Console.WriteLine($"Most borrowed book: {title} by {author} (Borrowed {borrowCount} times)");
                    }
                    else
                    {
                        Console.WriteLine("No books have been borrowed yet.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

}

    }









