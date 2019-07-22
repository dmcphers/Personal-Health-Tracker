using PersonalHealthTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthTracker.Data.Interfaces
{
    public interface ISleepRepository
    {
        // create
        Sleep Create(Sleep newSleepRec);

        // read
        Sleep GetById(int id);
        ICollection<Sleep> GetAllSleepRecs();

        // update
        Sleep Update(Sleep updatedSleepRec);

        // delete
        bool Delete(int id);

        // get by day
        List<Sleep> GetByDate(DateTime sleepDate);

        // get by date range
        List<Sleep> GetByDateRange(DateTime fromDate, DateTime toDate);
    }
}
