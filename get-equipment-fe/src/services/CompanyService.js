import axios from 'axios';

const apiUrl = 'https://localhost:44320/api/v1/company/GetAll';

const getCompanies = () => {
  return axios.get(apiUrl);
};

export default { getCompanies };