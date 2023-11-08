using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.CommonModels;
    public record RecievedDataModel(int OperationCode,
                                    string DeviceId,
                                    decimal Lat,
                                    decimal Lng,
                                    decimal Temp,
                                    decimal Speed,
                                    decimal FuelConsumption,
                                    long SendNumber,
                                    DateTime OperationDate,
                                    int ExecutiveOperationCode);


