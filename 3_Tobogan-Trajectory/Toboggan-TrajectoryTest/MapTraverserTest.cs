using NUnit.Framework;
using Toboggan_Trajectory;
using Utilities;

namespace Toboggan_TrajectoryTest
{
    public class MapTraverserTest
    {
        [SetUp]
        public void Setup()
        {
        }


        [TestCase(".#..............##....#.#.####.", 0, false)]
        [TestCase(".#..............##....#.#.####.", 1, true)]
        [TestCase(".#..............##....#.#.####.", 56, false)]
        [TestCase(".#..............##....#.#.####.", 57, true)]
        public void GivenASingleLineInput_WhenLatBeyondInput_ThenLoopsAroundToStartAndReturnsIfTreePresent(string input, int latitude, bool expected)
        {
            var traverser = new MapTreverser();
            Assert.AreEqual(expected, traverser.IsTreeAtLatitude(input, latitude));
        }


        [Test]
        public void GivenWholeSlope_WhenTraversed_ThenGivenCountOfTreesEncountered()
        {
            var trevser = new MapTreverser();

            var inputs = FileReader.ReadFileLines("input.txt");

            var countOfTrees = trevser.TraverseSlope(inputs);

            Assert.AreEqual(193, countOfTrees);
        }
    }
}