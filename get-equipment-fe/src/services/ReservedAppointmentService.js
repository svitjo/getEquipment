import axios from 'axios';
import qs from 'qs';

const apiUrl = 'https://localhost:44320/api/v1/reservedappointment';

const BookAppointment = (appointmentId, userId, equipmentIds) => {
  return axios.post(`${apiUrl}/ReserveAppointment?${qs.stringify({appointmentId:appointmentId, userId:userId, equipmentIds:equipmentIds})}`);
};

const CancelAppointment = (appointmentId) => {
  return axios.put(`${apiUrl}/CancelAppointment?${qs.stringify({appointmentId:appointmentId})}`);
};

export default { 
    BookAppointment,
    CancelAppointment
 };