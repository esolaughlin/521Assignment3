using MessagePack;
using Microsoft.EntityFrameworkCore;

namespace _521Assignment3.Models
{
    public class ActTweet
    {
        public string Tweet { get; set; }
        public double Sentiment { get; set; }
    }
}
