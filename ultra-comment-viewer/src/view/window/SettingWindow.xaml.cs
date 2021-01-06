using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ultra_comment_viewer.src.viemodel.settingsWindow;
using ultra_comment_viewer.src.viewLogic.settingWindow;

namespace ultra_comment_viewer.src.view.window
{
    /// <summary>
    /// SettingWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SettingWindow : Window
    {
        private readonly SettingWindowViewModel _model;

        private readonly BouyomiSettingLogic _bouyomi;

        public SettingWindow()
        {
            InitializeComponent();

            this._model = new SettingWindowViewModel();
            this.DataContext = this._model;

            this._bouyomi = new BouyomiSettingLogic(this);
        }

        private void Click_OpenPathDialog(object sender, RoutedEventArgs e)
        {
            this._model.BoyomiSettingPath =  this._bouyomi.ChoiceBouyomiApp();
            
        }

        private void Click_ApplyBouyomiSettings(object sender, RoutedEventArgs e)
        {
            this._bouyomi.ApplySettings(this._model);  
        }
    }
}
