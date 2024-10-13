import React, { useContext, useState } from "react";
import { MyDispatchContext, MyUserContext } from "../../configs/Contexts";
import {Link, Navigate, useNavigate} from "react-router-dom";
import APIs, { authApi, endpoints } from "../../configs/APIs";
import cookie from "react-cookies";
import { Button, Form } from "react-bootstrap";
import "./CommonStyle.css"

const Login = () => {
    const fields = [
        { label: "Email", type: "text", field: "email" },
        { label: "Password", type: "password", field: "password" }
    ];

    const [user, setUser] = useState({ email: "", password: "" });
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    const dispatch = useContext(MyDispatchContext);
    const currentUser = useContext(MyUserContext);
    const nav = useNavigate();

    const login = async (e) => {
        e.preventDefault();
        setLoading(true);
        setError(null); // Reset error message on new attempt

        try {
            const res = await APIs.post(endpoints['login'], user);
            cookie.save("token", res.data);
            const u = await authApi().get(endpoints['current-user']);

            dispatch({ type: "login", payload: u.data });
            console.log(res.data.role, res.data, u.data, u.data.role);
            if (u.data.role === "Patient"){
                nav("/");
            } else if (u.data.role === "Doctor"){
                nav("/")
            } else if (u.data.role === "Nurse"){
                nav("/")
            }
        } catch (error) {
            setError("Login failed. Please check your email and password.");
            console.log(error);
        } finally {
            setLoading(false);
        }
    }

    const change = (event, field) => {
        setUser(current => ({ ...current, [field]: event.target.value }));
    }

    if (currentUser !== null) {
        return <Navigate to="/" />;
    }


    return (
        <div className="login-container">
            <h1 className="login-label text-center">ĐĂNG NHẬP</h1>
            {error && <p className="text-danger">{error}</p>} {/* Display error message */}
            <Form onSubmit={login}>
                {fields.map(f => (
                    <Form.Group className="mb-3" controlId={f.field} key={f.field}>
                        <Form.Label>{f.label}</Form.Label>
                        <Form.Control
                            onChange={e => change(e, f.field)}
                            value={user[f.field]}
                            type={f.type}
                            placeholder={f.label}
                            required // Mark fields as required
                        />
                    </Form.Group>
                ))}
                <Button variant="info" type="submit" className="mb-1 mt-1" disabled={loading}>
                    {loading ? "Loading..." : "Đăng nhập"}
                </Button>
            </Form>
            <p className="mt-3 text-center">
                Bạn chưa có tài khoản? <Link to="/SignUp">Đăng ký ngay</Link> {/* Add signup link */}
            </p>
        </div>
    );
}

export default Login;
