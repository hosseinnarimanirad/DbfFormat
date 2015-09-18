using Dbf;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DbfFileTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TestFirstWriteMethod();
        }


        public void TestSecondWriteMethod()
        {

            var idColumn = DbfFieldDescriptors.GetIntegerField("Id");
            var nameColumn = DbfFieldDescriptors.GetStringField("Name");
            var columns = new List<DbfFieldDescriptor>() { idColumn, nameColumn };

            Func<MyClass, object> mapId = myClass => myClass.Id;
            Func<MyClass, object> mapName = myClass => myClass.Name;
            var mapping = new List<Func<MyClass, object>>() { mapId, mapName };

            List<MyClass> values = new List<MyClass>();
            values.Add(new MyClass() { Id = 1, Name = "name1" });

            DbfFileFormat.Write(@"D:\yourFile.dbf", values, mapping, columns, Encoding.ASCII);
        }

        public void TestFirstWriteMethod()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");

            dt.Rows.Add("1", "Chirag");

            DbfFileFormat.Write(@"D:\yourFile.DBF", dt, Encoding.Default);
        }
         
        private void testFirst_Click(object sender, RoutedEventArgs e)
        {
            TestFirstWriteMethod();
        }

        private void testSecond_Click(object sender, RoutedEventArgs e)
        {
            TestSecondWriteMethod();
        }
    }
}
