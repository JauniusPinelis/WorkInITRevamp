using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
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

		public ImageController(DataContext context)
		{
            _context = context;
		}

        //https://stackoverflow.com/questions/62847617/get-imagebinary-data-from-database-with-net-core-and-angular-8
        [HttpGet]
        //[FileResultContentType("image/jpeg")]
        public FileStreamResult GetImageStream()
        {
            var myImage = _context.Companies.Where(c => c.ImageData != null).First().ImageData;
            var stream = new MemoryStream(myImage);

            return new FileStreamResult(stream, "image/jpeg" /*chnage this based on your image type */ )
            {
                FileDownloadName = "test.jpeg"
            };

            //Stream imageStream = _context.Companies.Where(c => c.ImageData.Any()).First().ImageData;
            //imageStream.Seek(0, SeekOrigin.Begin);

            //var contentDisposition = new ContentDispositionHeaderValue("attachment");
            //contentDisposition.SetHttpFileName($"{imageId}.jpg");
            //Response.Headers.Add(HeaderNames.ContentDisposition, contentDisposition.ToString());

            //return new FileStreamResult(imageStream, "image/jpeg");
        }
    }
}
