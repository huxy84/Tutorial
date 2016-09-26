using PointFinder.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using Microsoft.Win32;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Media3D;
using PointFinder.Calculations;

namespace PointFinder.ViewModel
{
    public class PointFinderViewModel : INotifyPropertyChanged
    {
        public List<SourcePoint> PointFiles { get; set; }

        private double queryX;
        public double QueryX
        {
            get { return queryX; }

            set
            {
                if (queryX == value)
                    return;

                queryX = value;

                OnPropertyChanged("QueryX");
            }
        }

        private double queryY;
        public double QueryY
        {
            get { return queryY; }

            set
            {
                if (queryY == value)
                    return;

                queryY = value;

                OnPropertyChanged("QueryY");
            }
        }
        private double queryZ;
        public double QueryZ
        {
            get { return queryZ; }

            set
            {
                if (queryZ == value)
                    return;

                queryZ = value;

                OnPropertyChanged("QueryZ");
            }
        }

        private double transX;
        public double TransX
        {
            get { return transX; }

            set
            {
                if (transX == value)
                    return;

                transX = value;

                OnPropertyChanged("TransX");
            }
        }

        private double transY;
        public double TransY
        {
            get { return transY; }

            set
            {
                if (transY == value)
                    return;

                transY = value;

                OnPropertyChanged("TransY");
            }
        }
        private double transZ;
        public double TransZ
        {
            get { return transZ; }

            set
            {
                if (transZ == value)
                    return;

                transZ = value;

                OnPropertyChanged("TransZ");
            }
        }

        private int closestPointID;
        public int ClosestPointID
        {
            get { return closestPointID; }

            set
            {
                if (closestPointID == value)
                    return;

                closestPointID = value;

                OnPropertyChanged("ClosestPointID");
            }
        }

        private bool canFindPoints;
        public bool CanFindPoints
        {
            get { return canFindPoints; }

            set
            {
                if (canFindPoints == value)
                    return;

                canFindPoints = value;

                OnPropertyChanged("CanFindPoints");
            }
        }

        private int numPointsToList;
        public int NumPointsToList
        {
            get { return numPointsToList; }

            set
            {
                if (numPointsToList == value)
                    return;

                numPointsToList = value;

                OnPropertyChanged("NumPointsToList");
            }
        }

        private List<SourcePoint> closestPoints;
        public List<SourcePoint> ClosestPoints
        {
            get { return closestPoints; }
            set
            {
                if (closestPoints == value)
                    return;

                closestPoints = value;

                OnPropertyChanged("ClosestPoints");
            }
        }

        private List<SourcePoint> translatedPoints;
        public List<SourcePoint> TranslatedPoints
        {
            get { return translatedPoints; }
            set
            {
                if (translatedPoints == value)
                    return;

                translatedPoints = value;

                OnPropertyChanged("TranslatedPoints");
            }
        }

        private string filePath;
        public string FilePath
        {
            get
            {
                return filePath;
            }

            set
            {
                if (filePath == value)
                    return;

                filePath = value;

                OnPropertyChanged("FilePath");
            }
        }

        private SourceFile pointsSourceFile;
        public SourceFile PointsSourceFile
        {
            get
            {
                return pointsSourceFile;
            }

            set
            {
                if (pointsSourceFile == value)
                    return;

                pointsSourceFile = value;

                OnPropertyChanged("PointsSourceFile");
            }
        }

        public PointFinderViewModel()
        {
            FilePath = @"D:\SourceFileFormat.csv";
            PointFiles = new List<SourcePoint>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OpenCsvFile()
        {
            //string path = @"D:\Development\Other\Hexagon Mining\Assignment\PointFinder\SourceFileFormat.csv";

            PointsSourceFile = new SourceFile(FilePath);

            CanFindPoints = PointsSourceFile != null;
        }

        public void FindClosestPoint()
        {
            var queryPoint = new Point3D(QueryX, QueryY, QueryZ);
            ClosestPointID = Calculations.CalculatePoints.FindClosestPoint(PointsSourceFile.SourcePoints, queryPoint);
        }

        public void FindClosestPoints()
        {
            var queryPoint = new Point3D(QueryX, QueryY, QueryZ);
            ClosestPoints = CalculatePoints.FindClosestPoints(PointsSourceFile.SourcePoints, queryPoint, NumPointsToList);
        }

        public void TranslatePoints()
        {
            var transPoint = new Point3D(TransX, TransY, TransZ);
            TranslatedPoints = CalculatePoints.TranslatePoints(PointsSourceFile.SourcePoints, transPoint);
        }
    }
}