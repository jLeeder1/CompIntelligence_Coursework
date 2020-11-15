using CompIntelligence_Coursework.EvolutionaryAlgorithm;
using CompIntelligence_Coursework.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompIntelligence_Coursework_TestSuite.EvolutionaryAlgorithmTests
{
    public class ParentSelectionTests
    {
        private IParentSelection parentSelection;

        [SetUp]
        public void SetUp()
        {
            // This can't be good practice. is there a way to set a constant value both locally and temporarily?
            EvolutionaryAlgorithmConstants.TOURNAMENT_SIZE = 5;
            parentSelection = new ParentSelection();
        }

        [Test]
        public void GetParentPopulation_ReturnsCorrectAmountOfPotentialParents_WhenPopulationCountIsEven()
        {
            // Arrange
            List<Solution> currentParentPopulation = SetUpCurrentParentPopulation(true);

            // Act
            var result = parentSelection.GetParentPopulation(currentParentPopulation);

            // Assert
            result.Should().HaveCount(currentParentPopulation.Count);
        }

        [Test]
        public void GetParentPopulation_ReturnsCorrectAmountOfPotentialParents_WhenPopulationCountIsOdd()
        {
            // Arrange
            List<Solution> currentParentPopulation = SetUpCurrentParentPopulation(false);

            // Act
            var result = parentSelection.GetParentPopulation(currentParentPopulation);

            // Assert
            result.Should().HaveCount(currentParentPopulation.Count + 1);
        }

        private List<Solution> SetUpCurrentParentPopulation(bool isPopulationCountEven)
        {
            List<Solution> currentParentPopulation = new List<Solution>
            {
                new Solution
                {
                    SolutionCost = 10
                },

                new Solution
                {
                    SolutionCost = 60
                },

                new Solution
                {
                    SolutionCost = 30
                },

                new Solution
                {
                    SolutionCost = 40
                },
                new Solution
                {
                    SolutionCost = 50
                }

            };

            if(isPopulationCountEven == true)
            {
                currentParentPopulation.Add(
                    new Solution
                    {
                        SolutionCost = 20
                    }
                );
            }

            return currentParentPopulation;
        }
    }
}
