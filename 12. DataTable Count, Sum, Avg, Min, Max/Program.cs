using System;
using System.Data;
using System.Linq;


namespace _12.DataTable_Count__Sum__Avg__Min__Max
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

            foreach (DataRow row in EmployeesDataTable.Rows)
            {
                Console.WriteLine($"ID: {row["ID"]}\t Name: {row["Name"]}\t Country: {row["Country"]}\t Salary: {row["Salary"]}\t Date: {row["Date"]}");
            }

            int EmployeesCount = EmployeesDataTable.Rows.Count;
            double TotalSalary = Convert.ToDouble(EmployeesDataTable.Compute("SUM(Salary)", string.Empty));
            double AverageSalary = Convert.ToDouble(EmployeesDataTable.Compute("AVG(Salary)", string.Empty));
            double MinSalary = Convert.ToDouble(EmployeesDataTable.Compute("Min(Salary)", string.Empty));
            double MaxSlary = Convert.ToDouble(EmployeesDataTable.Compute("max(Salary)", string.Empty));

            Console.WriteLine($"Count = {EmployeesCount}");
            Console.WriteLine($"Total Salary = {TotalSalary}");
            Console.WriteLine($"Min Salary = {MinSalary}");
            Console.WriteLine($"Max Salary = {MaxSlary}");
            Console.WriteLine($"Avg Salary = {AverageSalary}");

            DataRow[] ResultRows;

            ResultRows = EmployeesDataTable.Select("Country = 'Jordan'");

            Console.WriteLine("\n\n↓↓ Filter Jordan Employees ↓↓");
            foreach (DataRow row in ResultRows)
            {
                Console.WriteLine($"ID: {row["ID"]}\t Name: {row["Name"]}\t Country: {row["Country"]}\t Salary: {row["Salary"]}\t Date: {row["Date"]}");
            }

            int ResultCount = ResultRows.Count();
            TotalSalary = Convert.ToDouble(EmployeesDataTable.Compute("SUM(Salary)", "Country = 'Jordan'"));
            AverageSalary = Convert.ToDouble(EmployeesDataTable.Compute("AVG(Salary)", "Country = 'Jordan'"));
            MinSalary = Convert.ToDouble(EmployeesDataTable.Compute("Min(Salary)", "Country = 'Jordan'"));
            MaxSlary = Convert.ToDouble(EmployeesDataTable.Compute("max(Salary)", "Country = 'Jordan'"));

            Console.WriteLine($"Count = {ResultCount}");
            Console.WriteLine($"Total Salary = {TotalSalary}");
            Console.WriteLine($"Min Salary = {MinSalary}");
            Console.WriteLine($"Max Salary = {MaxSlary}");
            Console.WriteLine($"Avg Salary = {AverageSalary}");

            // Filter KSA or USA Employees

            ResultRows = EmployeesDataTable.Select("Country = 'KSA' or Country = 'USA'");

            Console.WriteLine("\n\n↓↓ Filter KSA or USA Employees ↓↓");
            foreach (DataRow row in ResultRows)
            {
                Console.WriteLine($"ID: {row["ID"]}\t Name: {row["Name"]}\t Country: {row["Country"]}\t Salary: {row["Salary"]}\t Date: {row["Date"]}");
            }

            ResultCount = ResultRows.Count();
            TotalSalary = Convert.ToDouble(EmployeesDataTable.Compute("SUM(Salary)", "Country = 'KSA' or Country = 'USA'"));
            AverageSalary = Convert.ToDouble(EmployeesDataTable.Compute("AVG(Salary)", "Country = 'KSA' or Country = 'USA'"));
            MinSalary = Convert.ToDouble(EmployeesDataTable.Compute("Min(Salary)", "Country = 'KSA' or Country = 'USA'"));
            MaxSlary = Convert.ToDouble(EmployeesDataTable.Compute("max(Salary)", "Country = 'KSA' or Country = 'USA'"));

            Console.WriteLine($"Count = {ResultCount}");
            Console.WriteLine($"Total Salary = {TotalSalary}");
            Console.WriteLine($"Min Salary = {MinSalary}");
            Console.WriteLine($"Max Salary = {MaxSlary}");
            Console.WriteLine($"Avg Salary = {AverageSalary}");
        }
    }
}
