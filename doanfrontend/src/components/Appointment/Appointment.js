import React, {useContext, useEffect, useState} from 'react';
import BookAppointment from "./BookAppointment";
import AppointmentHistory from "./AppointmentHistory";
import './AppointmentStyles.css';
import Sidebar from "../Commons/Sidebar";
import Footer from "../Commons/Footer";
import {MyUserContext} from "../../configs/Contexts";

const AppointmentPage = () => { // Nhận role từ props
    const [activeTab, setActiveTab] = useState('book'); // Quản lý tab đang được chọn
    const [appointments, setAppointments] = useState([]); // Lưu danh sách lịch hẹn
    const { role } = useContext(MyUserContext); // Lấy role từ UserContext


    useEffect(() => {
        console.log("Received role:", role); // Kiểm tra role nhận được
    }, [role]);
    // Hàm thay đổi tab
    const handleTabClick = (tab) => {
        setActiveTab(tab);
    };

    return (
        <div className="container">
            <Sidebar role={role} /> {/* Truyền role vào Sidebar */}
            <div className="appointment-page">
                <div className="tab-bar">
                    <button
                        className={`tab-button ${activeTab === 'book' ? 'active' : ''}`}
                        onClick={() => handleTabClick('book')}
                    >
                        Đặt lịch
                    </button>
                    <button
                        className={`tab-button ${activeTab === 'history' ? 'active' : ''}`}
                        onClick={() => handleTabClick('history')}
                    >
                        Lịch sử đặt lịch
                    </button>
                </div>

                {/* Hiển thị component theo tab */}
                {activeTab === 'book' && (
                    <BookAppointment
                        appointments={appointments}
                        setAppointments={setAppointments}
                        role={role} // Truyền role cho BookAppointment nếu cần quản lý theo vai trò
                    />
                )}
                {activeTab === 'history' && (
                    <AppointmentHistory
                        appointments={appointments}
                        role={role} // Truyền role cho AppointmentHistory nếu cần quản lý theo vai trò
                    />
                )}
                <Footer />
            </div>
        </div>
    );
};

export default AppointmentPage;
