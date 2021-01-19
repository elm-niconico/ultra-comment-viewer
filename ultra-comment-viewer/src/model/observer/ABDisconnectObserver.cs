using System;
using System.Collections.Generic;
using System.Text;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.viewLogic.observer
{
    public abstract class ABDisconnectObserver
    {
        public CommentGenerator Generator { private get; set; }

        protected readonly MainWindowViewModel ItsMainModel;

        public ABDisconnectObserver(MainWindowViewModel model)
        {

            ItsMainModel = model;
        }

        public void Notify()
        {
            this.Generator.AddDisconnectComment();
            SwitchNotEnableDisconnectButton();
        }

        protected abstract void SwitchNotEnableDisconnectButton();
    }
}
