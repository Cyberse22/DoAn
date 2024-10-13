import React, { useState, useEffect } from 'react';
import { Button, Form } from 'react-bootstrap';
import { authApi, endpoints } from "../../configs/APIs"; // Import API
import './Users.css';
import Sidebar from "../Commons/Sidebar";
import Footer from "../Commons/Footer"; // Import file CSS để quản lý giao diện

const User = () => {
    const [currentUser, setCurrentUser] = useState(null);
    const [avatar, setAvatar] = useState('');
    const [isEditingAvatar, setIsEditingAvatar] = useState(false);
    const [newAvatar, setNewAvatar] = useState(null);

    // Lấy thông tin user từ API khi component được mount
    useEffect(() => {
        const fetchUserProfile = async () => {
            try {
                const response = await authApi().get(endpoints['current-user']);
                setCurrentUser(response.data);
                setAvatar(response.data.avatar || 'https://via.placeholder.com/500');
            } catch (error) {
                console.error("Lỗi khi lấy thông tin người dùng:", error);
            }
        };

        fetchUserProfile();
    }, []);

    const handleAvatarClick = () => {
        setIsEditingAvatar(true); // Kích hoạt chế độ cập nhật ảnh đại diện
    };

    const handleAvatarUpload = (e) => {
        const file = e.target.files[0];
        if (file) {
            setNewAvatar(URL.createObjectURL(file)); // Hiển thị ảnh đại diện mới
            setAvatar(file);
        }
    };

    const handleSaveAvatar = () => {
        // Thêm logic lưu ảnh đại diện mới, ví dụ gọi API
        console.log("Ảnh đại diện mới:", avatar);
        setIsEditingAvatar(false);
    };

    if (!currentUser) {
        return <div>Đang tải hồ sơ...</div>;
    }

    return (
    <div className="page-container">
        <div className="page-content">
            <Sidebar className="sidebar"/>
            <div className="user-profile-container">
                <h1>Hồ sơ của {currentUser.firstName} {currentUser.lastName}</h1>
                <div className="avatar-container">
                    <img
                        src={newAvatar || avatar}
                        alt="Avatar"
                        className="avatar"
                        onClick={handleAvatarClick}
                    />
                    {isEditingAvatar && (
                        <div className="avatar-upload">
                            <Form.Control
                                type="file"
                                accept="image/*"
                                onChange={handleAvatarUpload}
                            />
                            <Button variant="primary" onClick={handleSaveAvatar}>Lưu Avatar</Button>
                        </div>
                    )}
                </div>
                <div className="user-info">
                    <p><strong>Họ và Tên: </strong>{currentUser.firstName} {currentUser.lastName}</p>
                    <p><strong>Email: </strong>{currentUser.email}</p>
                    <p><strong>Số điện thoại: </strong>{currentUser.phoneNumber}</p>
                    <p><strong>Ngày sinh: </strong>{currentUser.dateOfBirth}</p>
                    <p><strong>Giới tính: </strong>{currentUser.gender}</p>
                </div>
                <div className="button-container">
                    <Button variant="warning" className="change-password-button">Đổi Mật Khẩu</Button>
                </div>
            </div>
        </div>
        <Footer className="footer"/>
    </div>);
};

export default User;
