namespace Cifrul___n_
{
    using System;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("1. Criptare");
            Console.WriteLine("2. Decriptare");
            Console.WriteLine("3. Criptanaliza");
            Console.Write("Alegeti optiunea: ");
            int opt = int.Parse(Console.ReadLine());

            if (opt == 1 || opt == 2)
            {
                Console.Write("Introduceti textul: ");
                string text = Console.ReadLine();

                Console.Write("Introduceti cheia n (0..25): ");
                int n = int.Parse(Console.ReadLine()) % 26;

                if (opt == 2)
                    n = 26 - n; // pentru decriptare

                string rezultat = Cifru(text, n);
                Console.WriteLine("Rezultat: " + rezultat);
            }
            else if (opt == 3)
            {
                Console.Write("Introduceti textul criptat: ");
                string textCriptat = Console.ReadLine();

                Console.WriteLine("\nCriptanaliza (toate cheile):");
                for (int n = 0; n < 26; n++)
                {
                    string posibil = Cifru(textCriptat, 26 - n);
                    Console.WriteLine($"n = {n} -> {posibil}");
                }
            }
        }

        static string Cifru(string text, int n)
        {
            char[] rezultat = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (char.IsUpper(c))
                {
                    rezultat[i] = (char)('A' + (c - 'A' + n) % 26);
                }
                else if (char.IsLower(c))
                {
                    rezultat[i] = (char)('a' + (c - 'a' + n) % 26);
                }
                else
                {
                    rezultat[i] = c; // caractere nemodificate
                }
            }

            return new string(rezultat);
        }
    }
}
