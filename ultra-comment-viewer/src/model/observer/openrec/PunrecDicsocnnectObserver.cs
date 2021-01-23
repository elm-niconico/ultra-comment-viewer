using System;
using System.Collections.Generic;
using System.Text;
using ultra_comment_viewer.src.viemodel;
using ultra_comment_viewer.src.viewLogic.observer;

namespace ultra_comment_viewer.src.model.observer.openrec
{
    public class PunrecDicsocnnectObserver : ABDisconnectObserver
    {
        public PunrecDicsocnnectObserver(MainWindowViewModel model) : base(model) { }

        protected override void SwitchNotEnableDisconnectButton()
        {
            ItsMainModel.IsNotConnectPunrecLive = true;
        }
    }
}
