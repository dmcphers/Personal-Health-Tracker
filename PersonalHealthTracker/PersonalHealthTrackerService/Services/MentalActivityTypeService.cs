using PersonalHealthTracker.Data.Interfaces;
using PersonalHealthTracker.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalHealthTrackerService.Services
{
    public interface IMentalActivityTypeService
    {
        // Read
        Mental_Activity_Type GetById(int id);
        ICollection<Mental_Activity_Type> GetAll();
    }

    public class MentalActivityTypeService : IMentalActivityTypeService
    {
        private readonly IMentalActivityTypeRepository _mentalActivityTypeRepository;

        public MentalActivityTypeService(IMentalActivityTypeRepository mentalActivityTypeRepository)
        {
            _mentalActivityTypeRepository = mentalActivityTypeRepository;
        }
        public ICollection<Mental_Activity_Type> GetAll()
        {
            return _mentalActivityTypeRepository.GetAll();
        }

        public Mental_Activity_Type GetById(int id)
        {
            return _mentalActivityTypeRepository.GetById(id);
        }
    }
}
