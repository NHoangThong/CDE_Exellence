using CDE_Exellence.Model;
using CDE_Exellence.Service.VisitFolder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CDE_Exellence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VisitController : ControllerBase
    {
        private readonly IVisitService _visitService;

        public VisitController(IVisitService visitService)
        {
            _visitService = visitService;
        }

        [HttpGet]
        public IActionResult GetVisits([FromQuery] int userId)
        {
            try
            {
                var visits = _visitService.GetVisitsForUser(userId);
                return Ok(visits);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        [HttpGet("search")]
        public IActionResult SearchVisits([FromQuery] string keyword,
                                  [FromQuery] DateTime? startDate,
                                  [FromQuery] DateTime? endDate,
                                  [FromQuery] string? status,
                                  [FromQuery] string? distributor)
        {
            try
            {
                var visits = _visitService.SearchAndFilterVisits(keyword, startDate, endDate, status, distributor);
                return Ok(visits);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
        // Xem danh sách lịch viếng thăm trong quá khứ hoặc đã hủy
        [HttpGet("history")]
        public IActionResult GetHistoryVisits()
        {
            try
            {
                var visits = _visitService.GetPastOrCancelledVisits();
                return Ok(visits);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // Xem danh sách lịch viếng thăm chưa thực hiện trong hiện tại hoặc tương lai
        [HttpGet("upcoming")]
        public IActionResult GetUpcomingVisits()
        {
            try
            {
                var visits = _visitService.GetUpcomingVisits();
                return Ok(visits);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // Xem chi tiết lịch viếng thăm
        [HttpGet("{visitId}")]
        public IActionResult GetVisitDetails(int visitId)
        {
            try
            {
                var visit = _visitService.GetVisitDetails(visitId); // Cần thêm phương thức này trong service
                return Ok(visit);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        // Cập nhật thông tin lịch viếng thăm
        [HttpPut("{visitId}")]
        public IActionResult UpdateVisit(int visitId, [FromBody] Visit visit)
        {
            try
            {
                var updatedVisit = _visitService.UpdateVisit(visitId, visit); // Cần thêm phương thức này trong service
                return Ok(updatedVisit);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
