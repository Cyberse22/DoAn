import React from 'react';
import "./AppointmentStyles.css"
const AppointmentList = ({ appointments }) => {
  const renderStatus = (status) => {
    switch (status) {
      case 'Pending':
        return 'Waiting for confirmation';
      case 'Confirm':
        return 'Confirmed';
      case 'Cancelled':
        return 'Cancelled';
      case 'ExaminationInProgress':
        return 'In Progress';
      case 'ExamCompleted':
        return 'Completed';
      default:
        return '';
    }
  };

  return (
    <div className="appointment-list">
      {appointments.length === 0 ? (
        <p>No appointments yet</p>
      ) : (
        <ul>
          {appointments.map((appointment, index) => (
            <li key={index}>
              <p>Date: {appointment.date.toDateString()}</p>
              <p>Details: {appointment.details}</p>
              <p>Status: {renderStatus(appointment.status)}</p>
            </li>
          ))}
        </ul>
      )}
    </div>
  );
};

export default AppointmentList;
