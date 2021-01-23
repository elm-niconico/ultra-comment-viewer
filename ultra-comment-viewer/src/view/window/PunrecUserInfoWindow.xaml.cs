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
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.view.window
{
    /// <summary>
    /// PunrecUserInfoWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class PunrecUserInfoWindow : Window
    {

        public PunrecUserInfoWindow(PunrecUserInfoViewModel model)
        {
            InitializeComponent();
            this.DataContext = model;
        }
    }
}
