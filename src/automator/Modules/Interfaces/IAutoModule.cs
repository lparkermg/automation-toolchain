namespace Modules.Interfaces
{
    public interface IAutoModule
    {
        bool Run<T>(T[] data);
    }
}