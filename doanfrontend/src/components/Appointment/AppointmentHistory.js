import React from 'react';

const AppointmentHistory = () => {
  // Dữ liệu giả lập lịch sử đặt lịch
  const appointments = [
    { id: 1, date: '2024-10-01', status: 'Confirmed' },
    { id: 2, date: '2024-09-25', status: 'Cancelled' },
    { id: 3, date: '2024-09-20', status: 'ExamCompleted' },
  ];

  return (
    <div>
      <h2>Lịch sử đặt lịch</h2>
      <ul>
        {appointments.map((appointment) => (
          <li key={appointment.id}>
            Ngày: {appointment.date}, Trạng thái: {appointment.status}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default AppointmentHistory;
