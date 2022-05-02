using System;
using System.Collections.Generic;
using System.Text;

namespace NPL.SMS.R2S.Training.Entities
{
    class Employee
    {
        int employeeId;
        string employeeName;
        double employeeSalary;
        int spvrId;

        public int EmployeeId { get => employeeId; set => employeeId = value; }
        public string EmployeeName { get => employeeName; set => employeeName = value; }
        public double EmployeeSalary { get => employeeSalary; set => employeeSalary = value; }
        public int SpvrId { get => spvrId; set => spvrId = value; }

        public Employee()
        { }
        public Employee(int employeeId,string employeeName,double employeeSalary,int spvrId)
        {
            this.EmployeeId = employeeId;
            this.EmployeeName = employeeName;
            this.EmployeeSalary = employeeSalary;
            this.SpvrId = spvrId;
        }
    }   
}
