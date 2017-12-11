namespace ConfirmitTest.Core
{
    public interface IStorable<out T>
        where T: class
    {
        T GetState();
    }
}