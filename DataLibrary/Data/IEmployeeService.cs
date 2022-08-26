using DataLibrary.Model;

namespace DataLibrary.Data;

public interface IEmployeeService
{
    Task<List<Employee>?> ReadAll();

    Task<Employee?> ReadById(int id);

    Task<int> Create(Employee employee);

    Task<int> Update(Employee employee);

    Task<int> Delete(int id); 
}