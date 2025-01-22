using System.Net;
using System.Net.Sockets;

namespace ServerApplication;

public class Server(string ipAddress, int port)
{
    private TcpListener _listener = new(IPAddress.Parse(ipAddress), port);
    private bool _isRunning = true;

    public void Start()
    {
        _listener.Start();
        Console.WriteLine($"Listening on port {port}");

        try
        {
            while (_isRunning)
            {
                var client = _listener.AcceptTcpClient();
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient!));
                clientThread.Start(client);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
        finally
        {
            _listener.Stop();
        }
    }

    private void HandleClient(object obj)
    {
        var client = (TcpClient)obj;
        var stream = client.GetStream();
        StreamReader reader = new StreamReader(stream);
        StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };
        
        Console.WriteLine("Client connected");
        try
        {
            string request = reader.ReadLine()!;
            Console.WriteLine($"Received request: {request}");
            string response = $"{request} received by server.";
            writer.WriteLine(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Communication error: {ex.Message}");
        }
        finally
        {
            client.Close();
        }
    }

    public void Stop()
    {
        _isRunning = false;
        _listener.Stop();
    }
}