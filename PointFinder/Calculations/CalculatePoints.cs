using PointFinder.Data;
using System;
using System.Collections.Generic;
using System.Windows.Media.Media3D;
using System.Linq;

namespace PointFinder.Calculations
{
    public static class CalculatePoints
    {
        public static double CalculateDistance(Point3D point, Point3D point2)
        {
            var xDistCalc = Math.Sqrt((point2.X - point.X));
            var yDistCalc = Math.Sqrt((point2.Y - point.Y));
            var zDistCalc = Math.Sqrt((point2.Z - point.Z));

            xDistCalc = !double.IsNaN(xDistCalc) ? xDistCalc : 0;
            yDistCalc = !double.IsNaN(yDistCalc) ? yDistCalc : 0;
            zDistCalc = !double.IsNaN(zDistCalc) ? zDistCalc : 0;

            var calc = Math.Sqrt(xDistCalc + yDistCalc + zDistCalc);

            return calc;
        }

        public static int FindClosestPoint(List<SourcePoint> points, Point3D queryPoint)
        {
            double currentDist = 0;
            double closestDist = 0;

            var closestPoint = new Point3D();

            points.ForEach(p =>
                {
                    currentDist = CalculateDistance(p.Point, queryPoint);

                    if(currentDist == 0)
                        closestPoint = p.Point;
                    else if (closestDist == 0 || closestDist < currentDist)
                    {
                        closestDist = currentDist;
                        closestPoint = p.Point;
                    }
                }
            );

            return points.FirstOrDefault(f => f.Point == closestPoint).ID;
        }

        public static List<SourcePoint> FindClosestPoints(List<SourcePoint> points, Point3D queryPoint, int numPoints)
        {
            double currentDist = 0;
            double closestDist = 0;

            var closestPoint = new Point3D();
            var closestPoints = new List<SourcePoint>();

            int count = 0;

            if (numPoints > 0)
            {
                points.ForEach(p =>
                    {
                        currentDist = CalculateDistance(p.Point, queryPoint);

                        if (closestPoints.Count < numPoints && (closestDist == 0 || closestDist > currentDist))
                        {
                            closestDist = currentDist;
                            closestPoint = p.Point;
                            closestPoints.Add(p);
                        }
                    }
                );
            }

            return closestPoints;
        }

        public static List<SourcePoint> TranslatePoints(List<SourcePoint> points, Point3D point2)
        {
            List<SourcePoint> newPoints = new List<SourcePoint>();

            for (int i = 0; i < points.Count; i++)
            {
                var point1 = points[i].Point;

                double distance = CalculateDistance(point1, point2);
                var vector = new Point3D(point2.X - point1.X, point2.Y - point1.Y, point2.Z - point1.Z); ;
                var length = Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y + (vector.Z * vector.Y));
                var unitVector = new Point3D(vector.X / length, vector.Y / length, vector.Z / length);

                var newX = point1.X + unitVector.X * distance;
                var newY = point1.Y + unitVector.Y * distance;
                var newZ = point1.Z + unitVector.Z * distance;

                newPoints.Add(new SourcePoint(points[i].ID, points[i].Description,
                    newX, newY, newZ));
            }

            return newPoints;
        }
    }
}