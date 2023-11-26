using System;
using System.Data;
using System.Linq;

namespace _17.DataTable__Autoincrement_and_Others_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable EmployeesDataTable = new DataTable();

            // Add Columns
            //EmployeesDataTable.Columns.Add("ID", typeof(int));
            //EmployeesDataTable.Columns.Add("Name", typeof(string));
            //EmployeesDataTable.Columns.Add("Country", typeof(string));
            //EmployeesDataTable.Columns.Add("Salary", typeof(double));
            //EmployeesDataTable.Columns.Add("Date", typeof(DateTime));

            DataColumn dtColumn = new DataColumn();

            dtColumn.DataType = typeof(int);
            dtColumn.ColumnName = "ID";
            dtColumn.AutoIncrement = true;
            dtColumn.AutoIncrementSeed = 1;
            dtColumn.AutoIncrementStep = 1;

            dtColumn.Caption = "Employee ID";
            dtColumn.ReadOnly = true;
            dtColumn.Unique = true;
            EmployeesDataTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn()
            {
                DataType = typeof(string),
                ColumnName = "Name",
                AutoIncrement = false,
                Caption = "Name",
                ReadOnly = false,
                Unique = false
            };

            EmployeesDataTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn()
            {
                DataType = typeof(string),
                ColumnName = "Country",
                AutoIncrement = false,
                Caption = "Country",
                ReadOnly = false,
                Unique = false
            };

            EmployeesDataTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn()
            {
                DataType = typeof(double),
                ColumnName = "Salary",
                AutoIncrement = false,
                Caption = "Salary",
                ReadOnly = false,
                Unique = false
            };

            EmployeesDataTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn()
            {
                DataType = typeof(DateTime),
                ColumnName = "Date",
                AutoIncrement = false,
                Caption = "Date",
                ReadOnly = false,
                Unique = false
            };

            EmployeesDataTable.Columns.Add(dtColumn);

            DataColumn[] primaryKey = new DataColumn[1];
            primaryKey[0] = EmployeesDataTable.Columns["ID"];
            EmployeesDataTable.PrimaryKey = primaryKey;

            // Add Values
            EmployeesDataTable.Rows.Add(null, "Mohamed Badwy", "Egypt", 10000, DateTime.Now);
            EmployeesDataTable.Rows.Add(null, "Elsaid Badwy", "Egypt", 20000, DateTime.Now);
            EmployeesDataTable.Rows.Add(null, "Asmaa Badwy", "Egypt", 30000, DateTime.Now);
            EmployeesDataTable.Rows.Add(null, "Mahasen Badwy", "Egypt", 40000, DateTime.Now);

            Console.WriteLine("Employees List\n");
            foreach (DataRow row in EmployeesDataTable.Rows)
            {
                Console.WriteLine($"ID: {row["ID"]}\t Name: {row["Name"]}\t Country: {row["Country"]}\t Salary: {row["Salary"]}\t Date: {row["Date"]}");
            }
        }
    }
}
