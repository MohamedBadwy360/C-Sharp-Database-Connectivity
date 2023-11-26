using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22.Access_Datatables_inDataset_By_Name
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable EmployeesDataTable = new DataTable("Employees");

            // Add Columns
            EmployeesDataTable.Columns.Add("ID", typeof(int));
            EmployeesDataTable.Columns.Add("Name", typeof(string));
            EmployeesDataTable.Columns.Add("Country", typeof(string));
            EmployeesDataTable.Columns.Add("Salary", typeof(double));
            EmployeesDataTable.Columns.Add("Date", typeof(DateTime));

            EmployeesDataTable.Rows.Add(1, "Mohamed Badwy", "Egypt", 10000, DateTime.Now);
            EmployeesDataTable.Rows.Add(2, "Elsaid Badwy", "Egypt", 20000, DateTime.Now);
            EmployeesDataTable.Rows.Add(3, "Asmaa Badwy", "Egypt", 30000, DateTime.Now);
            EmployeesDataTable.Rows.Add(4, "Mahasen Badwy", "Egypt", 40000, DateTime.Now);

            Console.WriteLine("Employees List\n");
            foreach (DataRow row in EmployeesDataTable.Rows)
            {
                Console.WriteLine($"ID: {row["ID"]}\t Name: {row["Name"]}\t Country: {row["Country"]}\t Salary: {row["Salary"]}\t Date: {row["Date"]}");
            }

            DataTable DepartmentsDataTable = new DataTable("Departments");

            DepartmentsDataTable.Columns.Add("ID", typeof(int));
            DepartmentsDataTable.Columns.Add("Name", typeof(string));

            DepartmentsDataTable.Rows.Add(1, "IT");
            DepartmentsDataTable.Rows.Add(2, "HR");
            DepartmentsDataTable.Rows.Add(3, "Marketing");

            Console.WriteLine("\n\nDepartments List\n");
            foreach (DataRow row in DepartmentsDataTable.Rows)
            {
                Console.WriteLine($"ID: {row["ID"]}\t Name: {row["Name"]}");
            }

            DataSet dataSet = new DataSet();

            dataSet.Tables.Add(EmployeesDataTable);
            dataSet.Tables.Add(DepartmentsDataTable);

            Console.WriteLine("\n\nEmployees List from DataSet\n");
            foreach (DataRow row in dataSet.Tables["Employees"].Rows)
            {
                Console.WriteLine($"ID: {row["ID"]}\t Name: {row["Name"]}\t Country: {row["Country"]}\t Salary: {row["Salary"]}\t Date: {row["Date"]}");
            }

            Console.WriteLine("\n\nDepartments List from DataSet\n");
            foreach (DataRow row in dataSet.Tables["Departments"].Rows)
            {
                Console.WriteLine($"ID: {row["ID"]}\t Name: {row["Name"]}");
            }
        }
    }
}
