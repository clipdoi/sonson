using DemoTest.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoTest.ViewModels
{
    public class OrdersViewModel
    {
        public Orders orders { get; set; }
        public SelectList customers { get; set; }
        
    }
}
