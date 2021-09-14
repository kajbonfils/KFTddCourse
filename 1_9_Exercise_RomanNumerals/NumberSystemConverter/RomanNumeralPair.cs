namespace NumberSystemConverter
{
    internal class RomanNumeralPair
    {
        public RomanNumeralPair(string romanNumeralRepresentation, int numericValue)
        {
            RomanNumeralRepresentation = romanNumeralRepresentation;
            NumericValue = numericValue;
        }

        public int NumericValue { get; set; }
        public string RomanNumeralRepresentation { get; set; }
    }
}