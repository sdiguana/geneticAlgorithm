using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geneticAlgorithm
{
    public static class Fitness
    {
        public static int Evaluate(List<Gene> chromosome)
        {
            var s = ConcatenateGenome(chromosome);
            var t = "this is the target sentance";  //27 char - Must Edit the Gene.GeneCount const to Match - no graceful error handling for genome length has been implemented yet.
            //this is the fitness function
            //the LINQ query below effetice says: for each char in the sentance, sum up the difference in letter points and multiply the sum by 10, then return it
            return s.Select((t1, i) => ScoreChar(t[i], t1)).Sum() * 10;
        }

        private static int ScoreChar(char target, char guess)
        {
            var scoreCard = new Dictionary<char, int>()
            {
                { '0',1},
                { '1',2},
                { '2',3},
                { '3',4},
                { '4',5},
                { '5',6},
                { '6',7},
                { '7',8},
                { '8',9},
                { '9',10},
                { 'a',11},
                { 'b',12},
                { 'c',13},
                { 'd',14},
                { 'e',15},
                { 'f',16},
                { 'g',17},
                { 'h',18},
                { 'i',19},
                { 'j',20},
                { 'k',21},
                { 'l',22},
                { 'm',23},
                { 'n',24},
                { 'o',25},
                { 'p',26},
                { 'q',27},
                { 'r',28},
                { 's',29},
                { 't',30},
                { 'u',31},
                { 'v',32},
                { 'w',33},
                { 'x',34},
                { 'y',35},
                { 'z',36},
                { ' ',37},
            };

            var targetValue = scoreCard.FirstOrDefault(s => s.Key.Equals(target)).Value;
            var guessValue = scoreCard.FirstOrDefault(s => s.Key.Equals(guess)).Value;
            var delta = Math.Abs(targetValue - guessValue);

            return delta;
        }

        private static string ConcatenateGenome(List<Gene> chromosome)
        {
            var sb = new StringBuilder();
            foreach (var gene in chromosome)
            {
                sb.Append(gene.GeneMap.Char);
            }
            return sb.ToString();
        }
    }
}
