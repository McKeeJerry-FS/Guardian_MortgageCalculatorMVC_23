using Guardian_MortgageCalculator.Models;

namespace Guardian_MortgageCalculator.Helpers.Interfaces
{
    public interface ILoanHelper
    {
        LoanDataModel GetLoanData(LoanDataModel loan);
        private decimal CalculatePayment(decimal amount, decimal rate, int term) 
        {
            decimal monthlyRate = CalcMonthlyRate(rate);
            double fixedRate = Convert.ToDouble(monthlyRate);
            double fixedAmount = Convert.ToDouble(amount);

            double fixedPayment = (fixedAmount * fixedRate) / (1 - Math.Pow(1 + fixedRate, -term));

            return Convert.ToDecimal(fixedPayment);
        }
        private decimal CalcMonthlyInterest(decimal balance, decimal monthlyRate)
        {
            return balance * monthlyRate;
        }
        private decimal CalcMonthlyRate(decimal rate)
        {
            return rate / 1200;
        }
    }
}
