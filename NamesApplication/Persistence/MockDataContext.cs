using NamesApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NamesApplication.Persistence
{
    public class MockDataContext
    {
        private List<Name> _names;
        public MockDataContext()
        {
            _names.AddRange( new List<Name> { 
                new Name { Id = new Guid(), FirstName = "AAA", LastName = "BBB"},
                new Name { Id = new Guid(), FirstName = "CCC", LastName = "DDD"},
                new Name { Id = new Guid(), FirstName = "EEE", LastName = "FFF"}
            });
        }


    }
}
