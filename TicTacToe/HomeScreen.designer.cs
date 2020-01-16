// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TicTacToe
{
    [Register ("HomeScreen")]
    partial class HomeScreen
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lbl_score { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIProgressView progressView { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lbl_score != null) {
                lbl_score.Dispose ();
                lbl_score = null;
            }

            if (progressView != null) {
                progressView.Dispose ();
                progressView = null;
            }
        }
    }
}