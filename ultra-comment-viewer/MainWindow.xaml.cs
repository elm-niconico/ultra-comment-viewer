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
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var test = new ObservableCollection<CommentInfoModel>();
            var comment = new CommentInfoModel() { Image=null,Comment="HELLO",UserName="TODO" };
            CommentList.ItemsSource = test;
            test.Add(comment);

        }
    }
}
