﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffe.CustomersApp.Command;
using WiredBrainCoffe.CustomersApp.Data;
using WiredBrainCoffe.CustomersApp.Models;

namespace WiredBrainCoffe.CustomersApp.ViewModel
{
    public class CustomersViewModel: ViewModelBase
    {
        private readonly ICustomerDataProvider _customerDataProvider;
        public DelegateCommand AddCommand { get; }
        public DelegateCommand MoveNavigationCommand { get; }
        public DelegateCommand DeleteCommand { get; }
        private CustomerItemViewModel? _selectedCustomer;
        private NavigationSide _navigationSide;

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
            AddCommand = new DelegateCommand(Add);
            MoveNavigationCommand = new DelegateCommand(MoveNavigation);
            DeleteCommand = new DelegateCommand(Delete, CanDelete);
        }

        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new ObservableCollection<CustomerItemViewModel>();

        public CustomerItemViewModel? SelectedCustomer 
        { 
            get => _selectedCustomer;
            set { 
                _selectedCustomer = value; 
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(IsCustomerSelected));
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public bool IsCustomerSelected => SelectedCustomer is not null;

        public async override Task LoadAsync()
        {
            if(Customers.Any())
            {
                return;
            }

            var customers =  _customerDataProvider.GetAllAsync();
            if(customers is not null) 
            {
                foreach (var customer in customers)
                {
                    Customers.Add(new CustomerItemViewModel(customer));
                }
            }
        }

        private void Add(object? parameter)
        {
            var customer = new Customer { FirstName = "New" };
            var viewModel = new CustomerItemViewModel(customer);
            Customers.Add(viewModel);
            SelectedCustomer = viewModel;
        }

        public NavigationSide NavigationSide { 
            get => _navigationSide;
            private set { 
                _navigationSide = value;
                RaisePropertyChanged();           
            }
        }

        private void MoveNavigation(object? parameter)
        {
            NavigationSide = NavigationSide == NavigationSide.Left ? NavigationSide.Right : NavigationSide.Left;
        }

        private bool CanDelete(object? parameter) => SelectedCustomer is not null;
      

        private void Delete(object? parameter)
        {
            if(SelectedCustomer  is not null)
            {
                Customers.Remove(SelectedCustomer);
                SelectedCustomer = null;
            }
        }
    }

    public enum NavigationSide
    {
        Left,
        Right
    }
}
