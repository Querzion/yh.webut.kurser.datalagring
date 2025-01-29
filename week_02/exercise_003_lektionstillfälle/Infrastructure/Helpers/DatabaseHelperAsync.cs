using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Infrastructure.Helpers;

public class DatabaseHelperAsync
{
    public static async Task<string> GetDatabaseConnectionStringAsync()
    {
        // Determine the correct database path based on the OS
        string databasePath = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
            ? @"C:\Projects\DataBase\SQLite_Database.db"
            : Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Projects", "Database", "SQLite_Database.db");

        await EnsureDatabaseExistsAsync(databasePath);
        await RunEfMigrationsAsync(); // Run the EF migration command

        return $"Data Source={databasePath}";
    }

    private static async Task EnsureDatabaseExistsAsync(string databasePath)
    {
        // Ensure the directory exists
        string? directoryPath = Path.GetDirectoryName(databasePath);
        if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        // Create the database file asynchronously if it does not exist
        if (!File.Exists(databasePath))
        {
            await using var stream = File.Create(databasePath);
            await stream.FlushAsync(); // Ensure the file is written properly before closing
        }
    }

    private static async Task RunEfMigrationsAsync()
    {
        try
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dotnet-ef",
                    Arguments = "database update",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WorkingDirectory = Directory.GetCurrentDirectory() // Ensure it's run in the correct project folder
                }
            };

            process.Start();

            string output = await process.StandardOutput.ReadToEndAsync();
            string error = await process.StandardError.ReadToEndAsync();
            await process.WaitForExitAsync(); // Wait asynchronously

            Console.WriteLine(output);
            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine("EF Migration Error: " + error);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to run EF migrations: {ex.Message}");
        }
    }
}