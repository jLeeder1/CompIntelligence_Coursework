using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;
using CompIntelligence_Coursework.Models;
using CompIntelligence_Coursework.solutionEveluation;

namespace CompIntelligence_Coursework_TestSuite.SolutionEvaluationTests
{
    class SolutionEvaluatorTests
    {
        /*
        private ISolutionEvaluator solutionEvaluator;
        private StockList stockLengthToCostLookup;
        
        [SetUp]
        public void Setup()
        {
            solutionEvaluator = new SolutionEvaluator();

            stockLengthToCostLookup = new StockList()
            {
                StockItemList = new Dictionary<double, double>()
                {
                    { 2, 10 },
                    { 4, 25 },
                    { 5, 30 },
                    { 10, 40 }
                }
            };
        }

        [Test]
        public void GetCostOfSolution_ReturnsCorrectSolutionCost()
        {
            // Arrange
            Solution solution = new Solution()
            {
                LengthToQuantity = new Dictionary<double, double>()
                {
                    { 2, 4 },
                    { 4, 3 },
                    { 5, 2 },
                    { 10, 1 }
                }
            };
            
            double correctAnswer = 215d;

            // Act
            var result = solutionEvaluator.GetCostOfSolution(solution, stockLengthToCostLookup);

            // Assert
            result.Should().NotBe(null);
            result.Should().Be(correctAnswer);
        }
        */
    }
}
