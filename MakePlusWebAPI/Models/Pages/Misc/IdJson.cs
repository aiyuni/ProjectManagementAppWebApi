using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Models.Pages.Misc
{
    public class IdJson
    {
        public int Id { get; set; }

        public IdJson(int id)
        {
            this.Id = id;
        }
    }
}
