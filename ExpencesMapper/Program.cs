// See https://aka.ms/new-console-template for more information
using ExpensesMapper.Interfaces;
using Ninject;
using System.Reflection;

Console.WriteLine("Hello, World!");

var kernel = new StandardKernel();

kernel.Load(Assembly.GetExecutingAssembly());
var aggregator = kernel.Get<IAggregator>();
aggregator.MapExpenses();