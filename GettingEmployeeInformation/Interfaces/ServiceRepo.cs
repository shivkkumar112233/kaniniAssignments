namespace GettingEmployeeInformation.Interfaces
{
    public interface IServiceRepo<T>
    {
       Task< T> GetValue();
    }
}
