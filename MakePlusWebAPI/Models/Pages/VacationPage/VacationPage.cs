using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakePlusWebAPI.Models.Pages.VacationPage
{
    [JsonObject]
    public class VacationPage : IEnumerable<VacationArr>
    {
        //vacation Page JSON
        public List<VacationArr> VacationArrList { get; set; }

        public IEnumerator<VacationArr> GetEnumerator()
        {
            return VacationArrList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return VacationArrList.GetEnumerator();
        }
    }
}
