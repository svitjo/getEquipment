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
        private readonly IWorkCalendarRepository _workCalendarRepository;


        public CompanyService(ICompanyRepository companyRepository, IWorkCalendarRepository workCalendarRepository)
        {
            _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
            _workCalendarRepository = workCalendarRepository ?? throw new ArgumentNullException(nameof(workCalendarRepository));
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

        public async Task<WorkCalendar> GetWorkCalendar(Guid companyID)
        {
            WorkCalendar workCalendar = await _workCalendarRepository.GetAsync(companyID);
            return workCalendar;
        }
    }
}