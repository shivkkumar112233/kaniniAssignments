using GettingEmployeeInformation.Interfaces;
using GettingEmployeeInformation.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace GettingEmployeeInformation.Services
{
    public class EmployeeDetailsRepo : IRepo<EmployeeDetails>
    {
        private readonly EmpContext _context;
      

        public EmployeeDetailsRepo(EmpContext context) {

            _context=context;
           
        }
        //collecting all the employeeDetails data
        public async Task<ICollection<EmployeeDetails> >GetAll()
        {
            //checking employeeDetails equal to null or not
            if (_context.EmployeeDetailss != null)
            {
                return await _context.EmployeeDetailss.ToListAsync();
            }
            throw new Exception("no data found");
        }
    }
}
