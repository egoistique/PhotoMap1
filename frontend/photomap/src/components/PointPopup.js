import React, { useState } from 'react';
import { Marker, Popup } from 'react-leaflet';
import AddFeedback from './AddFeedback';
import '../css/PointPopup.css';

const PointPopup = ({ point, onClick }) => {
  const [isAddingFeedback, setIsAddingFeedback] = useState(false);
  const [photoModalOpen, setPhotoModalOpen] = useState(false);
  const [selectedPhoto, setSelectedPhoto] = useState(null);

  const openAddFeedbackModal = () => {
    setIsAddingFeedback(true);
  };

  const closeAddFeedbackModal = () => {
    setIsAddingFeedback(false);
  };

  const handleFeedbackAdded = () => {
    setIsAddingFeedback(false);
  };

  const openPhotoModal = () => {
    setPhotoModalOpen(true);
  };

  const closePhotoModal = () => {
    setPhotoModalOpen(false);
  };

  const handlePhotoChange = (event) => {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onloadend = () => {
        setSelectedPhoto(reader.result);
      };
      reader.readAsDataURL(file);
    }
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

        <div className="photo-container">
          {selectedPhoto ? (
            <img src={selectedPhoto} alt="Selected" className="point-photo" />
          ) : point.imagePathes.length > 0 ? (
            <img src={point.imagePathes[0]} alt={point.title} className="point-photo" />
          ) : (
            <div className="placeholder">Фото не найдено</div>
          )}
          <input type="file" accept="image/*" onChange={handlePhotoChange} className="file-input" />
          <button className="add-photo-button" onClick={openPhotoModal}>Добавить фото</button>
        </div>

        {isAddingFeedback && (
          <AddFeedback
            pointId={point.id}
            userEmail={localStorage.getItem('email')}
            onClose={closeAddFeedbackModal}
            onFeedbackAdded={handleFeedbackAdded}
          />
        )}

        {/* Модальное окно для добавления фото */}
        {photoModalOpen && (
          <div className="photo-modal">
            <input type="file" accept="image/*" onChange={handlePhotoChange} className="file-input" />
            <button className="close-photo-modal" onClick={closePhotoModal}>Закрыть</button>
          </div>
        )}
      </Popup>
    </Marker>
  );
};

export default PointPopup;
