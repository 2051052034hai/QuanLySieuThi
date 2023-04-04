using QuanLySieuThi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi.DAO
{
    public class EventDAO
    {
        private readonly QuanLySieuThiContext context;

        public EventDAO()
        {
            context = new QuanLySieuThiContext(); // Replace with your actual DbContext instance
        }

        public void Save(Event eventModel, List<EventDetail> eventDetails)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Events.Add(eventModel);
                    context.SaveChanges();

                    foreach (var detail in eventDetails)
                    {
                        detail.EventID = eventModel.EventID;
                        context.EventDetails.Add(detail);
                    }

                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void Update(Event eventModel)
        {
            var existingEvent = context.Events.Find(eventModel.EventID);

            if (existingEvent == null)
            {
                throw new Exception($"Event with ID {eventModel.EventID} not found.");
            }

            existingEvent.StartDate = eventModel.StartDate;
            existingEvent.EndDate = eventModel.EndDate;
            existingEvent.Description = eventModel.Description;

            context.SaveChanges();
        }

        public Event GetById(int id)
        {
            return context.Events
                     .FirstOrDefault(e => e.EventID == id);
        }

        public List<Event> GetCurrentEvents()
        {
            DateTime currentDate = DateTime.Now.Date;
            return context.Events
                     .Where(e => e.StartDate <= currentDate && (!e.EndDate.HasValue || e.EndDate >= currentDate))
                     .ToList();
        }
    }

}
