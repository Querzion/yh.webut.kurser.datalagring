using Data.Entities;
using Data.Interfaces;
using Microsoft.Data.SqlClient;

namespace Data.Repositories;

public class UserRepository : IUserRepository
{
    // Unable to connect to the SQL server properly.
    private readonly string _connectionString = $@"
        Server=localhost;
        Database=sql_database;
        Trusted_Connection=False;
        Persist Security Info=False;
        Encrypt=False;
        User ID=Querzion;
        Password=Scam2014;
        Connect Timeout=30;
    ";
    
    public UserRepository()
    {
        CreateUsersTableIfNotExists();
    }

    public void CreateUsersTableIfNotExists()
    {
        try
        {
            string createUsersTableQuery = @"
                IF OBJECT_ID('Users', 'U') IS NULL
                    CREATE TABLE Users (
                        Id INT IDENTITY (1,1) PRIMARY KEY,
                        FirstName NVARCHAR(50) NOT NULL,
                        LastName NVARCHAR(50) NOT NULL,
                        Email NVARCHAR(100) NOT NULL,
                        PhoneNumber NVARCHAR(15) NULL
            )";

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = new SqlCommand(createUsersTableQuery, connection);
            command.ExecuteNonQuery();
            
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
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
            
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            
            using var command = new SqlCommand(insertQuery, connection);
            command.Parameters.AddWithValue("@FirstName", userEntity.FirstName);
            command.Parameters.AddWithValue("@LastName", userEntity.LastName);
            command.Parameters.AddWithValue("@Email", userEntity.Email);
            command.Parameters.AddWithValue("@PhoneNumber", userEntity.PhoneNumber ?? (object)DBNull.Value);
            command.ExecuteNonQuery();
            
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public IEnumerable<UserEntity> GetAll()
    {
        try
        {
            var users = new List<UserEntity>();
            string selectQuery = "SELECT * FROM Users";
            
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            
            using var command = new SqlCommand(selectQuery, connection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                users.Add(new UserEntity
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Email = reader.GetString(3),
                    PhoneNumber = reader.IsDBNull(4) ? null : reader.GetString(4)
                });
            }
            
            return users;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null!;
        }
    }
}