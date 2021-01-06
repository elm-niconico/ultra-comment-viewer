using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using ultra_comment_viewer.src.commons.extends_mothod;
using ultra_comment_viewer.src.model.http;
using ultra_comment_viewer.src.model.json.model.niconico.user_page;
using ultra_comment_viewer.src.model.parser;
using ultra_comment_viewer.src.viemodel;
using ultra_comment_viewer.src.view.window;

namespace ultra_comment_viewer.src.viewLogic.factory
{
    public class UserInfoWindowFactory
    {
        public async Task<Window> FactoryUserInfoWindow(CommentViewModel model, Window window)
        {
            switch (model.LiveName)
            {
                case LiveSiteName.TWICAS:
                    return await CreateTwicasUserInfoWindow(model, window);

                case LiveSiteName.NICONICO:
                    return await CreateNicoNicoUserInfoWindow(model, window);
                
                default:
                    MessageBox.Show(Messages.NOT_SUPPORT_WINDOW_TYPE);
                    throw new NullReferenceException();
            }
        }

        private async Task<NicoNicoUserInfoWindow> CreateNicoNicoUserInfoWindow(CommentViewModel model, Window window)
        {
         
            var parser = await CreateEnvironmentHtmlParser(model.UserId);
            
            var followCount = 0;
            var followerCount = 0;
            var description = String.Empty;

            if (parser.NotNull())
                SetUserDetailInfo(parser, ref followCount, ref followerCount, ref description);


            var viewModel = new NicoNicoUserInfoWindowViewModel()
            {
                UserId = model.UserId,
                UserIcon = model.Image,
                UserName = model.UserName,
                SupportCount = followCount,
                SupporterCount = followerCount,
                ProfileDescription = description
            };

            return new NicoNicoUserInfoWindow(viewModel)
            {
                Owner = window
            };
        }

        private void SetUserDetailInfo(NicoNicoHtmlDataEnvironmentParser parser, ref int follow, ref int follower, ref string description)
        {
            follow = parser.GetFollowCount();
            follower = parser.GetFollowerCount();
            description = parser.GetDescription();
        }

        private async Task<NicoNicoHtmlDataEnvironmentParser> CreateEnvironmentHtmlParser(string userId)
        {
            if (!int.TryParse(userId, out int id)) return null;

            var rest = new NicoNicoRestClient();
            var html = await rest.LoadUserMyPageHtmlAsync(id);

            return new NicoNicoHtmlDataEnvironmentParser(html);
        }


        private async Task<TwicasUserInfoWindow> CreateTwicasUserInfoWindow(CommentViewModel model, Window window)
        {
            var restClient = new TwicasRestClient();

            var jsonModel = await restClient.GetUserInfoAsync(model.UserId, "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImp0aSI6IjJlMTQyNjExYTdiYzhiZTIyZjU1MWJjYmE2ZDZhZGY0YjkyYTJiZjI4MjY5MjNhNTVmZTNkZDg2ZmQ3MGIzMTFmNjdiNWNkNDJjNTYwNWQwIn0.eyJhdWQiOiIxMjc0MTYyNjEyMTMzOTU3NjMyLmMxMWNmMTVhZTE2NGE1YTY4MzVlMjcxNzRhZDYxZTkxNWQxMjE4MGJmMjRlZDgyNWQxYjM1ZjEyN2VhNWZhODciLCJqdGkiOiIyZTE0MjYxMWE3YmM4YmUyMmY1NTFiY2JhNmQ2YWRmNGI5MmEyYmYyODI2OTIzYTU1ZmUzZGQ4NmZkNzBiMzExZjY3YjVjZDQyYzU2MDVkMCIsImlhdCI6MTYwOTQwNzQ3OSwibmJmIjoxNjA5NDA3NDc5LCJleHAiOjE2MjQ5NTk0NzksInN1YiI6IjEyNzQxNjI2MTIxMzM5NTc2MzIiLCJzY29wZXMiOlsicmVhZCIsIndyaXRlIl19.eavI1Vp4MAQds5rBwvUgx4fjczzPxbohtP1JolWpjVxZNfzy5H0YpCbpqqqQnDr56vQa7KofeexzqnqD23ScNj4b5ZtDNcTjnOrKW0xGMuw9lWpj_l7WxexNyajvwJYv5bTz_SoNObVO7K5-djHoI7WCUjrIwBB1ru0ORjkPlDZhUGW76sRsyngN2myNuoaAUGrCubx3_mgTadfJefPonxp1mGqa5oWDsZSATNQTudx6ZX8TRYrMBzIRwje8E5RgsvfZT2jlCwfuoDbRTlfAtCPhOOUksk4DcO3WFgWHp7rQdm10IyocjkTNOCWi7fdTTMZwzMPFr572uD5XCkIY_A");


            var userInfoViewModel = new TwicasUserInfoWindowViewModel()
            {
                ProfileDescription = jsonModel.user.profile,
                UserId = jsonModel.user.id,
                UserName = jsonModel.user.name,
                UserIcon = CreateThumbnail(jsonModel.user.image),
                SupportCount = jsonModel.supporting_count,
                SupporterCount = jsonModel.supporter_count,
                Level = jsonModel.user.level,
                
            };
            
            return new TwicasUserInfoWindow(userInfoViewModel) { Owner = window };
        }
        
        private Uri CreateUri(string uri)
        {
            try
            {
                return new Uri(uri);
            }
            catch
            {
                return null;
            }
        }

        private BitmapImage CreateThumbnail(string uri)
        {
            
            try
            {
                return new BitmapImage(new Uri(uri));
            }
            catch
            {
                return null;
            }
        }

    }
}
