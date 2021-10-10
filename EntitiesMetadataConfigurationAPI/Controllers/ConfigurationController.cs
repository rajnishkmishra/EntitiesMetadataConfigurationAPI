using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EntitiesMetadataConfigurationAPI.Models;
using EntitiesMetadataConfigurationAPI.Services;

namespace EntitiesMetadataConfigurationAPI.Controllers
{
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private IConfigurationService _configurationService;

        public ConfigurationController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }

        [HttpGet]
        [Route("api/{entity}")]
        public ActionResult<Result> Get(string entity)
        {
            var result = _configurationService.GetResult(entity);
            return result;
        }
    }
}
