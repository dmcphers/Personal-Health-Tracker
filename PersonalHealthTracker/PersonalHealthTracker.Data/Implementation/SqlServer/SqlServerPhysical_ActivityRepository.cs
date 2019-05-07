using PersonalHealthTracker.Data.Context;
using PersonalHealthTracker.Data.Interfaces;
using PersonalHealthTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace PersonalHealthTracker.Data.Implementation.SqlServer
{ 
    public class SqlServerPhysical_ActivityRepository : IPhysicalActivityRepository
    {

        public Physical_Activity GetById(int id)
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                // SQL --> Database look for table Physical_Activity
                var Physical_Activity = context.Physical_Activities.Single(p => p.Id == id);
                return Physical_Activity;  
            }
        }

        public ICollection<Physical_Activity> GetAllPhysicalActivities()
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                // Dbset != ICollection
                return context.Physical_Activities.ToList();  // now it is a collection
            }
        }

        public Physical_Activity Create(Physical_Activity newPhysical_Activity)
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                context.Physical_Activities.Add(newPhysical_Activity);
                context.SaveChanges();

                return newPhysical_Activity; // newPhysical_Activity.Id will be populated with new DB value
            }
        }

        public Physical_Activity Update(Physical_Activity updatedPhysical_Activity)
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                // find the old entity
                var OldPhysicalActivity = GetById(updatedPhysical_Activity.Id);

                // update each entity properties / get;set;
                context.Entry(OldPhysicalActivity).CurrentValues.SetValues(updatedPhysical_Activity);

                // save changes
                context.SaveChanges();

                return OldPhysicalActivity; // to ensure that the save happened
            }
        }

        public bool Delete(int id)
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                // Find what we are going to delete
                var PhysicalActivityToBeDeleted = GetById(id);

                // delete
                context.Physical_Activities.Remove(PhysicalActivityToBeDeleted);

                // save changes
                context.SaveChanges();

                // check if entity/model exists
                if(GetById(id) == null)
                {
                    return true;
                }

                return false;
            }
        }

       
    }
}
