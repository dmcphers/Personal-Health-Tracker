using PersonalHealthTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthTracker.Data.Interfaces
{
    public interface IMentalActivityRepository
    {
        // create
        Mental_Activity Create(Mental_Activity newMental_Activity);

        // read
        Mental_Activity GetById(int id);
        ICollection<Mental_Activity> GetAllMentalActivities();

        // update
        Mental_Activity Update(Mental_Activity updatedMental_Activity);

        // delete
        bool Delete(int id);

        // get by day
        List<Mental_Activity> GetByDate(DateTime activityDate);

        // get by date range
        List<Mental_Activity> GetByDateRange(DateTime fromDate, DateTime toDate);
    }
}
