using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ServiceBusApp.Presentation.Messages;
using ServiceBusApp.Presentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusApp.Presentation.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private INavigationService navigationService;

        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel { get => currentViewModel; set => Set(ref currentViewModel, value); }

        public MainViewModel(INavigationService navigationService,IMessenger messenger)
        {
            this.navigationService = navigationService;
            messenger.Register<NavigationMessage>(this,
                message =>
                {
                    var viewModel = App.Container.GetInstance(message.ViewModelType) as ViewModelBase;
                    CurrentViewModel = viewModel;
                });
        }

        public RelayCommand ClassPageCommand { get => new RelayCommand(() =>
        {
            navigationService.NavigateTo<ClassViewModel>();
        });
        }

        public RelayCommand StudentPageCommand
        {
            get => new RelayCommand(() =>
            {
                navigationService.NavigateTo<StudentViewModel>();
            });
        }

    }
}
