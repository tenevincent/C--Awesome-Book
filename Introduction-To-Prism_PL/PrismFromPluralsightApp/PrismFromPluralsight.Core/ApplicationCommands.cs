using Prism.Commands;

namespace PrismDemo.Core.Commands
{
    public class ApplicationCommands : IApplicationCommands
    {
        public CompositeCommand SaveAllCommand { get; } = new CompositeCommand();
    }
}
