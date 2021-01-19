using System;
using System.Collections.Generic;
using System.Text;
using ultra_comment_viewer.src.viemodel;
using ultra_comment_viewer.src.viewLogic.observer;

namespace ultra_comment_viewer.src.model.observer.niconico
{
    public class NicoDisconnectObserver : ABDisconnectObserver
    {
        public NicoDisconnectObserver(MainWindowViewModel model) : base(model) { }

        protected override void SwitchNotEnableDisconnectButton()
        {
            ItsMainModel.IsNotConnectNicoLive = true;
        }
    }
}
