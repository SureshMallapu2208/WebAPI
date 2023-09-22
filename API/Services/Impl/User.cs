using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace API.Services.Impl
{
    public class User : IUser
    {

        private readonly IConfiguration _configuration;
        public User(IConfiguration configuration)
        {

            _configuration = configuration;


        }
        public List<API.User> GetUsersDetails()
        {

            DataTable users = GetDtUsers();

            return (from DataRow dr in users.Rows
                    select new API.User()
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        Mobile = dr["Mobile"].ToString(),

                    }).ToList();
        }


        private DataTable GetDtUsers()
        {
            string constr = this._configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
            SqlConnection con = new SqlConnection(constr);
            string query = "SELECT * FROM [AER].[dbo].[Users]";
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, con);

            sqlDataAdapter.Fill(ds);
            con.Close();

            return ds.Tables[0];
        }
    }
}
