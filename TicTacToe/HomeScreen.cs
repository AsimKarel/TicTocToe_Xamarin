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
            var (score, match) = TicTocUserDefaults.getSharedInstance().getCounts();
            lbl_score.Text = "Score: " + score + "/" + match;
            var width = ((double)score / match) * percentView.Frame.Width;
            //percentView.Frame = new CoreGraphics.CGRect(pervcent_parent.Frame.X, pervcent_parent.Frame.Y, width, pervcent_parent.Frame.Height);
        }

        public void showScore(NSNotification notification)
        {
            var (score, match) = TicTocUserDefaults.getSharedInstance().getCounts();
            lbl_score.Text = "Score: " + score + "/" + match;
            var width = ((double)score / match) * percentView.Frame.Width;
            //percentView.Frame = new CoreGraphics.CGRect(pervcent_parent.Frame.X, pervcent_parent.Frame.Y, width, pervcent_parent.Frame.Height);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}