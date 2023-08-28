using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Codie.Painel.API.Controllers
{
    [Authorize, Route("api/[controller]"), ApiController]
    public class ImagemController : ControllerBase
    {
        private readonly IImagemService _imageService;


    }
}
