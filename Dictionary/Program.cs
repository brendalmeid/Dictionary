/*Na contagem de votos de uma eleição, são gerados vários registros de votação contendo o
    nome do candidato e a quantidade de votos (formato .csv) 
    que ele obteve em uma urna de votação a
    partir de um arquivo, e daí gerar um relatório consolidado com os totais de cada candidato. */
using System;
using System.Collections.Generic;
using System.IO;


namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter file full path:");
            string path = Console.ReadLine();

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {

                    Dictionary<string, int> votos = new Dictionary<string, int>();
                    while (!sr.EndOfStream)
                    {
                        string[] votingRecord = sr.ReadLine().Split(',');
                        string candidate = votingRecord[0];
                        int voto = int.Parse(votingRecord[1]);

                        if (votos.ContainsKey(candidate))
                        {
                            votos[candidate] += voto;
                        }
                        else
                        {
                            votos[candidate] = voto;
                        }
                    }

                    foreach (var item in votos)
                    {
                        Console.WriteLine($"{item.Key}: {item.Value}");
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred:");
                Console.WriteLine(e.Message);
            }
        }
    }
}






