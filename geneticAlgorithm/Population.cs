using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace geneticAlgorithm
{
    public class Population
    {
        //Fields
        //Properties
        public List<Individual> Individuals
        {
            get => _individuals.OrderBy(f => f.Fitness).ToList(); 
            set => _individuals = value;
        }

        public void Add(Individual i) => _individuals.Add(i);
        public void Remove(Individual i) => _individuals.Remove(i);
        private List<Individual> _individuals;

        public Individual Fittest => Individuals.First();
        //CTOR
        public Population(int? size)
        {
            _individuals = size == null ? new List<Individual>() : Individual.BuildFactory((int)size);
        }

        public Population Decimate()
        {
            _individuals.Clear();
            return this;
        }
        //Methods
       

        public static Individual[] Crossover(Individual a, Individual b, double threshold)
        {
            var ca = new Individual().Decimate();
            var cb = new Individual().Decimate();
            
            for (var i = 0; i < a.Genome.Count; i++)
            {
                // a deep copy must be performed to not mutate the parent population
                var agm = a.Genome[i];
                var bgm = b.Genome[i];
                var r = Rand.Random(0,100) / 100.0;
                ca.Genome.Add(r <= threshold ? agm.Copy() : bgm.Copy());
                cb.Genome.Add(r <= threshold ? bgm.Copy() : agm.Copy());
            }
            return new[] {ca,cb};
    }

        public Individual TournamentSelect()
        {
            Individual fittest = null;
            for (var i=0; i<1;i++)  // run 2 round tournaments
            {
                var index = Rand.Random(0, _individuals.Count);
                var a = _individuals[index];
                if (fittest == null || a.Fitness < fittest.Fitness)
                    fittest = a;
            }
            return fittest;
        }
        public void Cull(int n)
        {
            for (var i = 0; i < n; i++)
            {
                var dead = Individuals.Last();
                _individuals.Remove(dead);
                _individuals.Add(new Individual());
            }

        }
        public string Write()
        {
            var sb = new StringBuilder();
            foreach (var i in Individuals)
            {
                sb.Append(i);
                sb.Append(" ");
            }
            return sb.ToString();
        }
        
    }
}
