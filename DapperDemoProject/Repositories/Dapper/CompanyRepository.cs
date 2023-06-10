using Dapper;
using DapperDemoProject.Entities;
using DapperDemoProject.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DapperDemoProject.Repositories.Dapper
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly IDbConnection _db;

        public CompanyRepository(IConfiguration configuration)
        {
            _db = new SqlConnection(configuration.GetConnectionString("Default"));
        }

        public Company Add(Company company)
        {
            throw new NotImplementedException();
        }

        public Company Find(int id)
        {
            var query = "SELECT * FROM Companies WHERE Id = @CompanyId";
            return _db.Query<Company>(query, new { @CompanyId = id }).Single();
        }

        public List<Company> GetAll()
        {
            var query = "SELECT * FROM Companies";
            return _db.Query<Company>(query).ToList();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Company Update(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
