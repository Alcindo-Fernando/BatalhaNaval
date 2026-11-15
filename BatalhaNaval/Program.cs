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

escolherAtaque(mapa);



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
    for(int linha = 0; linha < tamanho; linha++)
    {
        for(int coluna = 0; coluna < tamanho; coluna++)
        {
            if (matriz[linha,coluna] == -1)
            {
                Console.Write("[ * ]");
            } else if (matriz[linha, coluna] == -2)
            {
                Console.Write("[   ]");
            }
            else
            {
                Console.Write($"[{linha},{coluna}]");
            }
        }
            Console.WriteLine();
    }
}

void mostrarMapa()
{

    int contador = 1;
    for (int i = 0; i < tamanho; i++)
    {
        for (int j = 0; j < tamanho; j++)
        {
            Console.Write($"[{i}, {j}]\t");
            contador++;
           
        }
        Console.WriteLine();
    }
}

void escolherAtaque(int[,] matriz)
{
    int soma = 0;
    while (soma < 16)
    {
        int linhaAtaque;
        int colunaAtaque;
        imprimirMapa(mapa);
        Console.Write("escolha a linha do ataque: ");
        linhaAtaque = int.Parse(Console.ReadLine());
        Console.Write("escolha a coluna do ataque: ");
        colunaAtaque = int.Parse(Console.ReadLine());

        soma += matriz[linhaAtaque, colunaAtaque];

        if (matriz[linhaAtaque, colunaAtaque] > 0)
        {
            matriz[linhaAtaque, colunaAtaque] = -1;
        } else
        {
            matriz[linhaAtaque, colunaAtaque] = -2;
        }

        
    }

    Console.WriteLine("Você ganhou!!");

}



