
using BusinessObject.DTO;
using DataAccess.InterfaceService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TimeKeepingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestLeaveController : ControllerBase
    {
        private readonly IAttendanceStatusService _service;
        private readonly IRequestLeaveService _requestLeaveService;

        public RequestLeaveController(IAttendanceStatusService service, IRequestLeaveService requestLeaveService)
        {
            _service = service;
            _requestLeaveService = requestLeaveService;
        }

        [HttpGet("get-request-leave-of-employee")]
        public ActionResult<object> GetRequestLeaveOfEmployeeById(Guid employeeId)
        {
            try
            {
                return Ok(_requestLeaveService.GetRequestLeaveOfEmployeeById(employeeId));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-work-date-setting-of-employee")]
        public async Task<ActionResult<WorkDateSettingDTO>> GetWorkDateSettingFromEmployeeId(Guid employeeId)
        {
            try
            {
                return Ok(await _requestLeaveService.GetWorkDateSettingFromEmployeeId(employeeId));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("edit-request-leave-of-employee")]
        public async Task<ActionResult<bool>> EditRequestLeave(LeaveRequestDTO dto, Guid employeeId)
        {
            try
            {
                return Ok(await _requestLeaveService.EditRequestLeave(dto, employeeId));
            } catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("create-request-leave-of-employee")]
        public async Task<ActionResult<object>> CreateRequestLeave(LeaveRequestDTO dto, Guid employeeId)
        {
            try
            {
                return Ok(await _requestLeaveService.CreateRequestLeave(dto, employeeId));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-request-leave-of-all-employee")]
        public ActionResult<object> GetRequestLeaveAllEmployee(string? nameSearch, int status)
        {
            try
            {
                return Ok(_requestLeaveService.GetRequestLeaveAllEmployee(nameSearch, status));
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("approve-leave-request")]
        public async Task<IActionResult> ApproveRequestAndChangeWorkslotEmployee(Guid requestId)
        {
            try
            {
                return Ok(await _requestLeaveService.ApproveRequestAndChangeWorkslotEmployee(requestId));
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("get-request-leave-by-request-id")]
        public IActionResult GetRequestLeaveByRequestId(Guid requestId)
        {
            try
            {
                return Ok(_requestLeaveService.GetRequestLeaveByRequestId(requestId));
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}

