using Application.Dtos;
using AutoMapper;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly DataContext _context;
		private readonly IMapper _mapper;

		public ImageController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //https://stackoverflow.com/questions/62847617/get-imagebinary-data-from-database-with-net-core-and-angular-8
        [HttpGet("{id}")]
        public ActionResult<Image> GetCompanyLogo(int id)
        {
            var company = _context.Companies.FirstOrDefault(c => c.Id == id);

            if (company == null)
			{
                return NotFound();
			}

            var image = _mapper.Map<Logo>(company);

            return Ok(image);
        }
    }
}
