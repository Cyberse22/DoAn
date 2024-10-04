import React, { useState } from 'react';
import CalendarModal from './CalendarModal';
import AppointmentFormModal from './AppointmentFormModal';

const BookAppointment = ({ appointments, setAppointments }) => {
  const [isCalendarOpen, setIsCalendarOpen] = useState(false); // Modal của lịch
  const [isFormOpen, setIsFormOpen] = useState(false); // Modal của form nhập nội dung
  const [selectedDate, setSelectedDate] = useState(null); // Lưu ngày đã chọn

  // Mở modal lịch
  const handleBookAppointment = () => {
    setIsCalendarOpen(true);
  };

  // Xử lý khi người dùng chọn ngày
  const handleDateSelect = (date) => {
    setSelectedDate(date);
    setIsCalendarOpen(false); // Đóng modal lịch
    setIsFormOpen(true); // Mở modal form nhập nội dung
  };

  // Xử lý khi người dùng submit form đặt lịch
  const handleFormSubmit = ({ details }) => {
    setAppointments((prevAppointments) => [
      ...prevAppointments,
      { date: selectedDate, details, status: 'Pending' }, // Lưu lịch với trạng thái "Pending"
    ]);
    setIsFormOpen(false); // Đóng modal form
    setSelectedDate(null); // Reset ngày đã chọn
  };

  return (
    <div>
      <button onClick={handleBookAppointment}>Đặt lịch mới</button>

      {/* Modal chọn ngày */}
      <CalendarModal
        isOpen={isCalendarOpen}
        onDateSelect={handleDateSelect}
        onClose={() => setIsCalendarOpen(false)}
      />

      {/* Modal nhập nội dung */}
      {isFormOpen && (
        <AppointmentFormModal
          onSubmit={handleFormSubmit}
          onClose={() => setIsFormOpen(false)}
        />
      )}

      {/* Hiển thị các lịch đã đặt */}
      <h2>Lịch hẹn đang chờ</h2>
      <ul>
        {appointments.map((appointment, index) => (
          <li key={index}>
            {appointment.date.toDateString()} - {appointment.details} - Trạng thái: {appointment.status}
          </li>
        ))}
      </ul>
    </div>
  );
};

export default BookAppointment;
