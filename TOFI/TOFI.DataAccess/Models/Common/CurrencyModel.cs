namespace DAL.Models.Common
{
    public class CurrencyModel: Model
    {
        public string Name { get; set; }


        public override bool Equals(object obj)
        {
            if (obj is CurrencyModel)
            {
                return ((CurrencyModel) obj).Name == Name;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}