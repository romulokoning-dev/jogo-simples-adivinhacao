using System;

class Program
{
    static void Main()
    {
        //cria a string condicional pro while manter o loop pro código
        string retry = "S"; 

        //início do primeiro loop, enquanto o valor de retry for "S" o loop se mantém
        while (retry.ToUpper() == "S")
        {
            // Cria o gerador do número usando Random
            Random gerador = new Random();
            // Diz pro gerador gerar o número entre 1 e 20
            int number = gerador.Next(1, 21);
            // Cria variável booleana para guardar a informação se acertou o número e manter o loop
            bool acerto = false;
            // Conta o número de palpites para futuramente o if verificar se passou do limite e também exibir quantos foram necessários
            int palpites = 0;
            //Escrevendo o texto no console
            Console.WriteLine("Número gerado! Faça seu palpite (entre 1 e 20):");
            //Condição do loop, enquanto a variável acerto não for verdadeira E a variável palpites for menor que 5 o loop se mantém
            while (!acerto && palpites < 5)
            {
                string pergunta = Console.ReadLine(); // Aqui cria a variável pergunta para o primeiro palpite
                // Essa variável tipo int vai guardar o valor da variável pergunta, após verificação para saber se foi digitado um número válido
                int tentativa;
                // Aqui verificamos com a variável bool, irá tentar converter a string pra int,e caso consiga o bool será verdadeiro, logo ele irá dar esse valor int pra variável tentativa
                bool sucesso = int.TryParse(pergunta, out tentativa);
                // caso seja valido:
                if (sucesso)
                {
                    // Adiciona +1 pra variável palpites
                    palpites++;
                    // Primeira verificação,nessa para verificar a tentativa foi igual ao número gerado
                    if (tentativa == number)
                    {
                        // Interpolação, então vai subsituir o {palpites} com a quantidade de palpites, ficando mais fácil de escrever
                        Console.WriteLine($"Você acertou com {palpites} palpites!");
                        // Aqui definimos o valor do acerto como true, entao quebramos o segundo while e perguntamos se o usuário gostaria de jogar novamente com um novo número
                        acerto = true;
                    }
                    // fazemos uma segunda verificação, agora para ver se a tentativa foi menor que o número e assim dar um palpite ao usuário
                    else if (tentativa < number)
                    {
                        // Após o palpite voltamos pro loop de pedir a entrada do usuário
                        Console.WriteLine("Tente um número maior!");
                    }
                    // Para deixar o código limpo, não fazemos uma terceira verificação, já verificamos se o número é o mesmo e menor que o gerado, então caso essas duas sejam false, só sobra a tentativa ser maior que o número
                    else
                    {
                        Console.WriteLine("Tente um número menor!");
                    }
                }
                //aqui é o else do primeiro if que converte a string em int usando o TryParse pra evitar quebra do código, então caso não converta com sucesso é gerado uma mensagem de erro e volta para o usuário digitar novamente
                else
                {
                    Console.WriteLine("Entrada inválida! Digite um número.");
                }
            }
            // Se o jogador sair do loop sem acertar enviamos a mensagem de derrota e revelamos o número gerado
            if (!acerto)
            {
                Console.WriteLine($"Você perdeu! O número era {number}.");
            }
            //Pergunta se quer jogar novamente , mas a entrada do usuário modifica o retry, que é a condicional do loop while
            Console.WriteLine("Deseja jogar novamente? (S/N)");
            retry = Console.ReadLine();
        }
        // Caso negativa, limpamos o console e agradecemos ao jogador
        Console.Clear();
        Console.WriteLine("Obrigado por jogar!");
    }
}
