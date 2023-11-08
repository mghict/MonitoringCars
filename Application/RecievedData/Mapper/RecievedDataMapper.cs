using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RecievedData.Mapper;


public class RecievedDataMapper:AutoMapper.Profile
{
    public RecievedDataMapper() { 
        CreateMap<Common.CommonModels.RecievedDataModel, Domain.Entities.RecievedData>();
        CreateMap<Commands.RecievedDataCreateCommand, Domain.Entities.RecievedData>()
            .ForMember(s=>s.Latitude,d=>d.MapFrom(p=>p.Lat))
            .ForMember(s => s.Longitude, d => d.MapFrom(p => p.Lng));
    }
}
