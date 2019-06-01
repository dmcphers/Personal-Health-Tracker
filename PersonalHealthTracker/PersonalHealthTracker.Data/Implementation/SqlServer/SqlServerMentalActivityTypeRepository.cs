using PersonalHealthTracker.Data.Context;
using PersonalHealthTracker.Data.Interfaces;
using PersonalHealthTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PersonalHealthTracker.Data.Implementation.SqlServer
{
    public class SqlServerMentalActivityTypeRepository : IMentalActivityTypeRepository
    {
        public ICollection<Mental_Activity_Type> GetAll()
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                return context.Mental_Activity_Types.ToList();
            }
        }

        public Mental_Activity_Type GetById(int id)
        {
            using (var context = new PersonalHealthTrackerDbContext())
            {
                var MentalActivityType = context.Mental_Activity_Types.SingleOrDefault(pat => pat.Id == id);
                return MentalActivityType;
            }
        }
    }
}
