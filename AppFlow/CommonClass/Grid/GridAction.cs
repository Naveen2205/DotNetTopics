using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppFlow.Api.MVC.Models;

namespace AppFlow.CommonClass.Grid
{
    public class GridAction
    {
        public List<Link> _link = new List<Link>();
        public IEnumerable<Link> link => _link;

        public GridAction Add(IEnumerable<Link> links)
        {
            _link.AddRange(links);
            return this;
        }
    }
}
