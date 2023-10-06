namespace hashCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OtusDictionary dictionary = new OtusDictionary();
            dictionary[1] = "один";
            dictionary[2] = "два";
            dictionary.Add(3, "три");
            try
            {
                dictionary.Add(2, "Два");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            Console.WriteLine(dictionary[4]);
            dictionary[4] = "четыре";
            dictionary[5] = "пять";
            dictionary[6] = "шесть";
            dictionary.Add(7, "семь");
            for (int i = 1; i <= 7; i++)
            {
                Console.WriteLine($"Key {i}: {dictionary[i]}");
            }

            Console.ReadKey();
        }
    }
}