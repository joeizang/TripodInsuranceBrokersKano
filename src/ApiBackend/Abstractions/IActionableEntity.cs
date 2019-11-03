using apibackend.Entities;

namespace apibackend.Abstractions
{
    public interface IActionableEntity : IEntity
    {
        ActionType ActionType { get; set; }
    }
}
