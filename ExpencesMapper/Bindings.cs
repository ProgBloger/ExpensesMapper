using ExpensesMapper.Interfaces;
using ExpensesMapper.Lib;
using Ninject.Modules;

namespace ExpensesMapper
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IAggregator>().To<Aggregator>();
            Bind<IOutputProcessor>().To<OutputProcessor>();
            Bind<IInputParser>().To<InputParser>();
            Bind<IInputProcessor>().To<InputProcessor>();
            Bind<ICategoriesParser>().To<CategoriesParser>();
            Bind<IInputMapper>().To<InputMapper>();
            Bind<IExpensesMerger>().To<ExpensesMerger>();
            Bind<IUnmachedExpensesWriter>().To<UnmachedExpensesWriter>();
            Bind<IOuputReader>().To<OuputReader>();
            Bind<IOuputWriter>().To<OuputWriter>();
        }
    }
}
