using CustomTranslator.API.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomTranslator.API.Controllers
{
    [Route("customtranslator/api/[controller]")]
    [ApiController]
    public class TranslatorHistoryController : ControllerBase
    {
        private readonly TranslatorContext translatorContext;
        public TranslatorHistoryController(TranslatorContext translatorContext)
        {
            this.translatorContext = translatorContext;
        }
        [HttpGet]
        public async Task<List<TranslatorHistory>> Get()
        {
            return translatorContext.TranslatorHistorys.ToList();
        }
    }
}
