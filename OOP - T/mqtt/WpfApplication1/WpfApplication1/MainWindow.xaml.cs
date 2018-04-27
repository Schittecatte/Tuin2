using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MqttClient client;

        public MainWindow()
        {
            InitializeComponent();

            // Client aanmaken
            client = new MqttClient(
                    "m23.cloudmqtt.com",
                    36308,
                    true,
                    MqttSslProtocols.SSLv3,
                    null,
                    null
                );
            // Events opvangen van de client
            client.MqttMsgPublishReceived += Client_MqttMsgPublishReceived;
            client.MqttMsgSubscribed += Client_MqttMsgSubscribed;
            client.MqttMsgUnsubscribed += Client_MqttMsgUnsubscribed;
            client.MqttMsgPublished += Client_MMqttMsgPublished;

            // Effectief verbinden
            client.Connect(Guid.NewGuid().ToString(),
                                "pprwdlkl",
                                "xhzeJXW - VNIO");

            // Aanmelden bij bepaalde topics...
            string[] topics = { "demo" };
            byte[] qosLevel = { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE };
            client.Subscribe(topics, qosLevel);

            // Melden in debug
            Debug.WriteLine("Wait for MQTT-message");
        }

        private void Client_MMqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
        {
            Debug.WriteLine("MqttMsgPublished");

        }

        private void Client_MqttMsgUnsubscribed(object sender, MqttMsgUnsubscribedEventArgs e)
        {
            Debug.WriteLine("MqttMsgUnsubscribed");

        }

        private void Client_MqttMsgSubscribed(object sender, MqttMsgSubscribedEventArgs e)
        {
            Debug.WriteLine("MqttMsgSubscribed");

        }

        private void Client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            string receivedMessage = UTF8Encoding.UTF8.GetString(e.Message);
            Debug.WriteLine("MqttMsgPublishReceived: " + receivedMessage);
            Dispatcher.Invoke(new Action<String>(updateLabel), receivedMessage);
        }

        private void updateLabel(string pData)
        {
            LblText.Content = pData;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string[] topics = { "demo" };
            client.Unsubscribe(topics);
            client.Disconnect();
        }

    }
}