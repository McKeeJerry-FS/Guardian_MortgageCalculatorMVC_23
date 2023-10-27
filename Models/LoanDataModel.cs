namespace Guardian_MortgageCalculator.Models
{
    public class LoanDataModel
    {
        public LoanDataModel()  // <-- Default Constructor (Empty)
        {
            
        }

        // User Input Values
        public decimal LoanAmount { get; set; } // <== Principal
        public decimal InterestRate { get; set; }
        public int Term { get; set; }


        // Top Stats Calculation Values  <== Can be a new class for further separation
        public decimal TotalCost { get; set; }
        public decimal TotalInterest { get; set; }
        public decimal MonthlyPayment { get; set;}

        // Results
        public List<LoanPayment> LoanPayments { get; set; } = new List<LoanPayment>();

    }
}
