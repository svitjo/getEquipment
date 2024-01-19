// CompanyDetails.js

import React, { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import companyService from '../services/CompanyService';
import equipmentService from '../services/EquipmentService';
import appointmentService from '../services/AppointmentService';

const CompanyDetails = () => {
  const { companyID } = useParams();
  const [company, setCompany] = useState({});
  const [equipmentList, setEquipmentList] = useState([]);
  const [appointmentList, setAppointmentList] = useState([]);
  const [workCalendarID, setWorkcalendarID] = useState(null);

  const handleCheckboxChange = (equipmentId) => {
    // Implement logic to handle checkbox change (e.g., update selected equipment)
  };

  useEffect(() => {
    companyService.getCompany(companyID)
      .then((response) => {
        setCompany(response.data);
        console.log(response.data)
      })
      .catch((error) => {
        console.error('Error fetching company details:', error);
      });

      equipmentService.getAllEquipmentByCompany(companyID)
      .then((response) => {
        setEquipmentList(response.data);
        console.log(response.data)
      })
      .catch((error) => {
        console.error('Error fetching equipment list:', error);
      });

      companyService.getWorkCalendar(companyID)
      .then((response) => {
        setWorkcalendarID(response.data.calendarId);
        console.log(response.data)
      })
      .catch((error) => {
        console.error('Error fetching company details:', error);
      });

      appointmentService.getNonReservedAppointments(workCalendarID)
      .then((response) => {
        setAppointmentList(response.data);
        console.log(response.data)
      })
      .catch((error) => {
        console.error('Error fetching equipment list:', error);
      });
  }, [companyID, workCalendarID]);

  return (
    <div className="container">
      <header>
        <h1>{company.name}</h1>
        <p>{company.address}</p>
      </header>
      <div>
        <h2>Equipment List:</h2>
        <ul>
          {equipmentList &&  equipmentList.map((equipment) => (
            <li key={equipment.equipmentID}>
              <input
                type="checkbox"
                id={`equipmentCheckbox_${equipment.equipmentid}`}
                onChange={() => handleCheckboxChange(equipment.equipmentid)}
              />
              <label htmlFor={`equipmentCheckbox_${equipment.equipmentid}`}>
                {equipment.name} - {equipment.description} - {equipment.averageRating}
              </label>
            </li>
          ))}
        </ul>
      </div>
      <div>
        <h2>Non-Reserved Appointments:</h2>
        <ul>
        {appointmentList && appointmentList.map((appointment) => (
        <li key={appointment.appointmentID}>
          {appointment.durationH}
        </li>
      ))}
        </ul>
      </div>
    </div>
  );
};

export default CompanyDetails;
