using PersonalHealthTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthTracker.Data.Interfaces
{
    public interface IPhysicalActivityTypeRepository
    {
        // Read
        Physical_Activity_Type GetById(int id);
        ICollection<Physical_Activity_Type> GetAll();
    }
}
