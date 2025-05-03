using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books;
using Members;

namespace Operations
{
    public class LibraryManager
    {
        private List<Book> books = new List<Book>();
        private List<Member> members = new List<Member>();

        public void AddBook(Book book) => books.Add(book);
        public void AddMember(Member member) => members.Add(member);

        public void ListBooks()
        {
            Console.WriteLine("Books:");
            foreach (var book in books)
                Console.WriteLine(book);
        }

        public void ListMembers()
        {
            Console.WriteLine("Members:");
            foreach (var member in members)
                Console.WriteLine(member);
        }

        public void BorrowBook(string title, int ticketNumber)
        {
            var member = members.Find(m => m.TicketNumber == ticketNumber);
            var book = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (member == null)
            {
                Console.WriteLine("Member not found.");
                return;
            }

            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            if (!book.IsAvailable)
            {
                Console.WriteLine("Book is already checked out.");
                return;
            }

            book.IsAvailable = false;
            Console.WriteLine($"{member.Name} successfully borrowed \"{book.Title}\".");
        }

        public void ReturnBook(string title)
        {
            var book = books.Find(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (book == null)
            {
                Console.WriteLine("Book not found.");
                return;
            }

            if (book.IsAvailable)
            {
                Console.WriteLine("Book was not checked out.");
                return;
            }

            book.IsAvailable = true;
            Console.WriteLine($"Book \"{book.Title}\" returned successfully.");
        }
    }
}
