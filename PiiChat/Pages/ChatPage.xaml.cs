using Newtonsoft.Json.Linq;
using PiiChat.Models;
using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
    public sealed partial class ChatPage : Page
    {
        public ObservableCollection<MessageContent> dataSource { get; set; }
        private readonly SynchronizationContext synchronizationContext;
        Socket socket = null;
        bool connected = false;

        public ChatPage()
        {
            this.InitializeComponent();
            dataSource = new ObservableCollection<MessageContent>();
            socket = IO.Socket("http://chat.socket.io/");
            socket.Connect();

            socket.Emit("add user", txbUsernameTarget.Text);

            socket.On("login", data =>
            {
                connected = true;

                // get the json data from the server message
                var jobject = data as JToken;

                // get the number of users
                var numUsers = jobject.Value<int>("numUsers");

            });
            // whenever the server emits "new message", update the chat body
            socket.On("new message", (data) =>
            {
                // get the json data from the server message
                var jobject = data as JToken;

                // get the message data values
                var username = jobject.Value<string>("username");
                var message = jobject.Value<string>("message");

                addMessage(message.ToString());
            });
        }

        protected override void OnDisconnectVisualChildren()
        {
            base.OnDisconnectVisualChildren();
            socket.Close();
        }

        private void SendMessage(object sender, RoutedEventArgs e)
        {
            
            addMessage(txtMessage.Text);

            if (connected)
            {
                socket.Emit("new message", txtMessage.Text);
            }
            txtMessage.Text = "";

        }

        public async void addMessage(string message)
        {
            
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                dataSource.Add(new MessageContent(message, DateTime.Now.ToString(), "", "Left"));
                ListMessage.ItemsSource = dataSource;
            });
        }

        private void txtMessage_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                SendMessage(sender, e);
            }
        }

        private void ShowEmoji(object sender, RoutedEventArgs e)
        {
            if (LayerEmoji.Visibility == Visibility.Collapsed)
            {
                LayerEmoji.Visibility = Visibility.Visible;
            }
            else
            {
                LayerEmoji.Visibility = Visibility.Collapsed;
            }
        }

        private void SelectImage(object sender, RoutedEventArgs e)
        {

        }

        private void txtMessage_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
