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
            var query = "INSERT INTO Companies (Name, Address, City, State, PostalCode) VALUES(@Name, @Address, @City, @State, @PostalCode);"
                + "SELECT CAST(SCOPE_IDENTITY() as int);";
            var id = _db.Query<int>(query, company).Single();
            company.Id = id;
            return company;
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
            var query = "DELETE FROM Companies WHERE Id = @Id";
            _db.Execute(query, new { id });
        }

        public Company Update(Company company)
        {
            var query = "UPDATE Companies SET Name = @Name, Address = @Address, City = @City, " +
                "State = @State, PostalCode = @PostalCode WHERE Id = @Id";
            _db.Execute(query, company);
            return company;
        }
    }
}
