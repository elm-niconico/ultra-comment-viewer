﻿using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ultra_comment_viewer.src;
using ultra_comment_viewer.src.commons;
using ultra_comment_viewer.src.commons.extends_mothod;
using ultra_comment_viewer.src.model;
using ultra_comment_viewer.src.model.connection;
using ultra_comment_viewer.src.model.observer.niconico;
using ultra_comment_viewer.src.model.observer.openrec;
using ultra_comment_viewer.src.model.parser;
using ultra_comment_viewer.src.viemodel;
using ultra_comment_viewer.src.view.validater;
using ultra_comment_viewer.src.viewLogic;

namespace ultra_comment_viewer
{



    public partial class MainWindow : Window
    {
        private MainWindowViewModel _model;

        private readonly CommentGenerator _punrectCommentGenerator;

        private readonly CommentGenerator _niconicoCommentGenerator;

        private bool _autoScrollFlag;

        private readonly DropLogic _dropLogic;

        private readonly MenuLogic _menuLogic;

        public MainWindow()
        {
            InitializeComponent();
            
            var collection = new ObservableCollection<CommentViewModel>();
            CommentList.ItemsSource = collection;

            this._model = new MainWindowViewModel();

            this.DataContext = this._model;

            
            var bouyomi = new BouyomiChanClient();
            var bouyomiSettings = BouyomiSettingsModel.GetInstance();

            if (bouyomiSettings.IsUsedBouyomi())
                bouyomi.StartRunningBouyomiChan(bouyomiSettings.GetBouyomiPath());

            _punrectCommentGenerator = new CommentGenerator(collection, new PunrecDicsocnnectObserver(_model));

            this._niconicoCommentGenerator = new CommentGenerator(collection, new NicoDisconnectObserver(_model));
                                                                  
                                                                  
            this._menuLogic = new MenuLogic();

            this._dropLogic = new DropLogic();
        }

   


        private void ScrollCommentView()
        {
            if (_autoScrollFlag)
            {
                CommentList.ScrollIntoView(CommentList.Items[^1]);
            }
        }

        // ============================　ライブコネクション　===============================================
 

        private async void Click_ConnectionNicoServer(object sender, RoutedEventArgs e)
        {

            var validater = new NicoLiveUrlValidater();
            (bool,string) result = validater.IsValidUrl(NicoUrlText.Text);

            bool isNotLiveUrl = !result.Item1;
            if (isNotLiveUrl) return;

            string liveId = result.Item2;
            this._model.IsNotConnectNicoLive = false;
            await this._niconicoCommentGenerator.ConnectCommentServerAsync(liveId, this.ScrollCommentView, new NicoConnectionCommentServer(_model));
        }


        private async void Click_ConnectionPunrecServer(object sender, RoutedEventArgs e)
        {
            var validater = new PunrecUrlValidater();
            (bool, string) result = validater.IsValidUrl(PunrecUrlText.Text);

            bool isNotLiveUrl = !result.Item1;
            if (isNotLiveUrl) return;

            string channelId = result.Item2;
            this._model.IsNotConnectPunrecLive = false;
            await _punrectCommentGenerator.ConnectCommentServerAsync(channelId, ScrollCommentView, new PunrecConnectionCommentServer(_model));
          
        }

        private async void Click_DisconnectPunrecServer(object sender, RoutedEventArgs e)
        {

            await _punrectCommentGenerator.DisConnectCommentServerAsync();
        }

        // ========================== END Connection ======================================================================================


        private async void Click_DisConnectNicoNicoServer(object sender, RoutedEventArgs e)
        {
             this._model.IsNotConnectNicoLive = true;
             await this._niconicoCommentGenerator.DisConnectCommentServerAsync();
           
        }

        private void EventScrollChanged_UpdateAutoScrollFlag(object sender, ScrollChangedEventArgs e)
        {
            _autoScrollFlag = (e.VerticalOffset + e.ViewportHeight >= e.ExtentHeight - 2);
        }

        private void EventDrop_OnUrlMark(object sender, DragEventArgs e)
        {
            var commentModel = CastToCommentModelOrNull(e);
            if (commentModel == null) return;
               
            this._dropLogic.DoStartOpenBrowser(commentModel.Comment);
        }

        private void MouseMove_CommentDrag(object sender, MouseEventArgs e)
        {
            if (sender.NotNull() && e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop((Card)sender, CommentList.SelectedItem, DragDropEffects.Copy);
            }
        }

        private void Drop_OpenLogWindow(object sender, DragEventArgs e)
        {
            var commentModel = CastToCommentModelOrNull(e);
            if (commentModel == null) return;

            this._dropLogic.OpenLogCommentWindow(window: this, commentModel);
        }

        private async void Drop_OpenUserInfoWindow(object sender, DragEventArgs e)
        {
            var commentModel = CastToCommentModelOrNull(e);
            if (commentModel == null) return;

            await this._dropLogic.OpenUserInfoWindow(this, commentModel);

        }


        private CommentViewModel CastToCommentModelOrNull(DragEventArgs e)
        {
            return (CommentViewModel)e.Data.GetData(typeof(CommentViewModel));
        }


        private void Click_ChangeIsUsedBouyomi(object sender, RoutedEventArgs e)
        {
            var setting = BouyomiSettingsModel.GetInstance();
            var useFlag = setting.IsUsedBouyomi();

            setting.SetIsUsedBouyomi(!useFlag);
            //セッターの中で自動で反映される
            this._model.BouyomiChanIcon = null;       
                
        }

        private void Click_OpenSettingWindow(object sender, RoutedEventArgs e)
        {
            this._menuLogic.OpenSettingWindow(this);
        }

        private void MouseLeave_ChangeAccountBackground(object sender, MouseEventArgs e)
        {
            this._dropLogic.ChangeWhiteColor((Card)sender, _model);
        }

        private void MouseMove_ChangeAccountBackGround(object sender, MouseEventArgs e)
        {

            this._dropLogic.ChangeGrayColor((Card)sender, _model);
        }


        private void Drop_ClipCommentText(object sender, DragEventArgs e)
        {
            var commentModel = CastToCommentModelOrNull(e);
            if (commentModel == null) return;

            this._dropLogic.ClipCommentText(commentModel);
            this.ClipCommentSnackbar.MessageQueue.Enqueue($"Copy : [{commentModel.Comment}]");
        }


        //================= URLFORM削除 ========================================
        private void Click_ClearPunrecUrlText(object sender, RoutedEventArgs e)
        {
            PunrecUrlText.Text = string.Empty;
        }

        private void Click_ClearNicoUrlText(object sender, RoutedEventArgs e)
        {
            NicoUrlText.Text = string.Empty;
        }
    }
}
