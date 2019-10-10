using System;
using System.Collections.Generic;
using System.Text;

namespace Uplift.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Service> ServiceList { get; set; }

        public IEnumerable<Category> CategoryList { get; set; }
    }
}
