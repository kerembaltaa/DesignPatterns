using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace Bridge_DP3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Employee is Type);
            SalaryCalculator salaryCalculator = new SalaryCalculator(new XMLWriter());
            Employee employee = new Employee { Id = 1001, Name = "John Doe", Basic = 3000, Incentive = 2000 };
            salaryCalculator.ProcessEmployeeSalary(employee);
            employee.Incentive = 2500;
            salaryCalculator = new SalaryCalculator(new JSONWriter());
            salaryCalculator.ProcessEmployeeSalary(employee);
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public decimal Incentive { get; set; }
        public decimal TotalSalary { get; set; }
    }

    public interface IFileWriter
    {
        void WriteFile(Employee employee);
    }

    public class XMLWriter : IFileWriter
    {
        string fileName = "EmployeeSalaryDetails.xml";
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Employee));
        FileStream fileStream;
        public void WriteFile(Employee employee)
        {
            fileStream = new FileStream(fileName, FileMode.OpenOrCreate);
            xmlSerializer.Serialize(fileStream, employee);
            Console.WriteLine($"EmployeeId# : {employee.Id} salary details sucessfully written to {fileName} ");
        }
    }

    public class JSONWriter : IFileWriter
    {
        string fileName = "EmployeeSalaryDetails.json";

        public void WriteFile(Employee employee)
        {
            var serializedEmployeeData = JsonSerializer.Serialize(employee);
            File.WriteAllText(fileName, serializedEmployeeData);
            Console.WriteLine($"EmployeeId# : {employee.Id} salary details sucessfully written to {fileName} ");
        }
    }

    public abstract class ContentWriter
    {
        protected IFileWriter fileWriter;
        public ContentWriter(IFileWriter fileWriter)
        {
            this.fileWriter = fileWriter;
        }
        public virtual void WriteContent(Employee employee)
        {
            fileWriter.WriteFile(employee);
        }
    }

    public class SalaryCalculator : ContentWriter
    {
        
        public SalaryCalculator(IFileWriter fileWriter) : base(fileWriter)
        {
        }
      
        public void ProcessEmployeeSalary(Employee employee)
        {
            // Some Processing
            employee.TotalSalary = employee.Basic + employee.Incentive;
            Console.WriteLine($"EmployeeId# {employee.Id} calculated salary# {employee.TotalSalary}");
            fileWriter.WriteFile(employee);
        }

    }

}
