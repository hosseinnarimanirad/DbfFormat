# Usage


## Sample 1. Write DataTable to dbf file

``` csharp
DataTable dt = new DataTable();
dt.Columns.Add("Id");
dt.Columns.Add("Name");

dt.Rows.Add("1", "Chirag");

Dbf.DbfFile.Write(@"D:\yourFile.DBF", dt, Encoding.Default);
```

## Sample 2. Write Custom Class to dbf file

Having a class like `Foo` :

``` csharp
public class Foo
{
    public int IdValue { get; set; }

    public DateTime DateValue { get; set; }

    public double DoubleValue { get; set; }
}
```

### wirte sample

``` csharp
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
```

### read Sample

``` csharp
var valuesFromFile = Dbf.DbfFile.Read(dbfFileName, true, null, null);
```
