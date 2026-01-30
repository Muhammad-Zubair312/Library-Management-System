using System;

public class Book
{
    private static Random random = new Random();

    public int BookID { get; }
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsIssued { get;  set; }

    public Book(string title, string author)
    {
        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author))
            throw new ArgumentException("Title and Author name cannot be empty.");

        BookID = GenerateBookID();
        Title = title;
        Author = author;
        IsIssued = false;
    }

    private static int GenerateBookID() => random.Next(1000, 9999);

    public void IssueBook()
    {
        if (!IsIssued)
        {
            IsIssued = true;
            Console.WriteLine($"The book '{Title}' has been issued.");
        }
        else
        {
            Console.WriteLine($"The book '{Title}' is already issued.");
        }
    }

    public void ReturnBook()
    {
        if (IsIssued)
        {
            IsIssued = false;
            Console.WriteLine($"The book '{Title}' has been returned.");
        }
        else
        {
            Console.WriteLine($"The book '{Title}' was not issued.");
        }
    }

    public override string ToString()
    {
        return $"The Book Class has Data Member Book ID: {BookID}, Title: {Title}, Author: {Author}, Issued: {IsIssued}";
    }
}
