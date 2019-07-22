using PersonalHealthTracker.Data.Context;
using PersonalHealthTracker.Data.Interfaces;
using PersonalHealthTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PersonalHealthTracker.Data.Implementation.SqlServer
{
    public class SqlServerMental_ActivityRepository : IMentalActivityRepository
    {

        public Mental_Activity GetById(int id)
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                // SQL --> Database look for table Mental_Activity
                // if not found then returns null value rather than exception
                var Mental_Activity = context.Mental_Activities.SingleOrDefault(p => p.Id == id);
                return Mental_Activity;
            }
        }

        public ICollection<Mental_Activity> GetAllMentalActivities()
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                // Dbset != ICollection
                return context.Mental_Activities.ToList();  // now it is a collection
            }
        }

        public Mental_Activity Create(Mental_Activity newMental_Activity)
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                context.Mental_Activities.Add(newMental_Activity);
                context.SaveChanges();

                return newMental_Activity; // newMental_Activity.Id will be populated with new DB value
            }
        }

        public Mental_Activity Update(Mental_Activity updatedMental_Activity)
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                // find the old entity
                var OldMentalActivity = GetById(updatedMental_Activity.Id);

                // update each entity properties / get;set;
                context.Entry(OldMentalActivity).CurrentValues.SetValues(updatedMental_Activity);

                // save changes
                context.Mental_Activities.Update(OldMentalActivity);
                context.SaveChanges();

                return OldMentalActivity; // to ensure that the save happened
            }
        }

        public bool Delete(int id)
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                // Find what we are going to delete
                var MentalActivityToBeDeleted = GetById(id);

                // delete
                context.Mental_Activities.Remove(MentalActivityToBeDeleted);

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

        public List<Mental_Activity> GetByDate(DateTime activityDate)
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                return context.Mental_Activities.Where(p => p.Date == activityDate).ToList();
            }
        }

        public List<Mental_Activity> GetByDateRange(DateTime fromDate, DateTime toDate)
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                return context.Mental_Activities.Where(p => p.Date >= fromDate && p.Date <= toDate).ToList();
            }
        }


    }
}
