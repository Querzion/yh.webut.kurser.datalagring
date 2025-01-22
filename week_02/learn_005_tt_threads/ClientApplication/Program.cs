// videolink: https://youtu.be/ptAwkL80fcE

using ClientApplication;

Client client = new("127.0.0.1", 13000);

Console.WriteLine("Write a message (to quit application, write 'exit')");
Console.Write("Send new message: ");
string message;

while ((message = Console.ReadLine()!) != "exit")
{
    client.SendMessage(message);
}

client.Close();