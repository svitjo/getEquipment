using GetEquipment.Data;
using GetEquipment.Interface;
using GetEquipment.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.Repository
{
    public class CompanyRepository: ICompanyRepository
    {
        private readonly DataContext _dbContext;

        public CompanyRepository(DataContext dataContext)
        {
            _dbContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
        }

        public IEnumerable<Company> GetAll()
        {
            var companies = _dbContext.Companies;
            return companies;
        }

        public async Task<Company> GetAsync(Guid companyID)
        {
            Company company = await _dbContext.Companies.SingleOrDefaultAsync(c => c.companyID == companyID);
            return company;
        }
    }
}
