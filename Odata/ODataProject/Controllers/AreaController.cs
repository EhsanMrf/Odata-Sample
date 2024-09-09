using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Odata.Contract.Dtos;
using Odata.Contract.Interface;
using Utility.Response;

namespace ODataProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ODataController
    {
        private readonly IAreaService _service;
        private readonly IAreaRepository _areaRepository;
        public AreaController(IAreaService service, IAreaRepository areaRepository)
        {
            _service = service;
            _areaRepository = areaRepository;
        }

        #region Create Update Delete Active DeActive

        [HttpPost]
        public async Task Create(AreaSave input)
        {
            await _service.Create(input);
        }

        [HttpPut("/{id}")]
        public async Task Update(short id, AreaSave input)
        {
            await _service.Update(id, input);
        }

        [HttpDelete("/{id}")]
        public async Task Delete(short id)
        {
            await _service.Delete(id);
        }

        #endregion



        [HttpGet]
        public async Task<ServiceResponse<DataList<IEnumerable<AreaDto>>>> GetList(ODataQueryOptions<Area> dataRequest)
        {
            return await _service.GetList(dataRequest);
        }


    }
}
