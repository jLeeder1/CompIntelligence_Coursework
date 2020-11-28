using CompIntelligence_Coursework.Helpers;
using CompIntelligence_Coursework.Models;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace CompIntelligence_Coursework_TestSuite.HelpersTests
{
    public class SolutionStrategyFactoryTests
    {
        /*
        private ISolutionStrategyFactory solutionStrategyFactory;

        [SetUp]
        public void Setup()
        {
            Mock<IOrder> mockPieceLengthToQuantityLookup = new Mock<IOrder>();
            Mock<IStockList> mockstockLengthToCostLookup = new Mock<IStockList>();

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
            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(PSOSolution));
        }*/
    }
}
