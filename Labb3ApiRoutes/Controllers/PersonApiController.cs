using System.Net;
using AutoMapper;
using Labb3ApiRoutes.Data;
using Labb3ApiRoutes.Models;
using Labb3ApiRoutes.Models.DTO;
using Labb3ApiRoutes.Models.DTO.PersonEverythingDTO;
using Labb3ApiRoutes.Repository.IRepository;

using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Person = Labb3ApiRoutes.Models.Person;

namespace Labb3ApiRoutes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonApiController : ControllerBase
    {
        private readonly Labb3ApiRouteDbContext _context;
        private readonly IRepository<Link> _linkDb;
        private readonly IRepository<Person>? _personDb;
        private readonly IMapper? _mapper;
        private readonly ApiResponse _apiResponse;

        public PersonApiController(IRepository<Person> context, IMapper mapper, IRepository<Link> linkDb, Labb3ApiRouteDbContext labbContext)
        {
            _personDb = context;
            _mapper = mapper;
            this._apiResponse = new ApiResponse();
            _linkDb = linkDb;
            _context = labbContext;

        }

        [HttpGet("GetAllWithInterestAndLink-With_context")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetAllWithInterestAndLinks(string startswith = "", int count = 0, bool includeInterest = false)
        {
            try
            {
                IQueryable<Link> query = _context.Links.Include(pe => pe.Persons);

                if (includeInterest)
                {
                    query = query.Include(pe => pe.Interests);
                }

                var personInterestLinks = await query
                    .Select(pe => new PersonEverythingDTO
                    {
                        FK_PersonId = pe.Persons.PersonId,
                        PersonName = pe.Persons.FullName,
                        FK_InterestId = pe.FK_InterestId,
                        InterestTitle = includeInterest ? pe.Interests.InterestTitle : null,
                        InterestDescription = includeInterest ? pe.Interests.InterestDescription : null,
                        FK_LinkId = pe.LinkId,
                        LinkTitle = pe.LinkTitle,
                        URL = pe.URL,
                    })
                    .ToListAsync();

                if (!string.IsNullOrWhiteSpace(startswith))
                {
                    personInterestLinks = personInterestLinks
                        .Where(p => p.PersonName.StartsWith(startswith, StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }

                if (count > 0)
                {
                    personInterestLinks = personInterestLinks.Take(count).ToList();
                }

                if (personInterestLinks.Count == 0)
                {
                    _apiResponse.IsSuccess = false;
                    _apiResponse.ErrorMessages = new List<string> { $"No person found starting with '{startswith}'" };
                }
                else
                {
                    _apiResponse.Result = personInterestLinks;
                    _apiResponse.StatusCode = HttpStatusCode.OK;
                }
            }
            catch (Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages = new List<string> { ex.Message };
            }

            return _apiResponse;
        }






        [HttpGet("GetPersonsFilteredOrNot")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetFilteredPersons(string startsWith = "", int count = 0)
        {
            try
            {
                IEnumerable<Person> personList = await _personDb.GetAllAsync();

                if (!string.IsNullOrEmpty(startsWith))
                {
                    personList = personList.Where(p => p.FirstName.StartsWith(startsWith, StringComparison.OrdinalIgnoreCase));
                }
                var filteredPersonList = _mapper.Map<List<PersonDTO>>(personList);
                if (filteredPersonList.Count == 0)
                {
                    _apiResponse.IsSuccess = false;
                    _apiResponse.ErrorMessages =
                        new List<string>() { $"No person found starting with '{startsWith}'." };
                }

                if (count > 0)
                {
                    personList = personList.Take(count);
                }

                _apiResponse.Result = _mapper.Map<List<PersonDTO>>(personList);
                _apiResponse.StatusCode = HttpStatusCode.OK;
                return _apiResponse;
            }
            catch (Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages =
                    new List<string>() { ex.Message };
            }

            // If startsWith is null or empty and count is not specified, return all persons
            if (count == 0)
            {
                _apiResponse.Result = _mapper.Map<List<PersonDTO>>(await _personDb.GetAllAsync());
            }
            else
            {
                _apiResponse.Result = new List<PersonDTO>();
            }

            _apiResponse.StatusCode = HttpStatusCode.OK;
            return _apiResponse;
        }

        // Get person by id
        [HttpGet("{id:int}", Name = "GetPerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> GetPerson(int id)
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
                var person = await _personDb.GetAsync(p => p.PersonId == id);
                if (person == null)
                {
                    _apiResponse.IsSuccess = false;
                    _apiResponse.ErrorMessages = new List<string>() { $"There is no person with ID {id}" };
                    _apiResponse.StatusCode = HttpStatusCode.NotFound;
                    return BadRequest(_apiResponse);
                }
                _apiResponse.Result = _mapper.Map<PersonDTO>(person);
                _apiResponse.StatusCode = HttpStatusCode.OK;
                _apiResponse.Messages = new List<string> { "Hi, you found me!" };
                _apiResponse.ErrorMessages = new List<string> { "Nice, no error!" };
                return _apiResponse;
            }
            catch (Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _apiResponse;
        }

        //Create new person
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> CreatePerson(PersonCreateDTO createDTO)
        {
            try
            {
                if (createDTO == null)
                {
                    _apiResponse.IsSuccess = false;
                    _apiResponse.ErrorMessages = new List<string>() { "No person created" };
                    return BadRequest(createDTO);
                }
                Person person = _mapper.Map<Person>(createDTO);
                await _personDb.CreateAsync(person);
                _apiResponse.Result = _mapper.Map<Person>(person);
                _apiResponse.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetPerson", new { id = person.PersonId }, _apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _apiResponse;
        }

        [HttpPut("UpdatePerson", Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> UpdatePerson(int id, [FromBody] PersonUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || id != updateDTO.PersonId)
                {
                    _apiResponse.IsSuccess = false;
                    return BadRequest();
                }
                Person model = _mapper.Map<Person>(updateDTO);

                await _personDb.UpdateAsync(model);
                _apiResponse.StatusCode = HttpStatusCode.OK;
                _apiResponse.IsSuccess = true;
                _apiResponse.Messages = new List<string> { $"Person with ID: {id} was successfully updated" };
                return _apiResponse;
            }
            catch (Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _apiResponse;
        }

        [HttpPatch("UpdatePartialPerson{id:int}", Name = "UpdatePartialPerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> UpdatePartialPerson(int id, JsonPatchDocument<PersonUpdateDTO> patchDTO)
        {
            var apiResponse = new ApiResponse { IsSuccess = true };

            try
            {
                if (patchDTO == null || id == 0)
                {
                    _apiResponse.IsSuccess = false;
                    return BadRequest(_apiResponse);
                }
                var person = await _personDb.GetAsync(p => p.PersonId == id, tracked: false);
                
                if (person == null)
                {
                    return BadRequest($"Person not found with ID {id}");
                }
                PersonUpdateDTO personDTO = _mapper.Map<PersonUpdateDTO>(person);
                patchDTO.ApplyTo(personDTO, ModelState);

                if (!ModelState.IsValid)
                {
                    apiResponse.IsSuccess = false;
                    apiResponse.ErrorMessages = ModelState.Values
                        .SelectMany(x => x.Errors)
                        .Select(x => x.ErrorMessage)
                        .ToList();
                    return BadRequest(apiResponse);
                }
                Person model = _mapper.Map<Person>(personDTO);
                await _personDb.UpdateAsync(model);

                _apiResponse.StatusCode = HttpStatusCode.OK;
                _apiResponse.IsSuccess = true;
                _apiResponse.Messages = new List<string> { $"Person with ID {id} was successfully partial updataed." };
                _apiResponse.ErrorMessages = new List<string> { "Nice! No Error! :-)"};
                return _apiResponse;
            }
            catch (Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages = new List<string> { ex.ToString() };
                return _apiResponse;
            }
        }

        [HttpDelete("DeletePersonBy{id:int}", Name = "DeletePerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse>> DeletePerson(int id)
        {
            try
            {
                if (id == 0)
                {
                    _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                    _apiResponse.IsSuccess = false;
                    _apiResponse.ErrorMessages = new List<string> { $"No person have ID: {id}" };
                    return BadRequest(_apiResponse);
                }
                var person = await _personDb.GetAsync(p => p.PersonId == id);
                if (person == null)
                {
                    return NotFound();
                }
                await _personDb.RemoveAsync(person);
                _apiResponse.StatusCode = HttpStatusCode.NoContent;
                _apiResponse.IsSuccess = true;
                _apiResponse.Messages = new List<string> { $"Person with ID: {id} was successfully deleted" };
                return _apiResponse;
            }
            catch (Exception ex)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _apiResponse;
        }
    }
}