using AutoMapper;
using Phonebook.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Core.Services
{
    public class MapFrom : IMapFrom<MapFrom>
    {
        public void Mapping(Profile profile) => profile.CreateMap(typeof(MapFrom), GetType());
    }
}
