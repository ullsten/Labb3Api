using System.Net;
using AutoMapper;
using Labb3ApiRoutes.Data;
using Labb3ApiRoutes.Models;
using Labb3ApiRoutes.Models.DTO;
using Labb3ApiRoutes.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Labb3ApiRoutes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestDTOController : ControllerBase
    {
        private readonly Labb3ApiRouteDbContext _context;
        private readonly IRepository<Interest> _interestDb;
        private readonly IMapper _mapper;
        private readonly ApiResponse _apiResponse;
        public InterestDTOController(IMapper mapper, IRepository<Interest> interestDb, Labb3ApiRouteDbContext context)
        {
            _context = context;
            _interestDb = interestDb;
            _mapper = mapper;
            this._apiResponse = new();
        }
        // GET: api/<InterestDTOController>
        [HttpGet("GetAllPersonsInterests")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetPersonInterest(string startsWith ="", int count = 0)
        {
            try
            {
                var interestList = await _interestDb.GetAllAsync(includeProperties: "Persons");

                if(!string.IsNullOrEmpty(startsWith))
                {
                    interestList = interestList.Where(p => p.Persons.FirstName.StartsWith(startsWith, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                var interestDTOList = interestList.Select(i => new InterestDTO
                {
                    FK_PersonId = i.FK_PersonId,
                    InterestDtoId = i.InterestId,
                    PersonName = i.Persons?.FullName ?? "",
                    InterestDescription = i.InterestDescription ?? "",
                    InterestTitle = i.InterestTitle ?? "",
                    Created = i.Created,

                });
                //check if count value is negative
                if (count < 0)
                {
                    _apiResponse.IsSuccess = false;
                    _apiResponse.ErrorMessages = new List<string> { $"Count can´t be negative ({count})"};
                    return BadRequest(_apiResponse);
                }
                //check if count value is bigger then maximum in list
                if(count > interestDTOList.Count())
                {
                    _apiResponse.IsSuccess = false;
                    _apiResponse.ErrorMessages = new List<string> { $"Count ({count}) exceeds the maximum number of items ({interestDTOList})" };
                    return BadRequest(_apiResponse);
                }
                //if no links in linkDtoList - message to answer
                if(interestDTOList.Count() == 0)
                {
                    _apiResponse.IsSuccess = false;
                    _apiResponse.ErrorMessages = new List<string> { $"No person found with related links, starting with '{startsWith}'"};
                    return BadRequest(_apiResponse);
                }
                //check if count value is greater than zero. If it is, items will be limit in answer
                if(count > 0)
                {
                    interestDTOList = interestDTOList.Take(count);
                }
                _apiResponse.Result = interestDTOList;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                _apiResponse.Messages = new List<string> { $"Result limit to {count} of {interestList.Count()}" };
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages = new List<string> { ex.Message };
            }
            return _apiResponse;
        }

        //Get person by id and interest
        [HttpGet("GetPersonInterestsBy{id:int}", Name = "GetPersonInterest")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetPersonInterest(int id)
        {
            try
            {
                if (id == 0)
                {
                    _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    _apiResponse.IsSuccess = false;
                    _apiResponse.ErrorMessages = new List<string> { $"No person can have ID {id}" };
                    return BadRequest(_apiResponse);
                }
                var interestList = await _interestDb.GetAllAsync(filter: i => i.FK_PersonId == id, includeProperties: "Persons");

                var interestDTOList = interestList.Select(i => new InterestDTO
                {
                    FK_PersonId = i.FK_PersonId,
                    InterestDtoId = i.InterestId,
                    PersonName = i.Persons?.FullName ?? "No name",
                    InterestDescription = i.InterestDescription ?? "No description",
                    InterestTitle = i.InterestTitle ?? "No title",
                    Created = i.Created,
                });

                if (interestList == null || interestList.Count == 0)
                {
                    _apiResponse.IsSuccess = false;
                    _apiResponse.ErrorMessages = new List<string>() { $"There is no person with ID {id}" };
                    _apiResponse.StatusCode = HttpStatusCode.NotFound;
                    return BadRequest(_apiResponse);
                }

                _apiResponse.Result = interestDTOList;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages = new List<string> { ex.Message };
                return _apiResponse;
            }
        }

        // POST api/<InterestDTOController>
        [HttpPost("AddPersonInterest")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> AddPersonInterest([FromBody] InterestCreateDTO interestCreateDTO)
        {
            try
            {
                if (interestCreateDTO == null)
                {
                    _apiResponse.IsSuccess = false;
                    _apiResponse.ErrorMessages = new List<string> { "No new interest and to person created" };
                    return BadRequest(interestCreateDTO);
                }
                Interest interest = _mapper.Map<Interest>(interestCreateDTO);
                await _interestDb.CreateAsync(interest);
                _apiResponse.Result = _mapper.Map<Interest>(interest);
                _apiResponse.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetPersonInterest", new { id = interest.InterestId }, _apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _apiResponse;
        }

        //// PUT api/<InterestDTOController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<InterestDTOController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }

}

