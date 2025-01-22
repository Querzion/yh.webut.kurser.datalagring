using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;
using Newtonsoft.Json;

namespace Presentation.Avalonia.Views;

public partial class MainWindow : Window
{
    private readonly string _url =
        "https://downloads.raspberrypi.com/raspios_oldstable_lite_arm64/images/raspios_oldstable_lite_arm64-2024-10-28/2024-10-22-raspios-bullseye-arm64-lite.img.xz";
    private readonly string _localPath = @"/home/querzion/Downloads/2024-10-22-raspios-bullseye-arm64-lite.img.xz";
    
    // Part 6
    private List<string> _languages = new();
    
    public MainWindow()
    {
        InitializeComponent();
        
        // Part 3 - Read the WebApi at application start.
        // Task.Run(async () =>
        // {
        //     Debug.WriteLine($"CURRENT TASK: {Task.CurrentId}, CURRENT THREAD: {Environment.CurrentManagedThreadId}");
        //     var result = await GetCustomersAsync();
        //
        //     // To fix the issue with the result not showing up; use a dispatcher to drag a task to the main thread.
        //     // WPF Dispatcher.Invoke(() => x);
        //     // Avalonia >>
        //     Dispatcher.UIThread.Invoke(() => StatusMessages.ItemsSource = result);
        // });
        
        // Part 8 - Best to use when it's more than one Task that needs to start at the startup of an application.
        Task.WhenAll(GetLanguageAsync(), GetLanguageCodeAsync());
        
        // Part 9 - this sets an await configuration, since await can't be used everywhere on its own.
        // Adding await to a constructor would make it a method, and thus would lose its functionality. 
        GetLanguageAsync().ConfigureAwait(false);
    }
    

    // Part 1 & 4
    // private void Btn_Execute_Click(object? sender, RoutedEventArgs e)
    // {
        // StatusMessages.Items.Clear();
        // StatusMessages.Items.Add("Downloading ...");
        // Download();
        // StatusMessages.Items.Add("Download finished.");
        
        // // Part 4
        // Task.Run(Calculate);
    // }
    
    // Part 2, 3 & 5
    private async void Btn_Execute_Click(object? sender, RoutedEventArgs e)
    {
        // // Part 2
        // StatusMessages.Items.Clear();
        // StatusMessages.Items.Add("Downloading ...");
        // await DownloadAsync();
        // StatusMessages.Items.Add("Download finished.");
        
        // // Part 3
        // StatusMessages.ItemsSource = null!;
        // StatusMessages.ItemsSource = await GetCustomersAsync();
        
        // // Part 5
        // var result = await GetCustomersAsync2();
        // StatusMessages.ItemsSource = result;
        
        // // Part 6
        // await AddLanguageAsync("English");
        
        // // Part 7
        // var result = GetLanguageAsync("ru-RU");
        
        // // Part 8
        // WhenAll starts both these methods at the same time.
        Task.WhenAll(GetLanguageAsync(), GetLanguageCodeAsync());
        // Instead of this way when you do one and then the next task.
        await GetLanguageAsync();
        await GetLanguageCodeAsync();
    }
    
    // Part 1
    // Synchronious (Sequential) (This should not be used out of several reasons,
    // one is that locks up the main process, second is that it's deprecated.)
    // private void Download()
    // {
    //     using var client = new WebClient();
    //     client.DownloadFile(_url, _localPath);
    // }
    
    // Part 2
    // Asynchronius (Paralell) (This is the method that should be used.)
    // private async Task DownloadAsync()
    // {
    //     using var client = new HttpClient();
    //     client.Timeout = TimeSpan.FromMinutes(10);
    //     
    //     var response = await client.GetAsync(_url);
    //
    //     using var fs = new FileStream(_localPath, FileMode.CreateNew);
    //     await response.Content.CopyToAsync(fs);
    // }

    private void Btn_Reset_Click(object? sender, RoutedEventArgs e)
    {
        // // Part 1 & 2
        // StatusMessages.ItemsSource = null!;
        //
        // if(File.Exists(_localPath))
        //     File.Exists(_localPath);
    }
    
    // Part 3
    // private async Task<IEnumerable<string>> GetCustomersAsync()
    // {
    //     // Part 3
    //     // Get a webapi that doesn't exist, so this will not work until a webapi is created.
    //     // using var client = new HttpClient();
    //     // var response = await client.GetAsync("https://localhost:7129/api/customers");
    //     // return JsonConvert.DeserializeObject<IEnumerable<string>>(await response.Content.ReadAsStringAsync())!;
    // }

    // Part 5
    // private Task<List<string>> GetCustomersAsync2()
    // {
    //     // Part 5
    //     var list = new List<string>() {"English", "Japanese", "Mandarin", "French", "Spanish", "Dutch", "Italian"};
    //     // Thread.Sleep(5000);
    //     return Task.FromResult(list);
    // }
    
    // Part 6
    // private Task AddLanguageAsync(string language)
    // {
    //     _languages.Add(language);
    //     return Task.CompletedTask;
    // }
    
    // Part 4
    // private void Calculate()
    // {
    //     for (long i = 0; i < 1000000000000000000; i++)
    //     {
    //         Debug.WriteLine($"{i}");
    //     }
    // }
    
    // Part 7
    // private string Get()
    // {
    //     var result = GetLanguageAsync("ru-RU");
    //     return result.Status.ToString();
    //     // return result.Start().Result;
    // }

    // private Task GetLanguageAsync(string language)
    // {
    //     using var client = new HttpClient();
    //     var response = client.GetAsync("https://localhost:7129/api/languages");
    //     return Task.FromResult(response);
    // }
    
    // Part 8
    private async Task GetLanguageAsync()
    {
        using var client = new HttpClient();
        var response = client.GetAsync("https://localhost:7129/api/languages");
    }
    private async Task GetLanguageCodeAsync()
    {
        using var client = new HttpClient();
        var response = client.GetAsync("https://localhost:7129/api/languageCodes");
    }
}