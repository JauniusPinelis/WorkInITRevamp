using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class ImageController
    {
        //https://stackoverflow.com/questions/62847617/get-imagebinary-data-from-database-with-net-core-and-angular-8
        [HttpGet]
        [FileResultContentType("image/jpeg")]
        public async Task<FileStreamResult> GetImageStream(string imageId)
        {
            Stream imageStream = await _imageStore.GetImage(imageId);
            imageStream.Seek(0, SeekOrigin.Begin);

            var contentDisposition = new ContentDispositionHeaderValue("attachment");
            contentDisposition.SetHttpFileName($"{imageId}.jpg");
            Response.Headers.Add(HeaderNames.ContentDisposition, contentDisposition.ToString());

            return new FileStreamResult(imageStream, "image/jpeg");
        }
    }
}
