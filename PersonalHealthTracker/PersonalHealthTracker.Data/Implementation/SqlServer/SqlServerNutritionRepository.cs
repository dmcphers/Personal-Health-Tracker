using PersonalHealthTracker.Data.Context;
using PersonalHealthTracker.Data.Interfaces;
using PersonalHealthTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonalHealthTracker.Data.Implementation.SqlServer
{
    public class SqlServerNutritionRepository : INutritionRepository
    {

        public Nutrition GetById(int id)
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                // SQL --> Database look for table Nutrition
                // if not found then returns null value rather than exception
                var NutritionRec = context.Nutrition.SingleOrDefault(p => p.Id == id);
                return NutritionRec;
            }
        }

        public ICollection<Nutrition> GetAllNutritionRecs()
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                // Dbset != ICollection
                return context.Nutrition.ToList();  // now it is a collection
            }
        }

        public Nutrition Create(Nutrition newNutritionRec)
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                context.Nutrition.Add(newNutritionRec);
                context.SaveChanges();

                return newNutritionRec; // newNutritionRec.Id will be populated with new DB value
            }
        }

        public Nutrition Update(Nutrition updatedNutritionRec)
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                // find the old entity
                var OldNutritionRec = GetById(updatedNutritionRec.Id);

                // update each entity properties / get;set;
                context.Entry(OldNutritionRec).CurrentValues.SetValues(updatedNutritionRec);

                // save changes
                context.Nutrition.Update(OldNutritionRec);
                context.SaveChanges();

                return OldNutritionRec; // to ensure that the save happened
            }
        }

        public bool Delete(int id)
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                // Find what we are going to delete
                var NutritionRecToBeDeleted = GetById(id);

                // delete
                context.Nutrition.Remove(NutritionRecToBeDeleted);

                // save changes
                context.SaveChanges();

                // check if entity/model exists
                if (GetById(id) == null)
                {
                    return true;
                }

                return false;
            }
        }
    }
}
