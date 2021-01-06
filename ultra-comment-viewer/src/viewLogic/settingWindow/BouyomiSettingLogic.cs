using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using ultra_comment_viewer.src.viemodel;
using ultra_comment_viewer.src.viemodel.settingsWindow;

namespace ultra_comment_viewer.src.viewLogic.settingWindow
{
    public class BouyomiSettingLogic
    {
        private readonly BouyomiSettingsModel _model;

        private readonly Window _window;

        public BouyomiSettingLogic(Window window)
        {
            this._window = window;
            this._model = BouyomiSettingsModel.GetInstance();
        }

        public string ChoiceBouyomiApp()
        {
            var diaLog = new OpenFileDialog
            {
                Filter = "棒読みちゃんパス | *.exe"
            };

            if (diaLog.ShowDialog() == true)
            {
                return diaLog.FileName;

            }
            return null;
            
        }

        public void ApplySettings(SettingWindowViewModel model)
        {
            var path = model.BoyomiSettingPath;
            this._model.SetBouyomiPath(path);
            
        }

        
    }
}
