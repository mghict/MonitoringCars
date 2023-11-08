using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RecievedData.Commands;

    public record RecievedDataCreateCommand(
        int OperationCode,
        string DeviceId,
        decimal Lat,
        decimal Lng,
        decimal Temp,
        decimal Speed,
        decimal FuelConsumption,
        long SendNumber,
        DateTime OperationDate,
        int ExecutiveOperationCode) : IRequest<FluentResults.Result>;

    
