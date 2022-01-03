using System;
namespace Healing.Models
{
    public class Note
    {
        /*
         * How You are Feeling
         * These are the bad symptoms
         */ 
        public Double Anxiety { get; set; }
        public Double Uneasyness { get; set; }
        public Double Heavyness { get; set; }

        /*
         * Happy Feelings 
         */
        public Double Happyness { get; set; }
        public Double Excitement { get; set; }

        /*
         * Expression:
         *  Express how you are feeling
         *  Is it better or worse than the previous day?
         *  Any Thoughts running through your mind?
         *  
         *  Remember Healing is not linear
         *  Be kind to Yourself
         */
        public String Expression { get; set; }

        public Note() { }

        public Note(double anxiety, double uneasyness, double heavyness,
            double happyness, double excitement, string expression)
        {
            Anxiety = anxiety;
            Uneasyness = uneasyness;
            Heavyness = heavyness;
            Happyness = happyness;
            Excitement = excitement;
            Expression = expression;
        }
    }
}
