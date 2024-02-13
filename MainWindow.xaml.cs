// MainWindow.xaml.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ATM_Project;
using Microsoft.VisualBasic;

namespace ATMApp;

public partial class MainWindow : Window
{
    // This list will hold your CardHolder instances.
    readonly List<CardHolder> cardHolders;
    CardHolder currentUserCardHolder;


    public MainWindow()
    {
        InitializeComponent();

        // Initialize your cardholders when the MainWindow is created.
        cardHolders = CardHolderManager.InitializeCardHolders();
        lstOptions.SelectionChanged += lstOptions_SelectionChanged;
    }
    void lstOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string selectedOption = (string)lstOptions.SelectedItem;
        int selectedIndex = lstOptions.SelectedIndex + 1;
        switch (selectedIndex)
        {
            case 1: // Check balance
                CurrentBalance(currentUserCardHolder);
                break;
            case 2: //"2: Deposit":
                double? depositAmount = GetAmountFromUser("Depposit");
                Deposit(currentUserCardHolder, depositAmount);
                break;
            case 3: //"3: Withdraw":
                double? withdrawAmount = GetAmountFromUser("Withdraw");
                Withdraw(currentUserCardHolder, withdrawAmount);
                break;
            case 4: //"4: Exit":
                ExitMenu();
                break;
        }

        lstOptions.SelectedItem = null;
    }

    void ExitMenu()
    {
        txtCardNumber.Text = string.Empty;
        txtPIN.Password = string.Empty;

        currentUserCardHolder = null;

        LoginPanel.Visibility = Visibility.Visible;
        ATMOperationsPanel.Visibility = Visibility.Collapsed;
    }
    double? GetAmountFromUser(string optionType)
    {
        double? amount = null;
        while (amount == null)
        {

            try
            {
                string input = Interaction.InputBox($"Enter {optionType} Amount", optionType, "0");
                if (string.IsNullOrEmpty(input)) return null;
                double depositAmount;
                if (double.TryParse(input, out depositAmount) && depositAmount > 0) return depositAmount;

                MessageBox.Show($"Invalid {optionType} amount. Please enter a positive number.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

            
        }
        return amount;
    }


void Withdraw(CardHolder currentUserCardHolder, double? withdrawAmount)
    {
        try
        {
            if (currentUserCardHolder == null) throw new ArgumentNullException(nameof(currentUserCardHolder));
            if (withdrawAmount == null) return;

            if (withdrawAmount > currentUserCardHolder.getBalance() || withdrawAmount < 0)
            {
                MessageBox.Show("Insufficient funds or negative amount entered.");
            }
            else
            {
                double? newBalance = currentUserCardHolder.getBalance() - withdrawAmount;
                currentUserCardHolder.setBalance(newBalance);
                MessageBox.Show($"Your new balance is: {newBalance}");
                MessageBox.Show("Please take your cash");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"An error occurred: {ex.Message}");
        }
    }

    void Deposit(CardHolder currentUserCardHolder, double? depositAmount)
    {
        double? amount = null;
        // while (amount == null)
        {   
            try
            {
                if (currentUserCardHolder == null) throw new ArgumentNullException(nameof(currentUserCardHolder));
                if (depositAmount == null) return;
                if (depositAmount < 0)
                    throw new ArgumentException($"Deposit amount cannot be negative. {nameof(depositAmount)}");

                double? currentBalance = currentUserCardHolder.getBalance();
                double? newBalance = currentBalance + depositAmount;
                currentUserCardHolder.setBalance(newBalance);
                MessageBox.Show($"Deposit successful. Your new balance is: {newBalance}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }


    void CurrentBalance(CardHolder currentUserCardHolder)
    {
        double? balance = currentUserCardHolder.getBalance();
        MessageBox.Show($"Your current balance is: {balance}");
    }

    void btnLogin_Click(object sender, RoutedEventArgs e)
    {
        string enteredCardNumber = txtCardNumber.Text;
        string enteredPin = txtPIN.Password;

        // Find the CardHolder with the entered card number.
        CardHolder cardHolder = cardHolders.FirstOrDefault(ch => ch.cardNumber == enteredCardNumber);

        if (cardHolder != null && cardHolder.getPin() == enteredPin)
        {
            //set the logged in user to the current user, session management. This info to be used in in ATM  options.
            currentUserCardHolder = cardHolder;
            // Here you would transition to the ATM operations interface
            LoginPanel.Visibility = Visibility.Collapsed;
            ATMOperationsPanel.Visibility = Visibility.Visible;
            ShowOptions();
        }
        else
        {
            MessageBox.Show("Invalid Card Number or PIN");
        }
    }

    // Additional methods and event handlers for your ATM operations
    void ShowOptions()
    {
        lstOptions.Items.Clear();
        
        lstOptions.Items.Add("1: Check balance");
        lstOptions.Items.Add("2: Deposit");
        lstOptions.Items.Add("3: Withdraw");
        lstOptions.Items.Add("4: Exit");
    }
    
    private void btnOpenDatabaseForm_Click(object sender, RoutedEventArgs e)
{
    DatabaseForm dbForm = new DatabaseForm();
    dbForm.ShowDialog();
}
}