using NUnit.Framework;
using Task3;

namespace TestsForTasks
{
    [TestFixture]
    public class Task3Tests
    {
        /// <summary>
        /// Checks the x and y value out of D area (far away from the D area)
        /// </summary>
        [TestCase(1, 1)] // 1st quarter
        [TestCase(-1, 1)] // 2nd quarter
        [TestCase(-1, -1)] // 3rd quarter
        [TestCase(1, -1)] // 4th quarter
        [Test]
        public void OutOfD_4and3quarters(double x, double y)
        {
             PointU point = new PointU(x, y);
             Assert.IsFalse(point.IsInAreaD);
        }

        /// <summary>
        /// Checks the x and y value within the 2nd quarter inside the D area
        /// </summary>
        [TestCase(-0.5, 0.5)] // in the middle of the area
        [TestCase(-0.5, 0.86)] // on the edge of the area
        [Test]
        public void InsideD_2quarter(double x, double y)
        {
            PointU point = new PointU(x, y);
            Assert.IsTrue(point.IsInAreaD);
        }
        
        /// <summary>
        /// Checks the x and y within the 1 quarter inside the D area (big circle)
        /// </summary>
        [TestCase(0.5, 0.5)] // in the middle of the area
        [TestCase(0.5, 0.86)] // on the edge of the area
        [Test]
        public void InsideD_1quarter(double x, double y)
        {
            PointU point = new PointU(x, y);
            Assert.IsTrue(point.IsInAreaD);
        }
        
        /// <summary>
        /// Checks the x and y within the 1 quarter outside the D area (small circle)
        /// </summary>
        [TestCase(0.1, 0.1)] // in the middle of the area
        [TestCase(0.1, 0)] // on the edge of the area
        [Test]
        public void OutSideD_1quarter(double x, double y)
        {
            PointU point = new PointU(x, y);
            Assert.IsFalse(point.IsInAreaD);
        }

    }
}