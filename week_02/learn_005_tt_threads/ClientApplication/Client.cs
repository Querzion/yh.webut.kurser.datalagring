using System.Net.Sockets;

namespace ClientApplication;

public class Client
{
    private TcpClient _client;
    private StreamReader _reader;
    private StreamWriter _writer;

    public Client(string ipAddress, int port)
    {
        _client = new TcpClient(ipAddress, port);
        var stream = _client.GetStream();
        _reader = new StreamReader(stream);
        _writer = new StreamWriter(stream) { AutoFlush = true };
    }
    
    public void SendMessage(string message)
    {
        _writer.WriteLine(message);
        Console.WriteLine($"Message sent: {message}");
        
        string response = _reader.ReadLine()!;
        Console.WriteLine($"Message received: {response}");
        Console.Write("Send new message: ");
    }
    
    public void Close()
    {
        _client.Close();
    }
}