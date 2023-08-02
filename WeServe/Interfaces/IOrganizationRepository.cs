using WeServe.Models;

namespace WeServe.Interfaces
{
    /// <summary>
    /// Repository for Organization
    /// </summary>
    /// <author>Justin Kruskie</author>
    /// <date>08/02/2023</date>
    public interface IOrganizationRepository
    {
        Task<ICollection<Organization>> GetOrganizationsAsync();
        Task<Organization> GetOrganizationByIdAsync(int id);
        Task<Organization> CreateOrganizationAsync(Organization organization);
        Task<Organization> UpdateOrganizationAsync(Organization organization);
        Task<Organization> DeleteOrganizationAsync(Organization organization);
    }
}
