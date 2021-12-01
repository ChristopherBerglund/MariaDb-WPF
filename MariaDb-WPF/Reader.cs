using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MariaDb_WPF
{
    public class Reader
    {
        public static MContext context = new MContext();
        
        public static int ReadUnOpenedEmails(ProgressBar ProgressBAR)
        {
            
            using (var client = new Pop3Client())
            {
                int mails = 0;
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.SslProtocols = System.Security.Authentication.SslProtocols.Tls12;
                client.Connect("pop.gmail.com", 995, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(Global.myEmail, Global.myEmailPassword);

                DateTime latestUpdate = Convert.ToDateTime(Helper.GetLatestUpdate(context));
                int proce = 100/client.Count;
                for (int i = 0; i < client.Count; i++)
                {
                    ProgressBAR.Value += proce;

                    var message = client.GetMessage(i);
                    var subjet = message.Subject;
                    var body = message.GetTextBody(MimeKit.Text.TextFormat.Text);
                        string[] relativData = body.Split("XYXY/(/(XYXY7");
                        string[] Data = relativData[0].Split("\"");
                        foreach (var item in Data)
                        {
                            {
                                try
                                {
                                    var date = Convert.ToDateTime(item);
                                    if(date > latestUpdate)
                                    {
                                        CreateCommand(relativData[0]);
                                        mails++;
                                    } 
                                }
                                catch (Exception)
                                {
                                    continue;
                                }
                            }
                        }
                }
                return mails;
            }
        }
        public static void CreateCommand(string queryString)
        {
            string connectionString = Global.ConnectionString;
            using MySqlConnection conn = new MySqlConnection(connectionString);
            {
                MySqlCommand comm = conn.CreateCommand();
                {
                    conn.Open();
                    comm.CommandText = queryString;
                    comm.ExecuteNonQuery();
                }
                
            }
        }
    }
}
