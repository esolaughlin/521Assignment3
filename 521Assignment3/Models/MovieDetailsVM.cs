namespace _521Assignment3.Models
{
    public class MovieDetailsVM
    {
        public Movie Movie { get; set; }
        public List<MovieTweet>? Tweets { get; set; }
        public double SentimentAvg(){
            if (Tweets == null) return 0;
            int tweetTowardCalc = 0;
            double totalScore = 0;
            foreach (MovieTweet tweet in Tweets){
                if (tweet.Sentiment != 0){
                    tweetTowardCalc++;
                    totalScore += tweet.Sentiment;
                }
            }
            return totalScore / tweetTowardCalc;
        }
    }
}
