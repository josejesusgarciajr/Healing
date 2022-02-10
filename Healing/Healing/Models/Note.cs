using System;
namespace Healing.Models
{
    public class Note
    {
        /*
         * ID to identify each Note
         */
        public int ID { get; set; }

        /*
         * Stamp Note with DateTime
         */
        public DateTime DateTime { get; set; }
        public string DateString { get; set; }

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

        public Note(int id, DateTime dateTime, double anxiety, double uneasyness, double heavyness,
            double happyness, double excitement, string expression)
        {
            ID = id;
            //DateString = dateString;
            DateTime = dateTime;
            Anxiety = anxiety;
            Uneasyness = uneasyness;
            Heavyness = heavyness;
            Happyness = happyness;
            Excitement = excitement;
            Expression = expression;
        }

        public void CleanUpApostrophe()
        {
            string cleanUp = "";

            int index = 0;

            while(index < Expression.Length)
            {
                if(Expression[index] == '\'')
                {
                    cleanUp += Expression[index] + "'";
                } else
                {
                    cleanUp += Expression[index];
                }
                index++;
            }
            Expression = cleanUp;
        }
    }
}
