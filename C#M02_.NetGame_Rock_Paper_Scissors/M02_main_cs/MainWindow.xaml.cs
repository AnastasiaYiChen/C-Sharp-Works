using System;
using System.Windows;
using System.Windows.Media.Imaging;


namespace Rock_Paper_Scissors_v01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// Author:Yi Chen
    public partial class MainWindow : Window
    {
        //declaring the variables for this game

      
        //enemy choice options stored inside an array for easy access
        string[] ComputerchoiseList = { "rock_r", "paper_r", "scissor_r", "rock_r", "scissor_r", "paper_r", "paper_r", "scissor_r", "rock_r", };
        string[] PlayerchoiseList = {"paper", "rock", "scissor", "scissor", "rock", "paper", "rock", "paper", "scissor", "rock", "scissor", };
        public int randomNumber = 0;
        public int randomNumberp = 0;
       
        Random rnd = new Random();
        string ComputerChoice;
        string playerChoice;
        int playerScore = 0;
        int computerScore = 0;
       


        public MainWindow()
        {
            InitializeComponent();
            playerChoice = "none";
        }

        /**
         * @R_Btn_Click
         * set rock button click event: when click button the image change to rock.
         */
        private void R_Btn_Click(object sender, RoutedEventArgs e)
        {
            User.Source = new BitmapImage(new Uri(@"/Images/rock.jpg", UriKind.Relative));
            Player_LB.Content = "Player";
            playerChoice = "rock";
        }

        /**
         * @R_Btn_Click
         * set paper button click event: when click button the image change to paper.
         */
        private void P_Btn_Click(object sender, RoutedEventArgs e)
        {
            User.Source = new BitmapImage(new Uri(@"/Images/paper.jpg", UriKind.Relative));
            Player_LB.Content = "Player";
            playerChoice = "paper";
        }

        /**
         * @R_Btn_Click
         * set scissor button click event: when click button the image change to scissor.
         */
        private void S_Btn_Click(object sender, RoutedEventArgs e)
        {
            User.Source = new BitmapImage(new Uri(@"/Images/scissors.jpg", UriKind.Relative));
            Player_LB.Content = "Player";
            playerChoice = "scissors";
        }


        /**
         * @PlayGame_LB_Click
         * Computer play with computer which they pick the image randomly in same(almost) time
         */
        private void PlayGame_LB_Click(object sender, RoutedEventArgs e)
        {
            Player_LB.Content = "Computer Player";
            randomNumber = rnd.Next(0, ComputerchoiseList.Length);
            randomNumberp = rnd.Next(0, PlayerchoiseList.Length);
            ComputerChoice = ComputerchoiseList[randomNumber];
            playerChoice = PlayerchoiseList[randomNumberp];


            switch (playerChoice)
            {
                case "rock":
                    User.Source = new BitmapImage(new Uri(@"/Images/rock.jpg", UriKind.Relative));
                    break;

                case "paper":
                    User.Source = new BitmapImage(new Uri(@"/Images/paper.jpg", UriKind.Relative));
                    break;

                case "scissor":
                    User.Source = new BitmapImage(new Uri(@"/Images/scissors.jpg", UriKind.Relative));
                    break;

            }


            switch (ComputerChoice)
            {
                case "rock_r":
                    Computer.Source = new BitmapImage(new Uri(@"/Images/rock_r.jpg", UriKind.Relative));                  
                    break;

                case "paper_r":
                    Computer.Source = new BitmapImage(new Uri(@"/Images/paper_r.jpg", UriKind.Relative));                    
                    break;

                case "scissor_r":
                    Computer.Source = new BitmapImage(new Uri(@"/Images/scissors_r.jpg", UriKind.Relative));                    
                    break;

            }

            CheckGame();

        }

        /**
         * Computer will choose a card randomly 
         * 
         */

        private void Computer_play_Btn_Click(object sender, RoutedEventArgs e)
        {
            randomNumber = rnd.Next(0, ComputerchoiseList.Length);
            
            ComputerChoice = ComputerchoiseList[randomNumber];


            switch (ComputerChoice)
            {
                case "rock_r":
                    Computer.Source = new BitmapImage(new Uri(@"/Images/rock_r.jpg", UriKind.Relative));
                    break;

                case "paper_r":
                    Computer.Source = new BitmapImage(new Uri(@"/Images/paper_r.jpg", UriKind.Relative));
                    break;

                case "scissor_r":
                    Computer.Source = new BitmapImage(new Uri(@"/Images/scissors_r.jpg", UriKind.Relative));
                    break;

            }

            CheckGame();


        }

        /**
         * @CheckGame()
         * Do the calculation and out put score to the textbox
         * 
         */
        private void CheckGame()
        {
            //computer
            if (playerChoice == "rock" && ComputerChoice == "paper_r")
            {
                computerScore += 1;
                ComputerScore_LB.Content = computerScore;
                Winner_LB.Content = "Computer Wins, Paper Covers Rock";
            }
            else if (playerChoice == "scissor" && ComputerChoice == "rock_r")
            {
                computerScore += 1;
                ComputerScore_LB.Content = computerScore;
                Winner_LB.Content = "Computer Wins, Rock breaks Scissors";
                
            }
            else if (playerChoice == "paper" && ComputerChoice == "scissor_r")
            {
                computerScore += 1;
                ComputerScore_LB.Content = computerScore;
                Winner_LB.Content = "Computer Wins, Scissor cuts Paper";

            }

            //player
            else if (playerChoice == "paper" && ComputerChoice == "rock_r")
            {
                playerScore += 1;
                PlayerScore_LB.Content = playerScore;
                Winner_LB.Content = "Player Wins, Paper Covers Rock";
            }

            else if (playerChoice == "scissor" && ComputerChoice == "paper_r")
            {
                playerScore += 1;
                PlayerScore_LB.Content = playerScore;
                Winner_LB.Content = "Player Wins, Scissor cuts Paper";
            }

            else if (playerChoice == "rock" && ComputerChoice == "scissor_r")
            {
                playerScore += 1;
                PlayerScore_LB.Content = playerScore;
                Winner_LB.Content = "Player Wins, Rock breaks Scissors";
            }
            else if (playerChoice == "none")
            {
                Winner_LB.Content = "Make a choice";
            }
            else
            {
                Winner_LB.Content = "Draw!!!";
            }

           
        }

        /**
         * @St_Btn_Click
         * when stop button be pressed the final result will be out put to win textbox
         * initalize the scores.
         */

        private void St_Btn_Click(object sender, RoutedEventArgs e)
        {
            User.Source = new BitmapImage(new Uri(@"/Images/User.jpg", UriKind.Relative));
            Computer.Source = new BitmapImage(new Uri(@"/Images/Robot.jpg", UriKind.Relative));
            Winner_LB.Content = "Player: " + playerScore + " - " + "CPU: " + computerScore;
           
            if (playerScore > computerScore)
            {
                Winner_LB.Content ="Player Won!!!  " + "Player: " + playerScore + " - " + "Computer: " + computerScore;
            }
            else if(computerScore > playerScore)
            {
                Winner_LB.Content = "Computer Won!!!  " + "Player: " + playerScore + " - " + "Computer: " + computerScore;
            }
            else
            {
                Winner_LB.Content = "Tied!!!  " + "Player: " + playerScore + " - " + "Computer: " + computerScore;
            }

            computerScore = 0;
            playerScore = 0;
            PlayerScore_LB.Content = 0;
            ComputerScore_LB.Content = 0;
            
        }
    }
}
