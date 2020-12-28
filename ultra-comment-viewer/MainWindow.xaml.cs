using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ultra_comment_viewer.src.model;
using ultra_comment_viewer.src.model.http;
using ultra_comment_viewer.src.model.json;
using ultra_comment_viewer.src.model.json.converter;
using ultra_comment_viewer.src.model.websocket;
using ultra_comment_viewer.src.viemodel;
using ultra_comment_viewer.src.view.validater;
using ultra_comment_viewer.src.viewLogic;

namespace ultra_comment_viewer
{ 

    

    public partial class MainWindow : Window
    {
        private MainWindowViewModel _model;

        private ConnectSwitcher _switcher;

        private bool _autoScrollFlag;

        public MainWindow()
        {
            InitializeComponent();
            
            var collection = new ObservableCollection<CommentModel>();
            CommentList.ItemsSource = collection;

            this._model = new MainWindowViewModel();

            this.DataContext = this._model;

            _switcher = new ConnectSwitcher(_model,
                                            new CommentGenerator(collection,
                                                                new ConnectionCommentServer(
                                                                    new TwicasWebSocketClient(),
                                                                    new TwicasRestClient(), 
                                                                    new TwicasCommentConverter())));

        }

   


        private void ScrollCommentView()
        {
            if (_autoScrollFlag)
            {
                CommentList.ScrollIntoView(CommentList.Items[^1]);
            }
        }


        private async void EventClickConnectionButtonHandler(object sender, RoutedEventArgs e)
        {
            await this._switcher.DoStart(ScrollCommentView);
        }


        private void EventChangedUrlTextBox(object sender, TextChangedEventArgs e)
        {
            var validater = new TwiacasUrlValidater();
            _model.IsWriteUrl = validater.IsValidUrl(_model);

        }

        private void EventScrollChangedUpdateAutoScrollFlag(object sender, ScrollChangedEventArgs e)
        {
            _autoScrollFlag = (e.VerticalOffset + e.ViewportHeight >= e.ExtentHeight - 2);
        }

        private void EventDropOnUrlMark(object sender, DragEventArgs e)
        {
            if (!(sender is ListViewItem)) return;

            var comment = sender as ListViewItem;

        }
    }
}
