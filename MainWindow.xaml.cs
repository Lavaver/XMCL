using System;
using System.Collections.Generic;
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
using MahApps.Metro.Controls;
using KMCCC.Launcher;
using KMCCC.Authentication;

namespace XMCL
{
    /// <summary>
    /// MainWindow.xaml 的实例对象
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        public static LauncherCore Core = LauncherCore.Create(); // 实例化 KMCCC 对象以便后续代码

        public MainWindow()
        {
            InitializeComponent();
            StartGame_Info.Content = "正在等待启动游戏";
            // 获取版本
            KMCCC.Launcher.Version[] versions = Core.GetVersions().ToArray();
            SelectGameVersion_ComboBox.ItemsSource = versions;

            // 判断是否有游戏版本可供选择  
            if (SelectGameVersion_ComboBox.Items.Count == 0)
            {
                // 如果没有找到游戏版本，则提示用户  
                MessageBox.Show("没有找到任何游戏版本！\n请在启动器内下载本体或自行导入到软件所在目录下的 .minecraft 文件夹内\n导入或下载成功后请重启刷新版本列表！","未找到游戏",MessageBoxButton.OK,MessageBoxImage.Information);
                StartGame_Info.Content = "未找到游戏";
            }

        }

        private async void StartGame_Button_Click(object sender, RoutedEventArgs e)
        {
            // 这两个 if 判断主要防止手贱
            if (SelectGameVersion_ComboBox.Items.Count == 0) 
            {
                StartGame_Info.Content = "未找到游戏";
                MessageBox.Show("请先导入或下载游戏，然后重新启动启动器再试\n启动器默认不会自动选中已安装版本，需要在下拉框选择", "未找到游戏", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string input = Offline_PlayerName.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                StartGame_Info.Content = "未输入账户名";
                MessageBox.Show("请先在账号页面输入用户名，然后再启动游戏！", "账户名为空", MessageBoxButton.OK, MessageBoxImage.Error);               
                return;
            }

            StartGame_Info.Content = "正在启动游戏，请稍候";
            int secondsToWait = 5; 
            await Task.Delay(secondsToWait * 1000); // 这俩行代码我故意的（


            Core.JavaPath = @"JAVA\bin\javaw.exe"; // Java 默认随软件本体附带，直接引用相对路径
            
            var ver = (KMCCC.Launcher.Version)SelectGameVersion_ComboBox.SelectedItem;
            var result = Core.Launch(new LaunchOptions
            {
                Version = ver, //选中启动版本
                MaxMemory = 4096, //最大新生代内存（1024M = 1G）
                Authenticator = new OfflineAuthenticator(Offline_PlayerName.Text),//离线启动
                Mode = LaunchMode.MCLauncher, //启动模式（默认）
                Size = new WindowSize { Height = 768, Width = 1280 } //设置窗口大小（默认）
                
        });
            StartGame_Info.Content = "已启动游戏";
            MessageBox.Show("游戏已启动！\n如果你未看到游戏画面请稍等一会（低版本由于加载快可以忽视本消息），这是正常现象","游戏已启动",MessageBoxButton.OK,MessageBoxImage.Information);
            // 你要问我这些代码的改进是什么？我想可能是避免为了像之前版本那样为了启动 Minecraft 而专门在代码里为了每一个需求写很长的命令...以及各种令人抓耳挠腮的参数。
        }

    }
}
