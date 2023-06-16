using GettingEmployeeInformation.Interfaces;
using GettingEmployeeInformation.Models.DTOs;
using GettingEmployeeInformation.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GettingEmployeeInformation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEnumerable<IServiceRepo<EmployeeInformationDTO>> _serviceRepos;
        //taking all sevices and repostiories as depency injection
        public EmployeeController(IEnumerable<IServiceRepo<EmployeeInformationDTO>> serviceRepos)
        {
            _serviceRepos = serviceRepos;
        }
        [ProducesResponseType(typeof(ActionResult<EmployeeInformationDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        // GetEmployeeRelivedData() returns all the Employees statitics of employees who are relived

        [HttpGet("EmployeeRelievedData")]
        public async Task<ActionResult<EmployeeInformationDTO>> GetEmployeeRelivedData()
        {
          
            var employeeDetailsService = _serviceRepos.FirstOrDefault(s => s is EmployeeDetailsService);
          
            var employeeInformationDTO = new EmployeeInformationDTO();
            if (employeeDetailsService == null)
                return BadRequest("No service found");
            try
            {
                employeeInformationDTO = await employeeDetailsService.GetValue();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            if (employeeInformationDTO == null)
                return BadRequest("no data found");
            return Ok(employeeInformationDTO);
        }
        [ProducesResponseType(typeof(ActionResult<EmployeeInformationDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("EmployeeNewJoinersData")]
       //getting all the freshers data stastics
        public async Task<ActionResult<EmployeeInformationDTO>> GetEmployeeFreshersData()
        {
            var experienceLevelService = _serviceRepos.FirstOrDefault(s => s is ExpereniceLevelService);
            if (experienceLevelService == null)
                return BadRequest("No service found");
            var employeeInformationDTO = new EmployeeInformationDTO();
            try
            {
                employeeInformationDTO = await experienceLevelService.GetValue();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            if (employeeInformationDTO == null)
                return BadRequest("no data found");
            return Ok(employeeInformationDTO);
        }
        [ProducesResponseType(typeof(ActionResult<EmployeeInformationDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        [HttpGet("EmployeeVacationData")]
        //GetEmployeeVacationData() mehod returns EmployeeinformationDto where it contains count and avg of employees 
        // who are in vacation

        public async Task<ActionResult<EmployeeInformationDTO>> GetEmployeeVacationData()
        {
            var vacationService = _serviceRepos.FirstOrDefault(s => s is VacationService);
            if (vacationService == null)
                return BadRequest("no service found");
            var employeeInformationDTO = new EmployeeInformationDTO();
            try
            {
                employeeInformationDTO = await vacationService.GetValue();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            if (employeeInformationDTO == null)
                return BadRequest("no data found");
            return Ok(employeeInformationDTO);
        }
        [ProducesResponseType(typeof(ActionResult<EmployeeInformationDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("EmployeeLeadershipData")]

        //GetEmployeeLeadershipData() mehod returns EmployeeinformationDto where it contains count and avg of employees 
        // who are in leadership position

        public async Task<ActionResult<EmployeeInformationDTO>> GetEmployeeLeadershipData()
        {
            var employeeInformationDTO = new EmployeeInformationDTO();
            var experienceLevelLeadershipService = _serviceRepos.FirstOrDefault(s => s is ExpereniceLevelLeadershipService);
            if (experienceLevelLeadershipService == null)
                return BadRequest("No service found");
            try
            {
                employeeInformationDTO = await experienceLevelLeadershipService.GetValue();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            if (employeeInformationDTO == null)
                return BadRequest("no data found");
            return Ok(employeeInformationDTO);
        }
    }
}
