using WeServe.Models;

namespace WeServe.Interfaces
{
    /// <summary>
    /// Repository for Events
    /// </summary>
    /// <author>Justin Kruskie</author>
    /// <date>08/02/2023</date>
    public interface IEventRepository
    {
        Task<ICollection<Event>> GetEventsAsync();
        Task<Event> GetEventByIdAsync(int id);
        Task<Event> CreateEventAsync(Event ev);
        Task<Event> UpdateEventAsync(Event ev);
        Task<Event> DeleteEventAsync(Event ev);
        Task<ICollection<Event>> GetEventsByOrganizationIdAsync(int id);
    }
}
