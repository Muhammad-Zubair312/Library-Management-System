# Library Management System (LMS)

A robust console-based application for managing library operations, including book inventory, member records, and borrowing transactions. Built with C# and backed by a SQL Server database.

## 🚀 Features

*   **Book Management**:
    *   Add new books to the library inventory.
    *   Update existing book details (Author).
    *   Delete books from the system.
    *   View all available books.
*   **Member Management**:
    *   Register new library members.
    *   Update member details (CNIC).
    *   Remove members from the system.
    *   List all registered members.
*   **Transactions**:
    *   **Issue Book**: Assign a book to a member (includes validation to prevent double issuing).
    *   **Return Book**: Process book returns and update inventory status.
    *   **Analytics**: View the most borrowed book statistics.
*   **Data Persistence**: Uses SQL Server (LocalDB) for reliable data storage.

## 🛠️ Tech Stack

*   **Language**: C#
*   **Framework**: .NET 8.0 (Console Application)
*   **Database**: Microsoft SQL Server (LocalDB)
*   **Data Access**: ADO.NET (`Microsoft.Data.SqlClient`)

## 📋 Prerequisites

Before running the application, ensure you have the following installed:

1.  **.NET 8.0 SDK**: [Download here](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).
2.  **SQL Server or LocalDB**: Included with Visual Studio or available separately.

## 💾 Database Setup

The application requires a SQL Server database named `LMs`. Run the following SQL script to set up the necessary tables:

```sql
-- Create Database
CREATE DATABASE LMs;
GO

USE LMs;
GO

-- Create Book Table
CREATE TABLE Book (
    BookID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(100) NOT NULL,
    Author NVARCHAR(100) NOT NULL,
    IsIssued BIT DEFAULT 0
);
GO

-- Create Member Table
CREATE TABLE Member (
    MemberID INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(100) NOT NULL,
    cnic NVARCHAR(50) UNIQUE NOT NULL -- Used as the primary identifier in the code
);
GO

-- Create BorrowedBooks Table (For tracking history/analytics)
CREATE TABLE BorrowedBooks (
    BorrowID INT PRIMARY KEY IDENTITY(1,1),
    MemberCNIC NVARCHAR(50),
    BookID INT,
    BorrowDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (BookID) REFERENCES Book(BookID)
);
GO
```

> **Note**: The application uses the following connection string by default:
> `Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LMs;Integrated Security=True`
> If your SQL Server instance is named differently, update the connection string in `Library.cs`.

## ⚙️ Installation & Usage

1.  **Clone the Repository** (if applicable) or download the source code.
2.  **Open the Solution**:
    *   Open `Library Management System.sln` in Visual Studio 2022+.
3.  **Restore Dependencies**:
    *   The project uses `Microsoft.Data.SqlClient`. Visual Studio should restore this automatically, or you can run:
        ```bash
        dotnet restore
        ```
4.  **Run the Application**:
    *   Press `F5` in Visual Studio, or run from the terminal:
        ```bash
        cd "Library Management System"
        dotnet run
        ```
5.  **Interact**:
    *   Follow the on-screen menu prompts to manage books and members.

## 📂 Project Structure

*   `Program.cs`: The entry point containing the main menu loop.
*   `Library.cs`: Contains all business logic and database operations (CRUD, transactions).
*   `Book.cs` & `Member.cs`: Data models representing the entities.

## 🤝 Contributing

1.  Fork the repository.
2.  Create a feature branch (`git checkout -b feature/NewFeature`).
3.  Commit your changes (`git commit -m 'Add NewFeature'`).
4.  Push to the branch (`git push origin feature/NewFeature`).
5.  Open a Pull Request.

