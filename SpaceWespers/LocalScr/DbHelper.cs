using System.Data.SqlClient;
namespace SpaceWespers.LocalScr
{
    public static class DbHelper
    {
        private static string connection = GetConnectionString();
        static private string GetConnectionString()
        {
            //local
            //return @"Data Source = (local)\SQLEXPRESS;Initial Catalog = SpaceDataBase; Integrated Security = True; TrustServerCertificate = True";
            //server
            return @"workstation id=SpaceDataBase.mssql.somee.com;packet size=4096;user id=AcroMan_SQLLogin_1;pwd=q54i3ozek2;data source=SpaceDataBase.mssql.somee.com;persist security info=False;initial catalog=SpaceDataBase;TrustServerCertificate=True";
        }
        public static void ExecuteWithoutAnswer(string str)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(str, conn);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                conn.Close();
            }
        }
        public static List<object> ExecuteWithAnswer(string str)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                List<object> result = new List<object>();
                SqlCommand cmd = new SqlCommand(str, conn);
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            result.Add(reader.GetValue(0));
                            result.Add(reader.GetValue(1));
                            result.Add(reader.GetValue(2));
                            result.Add(reader.GetValue(3));
                            result.Add(reader.GetValue(4));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                conn.Close();
                return result;
            }
        }
        public static string ExecuteQueryWithAnswer(string query)
        {
            using (SqlConnection conn = new SqlConnection(connection))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                var answer = cmd.ExecuteScalar();
                conn.Close();

                if (answer != null) return answer.ToString();
                else return null;
            }
        }
    }
}
//public interface IExecute
//{
//    public List<object> Execute(SqlCommand cmd);
//}
//class Value5Execute:IExecute
//{
//    public List<object> Execute(SqlCommand cmd)
//    {
//        List<object> result = new List<object>();
//        SqlDataReader reader = cmd.ExecuteReader();
//        if (reader.HasRows)
//        {
//            while (reader.Read())
//            {
//                result.Add(reader.GetValue(0));
//                result.Add(reader.GetValue(1));
//                result.Add(reader.GetValue(2));
//                result.Add(reader.GetValue(3));
//                result.Add(reader.GetValue(4));
//            }
//        }
//        return result;
//    }
//}
