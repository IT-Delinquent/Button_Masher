using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ButtonMasher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //player one score
        int player1Score = 0;
        int player2Score = 0;

        //LOAD FORM
        public MainWindow()
        {
            InitializeComponent();
        }

        //UPDATE PLAYER ONE SCORE
        void UpdatePlayerOneScore()
        {
            player1Score++;
            PlayerOneLabel.Content = player1Score;
        }

        //UPDATE PLAYER TWO SCORE
        void UpdatePlayerTwoScore()
        {
            player2Score++;
            PlayerTwoLabel.Content = player2Score;
        }

        //SET WON SCREEN VISIBILITY
        void WonScreenVisibility(bool visible)
        {
            if (visible)
            {
                //show won screen
                PlayerOneLabel.Visibility = Visibility.Collapsed;
                PlayerTwoLabel.Visibility = Visibility.Collapsed;
                ProgressBar1.Visibility = Visibility.Collapsed;
                ProgressBar2.Visibility = Visibility.Collapsed;
                RulesTextBlock.Visibility = Visibility.Collapsed;
                RulesSection.Visibility = Visibility.Collapsed;
                WonLabel.Visibility = Visibility.Visible;
                PlayAgainBorder.Visibility = Visibility.Visible;
                Grid.Background.Opacity = 100;
                MinWidth = 350;
                MinHeight = 170;
            }
            else
            {
                //hide won screen
                PlayerOneLabel.Visibility = Visibility.Visible;
                PlayerTwoLabel.Visibility = Visibility.Visible;
                ProgressBar1.Visibility = Visibility.Visible;
                ProgressBar2.Visibility = Visibility.Visible;
                RulesTextBlock.Visibility = Visibility.Visible;
                RulesSection.Visibility = Visibility.Collapsed;
                WonLabel.Visibility = Visibility.Collapsed;
                PlayAgainBorder.Visibility = Visibility.Collapsed;
                Grid.Background.Opacity = 0;
                MinWidth = 300;
                MinHeight = 145;
            }
            //switch "show" or "hide" in rules textblock
            if (RulesSection.Visibility == Visibility.Visible)
            {
                RulesTextBlock.Text = "Hide Rules";
            }
            else
            {
                RulesTextBlock.Text = "Show Rules";
            }
        }

        //WON SCREEN
        void WonScreen(string player)
        {
            if(player == "1")
            {
                WonScreenVisibility(true);
                WonLabel.Text = "Player 1 won!";
            }else if(player == "2")
            {
                WonScreenVisibility(true);
                WonLabel.Text = "Player 2 won!";
            }
        }

        //RESET SCORES AND BARS
        void Reset()
        {
            player1Score = 0;
            player2Score = 0;
            PlayerOneLabel.Content = player1Score;
            PlayerTwoLabel.Content = player2Score;
            ProgressBar1.Value = player1Score;
            ProgressBar2.Value = player2Score;
        }

        //USER PRESSES BUTTON FORM
        private void WindowKeyDown(object sender, KeyEventArgs e)
        {
            //checking which key was pressed
            if (e.Key == Key.A)
            {
                UpdatePlayerOneScore();
            }else if(e.Key == Key.L)
            {
                UpdatePlayerTwoScore();
            }

            //calculating progress bar value
            ProgressBar1.Value = player1Score;
            ProgressBar2.Value = player2Score;

            //checking if anyone won
            if (ProgressBar1.Value > 99)
            {
                //player one has won
                WonScreen("1");

            }
            else if (ProgressBar2.Value > 99)
            {
                //player two has won
                WonScreen("2");
            }
        }

        //PLAY AGAIN
        private void PlayAgain(object sender, RoutedEventArgs e)
        {
            WonScreenVisibility(false);
            Reset();
        }

        //TOGGLE RULES
        void ToggleRules(object sender, RoutedEventArgs e)
        {
            if (RulesSection.Visibility == Visibility.Collapsed)
            {
                //show rules
                RulesSection.Visibility = Visibility.Visible;
                RulesTextBlock.Text = "Hide Rules";
                SizeToContent = SizeToContent.Height;
                MinHeight = 265;
            }
            else
            {
                //hide rules
                RulesSection.Visibility = Visibility.Collapsed;
                RulesTextBlock.Text = "See Rules";
                SizeToContent = SizeToContent.Height;
                MinHeight = 145;
            }
        }
    }
}
