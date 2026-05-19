// =============================================================
// File: Controllers/ReviewController.cs
// Path: DunesOfArabia/Controllers/ReviewController.cs
// =============================================================

using DunesOfArabia.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DunesOfArabia.Controllers;

[Route("api/reviews")]
public class ReviewController : BaseApiController
{
    private readonly IReviewService _service;
    public ReviewController(IReviewService service) { _service = service; }

    // GET /api/reviews/destination/{destinationId}  — public
    [HttpGet("destination/{destinationId}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetByDestination(int destinationId)
    {
        var result = await _service.GetByDestinationIdAsync(destinationId);
        return Ok(result);
    }

    // POST /api/reviews  — logged-in users only
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateReviewDto dto)
    {
        var result = await _service.CreateAsync(CurrentUserId!, dto);
        return Ok(result);
    }

    // DELETE /api/reviews/{id}  — owner or admin
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var review = await _service.GetByIdAsync(id);
        if (review is null) return NotFound();

        var guard = ForbidIfNotOwner(review.UserId);
        if (guard != null) return guard;

        await _service.DeleteAsync(id);
        return NoContent();
    }
}
