using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ultra_comment_viewer.src.model.http;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.view.window
{
    /// <summary>
    /// TwicasUserInfoWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class TwicasUserInfoWindow : Window
    {


        private TwicasUserInfoWindowViewModel _model;

        public TwicasUserInfoWindow(TwicasUserInfoWindowViewModel model)
        {
            InitializeComponent();
            this._model = model;
            this.DataContext = model;
        }

        private async void EventClick(object sender, RoutedEventArgs e)
        {
            var restClient = new TwicasRestClient();
            var resultModel = await restClient.PutRegesiteSupporter(this._model.UserId);
            
            if(resultModel.added_count <= 0)
            {
                System.Windows.MessageBox.Show("サポータになれませんでした");
            }
        }
    }
}
