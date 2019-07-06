using PersonalHealthTracker.Data.Context;
using PersonalHealthTracker.Data.Interfaces;
using PersonalHealthTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonalHealthTracker.Data.Implementation.SqlServer
{
    public class SqlServerNutritionTypeRepository : INutritionTypeRepository
    {
        public ICollection<Nutrition_Type> GetAll()
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                return context.Nutrition_Types.ToList();
            }
        }

        public Nutrition_Type GetById(int id)
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                var nutritionType = context.Nutrition_Types.SingleOrDefault(pat => pat.Id == id);
                return nutritionType;
            }
        }
    }
}
