using AutoMapper;
using BusinessService.Dtos;
using BusinessService.Repository;
using DataService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Controllers
{
    
    [ApiController]
    public class GothamAppController : ControllerBase
    {
        
        private readonly IOutletRepo _outlet;
        private readonly IMapper _mapper;

        public GothamAppController(IOutletRepo outlet, IMapper mapper)
        {
            
            _outlet = outlet;
            _mapper = mapper;
        }
        //GET api/outlets
        [HttpGet("api/outlets")]
        public ActionResult<IEnumerable<OutletReadDto>> GetAllOutlets()
        {
            var outlets = _outlet.GetAllOutlets();
            return Ok(_mapper.Map<IEnumerable<OutletReadDto>>(outlets));

        }

        //GET api/outlets/{id}
        [HttpGet("api/outlets/{id}")]
        public ActionResult<OutletReadDto> GetOutletById(int id)
        {
            var outlet = _outlet.GetOutletById(id);
            if (outlet != null)
            {
                return Ok(_mapper.Map<OutletReadDto>(outlet));
            }
            return NotFound();
        }

        //POST api/outlets
        [HttpPost("api/outlets")]
        public ActionResult<OutletReadDto> CreateOutlet(OutletCreateDto outletCreateDto)
        {
            var outletModel = _mapper.Map<outlet>(outletCreateDto);
            _outlet.CreateOutlet(outletModel);
            _outlet.SaveChanges();

            var outletReadDto = _mapper.Map<OutletReadDto>(outletModel);

            return CreatedAtRoute(nameof(GetOutletById), new { Id = outletReadDto.OutletId }, outletReadDto);

        }

        //PUT api/outlets/{id}
        [HttpPut("api/outlets/{id}")]
        public ActionResult UpdateOutlet(int id, OutletUpdateDto outletUpdateDto)
        {
            var outletModelFromRepo = _outlet.GetOutletById(id);
            if (outletModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(outletUpdateDto, outletModelFromRepo);
            _outlet.UpdateOutlet(outletModelFromRepo);
            _outlet.SaveChanges();
            return NoContent();
        }

        //PATCH api/outlets/{id}
        [HttpPatch("api/outlets/{id}")]
        public ActionResult PartialOutletUpdate(int id, JsonPatchDocument<OutletUpdateDto> patchDoc)
        {
            var outletModelFromRepo = _outlet.GetOutletById(id);
            if (outletModelFromRepo == null)
            {
                return NotFound();
            }

            var outletToPatch = _mapper.Map<OutletUpdateDto>(outletModelFromRepo);
            patchDoc.ApplyTo(outletToPatch, ModelState);

            if (!TryValidateModel(outletToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(outletToPatch, outletModelFromRepo);
            _outlet.UpdateOutlet(outletModelFromRepo);
            _outlet.SaveChanges();
            return NoContent();

        }

        //DELETE api/outlets/{id}
        [HttpDelete("api/outlets/{id}")]
        public ActionResult DeleteOutlet(int id)
        {
            var outletModelFromRepo = _outlet.GetOutletById(id);
            if (outletModelFromRepo == null)
            {
                return NotFound();
            }

            _outlet.DeleteOutlet(outletModelFromRepo);
            _outlet.SaveChanges();
            return NoContent();
        }
    }
}
