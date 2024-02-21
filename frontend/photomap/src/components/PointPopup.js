import React from 'react';
import { Marker, Popup } from 'react-leaflet';

const handleAddFeedback = (point) => {
    // Ваша логика для открытия окна для написания отзыва
  };
  

const PointPopup = ({ point, onClick }) => {
  return (
    <Marker position={[point.latitude, point.longitude]} onClick={onClick}>
        <Popup>
        <h3>{point.title}</h3>
        <p>{point.description}</p>
        <p>{point.pointCategoryId}</p>
        <hr /> {/* Разделитель */}
        <div style={{ display: 'flex', alignItems: 'center' }}>
            <p style={{ marginRight: '10px' }}>Отзывы</p> {/* Надпись "Отзывы" */}
            <button onClick={() => handleAddFeedback(point)}>+</button> {/* Кнопка "+" */}
        </div>
        {point.feedbacks && point.feedbacks.length > 0 ? (
            <ul>
            {point.feedbacks.map((feedback, index) => (
                <li key={index}>{feedback}</li>
            ))}
            </ul>
        ) : (
            <p>Отзывов пока нет</p>
        )}
        {point.imagePathes.length > 0 &&
            <img src={point.imagePathes[0]} alt={point.title} style={{ maxWidth: '100%' }} />
        }
        </Popup>


    </Marker>
  );
};

export default PointPopup;
