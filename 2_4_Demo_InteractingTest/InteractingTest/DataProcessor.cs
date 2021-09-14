namespace InteractingTest
{
    public class DataProcessor
    {
        public int VerifyData( string myData)
        {
            return myData.Length;
        }

        public void ModifyData(ref string myData)
        {
            myData = "BAAARRR";
        }
    }
}