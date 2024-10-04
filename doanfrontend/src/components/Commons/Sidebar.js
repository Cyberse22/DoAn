import React from 'react';
import { Link } from 'react-router-dom';
import './CommonStyle.css'; // Tạo CSS cho Sidebar

const Sidebar = ({ role }) => {
    return (
        <div className="sidebar">
            <h2>Menu</h2>
            <ul>
                <li><Link to="/home">Home</Link></li>
                <li><Link to="/appointment">Appointment</Link></li>
                {role === 'Nurse' && (
                    <li><Link to="/invoice">Invoice</Link></li> // Thêm link cho Nurse
                )}
                <li><Link to="/settings">Settings</Link></li>
            </ul>
        </div>
    );
};

export default Sidebar;