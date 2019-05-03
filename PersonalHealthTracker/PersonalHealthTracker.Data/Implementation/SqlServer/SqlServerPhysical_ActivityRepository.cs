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

        public Physical_Activity Create(Physical_Activity newPhysical_Activity)
        {
            throw new NotImplementedException();
        }

        public Physical_Activity Update(Physical_Activity updatedPhysical_Activity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        

       
    }
}
