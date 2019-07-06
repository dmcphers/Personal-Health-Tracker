using PersonalHealthTracker.Data.Interfaces;
using PersonalHealthTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthTrackerService.Services
{
    public interface INutritionTypeService
    {
        // Read
        Nutrition_Type GetById(int id);
        ICollection<Nutrition_Type> GetAll();
    }

    public class NutritionTypeService : INutritionTypeService
    {
        private readonly INutritionTypeRepository _nutritionTypeRepository;

        public NutritionTypeService(INutritionTypeRepository nutritionTypeRepository)
        {
            _nutritionTypeRepository = nutritionTypeRepository;
        }
        public ICollection<Nutrition_Type> GetAll()
        {
            return _nutritionTypeRepository.GetAll();
        }

        public Nutrition_Type GetById(int id)
        {
            return _nutritionTypeRepository.GetById(id);
        }
    }
}
