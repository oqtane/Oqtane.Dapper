using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using MyCompany.Module.Dapper.Repository;
using Oqtane.Controllers;
using System.Net;
using System.Threading.Tasks;
using Oqtane.Extensions;

namespace MyCompany.Module.Dapper.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class ClientController : ModuleControllerBase
    {
        private readonly IClientRepository _ClientRepository;
        private readonly IHttpContextAccessor _accessor;

        public ClientController(IClientRepository ClientRepository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _ClientRepository = ClientRepository;
            _accessor = accessor;
        }

        // GET: api/<controller>
        [HttpGet]
        [Authorize(Roles = RoleNames.Registered)]
        public async Task<IEnumerable<Models.Client>> Get()
        {
            return await _ClientRepository.GetClients(_accessor.HttpContext.GetAlias().SiteId);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Roles = RoleNames.Registered)]
        public async Task<Models.Client> Get(int id)
        {
            var Client = await _ClientRepository.GetClient(id);
            if (Client != null && Client.SiteId == _accessor.HttpContext.GetAlias().SiteId)
            {
                return Client;
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Client Get Attempt {ClientId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Roles = RoleNames.Admin)]
        public async Task<Models.Client> Post([FromBody] Models.Client Client)
        {
            if (ModelState.IsValid)
            {
                Client.SiteId = _accessor.HttpContext.GetAlias().SiteId;
                Client = await _ClientRepository.AddClient(Client);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "Client Added {Client}", Client);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Client Post Attempt {Client}", Client);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                Client = null;
            }
            return Client;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Roles = RoleNames.Admin)]
        public async Task<Models.Client> Put(int id, [FromBody] Models.Client Client)
        {
            if (ModelState.IsValid)
            {
                Client.SiteId = _accessor.HttpContext.GetAlias().SiteId;
                Client = await _ClientRepository.UpdateClient(Client);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "Client Updated {Client}", Client);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Client Put Attempt {Client}", Client);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                Client = null;
            }
            return Client;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = RoleNames.Admin)]
        public async Task Delete(int id)
        {
            Models.Client Client = await _ClientRepository.GetClient(id);
            if (Client != null && Client.SiteId == _accessor.HttpContext.GetAlias().SiteId)
            {
                await _ClientRepository.DeleteClient(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "Client Deleted {ClientId}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized Client Delete Attempt {ClientId}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
