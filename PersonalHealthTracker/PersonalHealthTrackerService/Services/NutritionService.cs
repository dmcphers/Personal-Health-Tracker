using PersonalHealthTracker.Data.Interfaces;
using PersonalHealthTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthTrackerService.Services
{
    public interface INutritionService
    {
        // CRUD

        // create
        Nutrition Create(Nutrition newNutritionRec);
        ICollection<Nutrition> GetAllNutritionRecs();

        // read
        Nutrition GetById(int id);

        // update
        Nutrition Update(Nutrition updatedNutritionRec);

        // delete
        bool Delete(int id);

        // get by day
        List<Nutrition> GetByDate(DateTime nutritionDate);

        // get by date range
        List<Nutrition> GetByDateRange(DateTime fromDate, DateTime toDate);
    }

    public class NutritionService : INutritionService
    {
        private readonly INutritionRepository _nutritionRepository; // -> null

        // added a dependency to the constructor
        public NutritionService(INutritionRepository nutritionRepository)
        {
            _nutritionRepository = nutritionRepository; // -> not be null anymore
        }

        public ICollection<Nutrition> GetAllNutritionRecs()
        {
            return _nutritionRepository.GetAllNutritionRecs();
        }

        public Nutrition Create(Nutrition newNutritionRec)
        {
            return _nutritionRepository.Create(newNutritionRec); // create() is from repository
        }

        public bool Delete(int id)
        {
            return _nutritionRepository.Delete(id);
        }

        public Nutrition GetById(int id)
        {
            return _nutritionRepository.GetById(id);
        }

        public Nutrition Update(Nutrition updatedNutritionRec)
        {
            return _nutritionRepository.Update(updatedNutritionRec);
        }

        public List<Nutrition> GetByDate(DateTime nutritionDate)
        {
            return _nutritionRepository.GetByDate(nutritionDate);
        }

        public List<Nutrition> GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            return _nutritionRepository.GetByDateRange(fromDate, toDate);
        }
    }
}
