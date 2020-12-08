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
                potentialparentPopulation.AddRange(RandomTournamentSelection(tournament));
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

        private List<Solution> RandomTournamentSelection(List<Solution> tournament)
        {
            Random random = new Random();

            return new List<Solution>
            {
                tournament.ElementAt(random.Next(0, tournament.Count - 1)),
                tournament.ElementAt(random.Next(0, tournament.Count - 1))
            };
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
