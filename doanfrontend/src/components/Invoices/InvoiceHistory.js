import Sidebar from "../Commons/Sidebar";
import Footer from "../Commons/Footer";
import "./InvoiceStyles.css"
import {useState} from "react";

const InvoiceHistory = () => {
    const [unpaidModal, setUnpaidModal] = useState(false);
    const [paidModal, setPaidModal] = useState(false);
    const [selectedInvoice, setSelectedInvoice] = useState(null);

    // Dữ liệu mẫu cho hóa đơn chưa thanh toán và đã thanh toán
    const unpaidInvoices = [
        { id: 1, amount: 500000 },
        { id: 2, amount: 300000 }
    ];

    const paidInvoices = [
        { id: 3, amount: 400000, date: '12-10-2024', status: 'Đã thanh toán' },
        { id: 4, amount: 250000, date: '10-10-2024', status: 'Đã thanh toán' }
    ];

    const handleUnpaidClick = (invoice) => {
        setSelectedInvoice(invoice);
        setUnpaidModal(true);
    };

    const handlePaidClick = (invoice) => {
        setSelectedInvoice(invoice);
        setPaidModal(true);
    };

    const closeModal = () => {
        setUnpaidModal(false);
        setPaidModal(false);
    };

    return (
        <>
            <Sidebar />

            <div className="invoice-history-container">
                <h2>Lịch sử Hóa Đơn</h2>

                <div className="invoice-list">
                    <h3>Chưa Thanh Toán</h3>
                    <ul>
                        {unpaidInvoices.map((invoice) => (
                            <li key={invoice.id} onClick={() => handleUnpaidClick(invoice)}>
                                Hóa đơn #{invoice.id} - {invoice.amount} VND
                            </li>
                        ))}
                    </ul>
                </div>

                <div className="invoice-list">
                    <h3>Đã Thanh Toán</h3>
                    <ul>
                        {paidInvoices.map((invoice) => (
                            <li key={invoice.id} onClick={() => handlePaidClick(invoice)}>
                                Hóa đơn #{invoice.id} - {invoice.amount} VND - Ngày: {invoice.date}
                            </li>
                        ))}
                    </ul>
                </div>

                <Footer />

                {/* Modal cho hóa đơn chưa thanh toán */}
                {unpaidModal && selectedInvoice && (
                    <div className="modal">
                        <div className="modal-content">
                            <h3>Chi tiết Hóa Đơn Chưa Thanh Toán</h3>
                            <p>Số tiền: {selectedInvoice.amount} VND</p>
                            <button className="payment-btn">Thanh Toán</button>
                            <button className="close-btn" onClick={closeModal}>Đóng</button>
                        </div>
                    </div>
                )}

                {/* Modal cho hóa đơn đã thanh toán */}
                {paidModal && selectedInvoice && (
                    <div className="modal">
                        <div className="modal-content">
                            <h3>Chi tiết Hóa Đơn Đã Thanh Toán</h3>
                            <p>Số tiền: {selectedInvoice.amount} VND</p>
                            <p>Trạng thái: {selectedInvoice.status}</p>
                            <p>Ngày thanh toán: {selectedInvoice.date}</p>
                            <button className="close-btn" onClick={closeModal}>Đóng</button>
                        </div>
                    </div>
                )}
            </div>
        </>
    );
};

export default InvoiceHistory;