using CompIntelligence_Coursework.Models;
using CompIntelligence_Coursework.SolutionEvaluation;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace CompIntelligence_Coursework_TestSuite.SolutionEvaluationTests
{
    public class SolutionValidationTests
    {
        private SolutionValidation solutionValidation;
        private Order pieceLengthToQuantityLookup;
        private StockList stockLengthToCostLookup;
        /*
        [SetUp]
        public void Setup()
        {
            solutionValidation = new SolutionValidation();

            pieceLengthToQuantityLookup = new Order
            {
                OrderItemsList = new Dictionary<double, double>
                {
                    { 3, 4 },
                    { 5, 3 },
                    { 6, 2 },
                    { 15, 1 }
                }
            };

            stockLengthToCostLookup = new StockList
            {
                StockItemList = new Dictionary<double, double>
                {
                    { 2, 10 },
                    { 4, 25 },
                    { 5, 30 },
                    { 10, 40 }
                }
            };
        }

        [Test]
        public void IsValidSolution_ReturnsTrue_WhenSolutionIsValid()
        {
            // Arrange
            Solution solution = new Solution
            {
                LengthToQuantity = new Dictionary<double, double>()
                {
                    { 2, 4 },
                    { 4, 3 },
                    { 5, 2 },
                    { 10, 3 }
                }
            };

            // Act
            var result = solutionValidation.IsValidSolution(solution, pieceLengthToQuantityLookup, stockLengthToCostLookup);

            // Assert
            result.Should().BeTrue();
        }

        [Test]
        public void IsValidSolution_ReturnsFalse_WhenSolutionIsNotValid_AsSolutionContainsIncorrectStockLengths()
        {
            // Arrange
            Solution solution = new Solution
            {
                LengthToQuantity = new Dictionary<double, double>()
                {
                    { 1, 4 }, // Incorrect stock length
                    { 4, 3 },
                    { 5, 2 },
                    { 10, 3 }
                }
            };

            // Act
            var result = solutionValidation.IsValidSolution(solution, pieceLengthToQuantityLookup, stockLengthToCostLookup);

            // Assert
            result.Should().BeFalse();
        }

        [Test]
        public void IsValidSolution_ReturnsFalse_WhenSolutionIsNotValid_AsSolutionContainsACombinedLengthOfCutsTooShortToBePossible()
        {
            // Arrange
            Solution solution = new Solution
            {
                LengthToQuantity = new Dictionary<double, double>()
                {
                    { 2, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 10, 1 }
                }
            };

            // Act
            var result = solutionValidation.IsValidSolution(solution, pieceLengthToQuantityLookup, stockLengthToCostLookup);

            // Assert
            result.Should().BeFalse();
        }*/
    }

}
