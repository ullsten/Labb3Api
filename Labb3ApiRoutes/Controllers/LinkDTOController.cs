using System.Net;
using AutoMapper;
using Labb3ApiRoutes.Data;
using Labb3ApiRoutes.Models;
using Labb3ApiRoutes.Models.DTO;
using Labb3ApiRoutes.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Labb3ApiRoutes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkDTOController : ControllerBase
    {
        private readonly Labb3ApiRouteDbContext _context;
        private readonly IRepository<Link> _linkDb;
        private readonly IMapper _mapper;
        private readonly ApiResponse _apiResponse;

        public LinkDTOController(Labb3ApiRouteDbContext context, IMapper mapper, IRepository<Link> linkDb)
        {
            _context = context;
            _linkDb = linkDb;
            _mapper = mapper;
            _apiResponse = new ApiResponse();
        }

        // GET: api/<LinkDTOController>
        [HttpGet("GetAllLinkPerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAllLinkPerson(string startsWith = "", int count = 0)
        {
            try
            {
                IEnumerable<Link> linkList = await _linkDb.GetAllAsync(includeProperties: "Persons");
              
                if (!string.IsNullOrWhiteSpace(startsWith))
                {
                    linkList = linkList.Where(p => p.Persons.FirstName.StartsWith(startsWith, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                var linkDtoList = linkList.Select(l => new LinkDTO
                {
                    LinkId = l.LinkId,
                    PersonId = l.FK_PersonId,
                    PersonName = l.Persons?.FullName ?? "",
                    LinkTitle = l.LinkTitle,
                    URL = l.URL,
                });

                //check if count value is negative
                if (count <0)
                {
                    _apiResponse.IsSuccess = false;
                    _apiResponse.ErrorMessages = new List<string> { $"Count cannont be negative ({count})" };
                    return BadRequest(_apiResponse);
                }
                //check if count value is bigger then maximum in list
                if (count > linkList.Count())
                {
                    _apiResponse.IsSuccess = false;
                    _apiResponse.ErrorMessages = new List<string> { $"Count exceeds the maximum number of items ({linkList.Count()}" };
                    return BadRequest(_apiResponse);
                }
                //if no links in linkDtoList - message to answer
                if (linkList.Count() == 0)
                {
                    _apiResponse.IsSuccess = false;
                    _apiResponse.ErrorMessages = new List<string> { $"No person found starting with '{startsWith}'" };
                    return BadRequest(_apiResponse);
                }

                //check if count value is greater than zero. If it is, items will be limit in answer
                if (count > 0)
                {
                    linkDtoList = linkDtoList.Take(count).ToList();
                    _apiResponse.Messages = new List<string> { $"Result limit to {count} of {linkList.Count()}" };
                }
                else
                {
                    _apiResponse.Messages = new List<string> { $"All {linkDtoList.Count()} items will be displayed" };
                }

                _apiResponse.Result = linkDtoList.ToList();
                _apiResponse.StatusCode = HttpStatusCode.OK;

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages = new List<string> { ex.Message };
                return StatusCode(StatusCodes.Status500InternalServerError, _apiResponse);
            }
        }

        // GET api/<LinkDTOController>/5
        [HttpGet("GetPersonLinksBy{id}", Name = "GetLinkPerson")]
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
                var linkList = await _linkDb.GetAllAsync(filter: i => i.FK_PersonId == id, includeProperties: "Persons");

                var linkDTOList = linkList.Select(i => new LinkDTO
                {
                    LinkId = i.LinkId,
                    PersonId = i.FK_PersonId,
                    PersonName = i.Persons.FullName,
                    URL = i.URL,
                });

                if (linkList == null || linkList.Count == 0)
                {
                    _apiResponse.IsSuccess = false;
                    _apiResponse.ErrorMessages = new List<string>() { $"There is no person with ID {id}" };
                    _apiResponse.StatusCode = HttpStatusCode.NotFound;
                    return BadRequest(_apiResponse);
                }

                _apiResponse.Result = linkDTOList;
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

        // POST api/<LinkDTOController>
        [HttpPost("AddNewLinkPersonInterest")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> CreateNewLinkPersonInterest([FromBody] LinkCreateDTO linkCreateDTO)
        {
            try
            {
                if (linkCreateDTO == null)
                {
                    _apiResponse.IsSuccess = false;
                    _apiResponse.ErrorMessages = new List<string> { "No link created for person and interest." };
                    return BadRequest(linkCreateDTO);
                }
                Link link = _mapper.Map<Link>(linkCreateDTO);
                await _linkDb.CreateAsync(link);
                _apiResponse.Result = _mapper.Map<Link>(link);
                _apiResponse.StatusCode = HttpStatusCode.OK;
                return CreatedAtRoute("GetLinkPerson", new { id = link.LinkId }, _apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _apiResponse;
        }

        //Update Link
        [HttpPut("UpdateLinkPersonInterest{id:int}", Name = "UpdateLink")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> UpdateLinkPersonInterest(int id,[FromBody] LinkUpdateDTO updateDTO)
        {
            try
            {
                if(updateDTO == null || id != updateDTO.LinkId)
                {
                    return BadRequest();
                }
                Link model = _mapper.Map<Link>(updateDTO);

                await _linkDb.UpdateAsync(model);
                _apiResponse.StatusCode = HttpStatusCode.NoContent;
                _apiResponse.IsSuccess = true;
                return _apiResponse;
            }
            catch(Exception ex) 
            { 
                _apiResponse.IsSuccess=false;
                _apiResponse.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _apiResponse;
        }

        // DELETE api/<LinkDTOController>/5
        [HttpDelete("DeleteLinkPersonInterest{id}", Name ="DeleteLink")]
        public async Task<ActionResult<ApiResponse>> DeleteLink(int id)
        {
            try
            {
                if(id == 0)
                {
                    _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    _apiResponse.IsSuccess = false;
                    _apiResponse.ErrorMessages = new List<string> { $"There is no link with ID: {id}" };
                    return BadRequest(_apiResponse);
                }
                var link = await _linkDb.GetAsync(l => l.LinkId == id);
                if(link == null)
                {
                    return NotFound();
                }
                await _linkDb.RemoveAsync(link);
                _apiResponse.StatusCode = HttpStatusCode.NoContent;
                _apiResponse.IsSuccess = true;
                _apiResponse.Messages = new List<string> { $"Link with ID: {id} was succesfully deleted" };
                return _apiResponse;
            }
            catch(Exception ex)
            {
                _apiResponse.IsSuccess=false;
                _apiResponse.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _apiResponse;
        }
    }
}
