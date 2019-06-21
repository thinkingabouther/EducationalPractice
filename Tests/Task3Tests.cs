using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task3;

namespace Tests
{
    [TestClass]
    public class Task3Tests
    {
        /// <summary>
        /// Checks the x and y value out of D area (far away from the D area)
        /// </summary>
        [DataRow(1, 1)] // 1st quarter
        [DataRow(-1, 1)] // 2nd quarter
        [DataRow(-1, -1)] // 3rd quarter
        [DataRow(1, -1)] // 4th quarter
        [TestMethod]
        public void OutOfD_4and3quarters(double x, double y)
        {
            PointU point = new PointU(x, y);
            Assert.IsFalse(point.IsInAreaD);
        }

        /// <summary>
        /// Checks the x and y value within the 2nd quarter inside the D area
        /// </summary>
        [DataRow(-0.5, 0.5)] // in the middle of the area
        [DataRow(-0.5, 0.86)] // on the edge of the area
        [TestMethod]
        public void InsideD_2quarter(double x, double y)
        {
            PointU point = new PointU(x, y);
            Assert.IsTrue(Math.Abs(-0.75 - point.GetUValue()) < 0.0001);
        }

        /// <summary>
        /// Checks the x and y within the 1 quarter inside the D area (big circle)
        /// </summary>
        [DataRow(0.5, 0.5)] // in the middle of the area
        [DataRow(0.5, 0.86)] // on the edge of the area
        [TestMethod]
        public void InsideD_1quarter(double x, double y)
        {
            PointU point = new PointU(x, y);
            Assert.IsTrue(point.IsInAreaD);
        }

        /// <summary>
        /// Checks the x and y within the 1 quarter outside the D area (small circle)
        /// </summary>
        [DataRow(0.1, 0.1)] // in the middle of the area
        [DataRow(0.1, 0)] // on the edge of the area
        [TestMethod]
        public void OutSideD_1quarter(double x, double y)
        {
            PointU point = new PointU(x, y);
            Assert.IsFalse(point.IsInAreaD);
        }
        [DataRow(1, -1)]
        [TestMethod]
        public void OutSideD_FunctionValueCheck(double x, double y)
        {
            PointU point = new PointU(x, y);
            Assert.IsTrue(Math.Abs(point.GetUValue()) < 0.0001);
        }
    }
}