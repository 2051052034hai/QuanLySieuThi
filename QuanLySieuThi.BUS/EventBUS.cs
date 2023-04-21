using QuanLySieuThi.DAO;
using QuanLySieuThi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySieuThi.BUS
{
    public class EventBUS
    {
        private EventDAO eventDAO;

        public EventBUS()
        {
            eventDAO = new EventDAO();
        }

        public int AddEvent(Event eventModel, List<EventDetail> eventDetails)
        {
            return eventDAO.Save(eventModel, eventDetails);
        }

        public int UpdateEvent(Event eventModel)
        {
            return eventDAO.Update(eventModel);
        }

        public Event GetEventById(int id)
        {
            return eventDAO.GetById(id);
        }

        public List<Event> GetCurrentEvents()
        {
            return eventDAO.GetCurrentEvents();
        }

        public List<Event> GetEventsFromNow()
        {
            return eventDAO.GetEventsFromNow();
        }
    }
}
