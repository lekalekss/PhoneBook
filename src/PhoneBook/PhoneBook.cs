namespace PhoneBook;

public interface IPhoneBook
{
    void AddContact();
    void ViewContacts();
    void UpdateContact();
    void DeleteContact();
    void SearchContact();
    void SaveBook();
}

public class PhoneBook : IPhoneBook
{
    public PhoneBook(List<Contact> contacts)
    {
        Contacts = contacts;
    }

    public List<Contact> Contacts { get; set; }
    
    public void AddContact()
    {
        // Реализация добавления контакта
    }

    public void ViewContacts()
    {
        // Реализация просмотра контактов
    }

    public void UpdateContact()
    {
        // Реализация обновления контакта
    }

    public void DeleteContact()
    {
        // Реализация удаления контакта
    }

    public void SearchContact()
    {
        // Реализация поиска контакта
    }

    public void SaveBook()
    {
        // Реализация сохранения книги в текстовый файл (бонусное задание)
    }
}