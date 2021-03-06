﻿using PersonalHealthTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthTracker.Data.Interfaces
{
        public interface INutritionRepository
        {
            // create
            Nutrition Create(Nutrition newNutritionRec);

            // read
            Nutrition GetById(int id);
            ICollection<Nutrition> GetAllNutritionRecs();

            // update
            Nutrition Update(Nutrition updatedNutritionRec);

            // delete
            bool Delete(int id);

            // get by day
            List<Nutrition> GetByDate(DateTime nutritionDate);

            // get by date range
            List<Nutrition> GetByDateRange(DateTime fromDate, DateTime toDate);
    }
}
