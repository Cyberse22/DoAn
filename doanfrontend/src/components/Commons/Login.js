import React, { useContext, useState } from "react";
import { useNavigate } from "react-router-dom";
import { UserContext } from "../../contexts/UserContext";
import APIs, { authApi, endpoints } from "../../configs/APIs";
import cookie from "react-cookies";
import "./CommonStyle.css";

const Login = () => {
    const { dispatch } = useContext(UserContext); // Lấy dispatch từ context
    const [user, setUser] = useState({});
    const [error, setError]  = useState('');
    const [localRole, setLocalRole] = useState('Patient');
    const navigate = useNavigate();

   const login = async (e) => {
       e.preventDefault();
       try {
           let res = await APIs.post(endpoints['login'], {...user})
           console.info(res.data);
           cookie.save('token', res.data);

           let u = await authApi().set(endpoints['current-user']);
           cookie.save('user', u.data)

           dispatch({
               "type" : "login",
               "payload": u.data
           });
           navigate('/home');
       } catch (error) {
           console.log(error);
       }
   }

    return (
        <div className="login-container">
            <h2>Đăng Nhập</h2>
            <form onSubmit={login}>
                <div>
                    <label>Email:</label>
                    <input
                        type="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label>Mật Khẩu:</label>
                    <input
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                </div>
                <div className="role-selector">
                    <label>Chọn Vai Trò:</label>
                    <select value={localRole} onChange={(e) => setLocalRole(e.target.value)}>
                        <option value="Patient">Bệnh Nhân</option>
                        <option value="Doctor">Bác Sĩ</option>
                        <option value="Nurse">Y Tá</option>
                    </select>
                </div>
                <button type="submit">Đăng Nhập</button>
                {error && <p style={{ color: 'red' }}>{error}</p>}
            </form>
        </div>
    );
};

export default Login;
