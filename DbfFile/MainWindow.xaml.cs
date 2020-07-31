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


            List<Foo> values = new List<Foo>();
            values.Add(new Foo() { IdValue = 1, DateValue = DateTime.Now, DoubleValue = 1.1 });
            values.Add(new Foo() { IdValue = 2, DateValue = DateTime.Now.AddDays(1), DoubleValue = 2.1 });
            values.Add(new Foo() { IdValue = 3, DateValue = DateTime.Now.AddMonths(1), DoubleValue = 3.1 });

            var dbfFileName = "dbffile.dbf";


            Dbf.DbfFile.Write<Foo>(
                dbfFileName,
                values,
                new List<ObjectToDbfTypeMap<Foo>>()
                {
                    new ObjectToDbfTypeMap<Foo>(new DbfFieldDescriptor("dateField", (char)DbfColumnType.Date, 8, 0),f=>f.DateValue),
                    new ObjectToDbfTypeMap<Foo>(DbfFieldDescriptors.GetIntegerField("idField"),f=>f.IdValue),
                    new ObjectToDbfTypeMap<Foo>(DbfFieldDescriptors.GetDoubleField("doubleField"),f=>f.DoubleValue),
                },
                Encoding.ASCII,
                true);

            var valuesFromFile = Dbf.DbfFile.Read(dbfFileName, true, null, null);

            var test = valuesFromFile.Attributes.Count;
        }

        public void TestFirstWriteMethod()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");

            dt.Rows.Add("1", "Chirag");

            Dbf.DbfFile.Write(@"D:\yourFile.DBF", dt, Encoding.Default);
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
