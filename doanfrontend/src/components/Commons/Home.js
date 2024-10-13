import React, { useContext } from 'react';
import { Navigate } from 'react-router-dom';
import Sidebar from './Sidebar';
import Footer from './Footer';
import "./CommonStyle.css";
import {MyUserContext} from "../../configs/Contexts";
import ProductCard from "./ProductCard";
const Home = () => {
    const user = useContext(MyUserContext)
    console.log("Current User in Home:", user);

    if (user === null)
        return <Navigate to="/login" />

    // Tạm thời sử dụng dữ liệu giả để hiển thị sản phẩm
    const products = [
        { name: 'Paracetamol', price: 5000, description: 'Thuốc giảm đau hạ sốt' },
        { name: 'Khám tổng quát', price: 300000, description: 'Dịch vụ khám sức khỏe' },
        { name: 'Vitamin C', price: 10000, description: 'Thuốc bổ sung vitamin' },
        { name: 'Khám chuyên khoa', price: 500000, description: 'Dịch vụ khám chuyên khoa' },
    ];

    return (
        <>
            <div className="container">
                <Sidebar />

                {/* Phần lưới hiển thị sản phẩm */}
                <div className="product-grid">
                    {products.map((product, index) => (
                        <ProductCard
                            key={index}
                            name={product.name}
                            price={product.price}
                            description={product.description}
                        />
                    ))}
                </div>

                <Footer />
            </div>
        </>
    )
}

export default Home;
