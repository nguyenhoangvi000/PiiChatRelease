using PiiChat.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace PiiChat
{
    public class AppManager : IDisposable
    {
        private string _token = @"eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjU3ZTc4YTNjNWRhN2Y2NzBhODA3OGQzMSIsInVzZXJuYW1lIjoibWluaGR1YyIsImRpc3BsYXlOYW1lIjoiTMOqIE1pbmggxJDhu6ljIiwiaWF0IjoxNDc0Nzk1MDMyLCJleHAiOjE0NzYyMzUwMzJ9.emySrbqS1sj6K3ZsljfFiFj6wisMVi44O6y1IrDh54M";
        private static AppManager _appManager;
        public enum PageType { LOGIN_PAGE, MAIN_PAGE, WAITING_PAGE, REGISTER_PAGE, CONVERSATION_PAGE }

        protected AppManager()
        {
        }

        public static AppManager getInstance()
        {
            if (_appManager == null)
            {
                _appManager = new AppManager();
            }
            return _appManager;
        }

        public void Navigate(PageType type)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.NavigationFailed += OnNavigationFailed;

            switch (type)
            {
                case PageType.LOGIN_PAGE:
                    rootFrame.Navigate(typeof(LoginPage));
                    break;
                case PageType.MAIN_PAGE:
                    rootFrame.Navigate(typeof(MainPage));
                    break;
                case PageType.WAITING_PAGE:
                    rootFrame.Navigate(typeof(WaitingPage));
                    break;
                case PageType.REGISTER_PAGE:
                    rootFrame.Navigate(typeof(LoginPage));
                    break;
                case PageType.CONVERSATION_PAGE:
                    rootFrame.Navigate(typeof(LoginPage));
                    break;
                default:
                    break;
            }
        }

        public async Task Run(LaunchActivatedEventArgs e)
        {

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(WaitingPage), e.Arguments);

                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }





        public void LoadSetting()
        {
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            _token = localSettings.Values["token"].ToString();
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        public void Dispose()
        {
            SaveSettings();
        }

        public void SaveSettings()
        {
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            localSettings.Values["token"] = _token;
        }
    }
}
