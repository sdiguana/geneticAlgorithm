using System.Collections.Generic;
using System.Text;

namespace geneticAlgorithm
{
    public class Individual
    {
        //Fields
        public List<Gene> Genome;
        //Properties
        //CTOR
        public Individual()
        {
            Genome = Gene.ChromosomeFactory();
        }
        //Methods
        public static List<Individual> BuildFactory(int count)
        {
            var individuals = new List<Individual>();
            for (var i = 0; i < count; i++)
                individuals.Add(new Individual());
            return individuals;
        }
        public int Fitness => geneticAlgorithm.Fitness.Evaluate(Genome);

        public Individual Mutate(double mutationThreshold)
        {
            foreach (var g in Genome)
            {
                if (Rand.Random(0,101) / 100.0 <= mutationThreshold)
                    g.Mutate();
            }
            //if (Genome.Count > 4) throw new InvalidExpressionException();
            return this;
        }

        public Individual Decimate()
        {
            Genome.Clear();
            return this;
        }

        public override string ToString()
        {
            var sb= new StringBuilder();
            
            foreach (var g in Genome)
            {
                sb.Append(g);
            }
            return sb.ToString();
        }
    }

}
