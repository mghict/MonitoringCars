using Common.Attribute;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class RecievedData : Common.CommonModels.BaseEntity<Guid>
{
    [DisplayName("کد عملیات")]
    [Description("کد عملیات")]
    public int OperationCode { get; set; }

    [DisplayName("کد دستگاه")]
    [Description("کد دستگاه")]
    [NameOf("کد دستگاه")]
    public string DeviceId { get; set; }


    public decimal Longitude { get; set; }
    public decimal Latitude { get; set; }
    public decimal Speed { get; set; }
    public decimal FuelConsumption { get; set; }
    public long SendNumber { get; set; }
    public DateTime OperationDate { get; set; }

    [DisplayName("کد عملیات اجرایی")]
    public int ExecutiveOperationCode { get; set; }

    public RecievedData()
    {
        Id= Guid.NewGuid();
    }

}

