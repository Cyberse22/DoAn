import React from 'react';
import './CommonStyle.css';

const ProductCard = ({ name, price, description }) => {
    return (
        <div className="product-card">
            <h3 className="product-name">{name}</h3>
            <p className="product-price">{price} VND</p>
            <p className="product-description">{description}</p>
        </div>
    );
};

export default ProductCard;
