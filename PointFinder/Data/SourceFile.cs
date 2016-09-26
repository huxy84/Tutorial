using System;
using System.Collections.Generic;
using System.IO;

namespace PointFinder.Data
{
    public class SourceFile
    {
        public string FilePath { get; set; }

        public List<SourcePoint> SourcePoints { get; set; }

        public SourceFile(string path)
        {
            //@"D:\Development\Other\Hexagon Mining\Assignment\PointFinder\SourceFileFormat.csv"
            FilePath = path;

            SourcePoints = new List<SourcePoint>();

            using (StreamReader sr = new StreamReader(path))
            {
                int line = 0;

                while (sr.Peek() >= 0)
                {
                    var lineText = sr.ReadLine().Split(',');

                    if (line > 0)
                    {
                        if (lineText == null)
                            return;

                        var x = lineText[0];
                        var y = lineText[1];
                        var z = lineText[2];
                        var id = lineText[3];
                        var description = lineText[4];

                        try
                        {
                            var pointData = new SourcePoint(id, description, x, y, z);
                            SourcePoints.Add(pointData);
                        }
                        catch (Exception ex)
                        {
                            //Assert.Fail(ex.Message);
                        }
                    }

                    line++;
                }
            }
        }
    }
}