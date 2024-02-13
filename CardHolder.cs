namespace ATM_Project;

public class CardHolder(string cardNumber, int pin, string firstName, string lastName, double balance)
{
   public string cardNumber = cardNumber;
    int pin = pin;
    string firstName = firstName;
    string lastName = lastName;
    double balance = balance;

    public string getCardNumber()
    {
        return cardNumber;
    }
    public int getPin()
    {
        return pin;
    }

    public string getFristName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }
    public double getBalance()
    {
        return balance;
    }

    //create setters 
    public void setCardNumber(string newCardNumber)
    {
        cardNumber = newCardNumber;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }


}