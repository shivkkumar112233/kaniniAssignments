namespace GettingEmployeeInformation.Interfaces
{
    public interface IRepo<T>
    {
      Task< ICollection<T>> GetAll();
    }
}
