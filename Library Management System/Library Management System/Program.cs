using LMS;

namespace Program
{
    public class Program
    {
        public static void Main()
        {
            Library lib = new Library();
            Console.WriteLine("--------------Welcome to Library Management System-------\n");

            while (true)
            {
                Console.WriteLine("Select the Options");
                Console.WriteLine("1. Add a New Book");
                Console.WriteLine("2. Update a Book");
                Console.WriteLine("3. Delete a Book");
                Console.WriteLine("4. Display a Book");
                Console.WriteLine("5. Add a Members");
                Console.WriteLine("6. Delete a Members");
                Console.WriteLine("7. Update a Members");
                Console.WriteLine("8. Display a Members");
                Console.WriteLine("9. Issue a Book");
                Console.WriteLine("10. Return a Book");
                Console.WriteLine("11. Show Highest  a Book");
                Console.WriteLine("12. Exit");

                
                int id;
                if (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }

                if (id == 1)
                {
                    lib.AddBook();
                }
                else if (id == 2)
                {
                    lib.UpdateBook();
                }
                else if (id == 3)
                {
                    lib.DeleteBook();
                }
                else if (id == 4)
                {
                    lib.DisplayBooks();
                }
                else if (id == 5)
                {
                    lib.AddMembers();
                }
                else if (id == 6)
                {
                    lib.DeleteMembers();
                }
                else if (id == 7)
                {
                    lib.UpdateMembers();
                }
                else if (id == 8)
                {
                    lib.DisplayMembers();
                }
                else if (id == 9)
                {
                    Console.Write("Enter the Book id: ");
                    int bid = int.Parse(Console.ReadLine()); 

                    Console.Write("Enter the Member CNIC: ");
                    string cnic = Console.ReadLine();

                    lib.IssueBook(bid, cnic);
                  

                }

                else if (id == 10)
                {
                    Console.Write("Enter Book ID: ");
                    int bid = int.Parse(Console.ReadLine());

                    Console.Write("Enter Member CNIC: ");
                    string cnic = Console.ReadLine();

                    lib.returnBooks(bid, cnic);


                }
                else if (id == 11)
                {
                    lib.DeclareMostBorrowedBook();
                }
                else if (id == 12)
                {
                    Console.WriteLine("You Exist from the program...");
                    break;  
                }
                else
                {
                    Console.WriteLine("Invalid choice! Please select a valid option.");
                }
            }
        }
    }
}
