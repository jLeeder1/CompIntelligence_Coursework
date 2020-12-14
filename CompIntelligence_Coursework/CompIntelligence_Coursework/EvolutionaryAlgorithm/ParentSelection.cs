using CompIntelligence_Coursework.EvolutionaryAlgorithm;
using CompIntelligence_Coursework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompIntelligence_Coursework.EvolutionaryAlgorithm
{
    public class ParentSelection : IParentSelection
    {
        public List<Solution> GetParentPopulation(List<Solution> currentParentPopulation)
        {
            List<Solution> potentialparentPopulation = new List<Solution>();

            while (potentialparentPopulation.Count < currentParentPopulation.Count)
            {
                List<Solution> tournament = SelectTournament(currentParentPopulation);
                if (EvolutionaryAlgorithmConstants.IS_USING_RANKED_TOURNAMENT)
                {
                    potentialparentPopulation.AddRange(RankingTournamentSelection(tournament));
                }
                else
                {
                    potentialparentPopulation.AddRange(RandomTournamentSelection(tournament));
                    
                }
                
            }

            return potentialparentPopulation;
        }

        private List<Solution> SelectTournament(List<Solution> currentParentPopulation)
        {
            List<Solution> tournament = new List<Solution>();
            Random random = new Random();

            while (tournament.Count <= EvolutionaryAlgorithmConstants.TOURNAMENT_SIZE)
            {
                tournament.Add(currentParentPopulation.ElementAt(random.Next(0, currentParentPopulation.Count)));
            }

            return tournament;
        }

        /*
         * This (for now) will work by choosing 3 individuals: the bottom, middle and top in terms of cost
         * Hoping this will keep a diverse population and avoid converstion on a single solution quickly
         */
        private List<Solution> PickIndividualsFromTournament(List<Solution> tournament)
        {
            List<Solution> pickedIndividuals = new List<Solution>();

            // Sort tournament
            tournament.Sort((x, y) => x.SolutionCost.CompareTo(y.SolutionCost));

            // Add bottom individual
            pickedIndividuals.Add(tournament.Last());

            // Add middle individual
            pickedIndividuals.Add(FindMiddleIndividual(tournament));

            // Add top individual
            pickedIndividuals.Add(tournament.First());

            return pickedIndividuals;
        }

        private List<Solution> PickTopIndividualsFromTournament(List<Solution> tournament)
        {
            List<Solution> pickedIndividuals = new List<Solution>();

            // Sort tournament
            tournament.Sort((x, y) => x.SolutionCost.CompareTo(y.SolutionCost));

            // Add top individuals
            pickedIndividuals.Add(tournament.First());
            pickedIndividuals.Add(tournament.ElementAt(1));

            return pickedIndividuals;
        }

        private List<Solution> RandomTournamentSelection(List<Solution> tournament)
        {
            Random random = new Random();

            // Sort tournament
            tournament.Sort((x, y) => x.SolutionCost.CompareTo(y.SolutionCost));

            int halfwayPointInTournament = tournament.Count / 2;
            return new List<Solution>
            {
                tournament.ElementAt(random.Next(0, halfwayPointInTournament)),
                tournament.ElementAt(random.Next(0, halfwayPointInTournament))
            };
        }

        /*
         * This is the one i will use for the report
         */
        private List<Solution> RankingTournamentSelection(List<Solution> tournament)
        {
            List<Solution> pickedIndividuals = new List<Solution>();
            List<double> rankings = new List<double>();

            // Sort tournament
            tournament.Sort((x, y) => x.SolutionCost.CompareTo(y.SolutionCost));
            double sumOfRanks = 0;

            for(int index = 0; index <= tournament.Count - 1; index++)
            {
                double rank = 0;

                if (index == 0)
                {
                    rank = tournament.Count;
                }
                else
                {
                    rank = (index / tournament.Count) + (tournament.Count - index);
                }

                sumOfRanks += rank;
                rankings.Add(rank);
            }

            pickedIndividuals.Add(tournament.ElementAt(GetPickedIndividual(rankings, sumOfRanks)));
            pickedIndividuals.Add(tournament.ElementAt(GetPickedIndividual(rankings, sumOfRanks)));

            return pickedIndividuals;
        }

        private int GetPickedIndividual(List<double> rankings, double sumOfRanks)
        {
            Random random = new Random();
            double randomValue = random.NextDouble() * sumOfRanks;

            for (int index = 0; index <= rankings.Count - 1; index++)
            {
                if (randomValue >= rankings.ElementAt(index))
                {
                    return index;
                }
            }

            return rankings.Count - 1;
        }


        private Solution FindMiddleIndividual(List<Solution> tournament)
        {
            if (tournament.Count % 2 == 0)
            {
                return tournament.ElementAt(tournament.Count / 2);
            }

            // population size is odd
            return tournament.ElementAt((tournament.Count / 2) + 1);
        }
    }
}
