using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Media.Media3D;
using PointFinder.Calculations;
using System;
using System.IO;
using PointFinder.Data;
using System.Collections.Generic;

namespace PointFinder.Tests
{
    [TestClass]
    public class PointCalculationTests
    {
        [TestMethod]
        public void TestCalculateDistanceSuccess()
        {
            Point3D point = new Point3D { X = 2, Y = 4, Z = 6 };
            Point3D point2 = new Point3D { X = 3, Y = 5, Z = 7 };

            var distance = Math.Round(CalculatePoints.CalculateDistance(point, point2), 2);

            Assert.AreEqual(distance, 1.73);
        }

        // http://stackoverflow.com/questions/8914669/algorithm-for-calculating-a-distance-between-2-3-dimensional-points
        [TestMethod]
        public void Test_Find_Closest_PointSuccess()
        {
            //List<Point3D> points = new List<Point3D>
            //{
            //    new Point3D { X = 2, Y = 4, Z = 6 },
            //    new Point3D { X = 3, Y = 5, Z = 7 },
            //    new Point3D { X = 6, Y = 10, Z = 12 },
            //    new Point3D { X = 13, Y = 15, Z = 17 }
            //};

            string path = @"D:\Development\Other\Hexagon Mining\Assignment\PointFinder\SourceFileFormat.csv";

            SourceFile source = new SourceFile(path);

            Point3D queryPoint = new Point3D { X = 9, Y = 12, Z = 14 };

            var closestPoint = CalculatePoints.FindClosestPoint(source.SourcePoints, queryPoint);

            Assert.AreEqual(closestPoint, 1);
        }

        // http://stackoverflow.com/questions/4702782/move-point-to-another-in-c-sharp
        [TestMethod]
        public void Test_Shift_Translate_Point()
        {
            string path = @"D:\Development\Other\Hexagon Mining\Assignment\PointFinder\SourceFileFormat.csv";

            SourceFile source = new SourceFile(path);

            var a = new Point3D { X = 2, Y = 4, Z = 6 };

            Assert.IsNotNull(CalculatePoints.TranslatePoints(source.SourcePoints, a));
        }

        [TestMethod]
        public void TestOpenFileSuccess()
        {
            string path = @"D:\Development\Other\Hexagon Mining\Assignment\PointFinder\SourceFileFormat.csv";

            SourceFile source = new SourceFile(path);

            Assert.IsNotNull(source);
        }
    }
}