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
                MessageBox.Show(Messages.NOT_VALID_URL);
            }
        }

        public static void OpenBrowserSearch(string query)
        {
            var searchUrl = $"https://www.google.com/search?q={query}";
            OpenBrowser(searchUrl);
        }
    }
}
