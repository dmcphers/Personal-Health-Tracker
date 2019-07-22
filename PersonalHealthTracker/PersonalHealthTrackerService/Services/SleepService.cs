using PersonalHealthTracker.Data.Interfaces;
using PersonalHealthTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthTrackerService.Services
{
    public interface ISleepService
    {
        // CRUD

        // create
        Sleep Create(Sleep newNutritionRec);
        ICollection<Sleep> GetAllSleepRecs();

        // read
        Sleep GetById(int id);

        // update
        Sleep Update(Sleep updatedSleepRec);

        // delete
        bool Delete(int id);

        // get by day
        List<Sleep> GetByDate(DateTime sleepDate);

        // get by date range
        List<Sleep> GetByDateRange(DateTime fromDate, DateTime toDate);
    }

    public class SleepService : ISleepService
    {
        private readonly ISleepRepository _sleepRepository; // -> null

        // added a dependency to the constructor
        public SleepService(ISleepRepository sleepRepository)
        {
            _sleepRepository = sleepRepository; // -> not be null anymore
        }

        public ICollection<Sleep> GetAllSleepRecs()
        {
            return _sleepRepository.GetAllSleepRecs();
        }

        public Sleep Create(Sleep newSleepRec)
        {
            return _sleepRepository.Create(newSleepRec); // create() is from repository
        }

        public bool Delete(int id)
        {
            return _sleepRepository.Delete(id);
        }

        public Sleep GetById(int id)
        {
            return _sleepRepository.GetById(id);
        }

        public Sleep Update(Sleep updatedSleepRec)
        {
            return _sleepRepository.Update(updatedSleepRec);
        }

        public List<Sleep> GetByDate(DateTime sleepDate)
        {
            return _sleepRepository.GetByDate(sleepDate);
        }

        public List<Sleep> GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            return _sleepRepository.GetByDateRange(fromDate, toDate);
        }
    }
}
