import React from 'react';
import Modal from 'react-modal';
import { Calendar } from 'react-calendar'; // Sử dụng thư viện lịch
import './AppointmentStyles.css';

const CalendarModal = ({ isOpen, onDateSelect, onClose }) => {
  return (
    <Modal
      isOpen={isOpen}
      onRequestClose={onClose}
      shouldCloseOnOverlayClick={true}
      style={{
        overlay: {
          backgroundColor: 'rgba(0, 0, 0, 0.5)',
        },
        content: {
          width: '350px',
          margin: 'auto',
          padding: '20px',
          position: 'absolute',
          top: '50%',
          left: '50%',
          transform: 'translate(-50%, -50%)',
          borderRadius: '10px',
        },
      }}
    >
      <h2>Select a date</h2>
      <Calendar
        onClickDay={(date) => onDateSelect(date)} // Chọn ngày và đóng modal
      />
    </Modal>
  );
};

export default CalendarModal;
