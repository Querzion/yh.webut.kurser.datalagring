using System.Diagnostics;
using Data.Contexts;
using Data.Entities;
using Data.Helpers;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    static async Task Main(string[] args)
    {
        var cS = DatabaseHelper.GetSQLServerDatabaseConnectionString();

        var services = new ServiceCollection()
            .AddDbContext<DataContext>(x => x.UseSqlServer(cS))
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUserRepositoryWithCache, UserRepositoryWithCache>()
            .BuildServiceProvider();


        var userRepository = services.GetRequiredService<IUserRepository>();
        var userRepositoryWithCache = services.GetRequiredService<IUserRepositoryWithCache>();

        int totalUsers = 100000;
        int blocksCount = 50;
        await AddToDatabaseChatGptAsync(totalUsers, blocksCount, userRepository);

        // await AddToDatabaseSliskAsync(totalUsers, userRepository);
        
        
        // while (true)
        // {
        //     Console.Clear();
        //     
        //     IEnumerable<UserEntity> users = [];
        //     Stopwatch sw;
        //     
        //     sw = Stopwatch.StartNew();
        //     users = await userRepository.GetAllAsync();
        //     sw.Stop();
        //     Console.WriteLine($"Elapsed time(no cache): {sw.ElapsedMilliseconds} ms");
        //     Console.ReadKey();
        //     
        //     sw = Stopwatch.StartNew();
        //     users = await userRepositoryWithCache.GetAllAsync();
        //     sw.Stop();
        //     Console.WriteLine($"Elapsed time(with cache): {sw.ElapsedMilliseconds} ms");
        //     Console.WriteLine(users.Count());
        //     Console.ReadKey();
        //
        // }
    }

    private static async Task AddToDatabaseSliskAsync(int totalUsers, IUserRepository userRepository)
    {
        // Add 50,000 Users to the database.
        for (int i = 0; i <= totalUsers; i++)
        {
            var userEntity = new UserEntity()
            {
                FirstName = $"Slisk",
                LastName = $"Linqvist",
                Email = $"test{i}@trash.com"
            };
            await userRepository.AddAsync(userEntity);
        
            if (i == 10000)
                Console.WriteLine("10k Added");
            else if (i == 20000)
                Console.WriteLine("20k Added");
            else if (i == 30000)
                Console.WriteLine("30k Added");
            else if (i == 40000)
                Console.WriteLine("40k Added");
            else if (i == 50000)
            {
                Console.WriteLine("50k Added");
                Console.WriteLine(" Press any key to continue.");
                Console.ReadKey();
            }
        }
    }

    private static async Task AddToDatabaseChatGptAsync(int totalUsers, int blocksCount, IUserRepository userRepository)
    {
        var block = "█"; // Character to represent filled block

        for (int i = 0; i <= totalUsers; i++)
        {
            var userEntity = new UserEntity()
            {
                FirstName = $"Slisk",
                LastName = $"Linqvist",
                Email = $"test{i}@trash.com"
            };
            await userRepository.AddAsync(userEntity);

            // Calculate the percentage of users added
            var percentage = (i * 100) / totalUsers;

            // Calculate how many blocks to display
            var blocksFilled = (i * blocksCount) / totalUsers;

            // Print the progress bar
            Console.Clear(); // Clear the console to update the progress bar
            Console.WriteLine($"Processed Users added to the database:");
            Console.WriteLine($"{new string(block[0], blocksFilled)}{new string('-', blocksCount - blocksFilled)}| {percentage}%");

            // Optionally, you could add a small delay to prevent flickering
            // await Task.Delay(50);
        }

        Console.WriteLine("Finished adding users.");
    }
}
