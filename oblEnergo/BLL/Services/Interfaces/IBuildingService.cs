using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IBuildingService
    {
        IEnumerable<BuildingDTO> GetBuildings(StreetDTO street, int page);
        void AddBuilding(BuildingDTO building);
        IEnumerable<BuildingDTO> GetAllBuilding();
    }
}
