using Prism.Commands;

namespace PrismDemo.Core.Commands
{
    public interface IApplicationCommands
    {
        CompositeCommand SaveAllCommand { get; }
    }
}
