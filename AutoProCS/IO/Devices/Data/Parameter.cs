using AutoProCS.IO.Devices.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoProCS.IO.Devices.Data;

public class Parameter(ParameterSpec specification) 
{
    public ParameterSpec Specification => specification;

    public string Name => specification.Name;

    public string Description => specification.Description;

    public string UnitFormat => specification.UnitFormat;

    public double Value => throw new NotImplementedException();
}
