using System.Collections;
using Microsoft.AspNetCore.Mvc;

namespace KakaoLocal.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KakaoLocalController : ControllerBase
    {
        private readonly ILocalService localservice;   //인터페이스 참조변수 선언 

        public KakaoLocalController(ILocalService _localService)
        {
            localservice = _localService;         //의존성 주입 (DI)
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<KakaoLocalResult>>> GetLocal (string keyword)
        {
            var result = await localservice.SearchPlaceAsync(keyword);
            return Ok(result);
        }
    }
}
