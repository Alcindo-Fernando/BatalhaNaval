int tamanho = 10;

int[,] mapa = new int[tamanho, tamanho];
int[,] meuMapa = new int[tamanho, tamanho];

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
            int linhaX = Random.Shared.Next(0, tamanho);
            int colunaY = Random.Shared.Next(0, tamanho);




            if (colunaY + 1 > 9 && colunaY != 9)
            {
                colunaY -= tamanhoBarco;
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


            int linhaX = Random.Shared.Next(0, tamanho);
            int colunaY = Random.Shared.Next(0, tamanho);

            if (linhaX + 1 > 9 && linhaX != 9)
            {
                linhaX -= tamanhoBarco;
            }
            for (int coluna = 0; coluna < tamanhoBarco; coluna++)
            {

                matriz[linhaX, colunaY] += 1;

                colunaY += 1;

                if (colunaY > 9)
                {
                    colunaY -= tamanhoBarco;
                }
            }

        }
            tamanhoBarco--; 
    }
} 

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

void imprimirMeuMapa(int[,] matriz)
{
    for(int linha = 0; linha < tamanho; linha++)
    {
        for(int coluna = 0; coluna < tamanho; coluna++)
        {

            if (matriz[linha, coluna] > 0)
            {
                Console.Write("[ - ]");
            }
            else
            {
                Console.Write($"[{linha},{coluna}]");
            }

        }

        Console.WriteLine();
    }
}

void escolherAtaque(int[,] matriz)
{
    int soma = 0;
    while (soma < 15)
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


void escolherNavios(int[,] matriz)
{
    int tamanhoBarco = 5;

    int vertical = 0;


    for (int quantidadeBarcos = 0; quantidadeBarcos < 5; quantidadeBarcos++) //vai percorrer 5 vezes, pois são 5 barcos
    {
        imprimirMeuMapa(matriz);
        Console.WriteLine();
        Console.WriteLine("Informe 0 para barco na vertical e 1 para barco na horizontal");
        int posicao = int.Parse(Console.ReadLine());
        if (posicao == vertical)
        {
            Console.WriteLine("Informe a linha onde ira iniciar o barco");
            int linhaX = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe a coluna onde ira iniciar o barco");
            int colunaY = int.Parse(Console.ReadLine());

        

            if (colunaY + 1 > 9 && colunaY != 9)
            {
                colunaY -= tamanhoBarco;
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

            Console.WriteLine("Informe a linha onde ira iniciar o barco");
            int linhaX = int.Parse(Console.ReadLine());
            Console.WriteLine("Informe a coluna onde ira iniciar o barco");
            int colunaY = int.Parse(Console.ReadLine());
           

            if (colunaY + 1 > 9 && colunaY != 9)
            {
                colunaY -= tamanhoBarco;
            }
            for (int coluna = 0; coluna < tamanhoBarco; coluna++)
            {

                matriz[linhaX, colunaY] += 1;

                colunaY += 1;

                if (colunaY > 9)
                {
                    colunaY -= tamanhoBarco;
                }
            }

        }
        tamanhoBarco--;
    }


}


popularMatriz(mapa);
popularMatriz(meuMapa);

GerarNavios(mapa);

//escolherAtaque(mapa);

escolherNavios(meuMapa);
imprimirMeuMapa(meuMapa);


