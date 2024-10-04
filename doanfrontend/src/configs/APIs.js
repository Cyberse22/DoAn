import axios from "axios";
import cookie from "react-cookies";

const BASE_URL = "https://localhost:44379";
export const endpoints = {
    'login': '/api/Accounts/SignIn',
    'register': '/api/Accounts/SignUp',
    'current-user': '/api/Accounts/CurrentUser',
};

export const authApi = () => {
    return axios.create({
        baseURL: BASE_URL,
        headers: {
            Authorization: cookie.load("token") ? `Bearer ${cookie.load("token")}` : "",
        }
    });
}

export default axios.create({
    baseURL: BASE_URL
})
