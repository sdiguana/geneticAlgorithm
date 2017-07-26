using System;
using System.Linq;

namespace geneticAlgorithm
{
    public static class GeneticAlgorithm
    {
        private static double crossoverRate = 0.5;     // 50%
        private static double mutationRate = 0.025;    // 2.5%
        private static double breedingThreshold = 0.3; // 30% of the population is bred

        private static int PopulationSize = 20;

        private static Population _lastGen;
        public static Population Current;
        
       public static void GeneratePopulation()
        {
            Current = new Population(PopulationSize);
        }
        public static Population EvolvePopulation()
        {
            _lastGen = Current;
            Current = new Population(null);
            //Migrate Elite Parents to the new list
            MigrateElites(5);
            _lastGen.Cull(5);
            PropegateElitism(10);

            while (Current.Individuals.Count < PopulationSize)
            {
                //SievePopulation();
                
                 var r = Rand.Random(0, 100)/100.0;
                 if (r < breedingThreshold || _lastGen.Individuals.Count  == 1)
                     BreedPopulation();
                 else
                     SievePopulation();
                 
            }
            return Current;
        }

        private static void MigrateElites(int n)
        {
            for (int i = 0; i < n; i++)
            {
                var eliteParent = _lastGen.Individuals.First();
                Current.Add(eliteParent);
                _lastGen.Remove(eliteParent);
            }
        }

        private static void BreedPopulation()
        {
            var parentA = _lastGen.TournamentSelect();
            var parentB = _lastGen.TournamentSelect();

            _lastGen.Remove(parentA);
            _lastGen.Remove(parentB);

            var children = Population.Crossover(parentA, parentB, crossoverRate);
            Current.Add(children[0].Mutate(mutationRate));
            Current.Add(children[1].Mutate(mutationRate));
            //var child2 = Population.Crossover(parentB, parentA, crossoverRate);
            //Current.Add(child2.Mutate(mutationRate));
        }

        private static void PropegateElitism(int bebes)
        {
            var eliteParent = Current.Individuals.First();
            var parentB = _lastGen.TournamentSelect();

            for (int i = 0; i < bebes; i++)
            {
                var children = Population.Crossover(eliteParent, parentB, crossoverRate);

                Current.Add(children[0].Mutate(2*mutationRate));
                Current.Add(children[1].Mutate(2 * mutationRate));
            }
            if(!Current.Individuals.Contains(eliteParent)) throw new Exception("something bad happened");
            
        }

        private static void SievePopulation()
        {
            var r = Rand.Random(0, _lastGen.Individuals.Count);
            var i = _lastGen.Individuals[r].Mutate(mutationRate);
            _lastGen.Remove(i);
            Current.Add(i);
        }

        
    }
}
