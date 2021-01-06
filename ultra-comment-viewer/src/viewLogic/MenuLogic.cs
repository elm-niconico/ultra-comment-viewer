using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using ultra_comment_viewer.src.view.window;

namespace ultra_comment_viewer.src.viewLogic
{
    public class MenuLogic
    {
        

        public void OpenSettingWindow(Window window)
        {
            var settingWindow = new SettingWindow() { Owner = window};

            settingWindow.Show();

        }
    }
}
