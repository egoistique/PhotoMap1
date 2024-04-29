// AddFeedback.js

import React, { useState, useEffect } from 'react';
import axios from 'axios';

const AddFeedback = ({ pointId, userEmail, onClose, onFeedbackAdded }) => { // Добавляем пропс onFeedbackAdded
  const [title, setTitle] = useState('');
  const [rating, setRating] = useState(1);
  const [feedbackAuthor, setFeedbackAuthor] = useState(userEmail);
  const [token, setToken] = useState('');

  useEffect(() => {
    // Получаем токен из localStorage
    const storedToken = localStorage.getItem('token');
    if (storedToken) {
      setToken(storedToken);
    }
  }, []);

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      await axios.post('http://localhost:10000/v1/Feedback', {
        pointId,
        title,
        rating,
        feedbackAuthor
      }, {
        headers: {
          'Authorization': `Bearer ${token}` // Передача токена доступа
        }
      });

      // Очищаем форму после успешной отправки
      setTitle('');
      setRating(1);
      onClose();
      onFeedbackAdded(); // Вызываем функцию обновления списка отзывов
    } catch (error) {
      console.error('Ошибка при отправке отзыва:', error);
    }
  };

  return (
    <div>
      <h2>Добавить отзыв</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Автор:</label>
          <input type="text" value={feedbackAuthor} disabled />
        </div>
        <div>
          <label>Рейтинг:</label>
          <select value={rating} onChange={(e) => setRating(parseInt(e.target.value))}>
            {[1, 2, 3, 4, 5].map((value) => (
              <option key={value} value={value}>{value}</option>
            ))}
          </select>
        </div>
        <div>
          <label>Отзыв:</label>
          <textarea value={title} onChange={(e) => setTitle(e.target.value)}></textarea>
        </div>
        <button type="submit">Отправить</button>
      </form>
    </div>
  );
};

export default AddFeedback;
