using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using ultra_comment_viewer.src.model.http;
using ultra_comment_viewer.src.viemodel;
using ultra_comment_viewer.src.view.window;
using ultra_comment_viewer.src.viewLogic.factory;
using ultra_comment_viewer.src.viewLogic.log.logger;
using ultra_comment_viewer.src.viewLogic.parser;
using ultra_comment_viewer.src.viewLogic.util;

namespace ultra_comment_viewer.src.viewLogic
{
    public class DropLogic
    {
        public void DoStartOpenBrowser(string comment)
        {
            if (String.IsNullOrEmpty(comment)) return;

            var parser = new UrlParser();
            var url = parser.ParseUrl(comment);
            ProcessSupport.OpenBrowser(url);

        }


        public void OpenLogCommentWindow(Window window, CommentModel model)
        {
            var logger = new Logger();
            var logComment = logger.SelectLogComment(model);

            var logViewModel = new LogCommentViewModel() { UserIcon = model.Image, UserName = model.UserName };

            var logWindow = new LogCommentWindow(logComment, logViewModel)
            {
                Owner = window
            };

            logWindow.Show();
        }

        public async Task OpenTwicasUserInfoWindow(Window window, CommentModel model)
        {
            var factory = new UserInfoWindowFactory();

            var userInfoWindow = await factory.FactoryUserInfoWindow(model, window);
            userInfoWindow.Show();
        }

    }
}
