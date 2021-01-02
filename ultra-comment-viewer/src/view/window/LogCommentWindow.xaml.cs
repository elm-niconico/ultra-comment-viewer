using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// LogCommentWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class LogCommentWindow : Window
    {

        public LogCommentWindow(List<CommentViewModel> models, LogCommentViewModel logmodel)
        {
            InitializeComponent();

            var comments = new ObservableCollection<CommentViewModel>();
            models.ForEach(m => comments.Add(m));

            this.DataContext = logmodel;
            CommentList.ItemsSource = models;
           
        }

       
    }
}
