using System.Numerics;

char[,] matrizAguaTiros = new char[10, 10];

for (int linha = 0; linha < 10; linha++)
{
    for (int coluna = 0; coluna < 10; coluna++)
    {
        matrizAguaTiros[linha, coluna] = '~';
    }
}

char[,] matrizNavios = new char[10, 10];
void PosicionarNavio(char[,] matrizNavios, int tamanho)
{
    Random random = new Random();
    bool posicaoValida = true;
    int orientacaoBarco = random.Next(0, 2);
    if(orientacaoBarco == 0)
    {
        while (posicaoValida == true)
        {
            //GERANDO POSIÇÃO
            int linha = random.Next(0, 10);
            int coluna = random.Next(0, 10);
            if (coluna + tamanho <= 9)
            {
                for (int i = coluna; i <= coluna + tamanho; i++)
                {
                    if (matrizNavios[linha, i] == 'N')
                    {
                        posicaoValida = false;
                        break;
                    }
                }

                if (posicaoValida == true)
                {
                    for (int i = coluna; i <= coluna + tamanho; i++)
                    {
                        matrizNavios[linha, i] = 'N';
                    }
                    posicaoValida = false; //sai do laço While
                }
                else
                {
                    posicaoValida = true;
                }
            }
        }
    }
    else
    {
        while (posicaoValida == true)
        {
            //GERANDO POSIÇÃO
            int linha = random.Next(0, 10);
            int coluna = random.Next(0, 10);
            if (linha + tamanho <= 9)
            {
                for (int i = linha; i <= linha + tamanho; i++)
                {
                    if (matrizNavios[i, coluna] == 'N')
                    {
                        posicaoValida = false;
                        break;
                    }
                }

                if (posicaoValida == true)
                {
                    for (int i = linha; i <= linha + tamanho; i++)
                    {
                        matrizNavios[i, coluna] = 'N';
                    }
                    posicaoValida = false; //sai do laço While
                }
                else
                {
                    posicaoValida = true;
                }
            }
        }
    }
}

void InserirNavios(char[,] matrizNavios, int tamanho, int quantidade)
{   

    for(int i = 0; i < quantidade; i++)
    {
        PosicionarNavio(matrizNavios, tamanho);
    }
}