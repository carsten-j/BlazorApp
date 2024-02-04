
using BellyBox.Server.Data;
using BellyBox.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BellyBox.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BoxController : Controller
{
    private readonly BellyBoxContext _context;

	public BoxController(BellyBoxContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<Box>>> Get()
	{
		var boxes = await _context.Boxes.Include(b=>b.Meals).ToListAsync();
		return Ok(boxes.Select(b => b.ToBox()));
	}
}
