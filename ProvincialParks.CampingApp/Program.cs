using System;
using Ninject;
using ProvincialParks.CampingApp.Infrastructure.Interfaces;
using System.Reflection;
using Ninject.Parameters;

namespace ProvincialParks.CampingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            //Set the parameter
            IParameter parameterFileReader = new ConstructorArgument("fileReader", kernel.Get<IFileReader>());
            var expenseCalculator = kernel.Get<IExpenseCalculator>(parameterFileReader);


            Console.WriteLine("Enter Filename");
            var lineRead = Console.ReadLine();
            if (!string.IsNullOrEmpty(lineRead))
            {
                expenseCalculator.CalculateExpenses(lineRead);
            }
            else
            {
                Console.WriteLine("Filename Entered Invalid");
            }
        }
    }
}
