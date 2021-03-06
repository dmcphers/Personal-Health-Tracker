﻿using PersonalHealthTracker.Data.Context;
using PersonalHealthTracker.Data.Interfaces;
using PersonalHealthTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
                var mentalActivityType = context.Mental_Activity_Types.SingleOrDefault(pat => pat.Id == id);
                return mentalActivityType;
            }
        }
    }
}
