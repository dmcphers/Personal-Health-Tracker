using PersonalHealthTracker.Data.Interfaces;
using PersonalHealthTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthTrackerService.Services
{
    public interface IMentalActivityService
    {
        // CRUD

        // create
        Mental_Activity Create(Mental_Activity newMental_Activity);
        ICollection<Mental_Activity> GetAllMentalActivities();

        // read
        Mental_Activity GetById(int id);

        // update
        Mental_Activity Update(Mental_Activity updatedMental_Activity);

        // delete
        bool Delete(int id);
    }

    public class MentalActivityService : IMentalActivityService
    {
        private readonly IMentalActivityRepository _MentalActivityRepository; // -> null

        // added a dependency to the constructor
        public MentalActivityService(IMentalActivityRepository MentalActivityRepository)
        {
            _MentalActivityRepository = MentalActivityRepository; // -> not be null anymore
        }

        public ICollection<Mental_Activity> GetAllMentalActivities()
        {
            return _MentalActivityRepository.GetAllMentalActivities();
        }

        public Mental_Activity Create(Mental_Activity newMental_Activity)
        {
            return _MentalActivityRepository.Create(newMental_Activity); // create() is from repository
        }

        public bool Delete(int id)
        {
            return _MentalActivityRepository.Delete(id);
        }

        public Mental_Activity GetById(int id)
        {
            return _MentalActivityRepository.GetById(id);
        }

        public Mental_Activity Update(Mental_Activity updatedMental_Activity)
        {
            return _MentalActivityRepository.Update(updatedMental_Activity);
        }
    }
}
