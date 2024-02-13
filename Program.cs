// using System;
// using System.Collections.Generic;
// using System.Linq;
//
// namespace ATMApp;
// // See https://aka.ms/new-console-template for more information
// using ATM_Project;
//
// public class Program
// {
//     public static string Pg()
//     {
//         Console.WriteLine("Welcome to the ATM");
//
//         void PrintMenu()
//         {
//             Console.WriteLine("1. Check Balance");
//             Console.WriteLine("2. Deposit");
//             Console.WriteLine("3. Withdraw");
//             Console.WriteLine("4. Exit");
//         }
//
//        void Deposit(CardHolder currentUser)
// {
//     Console.WriteLine("Enter the amount you want to deposit: ");
//
//     try
//     {
//         double depositAmount = Convert.ToDouble(Console.ReadLine());
//         if (depositAmount < 0)
//         {
//             throw new ArgumentException("Deposit amount cannot be negative.");
//         }
//         currentUser.setBalance(depositAmount + currentUser.getBalance());
//         Console.WriteLine($"Your new balance is: {currentUser.getBalance()}");
//     }
//     catch (ArgumentException e)
//     {
//         Console.WriteLine("Error: " + e.Message);
//     }
// }
//
//         void Withdraw(CardHolder currentUser)
//         {
//             Console.WriteLine("Enter the amount you want to withdraw: ");
//             double withdrawAmount = Convert.ToDouble(Console.ReadLine());
//             if (withdrawAmount > currentUser.getBalance() || withdrawAmount < 0)
//             {
//                 Console.WriteLine("Insufficient funds or negative amount entered.");
//             }
//             else
//             {
//                 currentUser.setBalance(currentUser.getBalance() - withdrawAmount);
//                 Console.WriteLine($"Your new balance is: {currentUser.getBalance()}");
//                 Console.WriteLine("Please take your cash");
//             }
//         }
//
//         void CurrentBalance(CardHolder currentUser)
//         {
//             Console.WriteLine($"Your current balance is: {currentUser.getBalance()}");
//         }
//
//         CardHolder user1 = new("1234", 1234, "John", "Doe", 1000);
//         CardHolder user2 = new("5678", 5678, "Jane", "Doe", 2000);
//         CardHolder user3 = new("9101", 9101, "Jim", "Doe", 3000);
//         CardHolder user4 = new("1121", 1121, "Jill", "Doe", 4000);
//         CardHolder user5 = new("3141", 3141, "Jack", "Doe", 5000);
//
//         List<CardHolder> cardHolders = [user1, user2, user3, user4, user5];
//
//
//         // Prompt user to enter card number
//         Console.WriteLine("Inset your card: ");
//         string debitCardNum;
//         CardHolder currentUser;
//         while (true)
//             try
//             {
//                 debitCardNum = Console.ReadLine();
//                 //now check the debit card num against db. 
//                 currentUser = cardHolders.FirstOrDefault(a => a.cardNumber == debitCardNum);
//                 if (currentUser != null)
//                     break;
//                 Console.WriteLine("Invalid card number. Please try again");
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine("Invalid card number. Please try again");
//                 throw;
//             }
//
//         Console.WriteLine("Please enter your pin: ");
//         int pin = 0;
//         while (true)
//             try
//             {
//                 pin = int.Parse(Console.ReadLine());
//                 if (pin == currentUser.getPin())
//                     break;
//                 Console.WriteLine("Invalid pin. Please try again");
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine("Invalid pin. Please try again");
//                 throw;
//             }
//
//
//         Console.WriteLine($"Welcome {currentUser.getFristName()} {currentUser.getLastName()}");
//         int choice;
//         do
//         {
//             PrintMenu();
//             try
//             {
//                 choice = int.Parse(Console.ReadLine());
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine("Invalid choice. Please try again");
//                 throw;
//             }
//
//             Console.WriteLine("I am working");
//             switch (choice)
//             {
//                 case 1:
//                     CurrentBalance(currentUser);
//                     break;
//                 case 2:
//                     Deposit(currentUser);
//                     break;
//                 case 3:
//                     Withdraw(currentUser);
//                     break;
//                 case 4:
//                     Console.WriteLine("Thank you for banking with us");
//                     break;
//                 default:
//                     Console.WriteLine("Invalid choice. Please try again");
//                     break;
//             }
//         } while (choice != 4);
//
//         Console.WriteLine("Thank you for banking with us. Goodbye!");
//     }
// }