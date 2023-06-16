using System.Runtime.Intrinsics.X86;
using GettingEmployeeInformation.Interfaces;
using GettingEmployeeInformation.Models;
using GettingEmployeeInformation.Models.DTOs;

namespace GettingEmployeeInformation.Services
{
    public class ExpereniceLevelService : IServiceRepo<EmployeeInformationDTO>
{
        private readonly IRepo<ExperienceLevel> _experienceLevelRepo;
        private readonly ILogger<EmployeeDetailsRepo> _logger;

        public ExpereniceLevelService(IRepo<ExperienceLevel> experienceLevelRepo, ILogger<EmployeeDetailsRepo> logger)
        {
            _experienceLevelRepo= experienceLevelRepo;
            _logger = logger;
        }
        // the GetValue() method gets all the Experenicelevel data and calculates
        // the avg and count ,returns the EmployeeInfromationDTO
        public async  Task< EmployeeInformationDTO> GetValue()
        {
            try
            {
                // getting all the Experenicelevel data from the repo
                var totalemployees = await _experienceLevelRepo.GetAll();
                if (totalemployees.Count() == 0)
                    return null;
                //calcualting count of the employees whose employeelevel is
                //equal to juniorlevel
                var JuniorEmployeeCount = totalemployees.Count(c => c.EmployeesLevel == "JuniorLevel");
                // calculating EmployeeTotalCount
                var EmployeeTotalCount = totalemployees.Count();
                // calculating the avg
                var AvgOfEmp = (JuniorEmployeeCount / (double)EmployeeTotalCount) * 100;
                //creating new EmployeeInformationDTO with avg and count
                var result = new EmployeeInformationDTO();
                result.Average = AvgOfEmp;
                result.Count = JuniorEmployeeCount;
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
