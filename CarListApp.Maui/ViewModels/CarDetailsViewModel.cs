﻿using CarListApp.Maui.Models;
using CarListApp.Maui.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CarListApp.Maui.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public partial class CarDetailsViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly CarApiService _carApiService;  

        public CarDetailsViewModel(CarApiService carApiService)
        {
            _carApiService = carApiService;
        }

        NetworkAccess accessType = Connectivity.Current.NetworkAccess;

        [ObservableProperty]
        Car car;

        [ObservableProperty]
        int id;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Id = Convert.ToInt32(HttpUtility.UrlDecode(query["Id"].ToString()));

        }

        public async Task GetCarData()
        {
            if(accessType == NetworkAccess.Internet)
            {
                Car = await _carApiService.GetCar(Id);
            }
            else
            {
                Car = App.CarDatabaseService.GetCar(Id);
            }
        }
    }
}