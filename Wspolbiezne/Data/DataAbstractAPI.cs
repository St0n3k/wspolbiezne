namespace Data
{
    public abstract class DataAbstractAPI
    {
        public static DataAbstractAPI createApi()
        {
            return new DataAPI();
        }

        internal sealed class DataAPI : DataAbstractAPI
        {

        }
    }
}
