using CompIntelligence_Coursework.Helpers;
using CompIntelligence_Coursework.Models;
using CompIntelligence_Coursework.PSO;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace CompIntelligence_Coursework_TestSuite.Helpers
{
    public class SolutionStrategyFactoryTests
    {
        private ISolutionStrategyFactory solutionStrategyFactory;

        [SetUp]
        public void Setup()
        {
            Mock<IPieceLengthToQuantityLookup> mockPieceLengthToQuantityLookup = new Mock<IPieceLengthToQuantityLookup>();
            Mock<IStockLengthToCostLookup> mockstockLengthToCostLookup = new Mock<IStockLengthToCostLookup>();

            solutionStrategyFactory = new SolutionStrategyFactory(mockPieceLengthToQuantityLookup.Object, mockstockLengthToCostLookup.Object);
        }

        [Test]
        public void GetSolutionFinderStrategy_ShouldReturn_PSOSolution_WhenStrategyTypeIs_PSOSolutionStrategy()
        {
            // Arrange
            var strategyType = SolutionStrategyTypes.PSOSolutionStrategy;

            // Act
            var result = solutionStrategyFactory.GetSolutionFinderStrategy(strategyType);

            // Assert
            result.Should().BeNull();
            result.Should().BeOfType(typeof(PSOSolution));
        }
    }
}
