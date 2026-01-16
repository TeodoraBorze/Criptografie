namespace Cifrului_lui_Cezar
{
    using System;

    class CezarCipher
    {
        static void Main()
        {
            Console.WriteLine("CIFRUL LUI CEZAR");
            Console.WriteLine("1. Criptare");
            Console.WriteLine("2. Decriptare");
            Console.WriteLine("3. Criptanaliza");
            Console.Write("Alege optiunea: ");

            int opt = int.Parse(Console.ReadLine());

            Console.Write("Introdu textul: ");
            string text = Console.ReadLine();

            switch (opt)
            {
                case 1:
                    Console.WriteLine("Text criptat: " + Cezar(text, 3));
                    break;

                case 2:
                    Console.WriteLine("Text decriptat: " + Cezar(text, -3));
                    break;

                case 3:
                    Criptanaliza(text);
                    break;

                default:
                    Console.WriteLine("Optiune invalida!");
                    break;
            }
        }

        // Functie de criptare/decriptare
        static string Cezar(string text, int shift)
        {
            char[] rezultat = new char[text.Length];

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (char.IsLetter(c))
                {
                    char baza = char.IsUpper(c) ? 'A' : 'a';
                    rezultat[i] = (char)((c - baza + shift + 26) % 26 + baza);
                }
                else
                {
                    rezultat[i] = c; // caracterele non-literă rămân neschimbate
                }
            }

            return new string(rezultat);
        }

        // Criptanaliza – incearca toate deplasarile
        static void Criptanaliza(string text)
        {
            Console.WriteLine("\nRezultatele criptanalizei:");
            for (int i = 1; i <= 25; i++)
            {
                Console.WriteLine($"Deplasare {i}: {Cezar(text, -i)}");
            }
        }
    }
}