using PointFinder.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PointFinder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PointFinderViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            Point3D point = new Point3D { X = 2, Y = 4, Z = 6 };
            Point3D point2 = new Point3D { X = 3, Y = 5, Z = 7 };
            vm = ((PointFinderViewModel)this.DataContext);
            //txtDistance.Text = $"{Calculations.CalculatePoints.CalculateDistance(point, point2):F2}";
        }

        private void OpenCsvFile(object sender, RoutedEventArgs e)
        {
            vm.OpenCsvFile();
        }

        private void FindClosestPointID(object sender, RoutedEventArgs e)
        {
            vm.FindClosestPoint();
        }

        private void FindClosestPoints(object sender, RoutedEventArgs e)
        {
            vm.FindClosestPoints();
        }

        private void TranslatePoints(object sender, RoutedEventArgs e)
        {
            vm.TranslatePoints();
        }
    }
}
