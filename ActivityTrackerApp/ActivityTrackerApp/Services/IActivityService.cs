﻿using ActivityTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTrackerApp.Services
{
     public interface IActivityService
    {
        public ObservableCollection<Activity> Activities { get; set; }
        public Task GetActivities();
    }
}