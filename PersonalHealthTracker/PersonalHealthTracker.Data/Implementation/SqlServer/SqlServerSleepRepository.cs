using PersonalHealthTracker.Data.Context;
using PersonalHealthTracker.Data.Interfaces;
using PersonalHealthTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonalHealthTracker.Data.Implementation.SqlServer
{
    public class SqlServerSleepRepository : ISleepRepository
    {
        public Sleep GetById(int id)
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                // SQL --> Database look for table Sleep
                // if not found then returns null value rather than exception
                var SleepRec = context.Sleep.SingleOrDefault(p => p.Id == id);
                return SleepRec;
            }
        }

        public ICollection<Sleep> GetAllSleepRecs()
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                // Dbset != ICollection
                return context.Sleep.ToList();  // now it is a collection
            }
        }

        public Sleep Create(Sleep newSleepRec)
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                context.Sleep.Add(newSleepRec);
                context.SaveChanges();

                return newSleepRec; // newSleepRec.Id will be populated with new DB value
            }
        }

        public Sleep Update(Sleep updatedSleepRec)
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                // find the old entity
                var OldSleepRec = GetById(updatedSleepRec.Id);

                // update each entity properties / get;set;
                context.Entry(OldSleepRec).CurrentValues.SetValues(updatedSleepRec);

                // save changes
                context.Sleep.Update(OldSleepRec);
                context.SaveChanges();

                return OldSleepRec; // to ensure that the save happened
            }
        }

        public bool Delete(int id)
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                // Find what we are going to delete
                var SleepRecToBeDeleted = GetById(id);

                // delete
                context.Sleep.Remove(SleepRecToBeDeleted);

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
