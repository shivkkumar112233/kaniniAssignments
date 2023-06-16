using GettingEmployeeInformation.Interfaces;
using GettingEmployeeInformation.Models;
using GettingEmployeeInformation.Models.DTOs;

namespace GettingEmployeeInformation.Services
{
    public class ExpereniceLevelLeadershipService :IServiceRepo<EmployeeInformationDTO>
    {
        private IRepo<ExperienceLevel> _repo;
        private readonly ILogger<EmployeeDetailsRepo> _logger;

        public ExpereniceLevelLeadershipService(IRepo<ExperienceLevel> repo, ILogger<EmployeeDetailsRepo> logger) { 
            _repo=repo;
            _logger = logger;

        }
        // the GetValue() method gets all the Experenicelevel data and calculates
        // the avg and count ,returns the EmployeeInfromationDTO
        public async Task<EmployeeInformationDTO> GetValue()
        {
            try
            {
                // getting all the Experenicelevel data from the repo
                var ExpereniceLevel = await _repo.GetAll();
                if (ExpereniceLevel.Count == 0)
                    return null;
                //calcualting count of the employees whose employeelevel is
                //equal to seniorlevel and skillScore greater than 5
                var count = ExpereniceLevel.Count(c => c.EmployeesLevel == "SeniorLevel" && c.SkillScore > 5);
                //calculating the totalcount 
                var totalCount = ExpereniceLevel.Count();
                // calculating avg by avg=count/totalcount*100
                var avg = (count / (double)totalCount) * 100;
                // creting new employeeInformationDto with new Avg and sum
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

