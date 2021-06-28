using System;

namespace Ivory.TesteEstagio.CampoMinado
{
    class Program
    {
        static void Main(string[] args)
        {
            var campoMinado = new CampoMinado();
            Console.WriteLine("Início do jogo\n=========");
            Console.WriteLine(campoMinado.Tabuleiro);

            // Realize sua codificação a partir deste ponto, boa sorte!
            Console.WriteLine();

            var campoMinadoVitoria = new CampoMinado();
            string tabuleiroJogo = campoMinado.Tabuleiro;
            string[,] tabuleiroJogoMatriz = gerarMatriz(tabuleiroJogo);


            for(int linha = 0; linha < 9; linha++)
            {
                for(int coluna = 0; coluna < 9; coluna++)
                {
                    //Se a posição testada é uma casa fechada
                    if (tabuleiroJogoMatriz[linha, coluna].Equals("-"))
                    {
                        campoMinado.Abrir(linha + 1 , coluna + 1);
                        tabuleiroJogoMatriz = gerarMatriz(campoMinado.Tabuleiro);
                        
                        //Se a posição aberta não for uma bomba, pode abrir no novo tabuleiro.
                        if(!tabuleiroJogoMatriz[linha, coluna].Equals("*"))
                        {
                            campoMinadoVitoria.Abrir(linha + 1, coluna + 1);
                        }

                        //Se posição é bomba, informa no console localização.
                        else if (tabuleiroJogoMatriz[linha, coluna].Equals("*"))
                        {
                            Console.WriteLine("Bomba na linha: {0} | Coluna {1}", linha+1, coluna+1);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }


            //após testar todo o tabuleiro, gera uma nova matriz com o tabuleiro que foi aberto corretamente
            //e informa o novo tabuleiro no console.
          
            string[,] tabuleiroVitoriaMatriz = gerarMatriz(campoMinadoVitoria.Tabuleiro);

            for(int linha = 0; linha < 9; linha++ )
            {
                Console.WriteLine();
                for (int coluna = 0; coluna < 9; coluna++)
                {
                    Console.Write(tabuleiroVitoriaMatriz[linha, coluna]);
                }
            }

            //LINHA APENAS PARA NÃO FECHAR O CONSOLE AUTOMATICAMENTE CASO CONFIGURADO PARA O MESMO.
            Console.ReadLine();
        }



            //metodo gerador de matriz.
            //Recebe a String do tabuleiro, e converte para uma Matriz de String, com cada posição para testes
            //retorna a matriz de String com o formato do tabuleiro 9x9.
        static string[,] gerarMatriz(string tabuleiro)
        {
            string tabuleiroReplaced = tabuleiro.Replace("\r\n", "");
            int index = 0;
            string[,] novoTabuleiro = new string[9, 9];
            for (int linha = 0; linha < 9; linha++)
            {
                for (int coluna = 0; coluna < 9; coluna++)
                {

                    novoTabuleiro[linha, coluna] = tabuleiroReplaced.Substring(index, 1);
                    index++;
                }
            }
            return novoTabuleiro;
        }

    }
}
