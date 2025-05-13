using np.Application;
using Xunit;

namespace np.Test
{
    public class ApplicationTests
    {
        [Fact]
        public void GetShortestPath_ReturnsEmpty_WhenPathDoesNotExist()
        {
            // Arrange
            var graph = new Dictionary<string, Dictionary<string, int>>
            {
                { "A", new Dictionary<string, int> { { "B", 1 } } },
                { "B", new Dictionary<string, int> { { "A", 1 } } },
                { "C", new Dictionary<string, int> { { "D", 1 } } },
                { "D", new Dictionary<string, int> { { "C", 1 } } }
            };

            var start = "A";
            var destination = "D";

            // Act
            var result = NavigationService.GetShortestPath(graph, start, destination);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetShortestPath_HandlesEmptyGraph()
        {
            // Arrange
            var graph = new Dictionary<string, Dictionary<string, int>>();
            var start = "A";
            var destination = "D";

            // Act
            var result = NavigationService.GetShortestPath(graph, start, destination);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetShortestPath_ReturnsStart_WhenStartAndDestinationAreTheSame()
        {
            // Arrange
            var graph = new Dictionary<string, Dictionary<string, int>>
            {
                { "A", new Dictionary<string, int> { { "B", 1 }, { "C", 4 } } },
                { "B", new Dictionary<string, int> { { "A", 1 }, { "C", 2 } } },
                { "C", new Dictionary<string, int> { { "A", 4 }, { "B", 2 } } }
            };

            var start = "A";
            var destination = "A";

            // Act
            var result = NavigationService.GetShortestPath(graph, start, destination);

            // Assert
            var expectedPath = new List<string> { "A" };
            Assert.NotNull(result);
            Assert.Equal(expectedPath, result);
        }

        [Fact]
        public void GetShortestPath_ReturnsStart_WhenGraphHasSingleNode()
        {
            // Arrange
            var graph = new Dictionary<string, Dictionary<string, int>>
            {
                { "A", new Dictionary<string, int>() }
            };

            var start = "A";
            var destination = "A";

            // Act
            var result = NavigationService.GetShortestPath(graph, start, destination);

            // Assert
            var expectedPath = new List<string> { "A" };
            Assert.NotNull(result);
            Assert.Equal(expectedPath, result);
        }

        [Fact]
        public void GetShortestPath_ReturnsEmpty_WhenGraphHasNoConnections()
        {
            // Arrange
            var graph = new Dictionary<string, Dictionary<string, int>>
            {
                { "A", new Dictionary<string, int>() },
                { "B", new Dictionary<string, int>() },
                { "C", new Dictionary<string, int>() }
            };

            var start = "A";
            var destination = "C";

            // Act
            var result = NavigationService.GetShortestPath(graph, start, destination);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void GetShortestPath_ReturnsCorrectPath_WhenGraphHasCycles()
        {
            // Arrange
            var graph = new Dictionary<string, Dictionary<string, int>>
            {
                { "A", new Dictionary<string, int> { { "B", 1 }, { "C", 3 } } },
                { "B", new Dictionary<string, int> { { "C", 1 }, { "D", 2 } } },
                { "C", new Dictionary<string, int> { { "D", 1 } } },
                { "D", new Dictionary<string, int> { { "-", 0 } } }
            };

            var start = "A";
            var destination = "D";

            // Act
            var result = NavigationService.GetShortestPath(graph, start, destination);

            // Assert
            var expectedPath = new List<string> { "A", "B", "C", "D" };
            Assert.NotNull(result);
            Assert.Equal(expectedPath, result);
        }

        [Fact]
        public void GetShortestPath_ReturnsDirectConnection_WhenStartAndDestinationAreDirectlyConnected()
        {
            // Arrange
            var graph = new Dictionary<string, Dictionary<string, int>>
            {
                { "A", new Dictionary<string, int> { { "B", 5 } } },
                { "B", new Dictionary<string, int> { { "A", 5 } } }
            };

            var start = "A";
            var destination = "B";

            // Act
            var result = NavigationService.GetShortestPath(graph, start, destination);

            // Assert
            var expectedPath = new List<string> { "A", "B" };
            Assert.NotNull(result);
            Assert.Equal(expectedPath, result);
        }

    }
}
