using QuanLySieuThi.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi.DAO
{
    public class EventDAO
    {
        private QuanLySieuThiContext context;

        public EventDAO()
        {
            context = new QuanLySieuThiContext(); // Replace with your actual DbContext instance
        }

        public int Save(Event eventModel, List<EventDetail> eventDetails)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Events.Add(eventModel);
                    context.SaveChanges();
                    context.Entry(eventModel).State = EntityState.Detached;
                    foreach (var detail in eventDetails)
                    {
                        detail.EventID = eventModel.ID;
                        detail.ProductID = detail.Product.ID;
                        detail.Product = null;
                        context.EventDetails.Add(detail);
                    }

                    int res = context.SaveChanges();
                    transaction.Commit();
                    return res;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                    transaction.Rollback();
                    return 0;
                }
            }
        }

        public int Update(Event eventModel)
        {
            try
            {


                var existingEvent = context.Events.Find(eventModel.ID);

                if (existingEvent == null)
                {
                    throw new Exception($"Event with ID {eventModel.ID} not found.");
                }

                existingEvent.StartDate = eventModel.StartDate;
                existingEvent.EndDate = eventModel.EndDate;
                existingEvent.Description = eventModel.Description;

                return context.SaveChanges();
            }
            catch
            {
                return 0;
            }
        }

        public Event GetById(int id)
        {
            return context.Events
                     .FirstOrDefault(e => e.ID == id);
        }

        public List<Event> GetCurrentEvents()
        {
            DateTime currentDate = DateTime.Now.Date;
            return context.Events
                     .Where(e => e.StartDate <= currentDate && (!e.EndDate.HasValue || e.EndDate >= currentDate))
                     .ToList();
        }

        public List<Event> GetEventsFromNow()
        {
            DateTime currentDate = DateTime.Now.Date;
            return context.Events
                     .Where(e => e.EndDate >= currentDate)
                     .ToList();
        }
    }

}
