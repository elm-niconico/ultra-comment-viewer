using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.viemodel.settingsWindow
{
    public class SettingWindowViewModel: BindableBase
    {
        private string _boyomiSettingPath = Properties.BoyomiChan.Default.AppPath;
        private BouyomiSettingsModel _bouyomiModel;

        public SettingWindowViewModel()
        {
            this._bouyomiModel = BouyomiSettingsModel.GetInstance();
        }

        public string BoyomiSettingPath
        {
            get => this._boyomiSettingPath;
            set  {
                SetProperty(ref this._boyomiSettingPath, value);
              
            }
        }
    }
}
