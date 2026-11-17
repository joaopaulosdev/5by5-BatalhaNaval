using System.Numerics;
//INICIALIZANDO MATRIZES
char[,] matrizAguaTiros = new char[10, 10];
char[,] matrizNaviosP1 = new char[10, 10];
char[,] matrizNaviosP2 = new char[10, 10];
//CONTADOR DAS PARTES DOS NAVIOS
int partesNaviosP1 = 0;
int partesNaviosP2 = 0;

//PREENCHENDO AS MATRIZES COM ÁGUA
for (int linha = 0; linha < 10; linha++)
{
    for (int coluna = 0; coluna < 10; coluna++)
    {
        matrizAguaTiros[linha, coluna] = '~';
    }
}
for (int linha = 0; linha < 10; linha++)
{
    for (int coluna = 0; coluna < 10; coluna++)
    {
        matrizNaviosP1[linha, coluna] = '~';
    }
}
for (int linha = 0; linha < 10; linha++)
{
    for (int coluna = 0; coluna < 10; coluna++)
    {
        matrizNaviosP2[linha, coluna] = '~';
    }
}

//FUNÇÕES DE POSICIONAMENTO
void PosicionarNavio(char[,] matrizNavios, int tamanho)
{
    Random random = new Random();
    bool posicaoValida = true;
    int orientacaoBarco = random.Next(0, 2); //Orientação vertical/horizontal

    if (orientacaoBarco == 0) //caso for 0 ele posicionará na horizontal
    {
        while (posicaoValida == true)
        {
            //GERANDO POSIÇÃO
            int linha = random.Next(0, 10);
            int coluna = random.Next(0, 10);
            if (coluna + tamanho <= 9)
            {
                for (int i = coluna; i <= coluna + tamanho; i++) //Entra se o navio couber no mapa
                {
                    if (matrizNavios[linha, i] == 'N') //verifica se tem sobreposição de navios
                    {
                        posicaoValida = false;
                        break;
                    }
                }

                if (posicaoValida == true) //caso a posição não tiver sobreposição, sendo válida
                {
                    for (int i = coluna; i <= coluna + tamanho; i++) //posiciona o navio, colocando 'N' nas suas posições
                    {
                        matrizNavios[linha, i] = 'N';
                    }
                    posicaoValida = false; //define como falso para sair do laço
                }
                else
                {
                    posicaoValida = true; //reinicia a variável para que ele tente novamente outra posição.
                }
            }
        }
    }
    else //caso for 1 ele posicionará na vertical
    {
        while (posicaoValida == true)
        {
            //GERANDO POSIÇÃO
            int linha = random.Next(0, 10);
            int coluna = random.Next(0, 10);
            if (linha + tamanho <= 9)
            {
                for (int i = linha; i <= linha + tamanho; i++) //Entra se o navio coubmer no mapa
                {
                    if (matrizNavios[i, coluna] == 'N') //verifica se tem sobreposição de navios
                    {
                        posicaoValida = false;
                        break;
                    }
                }

                if (posicaoValida == true) //caso a posição não tiver sobreposição, sendo válida
                {
                    for (int i = linha; i <= linha + tamanho; i++) //posiciona o navio, colocando 'N' nas suas posições
                    {
                        matrizNavios[i, coluna] = 'N';
                    }
                    posicaoValida = false; //define como falso para sair do laço
                }
                else
                {
                    posicaoValida = true; //reinicia a variável para que ele tente novamente outra posição.
                }
            }
        }
    }
}

void InserirNavios(char[,] matrizNavios, int tamanho, int quantidade, ref int partesNavios)
{

    for (int i = 0; i < quantidade; i++) //roda a quantidade de navios indicado
    {
        PosicionarNavio(matrizNavios, tamanho);
    }

    partesNavios += (tamanho * quantidade); //faz a multiplicação e soma

}

void ExibirTabuleiros(char[,] meuTabuleiro, char[,] tabuleiroTiros)
{
    Console.Clear();
    Console.WriteLine("     SEU TABULEIRO (Navios)          TABULEIRO DE ATAQUE (Tiros)");
    Console.WriteLine("   0 1 2 3 4 5 6 7 8 9             0 1 2 3 4 5 6 7 8 9");

    for (int i = 0; i < 10; i++)
    {
        Console.Write($"{i} ");
        for (int j = 0; j < 10; j++)
        {
            Console.Write($" {meuTabuleiro[i, j]}");
        }

        Console.Write("          ");

        Console.Write($"{i} ");
        for (int j = 0; j < 10; j++)
        {
            Console.Write($" {tabuleiroTiros[i, j]}");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

void MostrarExplosao()
{
    Console.Clear();
    Console.WriteLine("     *     ");
    Console.WriteLine("  \\  |  /  ");
    Console.WriteLine("    BOOM!  ");
    Console.WriteLine("  /  |  \\  ");
    Console.WriteLine("     *     ");
    System.Threading.Thread.Sleep(1000); // Pausa de 1 segundo
}


//INSERINDO TIPOS DE NAVIOS
InserirNavios(matrizNaviosP1, 5, 1, ref partesNaviosP1); 
InserirNavios(matrizNaviosP1, 4, 1, ref partesNaviosP1); 
InserirNavios(matrizNaviosP1, 3, 2, ref partesNaviosP1);  
InserirNavios(matrizNaviosP1, 2, 1, ref partesNaviosP1);  

InserirNavios(matrizNaviosP2, 5, 1, ref partesNaviosP2);
InserirNavios(matrizNaviosP2, 4, 1, ref partesNaviosP2);
InserirNavios(matrizNaviosP2, 3, 2, ref partesNaviosP2);
InserirNavios(matrizNaviosP2, 2, 1, ref partesNaviosP2);

//RODANDO O JOGO 
while (partesNaviosP1 > 0 && partesNaviosP2 > 0)
{
    ExibirTabuleiros(matrizNaviosP1, matrizAguaTiros);

    bool tiroCorreto = false;

    //TIRO USUÁRIO P1
    do
    {
        tiroCorreto = false;
        int linhaTiro, colunaTiro;
        Console.WriteLine("Digite as coordenadas para o seu próximo tiro: ");
        Console.Write("Linha: ");
        linhaTiro = int.Parse(Console.ReadLine()!);
        Console.Write("Coluna: ");
        colunaTiro = int.Parse(Console.ReadLine()!);

        if (matrizNaviosP2[linhaTiro, colunaTiro] == 'O' || matrizNaviosP2[linhaTiro, colunaTiro] == 'D')
        {
            Console.WriteLine("Você já atirou nesta posição, tente novamente!");
            Console.ReadKey();
        }
        else if (matrizNaviosP2[linhaTiro, colunaTiro] == '~')
        {
            Console.WriteLine("Você errou o tiro!");
            matrizAguaTiros[linhaTiro, colunaTiro] = 'O';
            matrizNaviosP2[linhaTiro, colunaTiro] = 'O';
            tiroCorreto = true;
            Console.ReadKey();
        }
        else if (matrizNaviosP2[linhaTiro, colunaTiro] == 'N')
        {
            MostrarExplosao();
            Console.WriteLine("Você atingiu uma embarcação!");
            matrizAguaTiros[linhaTiro, colunaTiro] = 'D';
            matrizNaviosP2[linhaTiro, colunaTiro] = 'D';
            partesNaviosP2--;
            tiroCorreto = true;
            Console.ReadKey();
        }

    } while (tiroCorreto == false);

    //TIRO MÁQUINA P2
    do
    {
        tiroCorreto = false;

        Random random = new Random();
        int linhaTiro = random.Next(0, 10);
        int colunaTiro = random.Next(0, 10);

        if (matrizNaviosP1[linhaTiro, colunaTiro] == 'O' || matrizNaviosP1[linhaTiro, colunaTiro] == 'D')
        {
            continue; //POSIÇÃO JÁ TENTADA
        }
        else if (matrizNaviosP1[linhaTiro, colunaTiro] == '~')
        {
            Console.WriteLine("A MÁQUINA errou o tiro!");
            matrizNaviosP1[linhaTiro, colunaTiro] = 'O';
            tiroCorreto = true;
            Console.ReadKey();
        }
        else if (matrizNaviosP1[linhaTiro, colunaTiro] == 'N')
        {
            MostrarExplosao();
            Console.WriteLine("A MÁQUINA atingiu sua embarcação!!");
            matrizNaviosP1[linhaTiro, colunaTiro] = 'D';
            partesNaviosP1--;
            tiroCorreto = true;
            Console.ReadKey();
        }

    } while (tiroCorreto == false);
}

//RESULTADO DO JOGO
if (partesNaviosP1 == 0) //partes do navio do P1 chegou a 0 = navios foram destruídos.
{
    Console.WriteLine("O inacreditável aconteceu, você conseguiu perder para a máquina!");
}
else //partes do navio do P2 chegou a 0, navios foram destruídos.
{
    Console.WriteLine("Parabéns, não fez mais que a obrigação, você é o GANHADOR!!");
}

Console.WriteLine("\nPressione qualquer tecla para sair...");
Console.ReadKey();