using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRUDClassLibrary;

namespace CRUDConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************Welcome to Employee Management System*************\n");

            while (true)
            {

                Console.WriteLine("Please choose the operation you want to perform");
                Console.WriteLine("\t\t 1. List of all Employee");
                Console.WriteLine("\t\t 2. Add new Employee");
                Console.WriteLine("\t\t 3. Modify existing Employee");
                Console.WriteLine("\t\t 4. Delete an Employee");

                Console.Write("Enter your Choice no. : ");
                string ChoiceOption = Console.ReadLine();
                CRUDOperation operation = new CRUDOperation();
                int status = 0;
                switch (ChoiceOption)
                {
                    case "1":
                        Console.WriteLine("We are getting all employees....");

                        GetEmployeeList();
                        break;

                    case "2":
                        Console.WriteLine("Please give the details of Employee....");
                        Employee employee = GetEmployeeDetails();
                        Console.WriteLine("Please wait, WeakReference are adding the Employee....");
                        status = operation.AddEmployee(employee);
                        if (status == 1)
                        {
                            Console.WriteLine("An Employee name '{0}' is added", employee.FirstName);

                        }
                        else
                        {
                            Console.WriteLine("An Employee could not be insert.");
                        }

                        break;


                    case "3":
                        Console.WriteLine("Chose an Employee from the list below");
                        GetEmployeeList();
                        string employeeIdToUpdate = Console.ReadLine();

                        Employee UpdateEmployee = new Employee();
                        UpdateEmployee.Id = Convert.ToInt32(employeeIdToUpdate);

                        while (true)
                        {
                            Console.WriteLine("Please chouse field to update");
                            Console.WriteLine(@" 1. FirstName
                                             2. LastName
                                             3. EmailId
                                             4. PhoneNumber
                                             5. Address
                                             6. Department
                                            ");
                            string fieldOption = Console.ReadLine();
                            switch (fieldOption)
                            {
                                case "1":
                                    Console.Write("Please enter updated value for FirstName: ");
                                    UpdateEmployee.FirstName = Console.ReadLine();
                                    break;
                                case "2":
                                    Console.Write("Please enter updated value for LastName: ");
                                    UpdateEmployee.LastName = Console.ReadLine();
                                    break;
                                case "3":
                                    Console.Write("Please enter updated value for EmailId: ");
                                    UpdateEmployee.EmailId = Console.ReadLine();
                                    break;
                                case "4":
                                    Console.Write("Please enter updated value for PhoneNumber: ");
                                    UpdateEmployee.PhoneNumber = Convert.ToInt64(Console.ReadLine());
                                    break;
                                case "5":
                                    Console.Write("Please enter updated value for Address: ");
                                    UpdateEmployee.Address = Console.ReadLine();
                                    break;
                                case "6":
                                    Console.Write("Please enter updated value for Department: ");
                                    UpdateEmployee.Department = Console.ReadLine();
                                    break;
                            }
                            Console.Write("Do you want to update any more fields ? (y/n): ");
                            string usrChoiceToContinueUpdateFiled = Console.ReadLine();
                            if (usrChoiceToContinueUpdateFiled.ToLower() == 'y'.ToString())
                            {
                                continue;
                            }
                            else { break; }
                        }
                        Console.WriteLine("Pleasewait, updating the employee...");
                        
                        int result = operation.UpdateEmployee(UpdateEmployee);
                        if (result == 1)
                        {
                            Console.WriteLine("Updated employee successfully");

                        }
                        else
                        {
                            Console.WriteLine("Employee can not be updated");
                        }
                        break;
                    case "4":
                        Console.WriteLine("We are Deleting an employee.");
                        
                        Console.WriteLine("Chose an Employee ID from the list below");
                        GetEmployeeList();
                        string employeeIdToDelete = Console.ReadLine();
                        status = operation.DeleteEmployee(Convert.ToInt32(employeeIdToDelete));
                        if (status == 1)
                        {
                            Console.WriteLine("An Employee Deleted ");

                        }
                        else
                        {
                            Console.WriteLine("An Employee could not be Deleted.");
                        }
                        break;
                }

                Console.WriteLine("");
                Console.WriteLine("Do you want to continue ?(y/n)");
                string usrChoiceToContinue = Console.ReadLine();
                if(usrChoiceToContinue.ToLower() == 'y'.ToString())
                {
                    continue;
                }
                else { break; }

            }
            
        }
        static void GetEmployeeList() {
            CRUDOperation operation = new CRUDOperation();
            List<Employee> employees = operation.GetEmployees(null);
            if (employees != null && employees.Count > 1)
            {
                Console.WriteLine("Below is the list of employee");
                Console.WriteLine("***********************");
                foreach (Employee emp in employees)
                {
                    Console.WriteLine("\t{0} \t{1} \t{2} \t{3} \t{4} \t{5} \t{6}", emp.Id, emp.FirstName, emp.LastName, emp.EmailId, emp.PhoneNumber, emp.Address, emp.Department);
                }
                Console.WriteLine("***********************");
            }
            else
            {
                Console.WriteLine("There are no employe");
            }
        }
        static Employee GetEmployeeDetails()
        {
            Employee AddEmployee = new Employee();
           
            Console.Write("Please enter First Name :");
            AddEmployee.FirstName = Console.ReadLine();
            Console.Write("Please enter Last Name :");
            AddEmployee.LastName = Console.ReadLine();
            Console.Write("Please enter EmailId :");
            AddEmployee.EmailId = Console.ReadLine();
            Console.Write("Please enter PhoneNumber :");
            AddEmployee.PhoneNumber = Convert.ToInt64(Console.ReadLine());
            Console.Write("Please enter Address: ");
            AddEmployee.Address = Console.ReadLine();
            Console.Write("Please enter Department: ");
            AddEmployee.Department = Console.ReadLine();
            return AddEmployee;
        }
    }
}
