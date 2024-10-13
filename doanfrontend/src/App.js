import React, { useReducer } from 'react';
import { BrowserRouter, Route, Routes, Navigate } from "react-router-dom";
import Login from "./components/Commons/Login";
import Home from "./components/Commons/Home";
import Appointment from "./components/Appointment/Appointment";
import { MyUserReducer } from "./configs/Reducers";
import { Toaster } from 'react-hot-toast';
import { MyDispatchContext, MyUserContext } from "./configs/Contexts";
import SignUp from "./components/Commons/SignUp";
import Users from "./components/Users/User";
import InvoiceHistory from "./components/Invoices/InvoiceHistory";
import CreateInvoice from "./components/Invoices/CreateInvoice";
import CreatePrescription from "./components/Precrisptions/CreatPrescription";
import Medicine from "./components/Medicines/Medicine";
import ConfirmAppointment from "./components/Appointment/ConfirmAppointment";

const App = () => {
    const [user, useDispatch] = useReducer(MyUserReducer, null);

    return (
        <BrowserRouter>
            <Toaster position="top-right" />
            <MyUserContext.Provider value={user}>
                <MyDispatchContext.Provider value={useDispatch}>
                    <Routes>
                        <Route path="/" element={<Navigate to="/home" />} />
                        <Route path="/login" element={<Login />} />
                        <Route path="/home" element={user ? <Home /> : <Navigate to="/login" />} />
                        <Route path="/appointment" element={user ? <Appointment /> : <Navigate to="/login" />} />
                        <Route path="/signup" element={<SignUp/>}/>
                        <Route path="/users" element={<Users/>}/>
                        <Route path="/invoice-history" element={<InvoiceHistory/>}/>
                        <Route path="/create-invoice" element={<CreateInvoice/>}/>
                        <Route path="/create-prescription" element={<CreatePrescription/>}/>
                        <Route path="/medicine" element={<Medicine/>}/>
                        <Route path="/confirm-appointment" element={<ConfirmAppointment/>}/>
                    </Routes>
                </MyDispatchContext.Provider>
            </MyUserContext.Provider>
        </BrowserRouter>
    );
}

export default App;
