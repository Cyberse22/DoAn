import React, { createContext, useReducer, useEffect } from 'react';
import { authApi, endpoints } from "../configs/APIs";
import cookie from "react-cookies";

// Tạo Context cho User
const MyUserReducers = (user, action) => {
  switch (action.type) {
    case 'login':
      return action.payload;
    case 'logout':
      return null;
    default:
      return user;
  }
};

export const UserContext = createContext();

export const UserProvider = ({ children }) => {
  const [user, dispatch] = useReducer(MyUserReducers, null);

  useEffect(() => {
    const token = cookie.load('token');
    if (token) {
      const getUser = async () => {
        try {
          let res = await authApi().get(endpoints["current-user"]);
          console.log("Current User:", res.data); // In thông tin người dùng ra console
          dispatch({ type: 'login', payload: res.data });
          // Kiểm tra vai trò
          if (res.data.role) {
            console.log("User Role:", res.data.role);
          } else {
            console.log("No role found for the user.");
          }
        } catch (error) {
          console.error("Lỗi khi lấy current user:", error);
        }
      };
      getUser().then(r => endpoints.currentUser = r);
    }
  }, []);

  return (
    <UserContext.Provider value={{ user, dispatch }}>
      {children}
    </UserContext.Provider>
  );
};
