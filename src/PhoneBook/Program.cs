public class Program
{
    static List<Contact> contacts = new List<Contact>();

    static void Main(string[] args)
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("1. Добавить контакт");
            Console.WriteLine("2. Просмотреть контакты");
            Console.WriteLine("3. Обновить контакт");
            Console.WriteLine("4. Удалить контакт");
            Console.WriteLine("5. Поиск контакта");
            Console.WriteLine("6. Сохранить книгу");
            Console.WriteLine("7. Выйти");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddContact();
                    break;
                case 2:
                    ViewContacts();
                    break;
                case 3:
                    UpdateContact();
                    break;
                case 4:
                    DeleteContact();
                    break;
                case 5:
                    SearchContact();
                    break;
                case 6:
                    SaveBook();
                    break;
                case 7:
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                    break;
            }
        }
    }

    static void AddContact()
    {
        // Реализация добавления контакта
    }

    static void ViewContacts()
    {
        // Реализация просмотра контактов
    }

    static void UpdateContact()
    {
        // Реализация обновления контакта
    }

    static void DeleteContact()
    {
        // Реализация удаления контакта
    }

    static void SearchContact()
    {
        // Реализация поиска контакта
    }

    static void SaveBook()
    {
        // Реализация сохранения книги в текстовый файл (бонусное задание)
    }
}