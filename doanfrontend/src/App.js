import React from 'react';
import {BrowserRouter, Route, Routes, Navigate} from "react-router-dom";
import Login from "./components/Commons/Login";
import Home from "./components/Commons/Home";
import Appointment from "./components/Appointment/Appointment";
import {UserProvider} from "./contexts/UserContext";

const App = () => {
    const [role, setRole] = React.useState("Patient");
    return (
        <UserProvider>
            <BrowserRouter>
                <Routes>
                    <Route path="/" element={<Navigate to="/login"/>}/>
                    <Route path="/login" element={<Login setRole={setRole}/>}/>
                    <Route path="/home" element={<Home role={role}/>}/>
                    <Route path="/appointment" element={<Appointment setRole={setRole}/>}/>
                </Routes>
            </BrowserRouter>
        </UserProvider>
    )
}

export default App;
