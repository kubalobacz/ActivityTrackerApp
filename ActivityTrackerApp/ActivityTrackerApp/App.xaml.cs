﻿using ActivityTrackerApp.Services;
using ActivityTrackerApp.Pages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Autofac;
using Xamarin.Forms.Internals;
using Autofac.Core;
using System.Collections.Generic;
using ActivityTrackerApp.ViewModels;

namespace ActivityTrackerApp
{
    public partial class App : Application
    {
        static IContainer container;

        public App()
        {
            InitializeComponent();

            var builder = new ContainerBuilder();

            builder.RegisterType<AuthService>().As<IAuthService>().SingleInstance();
            builder.RegisterType<ActivityService>().As<IActivityService>().SingleInstance();

            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<RegisterViewModel>();
            builder.RegisterType<StartViewModel>();
            builder.RegisterType<ActivitiesViewModel>();
            builder.RegisterType<StravaViewModel>();
            MainPage = new AppShell();

            container = builder.Build();


            Shell.Current.GoToAsync(nameof(LoginPage));
        }

        public static T Resolve<T>() => container.Resolve<T>();

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
