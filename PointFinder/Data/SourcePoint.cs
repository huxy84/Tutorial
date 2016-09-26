using System;
using System.Windows.Media.Media3D;

namespace PointFinder.Data
{
    public class SourcePoint
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public Point3D Point { get; set; }

        public SourcePoint(string id, string description, string x, string y, string z)
            :this(Convert.ToInt32(id), description, Convert.ToDouble(x), Convert.ToDouble(y), Convert.ToDouble(z)) { }

        public SourcePoint(int id, string description, double x, double y, double z)
        {
            ID = id;
            Description = description;
            Point = new Point3D(x, y, z);
        }
    }
}