using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enterprise.ConfigurationServer.DataLayers.ConfigurationDB;
using Enterprise.ConfigurationServer.Interfaces.ConfigurationDB;
using Enterprise.Models.NetStandard;
using Microsoft.AspNetCore.Mvc;
using Enterprise.Extension.NetStandard;
using Enterprise.Enums.NetStandard;
using Enterprise.Exceptions.NetStandard;
using Enterprise.Constants.NetStandard;
using Microsoft.AspNetCore.Authorization;
using Enterprise.ActionResults.NetStandard;
using Enterprise.Interfaces.NetStandard.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.ConfigurationServer.Controllers
{
    [Route("api/[controller]")]
    public class URLConfigurationController : Controller
    {
        private readonly IConfigurationDBUnitOfWork _configurationDBUnitOfWork;
        #region Template
        private readonly ILoggingServices _loggingServices;
        private readonly LogModel logModel;
        private readonly UserScopesModel userScopesModel;
        #endregion

        public URLConfigurationController(IConfigurationDBUnitOfWork configurationDBUnitOfWork, ILoggingServices loggingServices)
        {
            _configurationDBUnitOfWork = configurationDBUnitOfWork;

            #region Template
            _loggingServices = loggingServices;
            logModel = new LogModel();
            userScopesModel = new UserScopesModel(HttpContext);
            logModel.SetModel(userScopesModel.Subject.ToString(), userScopesModel.Name, nameof(URLConfigurationController), ApplicationNames.ConfigurationServer, LogTypeEnum.Info);
            #endregion
        }
        // GET: api/<controller>
        [HttpGet]
        [Authorize(Policy = Policies.read_only_access_policy)]
        public async Task<IActionResult> Get()
        {
            IEnumerable<IntegratedApp> apps = null;
            try
            {
                logModel.LogMessage = "User Requested All App URLS Configuration.";

                // Logging
                await _loggingServices.LogAsync(logModel);

                apps = await _configurationDBUnitOfWork.IntegratedAppRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, _loggingServices);
            }
            return Ok(apps);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = Policies.write_access_policy)]
        public async Task<IActionResult> Put(string id, [FromBody]IntegratedApp value)
        {
            try
            {
                if (value == null)
                {
                    throw new ParameterNullException(ExceptionMessage.URL_CONFIGURATION_VALUE_CANT_BE_NULL);
                }
                var result = (await _configurationDBUnitOfWork.IntegratedAppRepository.FindByAsync(x => x.ID == new Guid(id))).SingleOrDefault();
                if (result == null)
                {
                    throw new ItemNotFoundException();
                }
                if (result.Integrated == value.Integrated && result.ApplicationURL == value.ApplicationURL)
                {
                    throw new NoChangesToUpdateException();
                }
                logModel.LogMessage = string.Format("User '{0}' Update App '{1}' Configurations Url from '{2}' to '{3}', Integrated '{4}' to '{5}'.",
                userScopesModel.Name,
                value.ApplicationName,
                result.ApplicationURL,
                value.ApplicationURL,
                result.Integrated,
                value.Integrated);

                // Logging
                await _loggingServices.LogAsync(logModel);

                result.ApplicationURL = value.ApplicationURL;
                result.Integrated = value.Integrated;
                _configurationDBUnitOfWork.IntegratedAppRepository.Update(result);

                await _configurationDBUnitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, _loggingServices);
            }
            return Ok();
        }
    }
}
