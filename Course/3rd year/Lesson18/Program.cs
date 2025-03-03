using System;
using Npgsql;
using System.Threading.Tasks;
class Program
{
    public static void Main()
    {   
        Thread.Sleep(10000); // Код работает, но опять же проблемки с подключением к бд, из-за того что она долго заводится

        string connectionString = "Host=db;Port=5432;Database=mydatabase;Username=myuser;Password=mypassword";

        using (var connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();

            CreateTable(connection);
            while (true)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add Contact");
                Console.WriteLine("2. Delete Contact");
                Console.WriteLine("3. Search Contact");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddContact(connection);
                        break;
                    case "2":
                        DeleteContact(connection);
                        break;
                    case "3":
                        SearchContact(connection);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }

    static void CreateTable(NpgsqlConnection connection)
    {
        string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS Contacts (
                Id SERIAL PRIMARY KEY,
                Name TEXT NOT NULL,
                PhoneNumber TEXT NOT NULL,
                Email TEXT NOT NULL
            );";

        using (var command = new NpgsqlCommand(createTableQuery, connection))
        {
            command.ExecuteNonQuery();
        }
    }

    static void AddContact(NpgsqlConnection connection)
    {
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Phone Number: ");
        string phoneNumber = Console.ReadLine();
        Console.Write("Enter Email: ");
        string email = Console.ReadLine();

        string insertContactQuery = @"
            INSERT INTO Contacts (Name, PhoneNumber, Email)
            VALUES (@Name, @PhoneNumber, @Email);";

        using (var command = new NpgsqlCommand(insertContactQuery, connection))
        {
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
            command.Parameters.AddWithValue("@Email", email);
            command.ExecuteNonQuery();
        }

        Console.WriteLine("Contact added successfully.");
    }

    static void DeleteContact(NpgsqlConnection connection)
    {
        Console.Write("Enter Contact ID to delete: ");
        int id = int.Parse(Console.ReadLine());

        string deleteContactQuery = @"
            DELETE FROM Contacts WHERE Id = @Id;";

        using (var command = new NpgsqlCommand(deleteContactQuery, connection))
        {
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }

        Console.WriteLine("Contact deleted successfully.");
    }

    static void SearchContact(NpgsqlConnection connection)
    {
        Console.Write("Enter Name to search: ");
        string name = Console.ReadLine();

        string searchContactQuery = @"
            SELECT * FROM Contacts WHERE Name LIKE @Name;";

        using (var command = new NpgsqlCommand(searchContactQuery, connection))
        {
            command.Parameters.AddWithValue("@Name", $"%{name}%");

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["Name"]}, PhoneNumber: {reader["PhoneNumber"]}, Email: {reader["Email"]}");
                }
            }
        }
    }
}
