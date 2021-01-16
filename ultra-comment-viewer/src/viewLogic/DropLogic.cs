using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using ultra_comment_viewer.src.commons;
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


        public void OpenLogCommentWindow(Window window, CommentViewModel model)
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

        public async Task OpenUserInfoWindow(Window window, CommentViewModel model)
        {
            var factory = new UserInfoWindowFactory();

            var userInfoWindow = await factory.FactoryUserInfoWindow(model, window);
            userInfoWindow.Show();
        }

        public void ChangeWhiteColor(Card card, 
                                     MainWindowViewModel model
                  
                                     )
        {
            var brush = ElmBackgroundUtil.WHITE;
            switch (card.Name)
            {
                case "Web":
                    model.WebColor = brush;
                    break;
                case "User":
                    model.AccountColor = brush;
                    break;
                case "Log":
                    model.LogColor = brush;
                    break;
                case "Clip":
                    model.ClipColor = brush;
                    break;
                default:
                    return;

            }
        }

        public void ChangeGrayColor(Card card,
                                     MainWindowViewModel model


                                     )
        {
            var gray = ElmBackgroundUtil.DARK_GRAY;
            switch (card.Name)
            {
                case "Web":
                    if (model.WebColor == gray) return;
                    model.WebColor = gray;
                    break;
                case "User":
                    if (model.AccountColor == gray) return;
                    model.AccountColor = gray;
                    break;
                case "Log":
                    if (model.LogColor == gray) return;
                    model.LogColor = gray;
                    break;
                case "Clip":
                    if (model.ClipColor == gray) return;
                    model.ClipColor = gray;
                    break;
                default:
                    return;

            }
        }

        public void ClipCommentText(CommentViewModel model)
        {
            Clipboard.SetData(DataFormats.Text, model.Comment);
        }
    }
}
