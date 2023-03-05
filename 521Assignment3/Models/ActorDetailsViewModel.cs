using Microsoft.EntityFrameworkCore;
using Tweetinvi.Core.Injectinvi;

namespace _521Assignment3.Models
{
    [Keyless]
    public class ActorDetailsViewModel
    {
        public Actor Actor { get; set; }
        public List<ActTweet>? Tweets { get; set; }
        public double SentimentAvg()
        {
            if (Tweets == null)
            {
                return 0;
            }

            int tweetTowardCalc = 0;
            double totalTweetScore = 0;
            foreach (ActTweet tweet in Tweets){
                if (tweet.Sentiment != 0){
                    tweetTowardCalc++;
                    totalTweetScore += tweet.Sentiment;
                }
            }
            return totalTweetScore / tweetTowardCalc;
        }
    }
}
