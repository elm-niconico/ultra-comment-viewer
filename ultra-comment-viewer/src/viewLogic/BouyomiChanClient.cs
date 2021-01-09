using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using ultra_comment_viewer.src.commons.extends_mothod;
using ultra_comment_viewer.src.model.parser.bouyomi;
using ultra_comment_viewer.src.viemodel;

namespace ultra_comment_viewer.src.viewLogic
{
    public class BouyomiChanClient
    {
        private const string HOST = "127.0.0.1";

        private const int PORT = 50001;

        private const Int16 VOLUME = -1;

        private const Int16 VOICE = -1;

        private const Int16 SPEED = -1;

        private const Int16 KOE = 0;

        private const Int16 COMMAND = 0x0001;

        private const Int16 CANCEL_ALL_TASK_COMMAND = 0x0040;


        private readonly BouyomiSettingsModel _boyomiSetting = BouyomiSettingsModel.GetInstance();

        private readonly ABBouyomiChanParser _parser;

        public BouyomiChanClient(ABBouyomiChanParser parser)
        {
            this._parser = parser;
        }
     
        public void SendComment(CommentViewModel model)
        {
            if (_boyomiSetting.IsNotUsedBouyomi()) return;


            var comment = (_parser.IsNotUserComment(model.Comment)) ?
                _parser.ParseComment() :
                model.Comment;

            using var client = new TcpClient(HOST, PORT);

            using var stream = client.GetStream();

            using var binaryWriter = new BinaryWriter(stream);



            var buffer = Encoding.UTF8.GetBytes(comment);
            binaryWriter.Write(COMMAND); //コマンド（ 0:メッセージ読み上げ）
            binaryWriter.Write(SPEED);   //速度    （-1:棒読みちゃん画面上の設定）
            binaryWriter.Write(VOICE);    //音程    （-1:棒読みちゃん画面上の設定）
            binaryWriter.Write(VOLUME);  //音量    （-1:棒読みちゃん画面上の設定）
            binaryWriter.Write(KOE);   //声質    （ 0:棒読みちゃん画面上の設定、1:女性1、2:女性2、3:男性1、4:男性2、5:中性、6:ロボット、7:機械1、8:機械2、10001～:SAPI5）
            binaryWriter.Write((byte)0);
            binaryWriter.Write(buffer.Length);
            binaryWriter.Write(buffer);
        }

        public void CancelAllTask()
        {
            if (this.IsBouyomiRunning() == false) return;

            using var client = new TcpClient(HOST, PORT);

            using var stream = client.GetStream();

            using var binaryWriter = new BinaryWriter(stream);

            binaryWriter.Write(CANCEL_ALL_TASK_COMMAND);
        }


        public bool IsBouyomiRunning() => Process.GetProcessesByName("BouyomiChan").Length > 0;

        public void StartRunningBouyomiChan(string path)
        {
            if (IsBouyomiRunning()) return;

            try
            {
                Process.Start(path);
            }
            catch
            {
                MessageBox.Show(Messages.FAILD_START_BOUYOMI);
            }

        }

        
                


    }
}
