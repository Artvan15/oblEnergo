using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IAppartmentService
    {
        IEnumerable<AppartmentDTO> GetAppartments(BuildingDTO building, int page);
        void AddAppartment(AppartmentDTO appartment);
        IEnumerable<AppartmentDTO> GetAllAppartments();
        AppartmentDTO GetAppartment(int Id);
    }
}
