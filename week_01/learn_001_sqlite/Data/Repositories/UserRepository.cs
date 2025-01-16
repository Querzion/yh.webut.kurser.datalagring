using Data.Entities;
using Data.Interfaces;
using Microsoft.Data.Sqlite;

namespace Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString = "Data Source=../../../../database.db;";

    public UserRepository()
    {
        CreateUserTableIfNotExists();
    }

    public void CreateUserTableIfNotExists()
    {
        try
        {
            // This connection is opened and closed within the curly brackets.
            // using (var connection = new SqliteConnection(_connectionString))
            // {
            //     connection.Open();
            // }
            
            // While this connection is opened till the method is over.
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            string createUserTableQuery = @"
            CREATE TABLE IF NOT EXISTS Users (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                FirstName TEXT NOT NULL,
                LastName TEXT NOT NULL,
                Email TEXT NOT NULL,
                PhoneNumber TEXT NULL
            )";

            using var command = new SqliteCommand(createUserTableQuery, connection);
            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating users table: {ex.Message}");
        }
    }

    public bool Create(UserEntity userEntity)
    {
        try
        {
            string insertQuery = @"
                INSERT INTO Users (FirstName, LastName, Email, PhoneNumber) 
                VALUES (@FirstName, @LastName, @Email, @PhoneNumber)
            ";
            
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            
            using var command = new SqliteCommand(insertQuery, connection);
            command.Parameters.AddWithValue("@FirstName", userEntity.FirstName);
            command.Parameters.AddWithValue("@LastName", userEntity.LastName);
            command.Parameters.AddWithValue("@Email", userEntity.Email);
            command.Parameters.AddWithValue("@PhoneNumber", userEntity.PhoneNumber);
            
            command.ExecuteNonQuery();
            
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding user to table: {ex.Message}");
            return false;
        }
    }

    public IEnumerable<UserEntity> GetAll()
    {
        try
        {
            var users = new List<UserEntity>();
            string selectQuery = @"SELECT * FROM Users";
            
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            
            using var command = new SqliteCommand(selectQuery, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                users.Add(new UserEntity
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Email = reader.GetString(3),
                    PhoneNumber = reader.GetString(4)
                });
            }
            
            return users;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading users table: {ex.Message}");
            return null!;
        }
    }
}