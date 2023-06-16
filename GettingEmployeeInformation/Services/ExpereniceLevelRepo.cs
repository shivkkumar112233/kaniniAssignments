using GettingEmployeeInformation.Interfaces;
using GettingEmployeeInformation.Models;
using Microsoft.EntityFrameworkCore;

namespace GettingEmployeeInformation.Services
{
    public class ExpereniceLevelRepo : IRepo<ExperienceLevel>
    {
        private readonly EmpContext _empContext;

        public ExpereniceLevelRepo(EmpContext empContext)
        {
          _empContext=empContext;
        }

       // getting all the Experenicelevel details
        public async Task< ICollection<ExperienceLevel>> GetAll()
        {
            if(_empContext.ExperienceLevels!=null)
              return  await _empContext.ExperienceLevels.ToListAsync();
            throw new Exception("no data found");

        }
    }
}
