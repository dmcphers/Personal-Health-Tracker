using PersonalHealthTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthTracker.Data.Interfaces
{
    public interface INutritionTypeRepository
    {
        // Read
        Nutrition_Type GetById(int id);
        ICollection<Nutrition_Type> GetAll();
    }
}
