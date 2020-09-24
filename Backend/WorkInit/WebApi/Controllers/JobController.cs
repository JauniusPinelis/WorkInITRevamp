using Domain.Models;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class JobController : ControllerBase
    {
		private readonly DataContext _context;

		public JobController(DataContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<JobUrl>>> GetJobUrls()
		{
			return await _context.JobUrls.Include(j => j.Tags).OrderByDescending(j => j.Created).Take(10).ToListAsync();
		}
    }
}
