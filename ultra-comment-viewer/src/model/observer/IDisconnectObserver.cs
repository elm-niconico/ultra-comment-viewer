using System;
using System.Collections.Generic;
using System.Text;

namespace ultra_comment_viewer.src.viewLogic.observer
{
    public class IDisconnectObserver
    {
        private readonly CommentGenerator _generator;

        public IDisconnectObserver(CommentGenerator generator)
        {
            this._generator = generator;
        }

        public void Notify()
        {
            this._generator.AddDisconnectComment();
        }
    }
}
