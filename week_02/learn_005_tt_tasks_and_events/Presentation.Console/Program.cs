// for (long i = 0; i < 1000000000000000000; i++)
// {
//        Console.WriteLine($"Number: {i}");     
// }

// Part 10 - Threads

// Calculate();

var calc = new Thread(Calculate);
calc.Start();

Console.ReadKey();

void Calculate()
{
    Console.WriteLine(Environment.CurrentManagedThreadId);
    
    long sum = 0;
    for (long i = 0; i < 1000000000000000000; i++)
    {
        sum += i;
        // Console.WriteLine(sum);
    }
}