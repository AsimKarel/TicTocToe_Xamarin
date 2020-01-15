using Foundation;
using System;
using UIKit;

namespace TicTacToe
{
    public partial class ViewController : UIViewController
    {
        private bool player1 = true;
        char[] values = { '0', '1', '2', '3', '4', '5', '6', '7', '8'};
        char? winner = null;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            AIMove();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void Btn_1_TouchUpInside(UIButton sender)
        {
            sender.Tag = 0;
            updateButton(sender);
        }

        partial void Btn_2_TouchUpInside(UIButton sender)
        {
            sender.Tag = 1;
            updateButton(sender);
        }

        partial void Btn_3_TouchUpInside(UIButton sender)
        {
            sender.Tag = 2;
            updateButton(sender);
        }

        partial void Btn_4_TouchUpInside(UIButton sender)
        {
            sender.Tag = 3;
            updateButton(sender);
        }

        partial void Btn_5_TouchUpInside(UIButton sender)
        {
            sender.Tag = 4;
            updateButton(sender);
        }

        partial void Btn_6_TouchUpInside(UIButton sender)
        {
            sender.Tag = 5;
            updateButton(sender);
        }

        partial void Btn_7_TouchUpInside(UIButton sender)
        {
            sender.Tag = 6;
            updateButton(sender);
        }

        partial void Btn_8_TouchUpInside(UIButton sender)
        {
            sender.Tag = 7;
            updateButton(sender);
        }

        partial void Btn_9_TouchUpInside(UIButton sender)
        {
            sender.Tag = 8;
            updateButton(sender);
        }

        private void updateButton(UIButton btn)
        {
            if (winner != null)
            {
                //Game Over
                return;
            }

            int index = Convert.ToInt16(btn.AccessibilityIdentifier);

            if (player1)
            {
                btn.SetBackgroundImage(new UIImage("x_1.png"), UIControlState.Disabled);
                values[index] = 'X';
                if (checkWinCondition() == 1)
                {
                    winner = 'X';
                    winLabel.Hidden = false;
                    btn.Enabled = false;
                    return;
                }
                player1 = !player1;
                btn.Enabled = false;

                //if singleplayer
                AIMove();
            }
            else
            {
                btn.SetBackgroundImage(new UIImage("o_1.png"), UIControlState.Disabled);
                values[index] = 'Y';
                if (checkWinCondition() == 1)
                {
                    winner = 'Y';
                    winLabel.Text = "You Lose";
                    winLabel.Hidden = false;
                    btn.Enabled = false;
                    return;
                }
                player1 = !player1;
                btn.Enabled = false;
            }
            randonlbl.Text = "";
            foreach (char c in values) {
                randonlbl.Text = randonlbl.Text + " " + c;
            }
        }

        void AIMove()
        {
            Random rnd = new Random();
            int position = rnd.Next(0, 9);
            while (values[position] == 'X' || values[position] == 'Y')
            {
                position = rnd.Next(0, 9);
            }
            foreach (UIView view in this.View.Subviews)
            {
                if (view.AccessibilityIdentifier == position.ToString())
                {
                    updateButton((UIButton)view);
                    break;
                }
            }
        }

        private int checkWinCondition()
        {

            //For First Row   
            if (values[0] == values[1] && values[1] == values[2])
            {
                return 1;
            }

            //For Second Row
            else if (values[3] == values[4] && values[4] == values[5])
            {
                return 1;
            }

            //For Third Row
            else if (values[5] == values[6] && values[6] == values[7])
            {
                return 1;
            }

            //For First Column
            else if (values[0] == values[3] && values[3] == values[6])
            {
                return 1;
            }

            //For Second Column
            else if (values[1] == values[4] && values[4] == values[7])
            {
                return 1;
            }

            //Winning Condition For Third Column  

            else if (values[2] == values[5] && values[5] == values[8])
            {
                return 1;
            }
            //Diag
            else if (values[0] == values[4] && values[4] == values[8])
            {
                return 1;
            }

            else if (values[2] == values[4] && values[4] == values[6])
            {
                return 1;
            }

            else if (values[0] != '0' && values[1] != '1' && values[2] != '2' && values[3] != '3' && values[4] != '4' && values[5] != '5' && values[6] != '6' && values[7] != '7' && values[8] != '8')
            {
                return -1;
            }


            return 0;
        }

    }
}