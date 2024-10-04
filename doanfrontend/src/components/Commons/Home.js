import React, { useContext } from 'react';
import { useNavigate } from 'react-router-dom';
import Sidebar from './Sidebar';
import Footer from './Footer';
import "./CommonStyle.css";
import { UserContext } from "../../contexts/UserContext";
import cookie from "react-cookies";

const Home = () => {
    const navigate = useNavigate();
    const { user, dispatch } = useContext(UserContext); // Lấy user và dispatch từ context

    const handleLogout = () => {
        // Xóa token khỏi cookies
        cookie.remove('token', { path: '/' });
        // Gọi dispatch để cập nhật trạng thái người dùng
        dispatch({ type: 'logout' });
        // Chuyển hướng đến trang đăng nhập
        navigate('/login');
    };

    return (
        <div className="home-container">
            <Sidebar role={user?.role} />
            <div className="main-content">
                {user?.role === 'Patient' && (
                    <div>
                        <h1>Welcome, Patient {user?.name}!</h1>
                        <p>Role: {user?.role}</p> {/* Hiển thị vai trò của người dùng */}
                        <p>This is the home page for patients.</p>
                    </div>
                )}
                {user?.role === 'Doctor' && (
                    <div>
                        <h1>Welcome, Doctor {user?.name}!</h1>
                        <p>Role: {user?.role}</p> {/* Hiển thị vai trò của người dùng */}
                        <p>This is the home page for doctors.</p>
                    </div>
                )}
                {user?.role === 'Nurse' && (
                    <div>
                        <h1>Welcome, Nurse {user?.name}!</h1>
                        <p>Role: {user?.role}</p> {/* Hiển thị vai trò của người dùng */}
                        <p>This is the home page for nurses.</p>
                    </div>
                )}

                <button onClick={handleLogout}>Logout</button>
            </div>
            <Footer />
        </div>
    );
};

export default Home;
