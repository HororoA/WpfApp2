using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        串口及网络通信.COM C = new 串口及网络通信.COM();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            C.receiveNameCOM = "COM4";//接收串口号
            C.sendNameCOM = "COM3";//发送串口号
            C.boolSixteenCOM = true;//是否16位数据
            C.baudRateCOM = 9600;//波特率
            C.startCOM();
            C.serialPortsMessage += C_serialPortsMessage;
            C.sendCOM("");//发送消息
        }

        private void C_serialPortsMessage(object sender, 串口及网络通信.serialPortsEventArgs e)
        {
            string s = null;
            foreach (byte c in e.getbyte)
            {
                //这里的e.getbyte里面得到的是ascII码，还需要转一下，就可以使用了，这个是接收的
                s += c.ToString();
            }
            Lable1.Content = s;
            throw new NotImplementedException();
        }
    }
}
