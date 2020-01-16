using System;
using Foundation;

namespace TicTacToe
{
    public class TicTocUserDefaults
    {
        static TicTocUserDefaults shared;
        private TicTocUserDefaults()
        {
        }

        public static TicTocUserDefaults getSharedInstance()
        {
            if (shared == null)
            {
                shared = new TicTocUserDefaults();
            }
            return shared;
        }

        public void incrementWin() {
            var score = NSUserDefaults.StandardUserDefaults.IntForKey("score");
            score = score+1;
            NSUserDefaults.StandardUserDefaults.SetInt(score, "score");
            NSUserDefaults.StandardUserDefaults.Synchronize();
        }

        public void incrementMatchCount()
        {

            var matches = NSUserDefaults.StandardUserDefaults.IntForKey("matches");
            matches = matches+1;
            NSUserDefaults.StandardUserDefaults.SetInt(matches, "matches");
            NSUserDefaults.StandardUserDefaults.Synchronize();
        }

        public void initCounts()
        {
            var matches = NSUserDefaults.StandardUserDefaults.IntForKey("matches");
            if (matches == 0)
            {
                NSUserDefaults.StandardUserDefaults.SetInt(0, "matches");
                NSUserDefaults.StandardUserDefaults.SetInt(0, "score");
                NSUserDefaults.StandardUserDefaults.Synchronize();
            }
            
        }

        public (int, int) getCounts()
        {
            var score = NSUserDefaults.StandardUserDefaults.IntForKey("score");
            var matches = NSUserDefaults.StandardUserDefaults.IntForKey("matches");
            return ((int)score, (int)matches);
            
        }



    }
}
