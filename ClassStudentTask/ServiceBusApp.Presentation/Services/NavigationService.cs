using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using ServiceBusApp.Presentation.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceBusApp.Presentation.Services
{
    public class NavigationService : INavigationService
    {
        public readonly IMessenger messenger;

        public NavigationService(IMessenger messenger)
        {
            this.messenger = messenger;
        }

        public void NavigateTo<T>() where T : ViewModelBase
        {
            messenger.Send(new NavigationMessage() { ViewModelType = typeof(T)});   
        }
    }
}
