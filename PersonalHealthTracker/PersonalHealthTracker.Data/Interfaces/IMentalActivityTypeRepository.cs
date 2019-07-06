using PersonalHealthTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthTracker.Data.Interfaces
{
    public interface IMentalActivityTypeRepository
    {
        // Read
        Mental_Activity_Type GetById(int id);
        ICollection<Mental_Activity_Type> GetAll();
    }
}
