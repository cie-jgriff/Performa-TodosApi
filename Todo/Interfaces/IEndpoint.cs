namespace Todo.Interfaces;

/// <summary>
/// A module is a collection of endpoints that are grouped together
/// </summary>
public interface IModule
{
    public void MapEndpoints(IEndpointRouteBuilder endpoints);
}