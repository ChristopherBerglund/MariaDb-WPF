using MailKit.Net.Imap;
using MailKit.Net.Pop3;
using MariaDb_WPF.Model;
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

        /// <summary>
        /// Funktion för att läsa in nya mail
        /// </summary>
        /// <returns>En int (antal mail)</returns>
        public static int ReadUnOpenedEmails(/*ProgressBar ProgressBAR*/)
        {

            using (var client = new Pop3Client())
            {
                int mails = 0;
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                client.SslProtocols = System.Security.Authentication.SslProtocols.Tls12;
                client.Connect("pop.gmail.com", 995, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(Global.myEmail, Global.myEmailPassword);

                //Ombyggnad om man vill ha en progression bar
                //DateTime latestUpdate = Convert.ToDateTime(Helper.GetLatestUpdate(context));
                //int proce = 0;
                //if (client.Count == 0)
                //{
                //    ProgressBAR.Value = 100;
                //}
                //else
                //{
                //    proce = 100 / client.Count;
                //}

                //För varje oöppnat mail, gör detta:
                for (int i = 0; i < client.Count; i++)
                {
                    //if (ProgressBAR.Value != 100)
                    //{
                    //    ProgressBAR.Value += proce;
                    //}
                    var message = client.GetMessage(i);
                    var subjet = message.Subject;
                
                    var body = message.GetTextBody(MimeKit.Text.TextFormat.Text);
                    //Splittar strängen på detta ifall oväntad text finns efter queryn i mailet:
                    string[] relativData = body.Split("XYXY/(/(XYXY7");
                    //string[] Data = relativData[0].Split("\"");

                    //Dekrypterar meddelandet
                    string decryptedMess = enCryption.Decrypt(relativData[0], Global.secretKey);
                    string[] Data = decryptedMess.Split("\"");

                    //Om det ej finns ngn tidigare tid i db så skapa en för att kunna jämföra värden
                    if (!context.timeSetter.Any())
                    {
                        TimeSetter time = new TimeSetter( new DateTime(1950, 01, 01));
                        context.timeSetter.Add(time);
                        context.SaveChanges();
                    }
                    DateTime LocalDate = context.timeSetter.Select(x => x.TimeSet).First();


                    string[] Sub = subjet.Split("/()/");


                    DateTime IncomeDate = Convert.ToDateTime(Sub[0]);
                    ////////////////
                    if (IncomeDate > LocalDate)
                    {

                        CreateCommand(decryptedMess);

                        //switch (Sub[1])
                        //{
                        //    case "DELETE":
                        //        CreateCommand(decryptedMess);
                        //        break;

                        //    case "PUT":
                        //        CreateCommand(decryptedMess);
                        //        break;

                        //    default:
                        //        CreateCommand(decryptedMess);
                        //        break;
                        //}

                        var thistimeSetter = context.timeSetter.Where(x => x.ID == 1).First();
                        thistimeSetter.TimeSet = IncomeDate;
                        context.timeSetter.Update(thistimeSetter);
                        context.SaveChanges();
                    }

                }
                return mails;
            }
        }

        /// <summary>
        /// Lägger in queryString i Databasen
        /// </summary>
        /// <param name="queryString">Sql Query</param>
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

        //public static void PostQuery(string[] maildata, DateTime latestUpdate, string decryptedMess)
        //{
        //    foreach (var item in maildata)
        //    {
        //        ///Om den hittar ett datetime från mailet. Försöker den skapa ett SQL-command om
        //        try
        //        {
        //            var dateInMailBody = Convert.ToDateTime(item);
        //            //Om det går jämför den med senaste tiden som finns i DB:n
        //            if (dateInMailBody > latestUpdate /*|| Convert.ToDateTime(subjet) > latestUpdate*/)
        //            {
        //                CreateCommand(decryptedMess);
        //                //kanske vill ha räknare för mailen den skapat
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            continue;
        //        }

        //    }
        //}
    }
}



//SUBJECT Datetime                                          CHECK 
//split hitta datetime                                      CHECK    
//Jämför ny tabell som sparar senaste tiden på mailet.      CHECK