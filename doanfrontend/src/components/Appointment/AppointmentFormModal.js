import React, { useState } from 'react';
import Modal from 'react-modal';
import './AppointmentStyles.css';

const AppointmentFormModal = ({ onSubmit, onClose }) => {
  const [details, setDetails] = useState("");

  const handleSubmit = () => {
    onSubmit({ details });
    onClose(); // Đóng modal sau khi submit
  };

  return (
    <Modal
      isOpen={true}
      onRequestClose={onClose}
      shouldCloseOnOverlayClick={true}
      style={{
        overlay: {
          backgroundColor: 'rgba(0, 0, 0, 0.5)',
        },
        content: {
          width: '300px',
          height: 'auto',
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
      <h2>Enter Appointment Details</h2>
      <textarea
        placeholder="Enter details..."
        value={details}
        onChange={(e) => setDetails(e.target.value)}
      />
      <button onClick={handleSubmit}>Submit</button>
    </Modal>
  );
};

export default AppointmentFormModal;
