using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace biblioteca
{
    class Nav
    {
        private string llegir(string sURL)
        {
            string var_pagina = string.Empty;
            // Capturem la pàgina
            try
            {
                System.Net.WebClient client = new System.Net.WebClient();
                Byte[] pagedata = client.DownloadData(sURL);
                var_pagina = System.Text.Encoding.GetEncoding("iso-8859-1").GetString(pagedata);                
            }
            catch (System.Net.WebException webEx)
            {
                if (webEx.Status == System.Net.WebExceptionStatus.ConnectFailure)
                {
                    System.Windows.Forms.MessageBox.Show("Are you behind a firewall? If so, go through the proxy server");
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Ha d'haver passat alguna cosa:" + Environment.NewLine + webEx.Message);
                }
            }
            return var_pagina;
        }
    }
}
