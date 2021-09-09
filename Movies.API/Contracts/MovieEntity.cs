using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Contracts
{
    public class MovieEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Director { get; set; }
    }
}
