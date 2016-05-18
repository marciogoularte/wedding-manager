﻿using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WeddingManager.Api.Models;
using WeddingManager.Core.Services;

namespace WeddingManager.Api.Controllers
{
    [RoutePrefix("api/services")]
    public class ServiceController : ControllerBase
    {
        [HttpOptions]
        [Route("")]
        public async Task<IHttpActionResult> Options1()
        {
            return Ok();
        }

        [HttpOptions]
        [Route("{companyId}")]
        public async Task<IHttpActionResult> Options2(int companyId)
        {
            return Ok();
        }

        [HttpPost]
        [Route("{customerId}")]
        public async Task<IHttpActionResult> CreateService(int customerId, [FromBody]ServiceDto serviceDto)
        {
            var serviceId = ServiceService.CreateService(customerId, serviceDto.ToService());

            return Ok(serviceId);
        }

        [HttpGet]
        [Route("{customerId}")]
        public async Task<IHttpActionResult> RetrieveServices(int customerId)
        {
            var services = ServiceService.RetrieveServices(customerId).Select(s => new ServiceDto(s));

            return Ok(services);
        }

        [HttpGet]
        [Route("{companyId}/{serviceId}")]
        public async Task<IHttpActionResult> RetrieveService(int companyId, int serviceId)
        {
            var service = ServiceService.RetrieveService(companyId, serviceId);

            if(service == null)
            {
                return NotFound();
            }

            var serviceDto = new ServiceDto(service);

            return Ok(serviceDto);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> UpdateService([FromBody]ServiceDto serviceDto)
        {
            ServiceService.UpdateService(serviceDto.ToService());

            return Ok();
        }

        [HttpDelete]
        [Route("{serviceId}")]
        public async Task<IHttpActionResult> DeleteService(int serviceId)
        {
            ServiceService.DeleteService(serviceId);

            return Ok();
        }

        protected IServiceService ServiceService
        {
            get
            {
                return Services.Resolve<IServiceService>();
            }
        }
    }
}