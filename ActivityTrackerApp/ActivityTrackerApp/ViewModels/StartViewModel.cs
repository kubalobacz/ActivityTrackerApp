﻿using ActivityTrackerApp.Models;
using ActivityTrackerApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ActivityTrackerApp.ViewModels
{
    public class StartViewModel : BaseViewModel
    {
        private readonly IActivityService _activityService;
        private string _username;
        private Activity _lastActivity;
        private ICommand _goToAddActivityPageCommand;

        public StartViewModel(IAuthService authService, IActivityService activityService)
        {
            _activityService = activityService;
        }

        public string Username 
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public Activity LastActivity 
        {
            get => _lastActivity;
            set => SetProperty(ref _lastActivity, value);
        }

        public ICommand GoToAddActivityPageCommand => _goToAddActivityPageCommand ??= new Command(GoToAddActivityPage);

        public override async Task Initialize()
        {
            await _activityService.GetActivities();
            LastActivity = _activityService.Activities.Any() ? _activityService.Activities.First() : null;
            await base.Initialize();
        }

        private async void GoToAddActivityPage()
        {
            await Shell.Current.GoToAsync("AddActivityPage");
        }

    }
}
