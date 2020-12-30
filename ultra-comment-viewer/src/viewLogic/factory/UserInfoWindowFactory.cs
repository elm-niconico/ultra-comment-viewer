using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using ultra_comment_viewer.src.model.http;
using ultra_comment_viewer.src.viemodel;
using ultra_comment_viewer.src.view.window;

namespace ultra_comment_viewer.src.viewLogic.factory
{
    public class UserInfoWindowFactory
    {
        public async Task<Window> FactoryUserInfoWindow(CommentModel model, Window window)
        {
            switch (model.LiveName)
            {
                case LiveSiteName.TWICAS:
                    return await CreateTwicasUserInfoWindow(model, window);
                case LiveSiteName.NICONICO:
                    throw new NotImplementedException();
                //TODO ニコニコのウィンドウ生成処理を記述する
                default:
                    MessageBox.Show(Messages.NOT_SUPPORT_WINDOW_TYPE);
                    throw new NullReferenceException();
            }
        }


        private async Task<TwicasUserInfoWindow> CreateTwicasUserInfoWindow(CommentModel model, Window window)
        {
            var restClient = new TwicasRestClient();   
            var userInfo = await restClient.GetUserInfoAsync(model.UserId, " eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImp0aSI6ImUwNTdjMjUwNzQ2NWExZWU3YjAxYTgzZjE3YWM1MzE2MTZmNmYwZWFiOGNkOWRlZDc1NDU4NzlhYzU5NjI2ZGFmYTcyZjVkMjE0NGUyMmM1In0.eyJhdWQiOiIxMjc0MTYyNjEyMTMzOTU3NjMyLmMxMWNmMTVhZTE2NGE1YTY4MzVlMjcxNzRhZDYxZTkxNWQxMjE4MGJmMjRlZDgyNWQxYjM1ZjEyN2VhNWZhODciLCJqdGkiOiJlMDU3YzI1MDc0NjVhMWVlN2IwMWE4M2YxN2FjNTMxNjE2ZjZmMGVhYjhjZDlkZWQ3NTQ1ODc5YWM1OTYyNmRhZmE3MmY1ZDIxNDRlMjJjNSIsImlhdCI6MTYwOTMyMDA2NywibmJmIjoxNjA5MzIwMDY3LCJleHAiOjE2MjQ4NzIwNjcsInN1YiI6IjEyNzQxNjI2MTIxMzM5NTc2MzIiLCJzY29wZXMiOlsicmVhZCIsIndyaXRlIl19.EukwHOQwxgcV162dHz2eGOb3J-UdcUeOWYRN-HrLl277Tqe56Z68IHJylhPF_CuwE94hVV4Pab5IPA6ZAtHaVslA5FXth6W7X_6lc2hH-VQAYasiNiODzD6Y8cRHebnlUb0eLSTafhtJPAD1VrtYh3aP1qeXlwcr_eJmnVsn3enu8D4SIw5QzCt5XQgzIuG6SPpVhnzMFKvCG0Q2XMsuCIUFHnaxI4ATx240UZm_Zjn1OL7KzFhlPpWzvzOIwpISAoZ0q4qIlWZkX2WYH2lD1cSgauOybZJ-UvwxAApTUyOd-4QTspAm-eGd9Lc7HQ-Z2rktO16ZdrmEEk95HBsXng");
            return new TwicasUserInfoWindow(userInfo) { Owner = window };
        }
        

    }
}
