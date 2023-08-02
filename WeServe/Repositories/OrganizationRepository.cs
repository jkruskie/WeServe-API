using Microsoft.EntityFrameworkCore;
using WeServe.Data;
using WeServe.Interfaces;
using WeServe.Models;

namespace WeServe.Repositories
{
    /// <summary>
    /// Repository for Organization
    /// </summary>
    /// <author>Justin Kruskie</author>
    /// <date>08/02/2023</date>
    public class OrganizationRepository : IOrganizationRepository
    {
        // Repository
        private readonly WeServeContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context for WeServe</param>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        public OrganizationRepository(WeServeContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all Organizations
        /// </summary>
        /// <returns>All organizations</returns>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        public async Task<ICollection<Organization>> GetOrganizationsAsync()
        {
            // Get all Organizations
            return await _context.Organizations.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Get an Organization by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Organization</returns>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        public async Task<Organization> GetOrganizationByIdAsync(int id)
        {
            // Get Organization by id
            return await _context.Organizations.AsNoTracking().FirstAsync(o => o.Id == id);
        }

        /// <summary>
        /// Create an Organization
        /// </summary>
        /// <param name="organization"></param>
        /// <returns>Organization</returns>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        public async Task<Organization> CreateOrganizationAsync(Organization organization)
        {
            // Create Organization
            _context.Organizations.Add(organization);
            // Save changes
            await _context.SaveChangesAsync();
            // Return Organization
            return organization;
        }

        /// <summary>
        /// Update an Organization
        /// </summary>
        /// <param name="organization"></param>
        /// <returns>Organization</returns>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        public async Task<Organization> UpdateOrganizationAsync(Organization organization)
        {
            // Update Organization
            _context.Organizations.Update(organization);
            // Save changes
            await _context.SaveChangesAsync();
            // Return Organization
            return organization;
        }

        /// <summary>
        /// Delete an Organization
        /// </summary>
        /// <param name="organization"></param>
        /// <returns>Organization</returns>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        public async Task<Organization> DeleteOrganizationAsync(Organization organization)
        {
            // Delete Organization
            organization.IsDeleted = true;
            organization.DeletedAt = DateTime.Now;
            // Update Organization
            _context.Organizations.Update(organization);
            // Save changes
            await _context.SaveChangesAsync();
            // Return Organization
            return organization;
        }
    }
}
