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

            var countOfTrees = trevser.TraverseSlope(inputs, 1, 3);

            Assert.AreEqual(193, countOfTrees);
        }

        [Test]
        public void GivenWholeSlopeMultipleTimes_WhenTraversed_ThenGivenCountOfTreesEncountered()
        {
            var trevser = new MapTreverser();

            var inputs = FileReader.ReadFileLines("input.txt");

            var slope1 = trevser.TraverseSlope(inputs, 1, 1);
            var slope2 = trevser.TraverseSlope(inputs, 1, 3);
            var slope3 = trevser.TraverseSlope(inputs, 1, 5);
            var slope4 = trevser.TraverseSlope(inputs, 1, 7);
            var slope5 = trevser.TraverseSlope(inputs, 2, 1);

            var total = slope1 * slope2 * slope3 * slope4 * slope5;

            Assert.AreEqual(1355323200, total);
        }
    }
}