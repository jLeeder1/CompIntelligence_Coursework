using CompIntelligence_Coursework.Models;
using CompIntelligence_Coursework.RandomGenerator;
using CompIntelligence_Coursework.SolutionEvaluation;
using CompIntelligence_Coursework.solutionEveluation;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace CompIntelligence_Coursework_TestSuite.RandomTests
{
    public class RandomSolutionGeneratorTests
    {
        /*
        private Mock<IOrder> mockPieceLengthToQuantityLookup;
        private Mock<IStockList> mockStockLengthToCostLookup;
        private Mock<ISolutionEvaluator> mockSolutionEvaluator;
        private Mock<ISolutionValidation> mockSolutionValidation;

        private IRandomSolutionGenerator randomSolutionGenerator;

        [SetUp]
        public void SetUp()
        {
            mockPieceLengthToQuantityLookup = new Mock<IOrder>();
            mockStockLengthToCostLookup = new Mock<IStockList>();
            mockSolutionEvaluator = new Mock<ISolutionEvaluator>();
            mockSolutionValidation = new Mock<ISolutionValidation>();

            randomSolutionGenerator = new RandomSolutionGenerator(mockPieceLengthToQuantityLookup.Object, mockStockLengthToCostLookup.Object, mockSolutionEvaluator.Object, mockSolutionValidation.Object);
        }

        [Test]
        public void GenerateRandomSolution_ReturnsValidSolution()
        {
            // Arrange
            Dictionary<double, double> mockStockLengthToCostLookupDictionary = new Dictionary<double, double>
            {
                { 2, 5 },
                { 4, 10 },
                { 8, 20 }
            };

            mockStockLengthToCostLookup.SetupGet(x => x.StockItemList).Returns(mockStockLengthToCostLookupDictionary);

            mockSolutionValidation.Setup(x => x.IsValidSolution(
                It.IsAny<Solution>(), 
                It.IsAny<IOrder>(), 
                It.IsAny<IStockList>()))
                .Returns(true);

            // Act
            var result = randomSolutionGenerator.GenerateRandomSolution();

            // Assert
            result.Should().NotBeNull();
            result.LengthToQuantity.Should().HaveSameCount(mockStockLengthToCostLookupDictionary);
            result.SolutionCost.Should().NotBe(null);
        }*/
    }

}
