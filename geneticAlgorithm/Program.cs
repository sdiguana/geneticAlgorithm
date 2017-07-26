using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geneticAlgorithm

{
    class Program
    {
        static void Main()
        {
            GeneticAlgorithm.GeneratePopulation();
            
            int generationCount = 0;
            var fittest = new Individual();
            while (fittest.Fitness != 0)
            {
                var p = GeneticAlgorithm.Current;
                generationCount++;
                Console.WriteLine("");
                Console.WriteLine("Generation: " + generationCount + " Fittest: " + p.Fittest.Fitness);
                Console.WriteLine("fittest: " + p.Fittest);
                Write(p.Individuals);
                
                p = GeneticAlgorithm.EvolvePopulation();
                fittest = p.Fittest;
                //Console.ReadKey();
            }
            Console.WriteLine("");
            Console.WriteLine("Generation: " + generationCount);
            //Console.WriteLine("Genes:");
            Console.WriteLine("Successor: " + fittest + " Score: " + fittest.Fitness);

            Console.ReadLine();

        }

        private static void Write(List<Individual> pList)
        {
            var sb = new StringBuilder();
            foreach (var i in pList)
            {
                sb.Append($"{i}:{i.Fitness} ");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
