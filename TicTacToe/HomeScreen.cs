using Foundation;
using System;
using UIKit;

namespace TicTacToe
{
    public partial class HomeScreen : UIViewController
    {
        public HomeScreen (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            TicTocUserDefaults.getSharedInstance().initCounts();
            NSNotificationCenter.DefaultCenter.AddObserver(new NSString("ScoreUpdated"), showScore);
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            updateScoreLabel();
        }

        public void showScore(NSNotification notification)
        {
            updateScoreLabel();
        }

        void updateScoreLabel()
        {
            var (score, match) = TicTocUserDefaults.getSharedInstance().getCounts();
            lbl_score.Text = "Score: " + score + "/" + match;
            progressView.SetProgress((float)score / (float)match, true);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}