import React, { useState, useEffect } from 'react';
import { Marker, Popup } from 'react-leaflet';
import { getStorage, ref, uploadBytes, getDownloadURL } from 'firebase/storage';
import AddFeedback from './AddFeedback';
import Slider from 'react-slick';
import 'slick-carousel/slick/slick.css';
import 'slick-carousel/slick/slick-theme.css';
import '../css/PointPopup.css';
import axios from 'axios';

const PointPopup = ({ point, onClick }) => {
  const [isAddingFeedback, setIsAddingFeedback] = useState(false);
  const [photoModalOpen, setPhotoModalOpen] = useState(false);
  const [selectedPhoto, setSelectedPhoto] = useState(null);
  const [categoryTitle, setCategoryTitle] = useState('');
  const storage = getStorage();

  useEffect(() => {
    const fetchCategoryTitle = async () => {
      try {
        const response = await axios.get(`https://localhost:7089/v1/PointCategory/${point.pointCategoryId}`);
        setCategoryTitle(response.data.title);
      } catch (error) {
        console.error('Ошибка получения названия категории:', error);
      }
    };

    fetchCategoryTitle();
  }, [point.pointCategoryId]);

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

  const handlePhotoChange = async (event) => {
    const file = event.target.files[0];
    if (file) {
      try {
        const storageRef = ref(storage, `images/${file.name}`);
        await uploadBytes(storageRef, file);
        const downloadURL = await getDownloadURL(storageRef);
        setSelectedPhoto(downloadURL);
  
        const postData = {
          pointId: point.id,
          title: downloadURL,
        };
  
        await axios.post('https://localhost:7089/v1/ImagePath', postData);
        closePhotoModal(); // закрываем модальное окно после успешной загрузки
      } catch (error) {
        console.error('Ошибка загрузки фото:', error);
      }
    }
  };
  

  const renderRatingStars = (rating) => {
    const stars = '★'.repeat(rating) + '☆'.repeat(5 - rating);
    return <span style={{ fontSize: '20px', color: 'gold' }}>{stars}</span>;
  };

  const settings = {
    dots: true,
    infinite: true,
    speed: 500,
    slidesToShow: 1,
    slidesToScroll: 1,
  };

  return (
    <Marker position={[point.latitude, point.longitude]} onClick={onClick}>
      <Popup>
        <div className="popup-container">
          <div className="photo-container">
            {point.imagePathes.length > 1 ? (
              <Slider {...settings}>
                {point.imagePathes.slice(0, 10).map((image, index) => (
                  <div key={index}>
                    <img src={image} alt={`Image ${index}`} className="point-photo" />
                  </div>
                ))}
              </Slider>
            ) : point.imagePathes.length === 1 ? (
              <img src={point.imagePathes[0]} alt={point.title} className="point-photo" />
            ) : (
              <div className="placeholder">Фото не найдено</div>
            )}
          </div>
          <div className="point-info">
            <div className="title-container">
              <h3 className="point-title">{point.title}</h3>
              <div className="category-container">
                <p className="category-title">{categoryTitle}</p>
              </div>
            </div>
            <p className="point-description">{point.description}</p>
            <div className="reviews-container">
              <div className="review-list">
                <p className="reviews-title">Отзывы</p>
                {point.feedbacks && point.feedbacks.length > 0 ? (
                  point.feedbacks.map((feedback, index) => {
                    const [text, author, rating] = feedback.split(' - ');
                    return (
                      <div key={index} className="review-item">
                        <p>
                          {author} {renderRatingStars(parseInt(rating))}
                        </p>
                        <p>{text}</p>
                        <hr />
                      </div>
                    );
                  })
                ) : (
                  <p>Отзывов пока нет</p>
                )}
              </div>
            </div>
            <div className="buttons-container">
              <button className="add-photo-button" onClick={openPhotoModal}>Добавить фото</button>
              <button className="add-feedback-button" onClick={openAddFeedbackModal}>Добавить отзыв</button>
            </div>
          </div>
        </div>
        {isAddingFeedback && (
          <AddFeedback
            pointId={point.id}
            userEmail={localStorage.getItem('email')}
            onClose={closeAddFeedbackModal}
            onFeedbackAdded={handleFeedbackAdded}
          />
        )}
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
