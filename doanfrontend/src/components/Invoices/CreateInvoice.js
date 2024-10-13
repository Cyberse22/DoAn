import Sidebar from "../Commons/Sidebar";
import Footer from "../Commons/Footer";
import "./InvoiceStyles.css"
import {useState} from "react";

const CreateInvoice = () => {
    const [invoiceCreated, setInvoiceCreated] = useState(false);
    const [showModal, setShowModal] = useState(false);
    const [showHistoryModal, setShowHistoryModal] = useState(false);
    const [invoiceData, setInvoiceData] = useState({ amount: 0, discount: 0 });
    const [historyInvoices, setHistoryInvoices] = useState([
        { id: 1, status: 'Đã thanh toán', amount: 300000, discount: 50000, date: '10-10-2024' }
    ]);

    // Mẫu Prescription, InvoiceMedicine, và InvoiceService
    const prescriptionData = {
        patientName: 'Nguyễn Văn A',
        doctorName: 'Dr. Lê Hữu B',
        medicines: [{ name: 'Paracetamol', price: 5000, quantity: 10 }],
        services: [{ name: 'Khám tổng quát', price: 200000 }]
    };

    const handleCreateInvoice = () => {
        // Xử lý tạo hóa đơn
        setShowModal(true);
    };

    const handlePayment = () => {
        // Sau khi nhập giá tiền và discount
        setInvoiceCreated(true); // Vô hiệu hóa nút tạo hóa đơn
        setShowModal(false); // Đóng modal
    };

    const openHistoryModal = () => {
        setShowHistoryModal(true);
    };

    return (
        <>
            <Sidebar />

            <div className="create-invoice-container">
                <h2>Tạo Hóa Đơn</h2>

                <div className="prescription-list">
                    <h3>Prescription & Invoice Items</h3>
                    <div className="prescription-details">
                        <p>Bệnh nhân: {prescriptionData.patientName}</p>
                        <p>Bác sĩ: {prescriptionData.doctorName}</p>

                        <h4>Thuốc:</h4>
                        <ul>
                            {prescriptionData.medicines.map((med, index) => (
                                <li key={index}>
                                    {med.name} - {med.price} VND x {med.quantity}
                                </li>
                            ))}
                        </ul>

                        <h4>Dịch vụ:</h4>
                        <ul>
                            {prescriptionData.services.map((service, index) => (
                                <li key={index}>
                                    {service.name} - {service.price} VND
                                </li>
                            ))}
                        </ul>
                    </div>

                    <button
                        className="create-invoice-btn"
                        disabled={invoiceCreated}
                        onClick={handleCreateInvoice}
                    >
                        {invoiceCreated ? 'Chờ thanh toán' : 'Tạo Hóa Đơn'}
                    </button>
                </div>

                <div className="invoice-history">
                    <h3>Lịch sử hóa đơn</h3>
                    <button className="invoice-history-btn" onClick={openHistoryModal}>
                        Xem lịch sử hóa đơn
                    </button>
                </div>

                <Footer />

                {/* Modal tạo hóa đơn */}
                {showModal && (
                    <div className="modal">
                        <div className="modal-content">
                            <h3>Tạo Hóa Đơn</h3>
                            <label>
                                Giá tiền:
                                <input
                                    type="number"
                                    value={invoiceData.amount}
                                    onChange={(e) =>
                                        setInvoiceData({ ...invoiceData, amount: e.target.value })
                                    }
                                />
                            </label>
                            <label>
                                Giảm giá:
                                <input
                                    type="number"
                                    value={invoiceData.discount}
                                    onChange={(e) =>
                                        setInvoiceData({ ...invoiceData, discount: e.target.value })
                                    }
                                />
                            </label>
                            <button className="payment-btn" onClick={handlePayment}>
                                Xác nhận
                            </button>
                            <button className="close-btn" onClick={() => setShowModal(false)}>
                                Đóng
                            </button>
                        </div>
                    </div>
                )}

                {/* Modal lịch sử hóa đơn */}
                {showHistoryModal && (
                    <div className="modal">
                        <div className="modal-content">
                            <h3>Lịch sử hóa đơn</h3>
                            <ul>
                                {historyInvoices.map((invoice) => (
                                    <li key={invoice.id}>
                                        Ngày: {invoice.date}, Số tiền: {invoice.amount} VND, Giảm giá: {invoice.discount} VND, Trạng thái: {invoice.status}
                                    </li>
                                ))}
                            </ul>
                            <button className="close-btn" onClick={() => setShowHistoryModal(false)}>
                                Đóng
                            </button>
                        </div>
                    </div>
                )}
            </div>
        </>
    );
};

export default CreateInvoice;