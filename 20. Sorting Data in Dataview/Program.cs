using System;
using System.Data;
using System.Linq;

namespace _20.Sorting_Data_in_Dataview
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
            EmployeesDataTable.Rows.Add(5, "Badwy Elsaid", "Jordan", 50000, DateTime.Now);
            EmployeesDataTable.Rows.Add(6, "Hanem Shawky", "Jordan", 60000, DateTime.Now);
            EmployeesDataTable.Rows.Add(6, "Ahmed Shawky", "KSA", 60000, DateTime.Now);
            EmployeesDataTable.Rows.Add(6, "Mustafa Shawky", "USA", 60000, DateTime.Now);

            Console.WriteLine("Employees List\n");
            foreach (DataRow row in EmployeesDataTable.Rows)
            {
                Console.WriteLine($"ID: {row["ID"]}\t Name: {row["Name"]}\t Country: {row["Country"]}\t Salary: {row["Salary"]}\t Date: {row["Date"]}");
            }

            DataView EmployeesDataView = EmployeesDataTable.DefaultView;
            
            Console.WriteLine("\n\nEmployees List from DataView\n");
            for (byte i = 0; i < EmployeesDataView.Count; i++)
            {
                Console.WriteLine($"{EmployeesDataView[i][0]}, {EmployeesDataView[i][1]}, {EmployeesDataView[i][2]}, {EmployeesDataView[i][3]}");
            }

            // Sorting DataView by Name
            EmployeesDataView.Sort = "Name asc";

            Console.WriteLine("\n\nEmployees List from DataView Sorted by Name asc\n");
            for (byte i = 0; i < EmployeesDataView.Count; i++)
            {
                Console.WriteLine($"{EmployeesDataView[i][0]}, {EmployeesDataView[i][1]}, {EmployeesDataView[i][2]}, {EmployeesDataView[i][3]}");
            }

        }
    }
}
