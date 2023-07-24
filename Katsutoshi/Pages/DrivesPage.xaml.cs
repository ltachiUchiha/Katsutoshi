﻿using Katsutoshi.Modules;
using Katsutoshi.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Katsutoshi.Pages
{
    /// <summary>
    /// Логика взаимодействия для DrivesPage.xaml
    /// </summary>
    public partial class DrivesPage : Page
    {
        private readonly DrivesViewModel _viewModel;

        private readonly KatsuLogger logger;

        public DrivesPage()
        {
            InitializeComponent();
            _viewModel = new DrivesViewModel();
            DataContext = _viewModel;

            logger = new KatsuLogger();

            Loaded += DrivesPage_Loaded;
        }

        // Drives page loaded
        private async void DrivesPage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                await _viewModel.LoadData();
                logger.Log(LogCode.Info, "Drives page loaded.");
            }
            catch (Exception ex)
            {
                logger.Log(LogCode.Error, ex.Message);
            }
        }
    }
}
