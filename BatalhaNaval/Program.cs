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
 
 void gerarNavios(int[,] matriz)
{
     int colunaY;
     int linhaX;

    int tamanhoBarco = 5;

    int vertical = 0;


    for (int quantidadeBarcos = 0; quantidadeBarcos < 5; quantidadeBarcos++) //vai percorrer 5 vezes, pois são 5 barcos
    {
        int posicao = Random.Shared.Next(0, 2);
        if (posicao == vertical)
        {
            do
            {
                linhaX = Random.Shared.Next(0, tamanho);
                colunaY = Random.Shared.Next(0, tamanho);
            } while (matriz[linhaX, colunaY] < 0);



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


            linhaX = Random.Shared.Next(0, tamanho);
            colunaY = Random.Shared.Next(0, tamanho);

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

        int linhaAtaque;
        int colunaAtaque;
        bool valido;
        do{
            imprimirMapa(matriz);
            valido = false;
            Console.Write("escolha a linha do ataque: ");
            linhaAtaque = int.Parse(Console.ReadLine());
            Console.Write("escolha a coluna do ataque: ");
            colunaAtaque = int.Parse(Console.ReadLine());
            if(linhaAtaque > 9 || linhaAtaque < 0 || colunaAtaque > 9 || colunaAtaque < 0)
            {
                valido = true;
            Console.WriteLine("Posição inválida, tente novamente!");
            }
        }while(valido);
        

        if (matriz[linhaAtaque, colunaAtaque] > 0)
        {
            matriz[linhaAtaque, colunaAtaque] = -1;
        } else
        {
            matriz[linhaAtaque, colunaAtaque] = -2;
        }


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

void escolhaDaMaquina(int[,] matriz)
{
    
        int linhaAtaque;
        int colunaAtaque;
        Console.WriteLine();
        do{
            linhaAtaque = Random.Shared.Next(0, 10);
        
            colunaAtaque = Random.Shared.Next(0, 10);

        } while (matriz[linhaAtaque, colunaAtaque] < 0);

        if (matriz[linhaAtaque, colunaAtaque] > 0)
        {
           
            matriz[linhaAtaque, colunaAtaque] = -1;
        }
        else if (matriz[linhaAtaque, colunaAtaque] != -1)
        {
            matriz[linhaAtaque, colunaAtaque] = -2;
        }


}

int soma(int[,] matriz)

{
    int soma = 0;
    for(int linha = 0; linha < tamanho; linha++)
    {
        for(int coluna = 0; coluna < tamanho; coluna++)
        {
            if (matriz[linha, coluna] < 0)
            {
                soma += 0;
            }
            else
            {
                soma += matriz[linha, coluna];

            }
        }
    }

    return soma;
}

void jogo(int[,] mapaMaquina, int[,] meuMapa)
{
    int jogarMais;


    do
    {
        popularMatriz(mapaMaquina);
        gerarNavios(mapaMaquina);

        popularMatriz(meuMapa);
        escolherNavios(meuMapa);




        while (soma(meuMapa) != 0 && soma(mapaMaquina) != 0)
        {

            escolhaDaMaquina(meuMapa);
            Console.WriteLine("Escolha da maquina");
            imprimirMapa(meuMapa);
            Console.WriteLine();
            Console.WriteLine("Escolher ataque");
            escolherAtaque(mapaMaquina);

            soma(meuMapa);
            soma(mapaMaquina);

        }

        if (soma(meuMapa) == 0)
        {
            Console.WriteLine("Você perdeu!!");
            imprimirMapa(mapaMaquina);
        }
        else if (soma(mapaMaquina) == 0)
        {
            Console.WriteLine("Você ganhou!!");
            imprimirMapa(mapaMaquina);
        }
        Console.Write("digite 1 para jogar denovo ou 0 para parar: ");
        jogarMais = int.Parse(Console.ReadLine());

    } while (jogarMais != 0);
}
 

jogo(mapa, meuMapa);