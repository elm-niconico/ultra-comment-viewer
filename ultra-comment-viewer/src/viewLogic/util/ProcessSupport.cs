using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;

namespace ultra_comment_viewer.src.viewLogic.util
{
    class ProcessSupport
    {
        private ProcessSupport() { }

        public static void OpenBrowser(string url)
        {
            try
            {
                var psi = new ProcessStartInfo()
                {
                    FileName = url,
                    UseShellExecute = true,
                };

                Process.Start(psi);
            }
            catch
            {
                MessageBox.Show(Mesasge.NOT_VALID_URL);
            }
        }
    }
}
