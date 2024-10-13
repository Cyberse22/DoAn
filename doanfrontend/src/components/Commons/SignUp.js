import React, { useState } from 'react';
import { Form, Button } from 'react-bootstrap';
import './CommonStyle.css'; // Import file CSS đã tạo

const SignUp = () => {
    const [user, setUser] = useState({
        firstName: '',
        lastName: '',
        dateOfBirth: '',
        gender: '',
        email: '',
        phoneNumber: '',
        avatar: '',
        password: '',
        confirmPassword: ''
    });

    const [dob, setDob] = useState(''); // Quản lý ngày sinh
    const [loading, setLoading] = useState(false);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setUser({
            ...user,
            [name]: value
        });
    };

    const handleDateChange = (e) => {
        const value = e.target.value;
        setDob(value); // Cập nhật state với dạng dd-mm-yyyy

        // Đổi thành yyyy-mm-dd khi submit
        const [day, month, year] = value.split("-");
        if (day && month && year) {
            const formattedDate = `${year}-${month}-${day}`; // Format yyyy-mm-dd
            setUser({ ...user, dateOfBirth: formattedDate }); // Cập nhật vào state của user
        }
    };

    const handleAvatarUpload = (e) => {
        const file = e.target.files[0];
        setUser({
            ...user,
            avatar: file
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        setLoading(true);
        console.log("Thông tin người dùng:", user);
        setLoading(false);
    };

    return (
        <div className="signup-container">
            <h1 className="signup-title">ĐĂNG KÝ</h1>
            <Form className="signup-form" onSubmit={handleSubmit}>
                <Form.Group className="mb-3" controlId="firstName">
                    <Form.Label>Họ: </Form.Label>
                    <Form.Control
                        name="firstName"
                        type="text"
                        placeholder="Nhập họ"
                        value={user.firstName}
                        onChange={handleChange}
                        required
                    />
                </Form.Group>

                <Form.Group className="mb-3" controlId="lastName">
                    <Form.Label>Tên: </Form.Label>
                    <Form.Control
                        name="lastName"
                        type="text"
                        placeholder="Nhập tên"
                        value={user.lastName}
                        onChange={handleChange}
                        required
                    />
                </Form.Group>

                <Form.Group className="mb-3" controlId="dateOfBirth">
                    <Form.Label>Ngày sinh</Form.Label>
                    <Form.Control
                        type="text"
                        placeholder="dd-mm-yyyy"
                        value={dob}
                        onChange={handleDateChange}
                        required
                    />
                </Form.Group>

                <Form.Group className="mb-3" controlId="gender">
                    <Form.Label>Giới tính: </Form.Label>
                    <Form.Control
                        name="gender"
                        type="text"
                        placeholder="Nhập giới tính"
                        value={user.gender}
                        onChange={handleChange}
                        required
                    />
                </Form.Group>

                <Form.Group className="mb-3" controlId="email">
                    <Form.Label>Email: </Form.Label>
                    <Form.Control
                        name="email"
                        type="email"
                        placeholder="Nhập email"
                        value={user.email}
                        onChange={handleChange}
                        required
                    />
                </Form.Group>

                <Form.Group className="mb-3" controlId="phoneNumber">
                    <Form.Label>Số điện thoại: </Form.Label>
                    <Form.Control
                        name="phoneNumber"
                        type="text"
                        placeholder="Nhập số điện thoại"
                        value={user.phoneNumber}
                        onChange={handleChange}
                        required
                    />
                </Form.Group>

                <Form.Group className="mb-3" controlId="avatar">
                    <Form.Label>Ảnh đại diện: </Form.Label>
                    <Form.Control
                        type="file"
                        accept="image/*"
                        onChange={handleAvatarUpload} // Xử lý upload file
                        required
                    />
                </Form.Group>

                <Form.Group className="mb-3" controlId="password">
                    <Form.Label>Mật khẩu: </Form.Label>
                    <Form.Control
                        name="password"
                        type="password"
                        placeholder="Nhập mật khẩu"
                        value={user.password}
                        onChange={handleChange}
                        required
                    />
                </Form.Group>

                <Form.Group className="mb-3" controlId="confirmPassword">
                    <Form.Label>Xác nhận mật khẩu: </Form.Label>
                    <Form.Control
                        name="confirmPassword"
                        type="password"
                        placeholder="Nhập lại mật khẩu"
                        value={user.confirmPassword}
                        onChange={handleChange}
                        required
                    />
                </Form.Group>

                <Button variant="success" type="submit" className="mb-1 mt-1 signup-button" disabled={loading}>
                    {loading ? "Đang đăng ký..." : "Đăng ký"}
                </Button>
            </Form>
        </div>
    );
};

export default SignUp;
