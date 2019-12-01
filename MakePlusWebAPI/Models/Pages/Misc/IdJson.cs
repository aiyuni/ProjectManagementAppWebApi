using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Models.Pages.Misc
{
    /// <summary>
    /// Class that represents an ID, in JSON format.
    /// </summary>
    public class IdJson
    {
        public int Id { get; set; }

        public IdJson(int id)
        {
            this.Id = id;
        }
    }
}
