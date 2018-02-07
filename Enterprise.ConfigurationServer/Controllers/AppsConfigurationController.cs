using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Enterprise.ConfigurationServer.DTO;
using Enterprise.ConfigurationServer.Interfaces.ConfigurationDB;
using Enterprise.Models.NetStandard;
using Enterprise.Extension.NetStandard;
using Microsoft.AspNetCore.Mvc;
using Enterprise.Enums.NetStandard;
using Microsoft.EntityFrameworkCore;
using Enterprise.Constants.NetStandard;
using Enterprise.Exceptions.NetStandard;
using Microsoft.AspNetCore.Authorization;
using Enterprise.ActionResults.NetStandard;
using Enterprise.Interfaces.NetStandard.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Enterprise.ConfigurationServer.Controllers
{
    [Route("api/[controller]")]
    public class AppsConfigurationController : Controller
    {
        private readonly IConfigurationDBUnitOfWork _configurationDBUnitOfWork;

        #region Template
        private readonly ILoggingServices _loggingServices;

        private readonly LogModel logModel;
        private readonly UserScopesModel userScopesModel;
        #endregion

        public AppsConfigurationController(IConfigurationDBUnitOfWork configurationDBUnitOfWork, ILoggingServices loggingServices)
        {
            _configurationDBUnitOfWork = configurationDBUnitOfWork;

            _loggingServices = loggingServices;

            #region Template
            logModel = new LogModel();
            userScopesModel = new UserScopesModel(HttpContext);
            logModel.SetModel(userScopesModel.Subject.ToString(), userScopesModel.Name, nameof(AppsConfigurationController), ApplicationNames.ConfigurationServer, LogTypeEnum.Info);
            #endregion
        }
        // GET: api/<controller>
        [HttpGet]
        [Authorize(Policy = Policies.read_only_access_policy)]
        public async Task<IActionResult> Get()
        {
            IEnumerable<AppsConfigurationDTO> result = null;
            try
            {
                logModel.LogMessage = "User Requested All App Configurations.";

                // Logging
                await _loggingServices.LogAsync(logModel);

                result = await _configurationDBUnitOfWork
                    .ConfigurationDBContext
                    .ApplicationConfigurations
                    .Include(b => b.IntegratedApp)
                    .Select(x => new AppsConfigurationDTO
                    {
                        ApplicationName = x.IntegratedApp.ApplicationName,
                        ID = x.ID,
                        Integrated = x.IntegratedApp.Integrated,
                        Key = x.Key,
                        Values = x.Values
                    }).ToListAsync();
            }
            catch (Exception ex)
            {
                return new ExceptionResult(ex, _loggingServices);
            }
            return Ok(result);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = Policies.write_access_policy)]
        public async Task<IActionResult> Put(string id, [FromBody]string value)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ParameterNullException(ExceptionMessage.CONFIGURATION_VALUE_CANT_BE_NULL);
                }
                var result = (await _configurationDBUnitOfWork.ApplicationConfigurationRepository.FindByAsync(x => x.ID == new Guid(id))).SingleOrDefault();

                if (result == null)
                {
                    throw new ItemNotFoundException();
                }
                else if (result.Values == value)
                {
                    throw new NoChangesToUpdateException();
                }
                
                logModel.LogMessage = string.Format("User '{0}' Changed '{1}' App Configurations Key '{2}' Value from '{3}' to '{4}'.",
                    userScopesModel.Name,
                    (await _configurationDBUnitOfWork.IntegratedAppRepository.GetSingleAsync(x=>x.ID== result.IntegratedAppID)).ApplicationName,
                    result.Key,
                    result.Values,
                    value);

                // Logging
                await _loggingServices.LogAsync(logModel);

                result.Values = value;
                _configurationDBUnitOfWork.ApplicationConfigurationRepository.Update(result);

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
