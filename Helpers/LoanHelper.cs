using Guardian_MortgageCalculator.Helpers.Interfaces;
using Guardian_MortgageCalculator.Models;

namespace Guardian_MortgageCalculator.Helpers
{
    public class LoanHelper : ILoanHelper
    {
        
        private decimal CalcMonthlyInterest(decimal balance, decimal monthlyRate)
        {
            return balance * monthlyRate;
        }

        private decimal CalcMonthlyRate(decimal rate)
        {
            return rate / 1200;
        }

        private decimal CalculatePayment(decimal amount, decimal rate, int term)
        {
            decimal monthlyRate = CalcMonthlyRate(rate);
            double fixedRate = Convert.ToDouble(monthlyRate);
            double fixedAmount = Convert.ToDouble(amount);

            double fixedPayment = (fixedAmount * fixedRate) / (1 - Math.Pow(1 + fixedRate, -term));

            return Convert.ToDecimal(fixedPayment);
        }

        public LoanDataModel GetLoanData(LoanDataModel loan)
        {
            loan.MonthlyPayment = CalculatePayment(loan.LoanAmount, loan.InterestRate, loan.Term);

            decimal balance = loan.LoanAmount;
            decimal totalInterest = 0.0M;
            decimal monthlyRate = CalcMonthlyRate(loan.InterestRate);

            for (int month = 1; month <= loan.Term; month++)
            {
                decimal monthlyInterest = CalcMonthlyInterest(balance, monthlyRate);
                totalInterest += monthlyInterest;
                decimal monthlyPrincipal = loan.MonthlyPayment - monthlyInterest;
                balance -= monthlyPrincipal;

                LoanPayment laonPayment = new LoanPayment()
                {
                    Month = month,
                    Payment = loan.MonthlyPayment,
                    MonthlyPrincipal = monthlyPrincipal,
                    MonthlyInterest = monthlyInterest,
                    TotalInterest = totalInterest,
                    Balance = balance,
                };

                loan.LoanPayments.Add(laonPayment);

                loan.TotalInterest = totalInterest;
                loan.TotalCost = loan.LoanAmount + totalInterest;


            }

            return loan;
        }
    }
}
