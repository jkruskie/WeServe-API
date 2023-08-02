using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeServe.Interfaces;
using WeServe.Models;

namespace WeServe.Controllers
{
    /// <summary>
    /// Controller for Organization
    /// </summary>
    /// <author>Justin Kruskie</author>
    /// <date>08/02/2023</date>
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController
    {
        // Repository
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IEventRepository _eventRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="organizationRepository">Repository for Organization</param>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        public OrganizationController(
            IOrganizationRepository organizationRepository, IEventRepository eventRepository
        )
        {
            _organizationRepository = organizationRepository;
            _eventRepository = eventRepository;
        }

        /// <summary>
        /// Get all Organizations
        /// </summary>
        /// <returns>All organizations</returns>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        [HttpGet]
        [Authorize(Roles = "student,organization,moderator,admin")]
        public async Task<ICollection<Organization>> GetOrganizationsAsync()
        {
            return await _organizationRepository.GetOrganizationsAsync();
        }

        /// <summary>
        /// Get Organization by Id
        /// </summary>
        /// <param name="id">Id of Organization</param>
        /// <returns>Organization</returns>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        [HttpGet("{id}")]
        [Authorize(Roles = "student,organization,moderator,admin")]
        public async Task<Organization> GetOrganizationByIdAsync(int id)
        {
            return await _organizationRepository.GetOrganizationByIdAsync(id);
        }

        /// <summary>
        /// Create an Organization
        /// </summary>
        /// <param name="organization">Organization to create</param>
        /// <returns>Organization</returns>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        [HttpPut]
        [Authorize(Roles = "student,organization,moderator,admin")]
        public async Task<Organization> CreateOrganizationAsync(Organization organization)
        {
            return await _organizationRepository.CreateOrganizationAsync(organization);
        }

        /// <summary>
        /// Update an Organization
        /// </summary>
        /// <param name="organization">Organization to update</param>
        /// <returns>Organization</returns>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        [HttpPost]
        [Authorize(Roles = "student,organization,moderator,admin")]
        public async Task<Organization> UpdateOrganizationAsync(Organization organization)
        {
            return await _organizationRepository.UpdateOrganizationAsync(organization);
        }

        /// <summary>
        /// Delete an Organization
        /// </summary>
        /// <param name="organization">Organization to delete</param>
        /// <returns>Organization</returns>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        [HttpDelete]
        [Authorize(Roles = "moderator,admin")]
        public async Task<Organization> DeleteOrganizationAsync(Organization organization)
        {
            return await _organizationRepository.DeleteOrganizationAsync(organization);
        }

        /// <summary>
        /// Get all Events for an Organization
        /// </summary>
        /// <param name="id">Id of Organization</param>
        /// <returns>All Events for an Organization</returns>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        [HttpGet("{id}/events")]
        [Authorize(Roles = "student,organization,moderator,admin")]
        public async Task<ICollection<Event>> GetEventsByOrganizationIdAsync(int id)
        {
            return await _eventRepository.GetEventsByOrganizationIdAsync(id);
        }
    }
}
