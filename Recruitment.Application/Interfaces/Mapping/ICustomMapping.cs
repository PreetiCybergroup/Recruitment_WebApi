using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Recruitment.Application.Interfaces.Mapping
{
   public interface ICustomMapping
    {
        void CreateMappings(Profile configuration);
    }
}
