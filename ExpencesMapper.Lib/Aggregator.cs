using ExpensesMapper.Interfaces;

namespace ExpensesMapper.Lib
{
    public class Aggregator : IAggregator
    {
        public IInputProcessor _inputProcessor { get; }
        public IOutputProcessor _outputProcessor { get; }

        public Aggregator(IInputProcessor inputProcessor, IOutputProcessor outputProcessor)
        {
            _inputProcessor = inputProcessor;
            _outputProcessor = outputProcessor;
        }

        public void MapExpenses()
        {
            var inputExpenses = _inputProcessor.Run();
            _outputProcessor.Run(inputExpenses.MappedExpenses, inputExpenses.UnmappedExpenses);
        }
    }
}