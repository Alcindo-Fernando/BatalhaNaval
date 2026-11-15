int tamanho = 10;

int[,] mapa = new int[tamanho, tamanho];

void popularMatriz(int[,] matriz)
{

    for (int linha = 0; linha < tamanho; linha++)
    {

        for(int coluna = 0; coluna < tamanho; coluna++)
        {

            matriz[linha, coluna] = 0;

        }

    }

}
 

 void GerarNavios(int[,] matriz)
{

    int tamanhoBarco = 5;

    int vertical = 0;


    for (int quantidadeBarcos = 0; quantidadeBarcos < 5; quantidadeBarcos++) //vai percorrer 5 vezes, pois são 5 barcos
    {
        int posicao = Random.Shared.Next(0, 2);
        if (posicao == vertical)
        {
            int linhaX = Random.Shared.Next(0, 10);
            int colunaY = Random.Shared.Next(0, 10);




            if (colunaY + 1 > 9)
            {
                colunaY -= 4;
            }
            for (int coluna = 0; coluna < tamanhoBarco; coluna++)
            {

                matriz[linhaX, colunaY] += 1;

                linhaX += 1;

                if (linhaX > 9)
                {
                    linhaX -= tamanhoBarco;
                }
                
            }
        }
        else
        {


            int linhaX = Random.Shared.Next(0, 10);
            int colunaY = Random.Shared.Next(0, 10);

            if (linhaX + 1 > 9)
            {
                linhaX -= 4;
            }
            for (int coluna = 0; coluna < tamanhoBarco; coluna++)
            {

                matriz[linhaX, colunaY] += 1;

                colunaY += 1;

                if (colunaY + 1 > 9)
                {
                    colunaY -= tamanhoBarco;
                }
            }

        }
            tamanhoBarco--; 
    }
} 


popularMatriz(mapa);

GerarNavios(mapa);

Console.WriteLine();

imprimirMapa(mapa);

//int soma = 0;

//for(int i = 0; i < tamanho; i++)
//{
//    for(int j = 0; j < tamanho; j++)
//    {
//        soma += mapa[i, j]; 
//    }
//}

void imprimirMapa(int[,] matriz)
{
    int contador = 0;
    for (int i = 0; i < tamanho; i++)
    {
        for (int j = 0; j < tamanho; j++)
        {
            if (mapa[i, j] == 0)
            {
                Console.Write($"[ ]");

            }
            else
            {
                Console.Write($"[{mapa[i, j]}]");
            }
        }
        Console.WriteLine();
    }
}

