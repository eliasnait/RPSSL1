using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace AvaloniaApplication1
{
    public partial class MainWindow : Window
    {
        private int playerScore = 0;
        private int computerScore = 0;
        private const int WinningScore = 3;
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnChoiceClick(object? sender, RoutedEventArgs e)
        {
            if (playerScore >= WinningScore || computerScore >= WinningScore)
                return;

            var btn = sender as Button;
            string playerChoice = btn?.Content?.ToString() ?? "";
            string computerChoice = GetRandomChoice();

            string result;
            if (playerChoice == computerChoice)
            {
                result = "Uafgjort!";
            }
            else if (
                (playerChoice == "Rock" && (computerChoice == "Scissors" || computerChoice == "Lizard")) ||
                (playerChoice == "Paper" && (computerChoice == "Rock" || computerChoice == "Spock")) ||
                (playerChoice == "Scissors" && (computerChoice == "Paper" || computerChoice == "Lizard")) ||
                (playerChoice == "Spock" && (computerChoice == "Rock" || computerChoice == "Scissors")) ||
                (playerChoice == "Lizard" && (computerChoice == "Spock" || computerChoice == "Paper"))
            )
            {
                result = "Du vandt runden!";
                playerScore++;
            }
            else
            {
                result = "Computeren vandt runden!";
                computerScore++;
            }

            InfoText.Text = $"Du: {playerChoice} | Comp: {computerChoice}\n{result}";
            ScoreText.Text = $"Spiller: {playerScore} - Computer: {computerScore}";

            if (playerScore == WinningScore)
                InfoText.Text += "\n🎉 Du vandt spillet!";
            else if (computerScore == WinningScore)
                InfoText.Text += "\n💻 Computeren vandt spillet!";
        }

        private void OnResetClick(object? sender, RoutedEventArgs e)
        {
            playerScore = 0;
            computerScore = 0;
            InfoText.Text = "Vælg en form";
            ScoreText.Text = "Spiller: 0 - Computer: 0";
        }

        private string GetRandomChoice()
        {
            string[] choices = { "Rock", "Paper", "Scissors", "Spock", "Lizard" };
            return choices[random.Next(choices.Length)];
        }
    }
}

