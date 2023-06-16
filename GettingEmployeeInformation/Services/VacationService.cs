using System.Diagnostics;
using GettingEmployeeInformation.Interfaces;
using GettingEmployeeInformation.Models;
using GettingEmployeeInformation.Models.DTOs;

namespace GettingEmployeeInformation.Services
{
    public class VacationService : IServiceRepo<EmployeeInformationDTO>
    {
        private readonly IRepo<Vacation> _repo;
        private readonly EmpContext _context;
        private readonly ILogger<EmployeeDetailsRepo> _logger;

        public VacationService(IRepo<Vacation>repo,EmpContext context, ILogger<EmployeeDetailsRepo> logger) { 
            _repo=repo;
            _context=context;
            _logger = logger;
        }
        // getting all the vacation data and calculating avg and sum
        public  async Task<EmployeeInformationDTO>GetValue()
        {
            try
            {
                // getting all the data
                var vacationDetails = await _repo.GetAll();
                if (vacationDetails.Count == 0)
                    return null;
                
                //performing inner join on the employeeDetailss and vactions and based on the empid and
                //getting the count
                var totalCount = _context.EmployeeDetailss
                    .GroupJoin(
                    _context.Vacations,
                     emp => emp.EmpId,
                      vac => vac.EmpId,
                   (emp, vac) => new { emp, vac }
                    )
               .SelectMany(
                   x => x.vac.DefaultIfEmpty(),
                (emp, vac) => new { emp.emp, vac }
                )
             .Count();
                var count = vacationDetails.Count();
                //calcualting the avg
                var avg = (Convert.ToDouble(count) / totalCount) * 100.0;
                //creating new EmplopyeeInfromation DTO and returning it

                var result = new EmployeeInformationDTO();
                result.Average = avg;
                result.Count = count;
                return result;
            }
            //catching the expection
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;

        }
    }
}
