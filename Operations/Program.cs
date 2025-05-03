//Задание 5
//Создайте консольное приложение, моделирующее библиотеку. Разделите приложение на несколько пространств имен, таких как:

//Library.Books: Классы для хранения информации о книгах (например, название, автор, жанр).
//Library.Members: Классы, представляющие информацию о членах библиотеки (например, имя, номер билета).
//Library.Operations: Классы для реализации операций с книгами (например, взятие и возврат книг).
//Используйте вложенные пространства имен и добавьте функ­цио­нальность для работы с книгами и членами библиотеки.


namespace Operations
{
    internal class Program
    {
        static void Main()
        {
            var manager = new Operations.LibraryManager();

            // Предустановленные книги и читатели
            manager.AddBook(new Books.Book("1984", "George Orwell", "Dystopia"));
            manager.AddBook(new Books.Book("The Hobbit", "J.R.R. Tolkien", "Fantasy"));
            manager.AddMember(new Members.Member("Alice", 1001));
            manager.AddMember(new Members.Member("Bob", 1002));

            while (true)
            {
                Console.WriteLine("\n===== Library Menu =====");
                Console.WriteLine("1. Список книг");
                Console.WriteLine("2. Список читателей");
                Console.WriteLine("3. Взять книгу");
                Console.WriteLine("4. Вернуть книгу");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        manager.ListBooks();
                        break;
                    case "2":
                        manager.ListMembers();
                        break;
                    case "3":
                        Console.Write("Введите название книги: ");
                        string? titleToBorrow = Console.ReadLine();
                        if (string.IsNullOrEmpty(titleToBorrow))
                        {
                            Console.WriteLine("Название книги не может быть пустым.");
                            continue;
                        }
                        Console.Write("Введите номер билета: ");
                        string? InputTicketNum = Console.ReadLine();
                        if (string.IsNullOrEmpty(InputTicketNum) || !int.TryParse(InputTicketNum, out _))
                        {
                            Console.WriteLine("Номер билета должен быть числом.");
                            continue;
                        }
                        int borrowTicket = int.Parse(InputTicketNum);
                        manager.BorrowBook(titleToBorrow, borrowTicket);
                        break;
                    case "4":
                        Console.Write("Введите название книги: ");
                        string? titleToReturn = Console.ReadLine();
                        if (string.IsNullOrEmpty(titleToReturn))
                        {
                            Console.WriteLine("Название книги не может быть пустым.");
                            continue;
                        }
                        manager.ReturnBook(titleToReturn);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }
            }
        }
    }
}
