using PersonalHealthTracker.Domain.Models;
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

        // update
        Physical_Activity Update(Physical_Activity updatedPhysical_Activity);

        // delete
        bool Delete(int id);
    }
}
