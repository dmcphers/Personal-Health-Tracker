using PersonalHealthTracker.Data.Interfaces;
using PersonalHealthTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthTrackerService.Services
{
    public interface IPhysicalActivityService
    {
        // CRUD

        // create
        Physical_Activity Create(Physical_Activity newPhysical_Activity);
        ICollection<Physical_Activity> GetAllPhysicalActivities();

        // read
        Physical_Activity GetById(int id);

        // update
        Physical_Activity Update(Physical_Activity updatedPhysical_Activity);

        // delete
        bool Delete(int id);

        // get by date
        List<Physical_Activity> GetByDate(DateTime activityDate);

        // get by date range
        List<Physical_Activity> GetByDateRange(DateTime fromDate, DateTime toDate);
    }

    public class PhysicalActivityService : IPhysicalActivityService
    {
        private readonly IPhysicalActivityRepository _physicalActivityRepository; // -> null

        // added a dependency to the constructor
        public PhysicalActivityService(IPhysicalActivityRepository physicalActivityRepository)
        {
            _physicalActivityRepository = physicalActivityRepository; // -> not be null anymore
        }

        public ICollection<Physical_Activity> GetAllPhysicalActivities()
        {
            return _physicalActivityRepository.GetAllPhysicalActivities();
        }

        public Physical_Activity Create(Physical_Activity newPhysical_Activity)
        {
            return _physicalActivityRepository.Create(newPhysical_Activity); // create() is from repository
        }

        public bool Delete(int id)
        {
            return _physicalActivityRepository.Delete(id);
        }

        public Physical_Activity GetById(int id)
        {
            return _physicalActivityRepository.GetById(id);
        }

        public Physical_Activity Update(Physical_Activity updatedPhysical_Activity)
        {
            return _physicalActivityRepository.Update(updatedPhysical_Activity);
        }

        public List<Physical_Activity> GetByDate(DateTime activityDate)
        {
            return _physicalActivityRepository.GetByDate(activityDate);
        }

        public List<Physical_Activity> GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            return _physicalActivityRepository.GetByDateRange(fromDate, toDate);
        }
    }
}
