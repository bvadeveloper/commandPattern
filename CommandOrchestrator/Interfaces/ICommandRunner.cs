namespace CommandOrchestrator.Interfaces
{
    public interface ICommandRunner
    {
        void Run(ICommand command);
    }
}