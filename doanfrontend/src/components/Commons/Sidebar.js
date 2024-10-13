import React, {useContext} from 'react';
import {Link, Navigate} from 'react-router-dom';
import './CommonStyle.css';
import {Button} from "react-bootstrap";
import {MyDispatchContext, MyUserContext} from "../../configs/Contexts"; // Tạo CSS cho Sidebar

const Sidebar = ({ role }) => {
    const dispatch = useContext(MyDispatchContext);
    const user = useContext(MyUserContext);

    if (!user || !user.role) {
    return <Navigate to="/login"/>;
    }

    return (
        <div className="sidebar">
            <h2><Link to="/home">Clinic App</Link></h2>
            <ul>
                <li><Link to="/home">Home</Link></li>
                {user.role === 'Nurse' && (<>
                    <li><Link to="/confirm-appointment">Appointment</Link></li>
                    <li><Link to="/create-invoice">Invoice</Link></li>
                    <li><Link to="/shift">Shift</Link></li>
                </>)}
                {user.role === 'Doctor' && (<>
                    <li><Link to="/prescription">Prescription</Link></li>
                    <li><Link to="/medicine">Medicine</Link></li>
                    <li><Link to="/shift">Shift</Link></li>
                </>)}
                {user.role === 'Patient' && (<>
                    <li><Link to="/appointment">Appointment</Link></li>
                    <li><Link to="/invoice-history">Invoice</Link></li>
                </>)}
                {user && <>
                    <li><Link to="/users">Profile</Link></li>
                    <Button className="ms-2" variant="primary" onClick={() => dispatch({ "type": "logout" })}>Đăng xuất</Button>
                </>
                }
            </ul>
        </div>
    );
};

export default Sidebar;