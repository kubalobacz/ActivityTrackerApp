﻿using ActivityTrackerApp.Models.DTOs;
using ActivityTrackerApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ActivityTrackerApp.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;
        private string _username;
        private string _email;
        private string _password;
        private ICommand _registerCommand;

        public RegisterViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        public ICommand RegisterCommand => _registerCommand ??= new Command(Register);

        public string Username 
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private async void Register()
        {
            var registerRequest = new RegisterRequestDto
            {
                Username = Username,
                Email = Email,
                Password = Password,
            };
            var result = await _authService.Register(registerRequest);

            if (result.IsSuccesful)
                await Shell.Current.GoToAsync("login");

            else
            {
                Console.WriteLine("NOT LOGGED");
            }
        }
    }
}
