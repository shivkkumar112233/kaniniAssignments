using GettingEmployeeInformation.Interfaces;
using GettingEmployeeInformation.Models;
using GettingEmployeeInformation.Models.DTOs;
using System.Linq;
namespace GettingEmployeeInformation.Services
{
    public class EmployeeDetailsService : IServiceRepo<EmployeeInformationDTO>
    {


        private readonly IRepo<EmployeeDetails> _employeeDetailsRepo;
        private readonly ILogger<EmployeeDetailsRepo> _logger;
        public EmployeeDetailsService(IRepo<EmployeeDetails> employeeDetailsRepo, ILogger<EmployeeDetailsRepo> logger)
        {
            _employeeDetailsRepo = employeeDetailsRepo;
            _logger = logger;
        }


        // getting all the employeeDetails and calculating the avg and sum 
        // returning the EmployeeInformationDTO 

      public async Task<EmployeeInformationDTO> GetValue()
        {
            try
            {
                //getting all the details from repo
                var employees = await _employeeDetailsRepo.GetAll();
                if (employees.Count() == 0)
                    return null;
                //count of employees activestatus is equal to Relieved
                var count = employees.Count(c => c.ActiveStatus == "Relieved");
                // totalcount of the employees
                var totalCount = employees.Count();
                //calculating the average
                var avg = (count / (double)totalCount) * 100;
                // creating a new employeeinformationDTO with average and count and returning it
                var result = new EmployeeInformationDTO();
                result.Average = avg;
                result.Count = count;
                return result;
            }
            //catching the expection and printing it in logger
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;



        }

      
    }
}
