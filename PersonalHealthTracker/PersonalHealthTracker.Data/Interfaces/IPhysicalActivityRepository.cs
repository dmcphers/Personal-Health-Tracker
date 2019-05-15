using PersonalHealthTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthTracker.Data.Interfaces
{
    public interface IPhysicalActivityRepository
    {
        // create
        Physical_Activity Create(Physical_Activity newPhysical_Activity);

        // read
        Physical_Activity GetById(int id);
        ICollection<Physical_Activity> GetAllPhysicalActivities();

        // update
        Physical_Activity Update(Physical_Activity updatedPhysical_Activity);

        // delete
        bool Delete(int id);
    }
}
