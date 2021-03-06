using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariaDb_WPF
{
    public class Helper
    {

        public static string GetLatestUpdate(MContext context)
        {
            DateTime latestCom = new DateTime(1950, 1, 1);
            DateTime latestDis = new DateTime(1950, 1, 1);
            DateTime latestPos = new DateTime(1950, 1, 1);

            var latestPost = context.Posts.OrderByDescending(x => x.DateTime).ToList();
            var latestComments = context.Comments.OrderByDescending(x => x.date).ToList();
            var latestDiscussion = context.Discussion.OrderByDescending(x => x.createddate).ToList();
            if(latestPost.Count > 0 || latestDiscussion.Count > 0 || latestDiscussion.Count > 0)
            {
                if(latestComments.Count > 0)
                {
                     latestCom = Convert.ToDateTime(latestComments[0].date);
                }
                if(latestPost.Count > 0)
                {
                     latestPos = Convert.ToDateTime(latestPost[0].DateTime);
                }
                if(latestDiscussion.Count > 0)
                {
                     latestDis = Convert.ToDateTime(latestDiscussion[0].createddate);
                }
                List<DateTime> alltime = new List<DateTime>() { latestCom, latestDis, latestPos };
                DateTime alltimer = alltime.Max();
                return alltimer.ToString();
            }
            else
            {
                DateTime random = new DateTime(1950, 1, 1);
                return random.ToString();
            }
        }
    }
}
