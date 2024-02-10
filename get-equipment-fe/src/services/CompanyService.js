import axios from 'axios';
import qs from 'qs';

const apiUrl = 'https://localhost:44320/api/v1/company';

const getCompanies = () => {
  return axios.get(`${apiUrl}/GetAll`);
};

const getCompany = (companyID) => {
  return axios.get(`${apiUrl}/GetById?${qs.stringify({companyID:companyID})}`);
};

export default { 
  getCompanies,
  getCompany
 };