// PointPopup.js

import React, { useState } from 'react';
import { Marker, Popup } from 'react-leaflet';
import AddFeedback from './AddFeedback';
import '../css/PointPopup.css';

const PointPopup = ({ point, onClick }) => {
  const [isAddingFeedback, setIsAddingFeedback] = useState(false);

  const openAddFeedbackModal = () => {
    setIsAddingFeedback(true);
  };

  const closeAddFeedbackModal = () => {
    setIsAddingFeedback(false);
  };

  const handleFeedbackAdded = () => {
    setIsAddingFeedback(false);
  };

  const renderRatingStars = (rating) => {
    const stars = '★'.repeat(rating) + '☆'.repeat(5 - rating);
    return <span style={{ fontSize: '20px', color: 'gold' }}>{stars}</span>;
  };

  return (
    <Marker position={[point.latitude, point.longitude]} onClick={onClick}>
      <Popup>
        <h3>{point.title}</h3>
        <p>{point.description}</p>
        <p>{point.pointCategoryId}</p>
        <hr />
        <div style={{ display: 'flex', alignItems: 'center' }}>
          <p style={{ marginRight: '10px' }}>Отзывы</p>
          <button className="add-feedback-button" onClick={openAddFeedbackModal}></button>
        </div>
        {point.feedbacks && point.feedbacks.length > 0 ? (
          <div>
            {point.feedbacks.map((feedback, index) => {
              const [text, author, rating] = feedback.split(' - ');

              return (
                <div key={index}>
                  <p>
                    {author} {renderRatingStars(parseInt(rating))}
                  </p>
                  <p>{text}</p>
                  <hr />
                </div>
              );
            })}
          </div>
        ) : (
          <p>Отзывов пока нет</p>
        )}

        {point.imagePathes.length > 0 && (
          <img src={point.imagePathes[0]} alt={point.title} style={{ maxWidth: '100%' }} />
        )}

        {isAddingFeedback && (
          <AddFeedback
            pointId={point.id}
            userEmail={localStorage.getItem('email')}
            onClose={closeAddFeedbackModal}
            onFeedbackAdded={handleFeedbackAdded}
          />
        )}
      </Popup>
    </Marker>
  );
};

export default PointPopup;
