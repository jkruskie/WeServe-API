using Microsoft.EntityFrameworkCore;
using WeServe.Data;
using WeServe.Interfaces;
using WeServe.Models;

namespace WeServe.Repositories
{
    /// <summary>
    /// Repository for Events
    /// </summary>
    /// <author>Justin Kruskie</author>
    /// <date>08/02/2023</date>
    public class EventRepository : IEventRepository
    {
        // Repository
        private readonly WeServeContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">Context for WeServe</param>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        public EventRepository(WeServeContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all Events
        /// </summary>
        /// <returns>All events</returns>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        public async Task<ICollection<Event>> GetEventsAsync()
        {
            // Get all Events
            return await _context.Events.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Get an Event by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Event</returns>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        public async Task<Event> GetEventByIdAsync(int id)
        {
            // Get Event by id
            return await _context.Events.AsNoTracking().FirstAsync(o => o.Id == id);
        }

        /// <summary>
        /// Create an Event
        /// </summary>
        /// <param name="event"></param>
        /// <returns>Event</returns>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        public async Task<Event> CreateEventAsync(Event ev)
        {
            // Create Event
            _context.Events.Add(ev);
            // Save changes
            await _context.SaveChangesAsync();
            // Return Event
            return ev;
        }

        /// <summary>
        /// Update an Event
        /// </summary>
        /// <param name="event"></param>
        /// <returns>Event</returns>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        public async Task<Event> UpdateEventAsync(Event ev)
        {
            // Update Event
            _context.Events.Update(ev);
            // Save changes
            await _context.SaveChangesAsync();
            // Return Event
            return ev;
        }

        /// <summary>
        /// Delete an Event
        /// </summary>
        /// <param name="event"></param>
        /// <returns>Events</returns>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        public async Task<Event> DeleteEventAsync(Event ev)
        {
            // Delete Event
            ev.IsDeleted = true;
            ev.DeletedAt = DateTime.Now;
            // Update Event
            _context.Events.Update(ev);
            // Save changes
            await _context.SaveChangesAsync();
            // Return Organization
            return ev;
        }

        /// <summary>
        /// Get all Events by Organization id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Events</returns>
        /// <author>Justin Kruskie</author>
        /// <date>08/02/2023</date>
        public async Task<ICollection<Event>> GetEventsByOrganizationIdAsync(int id)
        {
            // Get Events by Organization id
            return await _context.Events.AsNoTracking().Where(o => o.OrganizationId == id).ToListAsync();
        }
    }
}
