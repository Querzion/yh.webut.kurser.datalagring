using Data.Enteties;
using Data.Interfaces;
using Microsoft.Data.SqlClient;

namespace Data.Repositories;

public class UserRepository : IUserRepository
{
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

    private void CreateUsersTableIfNotExists()
    {
        try
        {
            string sqlUserTableFilePath = @"../../../../Data/Scripts/UserTable.sql";
            string sqlScript = File.ReadAllText(sqlUserTableFilePath);

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = new SqlCommand(sqlScript, connection);
            command.ExecuteNonQuery(); 
            
            Console.WriteLine("Table created successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    public bool Create(UserEntity userEntity)
    {
        try
        {
            string sqlInsertQueryFilePath = @"../../../../Data/Scripts/UserInsertQuery.sql";
            string sqlScript = File.ReadAllText(sqlInsertQueryFilePath);

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = new SqlCommand(sqlScript, connection);
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
            
            string sqlSelectQueryFilePath = @"../../../../Data/Scripts/UserSelectQuery.sql";
            string sqlScript = File.ReadAllText(sqlSelectQueryFilePath);

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            using var command = new SqlCommand(sqlScript, connection);
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