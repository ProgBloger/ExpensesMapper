// See https://aka.ms/new-console-template for more information
using ExpensesMapper;
using ExpensesMapper.Interfaces;
using ExpensesMapper.Models;
using Microsoft.Extensions.Configuration;
using Ninject;

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

IConfiguration configuration = builder.Build();

string inputPath = configuration["path:input:path"];
string categoriesInputPath = configuration["path:input:categories"];
string outputPath = configuration["path:output"];

var conf = new Configuration(inputPath, outputPath, categoriesInputPath);

var kernel = new StandardKernel();

kernel.Bind<Configuration>().ToConstant(conf);
kernel.Load(new Bindings());
var aggregator = kernel.Get<IAggregator>();
aggregator.MapExpenses();