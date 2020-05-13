using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook.Core.Contracts
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile);
        
    }
}
