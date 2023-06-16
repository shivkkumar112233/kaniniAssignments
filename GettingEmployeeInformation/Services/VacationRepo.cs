using GettingEmployeeInformation.Interfaces;
using GettingEmployeeInformation.Models;
using Microsoft.EntityFrameworkCore;

namespace GettingEmployeeInformation.Services
{
    public class VacationRepo : IRepo<Vacation>
    {
        private readonly EmpContext _context;

        public VacationRepo(EmpContext context) { 
            _context=context;
        }
        // getting all the vacation data 
        public  async Task<ICollection<Vacation> >GetAll()
        {
            if(_context.Vacations!=null) 
              return await  _context.Vacations.ToListAsync();
            throw new Exception("no data found");

        }
    }
}
