namespace DataAccess.Repository
{
    using System.Configuration;

    public class OracleConexion
    {
        protected string srtOracle = string.Empty;

        public OracleConexion()
        {
            srtOracle = ConfigurationManager.ConnectionStrings["oracleConex"].ConnectionString;
        }
    }
}