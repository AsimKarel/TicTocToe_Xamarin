using Foundation;
using System;
using System.Threading.Tasks;
using UIKit;

namespace TicTacToe
{
    public partial class ViewController : UIViewController
    {
        private bool player1 = true;
        private bool isStarterHuman = true;
        char[] values = { '0', '1', '2', '3', '4', '5', '6', '7', '8'};
        char? winner = null;
        UIColor wincolor = UIColor.FromRGB(0.93f,0.86f,0.24f);

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //AIMove();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }


        partial void Btn_1_TouchUpInside(UIButton sender)
        {
            updateButton(sender);
        }

        partial void Btn_2_TouchUpInside(UIButton sender)
        {
            updateButton(sender);
        }

        partial void Btn_3_TouchUpInside(UIButton sender)
        {
            updateButton(sender);
        }

        partial void Btn_4_TouchUpInside(UIButton sender)
        {
            updateButton(sender);
        }

        partial void Btn_5_TouchUpInside(UIButton sender)
        {
            updateButton(sender);
        }

        partial void Btn_6_TouchUpInside(UIButton sender)
        {
            updateButton(sender);
        }

        partial void Btn_7_TouchUpInside(UIButton sender)
        {
            updateButton(sender);
        }

        partial void Btn_8_TouchUpInside(UIButton sender)
        {
            updateButton(sender);
        }

        partial void Btn_9_TouchUpInside(UIButton sender)
        {
            updateButton(sender);
        }

        private async void updateButton(UIButton btn)
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
                btn.Enabled = false;
                values[index] = 'X';
                player1 = !player1;
                if (checkWinCondition() == 1)
                {
                    setResultView('X');
                    btn.Enabled = false;
                    return;
                }
                else if (checkWinCondition() == -1)
                {
                    setResultView('D');
                    return;
                }

                //if singleplayer
                AIMove();
            }
            else
            {
                await Task.Delay(500);
                btn.SetBackgroundImage(new UIImage("o_1.png"), UIControlState.Disabled);
                values[index] = 'Y';
                player1 = !player1;
                btn.Enabled = false;
                if (checkWinCondition() == 1)
                {
                    setResultView('Y');
                    btn.Enabled = false;
                    return;
                }
                else if (checkWinCondition() == -1)
                {
                    setResultView('D');
                    return;
                }
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
                btn_1.BackgroundColor = wincolor;
                btn_2.BackgroundColor = wincolor;
                btn_3.BackgroundColor = wincolor;
                return 1;
            }

            //For Second Row
            else if (values[3] == values[4] && values[4] == values[5])
            {
                btn_4.BackgroundColor = wincolor;
                btn_5.BackgroundColor = wincolor;
                btn_6.BackgroundColor = wincolor;
                return 1;
            }

            //For Third Row
            else if (values[6] == values[7] && values[7] == values[8])
            {
                btn_7.BackgroundColor = wincolor;
                btn_8.BackgroundColor = wincolor;
                btn_9.BackgroundColor = wincolor;
                return 1;
            }

            //For First Column
            else if (values[0] == values[3] && values[3] == values[6])
            {
                btn_1.BackgroundColor = wincolor;
                btn_4.BackgroundColor = wincolor;
                btn_7.BackgroundColor = wincolor;
                return 1;
            }

            //For Second Column
            else if (values[1] == values[4] && values[4] == values[7])
            {
                btn_2.BackgroundColor = wincolor;
                btn_5.BackgroundColor = wincolor;
                btn_8.BackgroundColor = wincolor;
                return 1;
            }

            //Winning Condition For Third Column  

            else if (values[2] == values[5] && values[5] == values[8])
            {
                btn_3.BackgroundColor = wincolor;
                btn_6.BackgroundColor = wincolor;
                btn_9.BackgroundColor = wincolor;
                return 1;
            }
            //Diag
            else if (values[0] == values[4] && values[4] == values[8])
            {
                btn_1.BackgroundColor = wincolor;
                btn_5.BackgroundColor = wincolor;
                btn_9.BackgroundColor = wincolor;
                return 1;
            }

            else if (values[2] == values[4] && values[4] == values[6])
            {
                btn_3.BackgroundColor = wincolor;
                btn_5.BackgroundColor = wincolor;
                btn_7.BackgroundColor = wincolor;
                return 1;
            }

            else if (values[0] != '0' && values[1] != '1' && values[2] != '2' && values[3] != '3' && values[4] != '4' && values[5] != '5' && values[6] != '6' && values[7] != '7' && values[8] != '8')
            {
                return -1;
            }


            return 0;
        }

        void setResultView(char result)
        {
            result_view.Hidden = false;
            TicTocUserDefaults.getSharedInstance().incrementMatchCount();
            switch (result)
            {
                case 'X':
                    winner = 'X';
                    winLabel.Text = "You Win";
                    result_logo.Image = new UIImage("face_happy_x3");
                    TicTocUserDefaults.getSharedInstance().incrementWin();
                    break;
                case 'Y':
                    winner = 'Y';
                    winLabel.Text = "You Lose";
                    result_logo.Image = new UIImage("face_sad_x3");
                    break;
                case 'D':
                    winner = 'D';
                    winLabel.Text = "That's a draw!";
                    result_logo.Image = new UIImage("face_indifferent_x3");
                    break;
            }

            NSNotificationCenter.DefaultCenter.PostNotificationName("ScoreUpdated", this);

        }

        partial void Btn_done_TouchUpInside(UIButton sender)
        {
            foreach (UIView view in this.View.Subviews)
            {
                if (view is UIButton)
                {
                    ((UIButton)view).Enabled = true;
                    winner = null;
                    result_view.Hidden = true;
                    view.BackgroundColor = null;
                    for (int i = 0; i < 9; i++)
                    {
                        values[i] = i.ToString().ToCharArray()[0];
                    }
                }
            }
            toggleChance();
            
        }

        public void toggleChance()
        {
            isStarterHuman = !isStarterHuman;
            if (isStarterHuman)
            {
                player1 = true;
            }
            else
            {
                player1 = false;
                AIMove();
            }
        }

        partial void Btn_exit_TouchUpInside(UIButton sender)
        {
            DismissViewController(true, null);
        }
    }
}