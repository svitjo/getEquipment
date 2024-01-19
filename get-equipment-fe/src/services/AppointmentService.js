import axios from 'axios';
import qs from 'qs';

const apiUrl = 'https://localhost:44320/api/v1/appointment';

const getAppointmentsByAdmin = (adminID) => {
  return axios.get(`${apiUrl}/GetAllAppointmentsByAdmin?${qs.stringify({adminID:adminID})}`);
};

const getAppointment = (appointmentID) => {
  return axios.get(`${apiUrl}/GetAsync?${qs.stringify({appointmentID:appointmentID})}`);
};

const getNonReservedAppointments = (workcalendarID) => {
    return axios.get(`${apiUrl}/GetNonReservedAppointments?${qs.stringify({workcalendarID:workcalendarID})}`);
  };

const getAllAppointmentsByCompany = (workcalendarID) => {
    return axios.get(`${apiUrl}/GetAllAppointmentsByCompany?${qs.stringify({workcalendarID:workcalendarID})}`);
};

export default { 
    getAppointmentsByAdmin,
    getAppointment,
    getNonReservedAppointments,
    getAllAppointmentsByCompany
 };