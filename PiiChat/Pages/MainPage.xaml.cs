using PiiChat.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace PiiChat.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public List<string> contactListRecent;
        public MainPage()
        {
            this.InitializeComponent();
            contactListRecent = new List<string>()
            {
                "ABC",
                "DEF",
                "ABC",
                "DEF",
                "ABC",
                "DEF",
                "ABC",
                "DEF"
            };
            ListViewContact.ItemsSource = contactListRecent;
            ListViewContacts1.ItemsSource = contactListRecent;
            //ListViewContacts.ItemsSource = contactListRecent;
            MyItems.Source = Header.GetItemsGrouped();
        }

        private void ListViewContacts_Tapped(object sender, TappedRoutedEventArgs e)
        {
            AppManager manager = AppManager.getInstance();
            manager.Navigate(AppManager.PageType.CONVERSATION_PAGE);
        }

        private void ListViewContacts_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            AppManager manager = AppManager.getInstance();
            manager.Navigate(AppManager.PageType.CONVERSATION_PAGE);
        }

        private void ListViewContact_Tapped(object sender, TappedRoutedEventArgs e)
        {
            AppManager manager = AppManager.getInstance();
            manager.Navigate(AppManager.PageType.CONVERSATION_PAGE);
        }
    }
}
