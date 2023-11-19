using GetEquipment.Interface;
using GetEquipment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetEquipment.Service
{
    public class CompanyService: ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
        }

        public IEnumerable<Company> GetAll()
        {
            var companies = _companyRepository.GetAll();
            return companies;
        }

        public async Task<Company> GetAsync(Guid companyID)
        {
            Company company = await _companyRepository.GetAsync(companyID);
            return company;
        }
    }
}