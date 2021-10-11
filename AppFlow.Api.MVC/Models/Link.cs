using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft;
using Newtonsoft.Json;

namespace AppFlow.Api.MVC.Models
{
    public class Link
    {
        public string Relation { get; private set; }
        public string Url { get; private set; }
        public Link(string relation, string href)
        {
            Relation = relation;
            Url = href;
        }
    }
}
