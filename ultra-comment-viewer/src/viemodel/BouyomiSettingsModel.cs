
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;
using ultra_comment_viewer.src.model.parser;
using ultra_comment_viewer.src.viewLogic;

namespace ultra_comment_viewer.src.viemodel
{
    public class BouyomiSettingsModel 
    {
        private BouyomiSettingsModel() 
        {
        }

        public readonly BitmapImage _useBoyomiIcon = new BitmapImage(new Uri("Resources\\bouyomi.png",UriKind.Relative));

        public readonly BitmapImage _isNotUsedBouyomiIcon = new BitmapImage(new Uri("Resources\\not_use_boyomi.png", UriKind.Relative));


      
        private static readonly BouyomiSettingsModel _instance = new BouyomiSettingsModel();

        public static BouyomiSettingsModel GetInstance() => _instance;

        public  BitmapImage BoyomiIcon
        {
            get =>  IsUsedBouyomi()? this._useBoyomiIcon : this._isNotUsedBouyomiIcon;
         
        }

    
        
        public bool IsUsedBouyomi() => Properties.BoyomiChan.Default.IsUseBouyomi;
        public bool IsNotUsedBouyomi() => !Properties.BoyomiChan.Default.IsUseBouyomi;
        public void SetIsUsedBouyomi(bool use)
        {
            Properties.BoyomiChan.Default.IsUseBouyomi = use;
            Properties.BoyomiChan.Default.Save();

            if (use) RunningBouyomiOrNull();
            else     CancelAllTask();
        }
        public string GetBouyomiPath() => Properties.BoyomiChan.Default.AppPath;
        public void SetBouyomiPath(string path)
        {
            Properties.BoyomiChan.Default.AppPath = path;
            Properties.BoyomiChan.Default.Save();
        }

        private void CancelAllTask()
        {
            var client = new BouyomiChanClient(new NicoBouyomiChanParser());
            client.CancelAllTask();
        }

        private void RunningBouyomiOrNull()
        {
            var client = new BouyomiChanClient(new NicoBouyomiChanParser());

            if (client.IsBouyomiRunning()) return;

            client.StartRunningBouyomiChan(this.GetBouyomiPath());
            
        }
    }
}
