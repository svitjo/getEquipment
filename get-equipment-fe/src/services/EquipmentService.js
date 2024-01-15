import axios from 'axios';
import qs from 'qs';

const apiUrl = 'https://localhost:44320/api/v1/equipment';

const getAllEquipmentByCompany = (companyID) => {
  return axios.get(`${apiUrl}/GetAllEquipmentByCompany?${qs.stringify({companyID:companyID})}`);
};

export default { 
    getAllEquipmentByCompany
 };