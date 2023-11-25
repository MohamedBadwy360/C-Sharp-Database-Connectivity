using System;
using System.Data;
using System.Linq;

namespace _11.Create_Offline_Data_Table_and_ListData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable EmployeesDataTable = new DataTable();

            // Add Columns
            EmployeesDataTable.Columns.Add("ID", typeof(int));
            EmployeesDataTable.Columns.Add("Name", typeof(string));
            EmployeesDataTable.Columns.Add("Country", typeof(string));
            EmployeesDataTable.Columns.Add("Salary", typeof(double));
            EmployeesDataTable.Columns.Add("Date", typeof(DateTime));

            // Add Values
            EmployeesDataTable.Rows.Add(1, "Mohamed Badwy", "Egypt", 10000, DateTime.Now);
            EmployeesDataTable.Rows.Add(2, "Elsaid Badwy", "Egypt", 20000, DateTime.Now);
            EmployeesDataTable.Rows.Add(3, "Asmaa Badwy", "Egypt", 30000, DateTime.Now);
            EmployeesDataTable.Rows.Add(4, "Mahasen Badwy", "Egypt", 40000, DateTime.Now);

            foreach(DataRow row in EmployeesDataTable.Rows)
            {
                Console.WriteLine($"ID: {row["ID"]}\t Name: {row["Name"]}\t Country: {row["Country"]}\t Salary: {row["Salary"]}\t Date: {row["Date"]}");
            }
        }
    }
}
