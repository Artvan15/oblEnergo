using System;
using System.Collections.Generic;
using System.Text;
using BLL.DTO;

namespace BLL.Services.Interfaces
{
    public interface IRegionService
    {
        IEnumerable<RegionDTO> GetRegions(int page);
        void AddRegion(RegionDTO region);
        IEnumerable<RegionDTO> GetAllRegions();
    }
}
