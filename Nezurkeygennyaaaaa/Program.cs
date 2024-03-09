using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("How many keys? :3");
        int count;
        while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
        {
            Console.WriteLine("code broke :O");
        }

        Console.WriteLine($"Generating {count} keys made check the file");

        GenerateAndSaveRandomStrings(count);

        Console.WriteLine("keys saved to file");
        Console.WriteLine("press butrton 2 close");
        Console.ReadKey();
    }

    static void GenerateAndSaveRandomStrings(int count)
    {
        string filePath = "keysUwU.txt";

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < count; i++)
            {
                string randomString = GenerateRandomString();
                Console.WriteLine(randomString);
                writer.WriteLine(randomString);
            }
        }
    }

    static string GenerateRandomString()
    {
        Random random = new Random();
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        return $"nezur-{GenerateRandomSegment(chars, 6)}-{GenerateRandomSegment(chars, 6)}-{GenerateRandomSegment(chars, 6)}-{GenerateRandomSegment(chars, 6)}-{GenerateRandomSegment(chars, 6)}-{GenerateRandomSegment(chars, 6)}";
    }

    static string GenerateRandomSegment(string chars, int length)
    {
        Random random = new Random();
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
}
