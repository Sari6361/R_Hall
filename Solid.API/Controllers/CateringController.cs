using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solid.Core.DTOs;
using Solid.Core.Entities;
using Solid.Core.Service;
using Solid.Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Solid.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CateringController : ControllerBase
    {
        private readonly ICateringService _cateringService;
        private readonly IMapper _mapper;

        public CateringController(ICateringService cateringService, IMapper mapper)
        {
            _cateringService = cateringService;
            _mapper = mapper;
        }
        // GET: api/<CateringController>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<CateringDto>> Get(bool? status)
        {
            var list = _cateringService.GetCaterings(status);
            var listDto = list.Select(c => _mapper.Map<CateringDto>(c)).ToList();
            return Ok(listDto);
        }

        // GET api/<CateringController>/5
        [HttpGet("{id}/id")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            var c = _cateringService.GetCateringById(id);
            if (c == null)
                return NotFound();
            var cateringDto = _mapper.Map<CateringDto>(c);
            return Ok(cateringDto);
        }


        [HttpGet("{name}/name")]
        [AllowAnonymous]
        public IActionResult GetByName(string name)
        {
            Catering c = _cateringService.GetCateringByName(name);
            if (c is null)
                return NotFound();
            var catingDto = _mapper.Map<CateringDto>(c);
            return Ok(catingDto);
        }

        // POST api/<CateringController>
        [HttpPost]
        public ActionResult Post([FromBody] Catering c)
        {
            var addedCatering = _cateringService.AddCatering(c);
            var newCatering = _cateringService.GetCateringById(addedCatering.Id);
            var cateringDto = _mapper.Map<CateringDto>(newCatering);
            return Ok(cateringDto);
        }


        // PUT api/<CateringController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Catering c)
        {
            var existCatering = _cateringService.GetCateringById(id);
            if (existCatering is null)
                return NotFound();
            _mapper.Map(c, existCatering);
            _cateringService.UpdateCateringById(id, c);
            return Ok(_mapper.Map<CateringDto>(existCatering));
        }

        [HttpPut("{id}/status")]
        public ActionResult PutStatus(int id, [FromBody] bool status)
        {
            var existCatering = _cateringService.GetCateringById(id);
            if (existCatering is null)
                return NotFound();
            existCatering.Status = status;
            _cateringService.UpdateCateringStatus(id, status);
            return Ok(_mapper.Map<CustomerDto>(existCatering));
        }
    }
}
