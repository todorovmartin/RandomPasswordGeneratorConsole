using System;

namespace RandomPassowrdGeneratorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Password Length");
            int passwordLength = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Use Lower Case? (yes/no)");
            string useLowerCase = Console.ReadLine();
            Console.WriteLine("Use Upper Case? (yes/no)");
            string useUpperCase = Console.ReadLine();
            Console.WriteLine("Use Numbers? (yes/no)");
            string useNumbers = Console.ReadLine();

            bool LC = true;
            bool UC = true;
            bool NUM = true;

            if (useLowerCase == "no") { LC = false; }
            if (useUpperCase == "no") { UC = false; }
            if (useNumbers == "no") { NUM = false; }

            var passwd = new RandomPasswordGenerator().GeneratePassword(LC, UC, NUM, passwordLength);
            Console.WriteLine(passwd);

        }

        private class RandomPasswordGenerator
        {
            const string LOWER_CASE = "abcdefghijklmnopqursuvwxyz";
            const string UPPER_CAES = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string NUMBERS = "123456789";

            public string GeneratePassword(bool useLowerCase, bool useUpperCase, bool useNumbers, int passwordLength)
            {
                char[] password = new char[passwordLength];
                string charSet = "";
                Random random = new Random();

                if (useLowerCase) { charSet += LOWER_CASE; }
                if (useUpperCase) { charSet += UPPER_CAES; }
                if (useNumbers) { charSet += NUMBERS; }

                for (int i = 0; i < passwordLength; i++)
                {
                    password[i] = charSet[random.Next(charSet.Length - 1)];
                }

                return String.Join(null, password);
            }
        }
    }
}
