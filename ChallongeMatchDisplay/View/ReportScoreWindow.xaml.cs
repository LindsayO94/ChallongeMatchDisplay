using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using Fizzi.Applications.ChallongeVisualization.Common;
using Fizzi.Applications.ChallongeVisualization.ViewModel;

namespace Fizzi.Applications.ChallongeVisualization.View
{
    /// <summary>
    /// Interaction logic for ReportScoreWindow.xaml
    /// </summary>
    public partial class ReportScoreWindow : Window, INotifyPropertyChanged
    {
        private int _player1Score;
        public int Player1Score
        {
            get { return _player1Score; }
            set
            {
                _player1Score = value;
                updateConfirmationMessage();
            }
        }

        private int _player2Score;
        public int Player2Score
        {
            get { return _player2Score; }
            set
            {
                _player2Score = value;
                updateConfirmationMessage();
            }
        }

        //True when the score is 2-0, false otherwise. Each of the other four scores are similar.
        private bool _matchScore2_0;
        public bool MatchScore2_0
        {
            get { return _matchScore2_0; }
            set
            {
                this.RaiseAndSetIfChanged("MatchScore2_0", ref _matchScore2_0, value, PropertyChanged);
                updateConfirmationMessage();
            }
        }

        private bool _matchScore2_1;
        public bool MatchScore2_1
        {
            get { return _matchScore2_1; }
            set
            {
                this.RaiseAndSetIfChanged("MatchScore2_1", ref _matchScore2_1, value, PropertyChanged);
                updateConfirmationMessage();
            }
        }

        private bool _matchScore3_0;
        public bool MatchScore3_0
        {
            get { return _matchScore3_0; }
            set
            {
                this.RaiseAndSetIfChanged("MatchScore3_0", ref _matchScore3_0, value, PropertyChanged);
                updateConfirmationMessage();
            }
        }

        private bool _matchScore3_1;
        public bool MatchScore3_1
        {
            get { return _matchScore3_1; }
            set
            {
                this.RaiseAndSetIfChanged("MatchScore3_1", ref _matchScore3_1, value, PropertyChanged);
                updateConfirmationMessage();
            }
        }

        private bool _matchScore3_2;
        public bool MatchScore3_2
        {
            get { return _matchScore3_2; }
            set
            {
                this.RaiseAndSetIfChanged("MatchScore3_2", ref _matchScore3_2, value, PropertyChanged);
                updateConfirmationMessage();
            }
        }

        //True when player 1 wins, False when player 2 wins
        private bool _player1Victory;
        public bool Player1Victory 
        { 
            get { return _player1Victory; } 
            set 
            { 
                this.RaiseAndSetIfChanged("Player1Victory", ref _player1Victory, value, PropertyChanged);
                updateConfirmationMessage();
            } 
        }

        //Confirmation message
        private string _confirmationMessage;
        public string ConfirmationMessage { get { return _confirmationMessage; } set { this.RaiseAndSetIfChanged("ConfirmationMessage", ref _confirmationMessage, value, PropertyChanged); } }

        public ReportScoreWindow()
        {
            InitializeComponent();
        }

        private void updateConfirmationMessage()
        {
            var match = (DisplayMatch)this.DataContext;

            if (Player1Victory) ConfirmationMessage = string.Format("{0} wins {1}-{2}", match.Match.Player1.Name, Player1Score, Player2Score);
            else ConfirmationMessage = string.Format("{0} wins {1}-{2}", match.Match.Player2.Name, Player2Score, Player1Score);
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            //If scores don't make sense, warn the user
            if ((Player1Score >= Player2Score && !Player1Victory) || (Player2Score >= Player1Score && Player1Victory))
            {
                var result = MessageBox.Show(this, "The player marked as the victor does not appear to have a higher score than the loser. Report match as is?", "Warning", 
                    MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.No) return;
            }

            //Scores have been decided
            DialogResult = true;
            Close();
        }

        private void Player1WinsButton_Click(object sender, RoutedEventArgs e)
        {
            Player1Victory = true;
            //Swap the scores around so they correspond to the new winner.
            if (Player2Score > Player1Score)
            {
                int score = Player2Score;
                Player2Score = Player1Score;
                Player1Score = score;
            }
        }

        private void Player2WinsButton_Click(object sender, RoutedEventArgs e)
        {
            Player1Victory = false;
            if (Player1Score > Player2Score)
            {
                int score = Player2Score;
                Player2Score = Player1Score;
                Player1Score = score;
            }
        }

        private void MatchScore2_0Button_Click(object sender, RoutedEventArgs e)
        {
            //Set the scores according to the currently selected winner.
            if (Player1Victory)
            {
                Player1Score = 2;
                Player2Score = 0;
            }
            else
            {
                Player2Score = 2;
                Player1Score = 0;
            }

            //Updates the preview score box
            MatchScore2_0 = true;
            MatchScore2_1 = false;
            MatchScore3_0 = false;
            MatchScore3_1 = false;
            MatchScore3_2 = false;
        }

        private void MatchScore2_1Button_Click(object sender, RoutedEventArgs e)
        {
            if (Player1Victory)
            {
                Player1Score = 2;
                Player2Score = 1;
            }
            else
            {
                Player2Score = 2;
                Player1Score = 1;
            }
            MatchScore2_0 = false;
            MatchScore2_1 = true;
            MatchScore3_0 = false;
            MatchScore3_1 = false;
            MatchScore3_2 = false;
        }

        private void MatchScore3_0Button_Click(object sender, RoutedEventArgs e)
        {
            if (Player1Victory)
            {
                Player1Score = 3;
                Player2Score = 0;
            }
            else
            {
                Player2Score = 3;
                Player1Score = 0;
            }
            MatchScore2_0 = false;
            MatchScore2_1 = false;
            MatchScore3_0 = true;
            MatchScore3_1 = false;
            MatchScore3_2 = false;
        }

        private void MatchScore3_1Button_Click(object sender, RoutedEventArgs e)
        {
            if (Player1Victory)
            {
                Player1Score = 3;
                Player2Score = 1;
            }
            else
            {
                Player2Score = 3;
                Player1Score = 1;
            }
            MatchScore2_0 = false;
            MatchScore2_1 = false;
            MatchScore3_0 = false;
            MatchScore3_1 = true;
            MatchScore3_2 = false;
        }

        private void MatchScore3_2Button_Click(object sender, RoutedEventArgs e)
        {
            if (Player1Victory)
            {
                Player1Score = 3;
                Player2Score = 2;
            }
            else
            {
                Player2Score = 3;
                Player1Score = 2;
            }
            MatchScore2_0 = false;
            MatchScore2_1 = false;
            MatchScore3_0 = false;
            MatchScore3_1 = false;
            MatchScore3_2 = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
	}
}
