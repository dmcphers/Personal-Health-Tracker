using PersonalHealthTracker.Data.Interfaces;
using PersonalHealthTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthTrackerService.Services
{
    public interface IPhysicalActivityTypeService
    {
        // Read
        Physical_Activity_Type GetById(int id);
        ICollection<Physical_Activity_Type> GetAll();
    }

    public class PhysicalActivityTypeService : IPhysicalActivityTypeService
    {
        private readonly IPhysicalActivityTypeRepository _physicalActivityTypeRepository;

        public PhysicalActivityTypeService(IPhysicalActivityTypeRepository physicalActivityTypeRepository)
        {
            _physicalActivityTypeRepository = physicalActivityTypeRepository;
        }
        public ICollection<Physical_Activity_Type> GetAll()
        {
            return _physicalActivityTypeRepository.GetAll();
        }

        public Physical_Activity_Type GetById(int id)
        {
            return _physicalActivityTypeRepository.GetById(id);
        }
    }
}
