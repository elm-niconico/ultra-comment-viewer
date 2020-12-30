using System;
using System.Collections.Generic;
using System.Text;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.view.window
{
    public abstract class ABUserInfoWindow<T> where T : IUserInfoViewModel
    {
        protected T itsModel;

        public ABUserInfoWindow(T model)
        {
            this.itsModel = model;
        }
    }
}
