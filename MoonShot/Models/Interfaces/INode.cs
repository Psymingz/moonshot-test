namespace MoonShot.Models.Interfaces
{
    public interface INode<T>
    {
        INode<T> Left { get; set; }
        INode<T> Right { get; set; }
        T Value { get; set; }
    }
}
