using assignment2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment2.ViewModels
{
    public class EventsViewModel
    {
        public string EventName { get; set; }

        public Coach Model { get; set; }

        public SelectList CoachSelectList { get; set; }

        public EventsViewModel()
        {
            Model = new Coach();
        }
    }
}
