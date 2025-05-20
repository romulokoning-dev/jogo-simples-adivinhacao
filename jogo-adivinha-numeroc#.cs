using System;

class Program
{
    static void Main()
    {
        string retry = "S";

        while (retry.ToUpper() == "S")
        {
            Random gerador = new Random();
            int number = gerador.Next(1, 21);
            bool acerto = false;
            int palpites = 0;

            Console.WriteLine("Número gerado! Faça seu palpite (entre 1 e 20):");

            while (!acerto && palpites < 5)
            {
                string pergunta = Console.ReadLine();
                int tentativa;

                bool sucesso = int.TryParse(pergunta, out tentativa);

                if (sucesso)
                {
                    palpites++;

                    if (tentativa == number)
                    {
                        Console.WriteLine($"Você acertou com {palpites} palpites!");
                        acerto = true;
                    }
                    else if (tentativa < number)
                    {
                        Console.WriteLine("Tente um número maior!");
                    }
                    else
                    {
                        Console.WriteLine("Tente um número menor!");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada inválida! Digite um número.");
                }
            }

            if (!acerto)
            {
                Console.WriteLine($"Você perdeu! O número era {number}.");
            }

            Console.WriteLine("Deseja jogar novamente? (S/N)");
            retry = Console.ReadLine();
        }

        Console.WriteLine("Obrigado por jogar!");
    }
}
