// В компоненте AddPointForm

import React, { useState, useEffect } from 'react';
import '../css/AddPointForm.css';

const AddPointForm = ({ onAdd, onClose, latitude, longitude  }) => {
  const [formData, setFormData] = useState({
    title: '',
    description: '',
    latitude: latitude,
    longitude: longitude,
    category: ''
  });
  const [categories, setCategories] = useState([]);
  const [token, setToken] = useState('');

  useEffect(() => {
    const fetchCategories = async () => {
      try {
        const response = await fetch('https://localhost:7089/v1/PointCategory');
        if (!response.ok) {
          throw new Error('Failed to fetch categories');
        }
        const data = await response.json();
        setCategories(data);
      } catch (error) {
        console.error('Error fetching categories:', error);
      }
    };

    fetchCategories();
    
    // Получаем токен из localStorage
    const storedToken = localStorage.getItem('token');
    if (storedToken) {
      setToken(storedToken);
    }
  }, []);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: name === 'latitude' || name === 'longitude' ? parseFloat(value) : value
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    // Добавляем точку на бэкенд
    try {
      const response = await fetch('https://localhost:7089/v1/Point', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${token}` // Передача токена доступа
        },
        body: JSON.stringify({
          pointCategoryId: formData.category,
          title: formData.title,
          description: formData.description,
          latitude: formData.latitude,
          longitude: formData.longitude
        })
      });
      if (!response.ok) {
        throw new Error('Failed to add point');
      }
      // Если запрос успешен, вызываем функцию onAdd и передаем ей данные из формы
      onAdd(formData);
      // Очищаем форму после отправки
      setFormData({
        title: '',
        description: '',
        latitude: 0,
        longitude: 0,
        category: ''
      });
      // Закрываем форму
      onClose();
    } catch (error) {
      console.error('Error adding point:', error);
    }
  };

  const handleClose = () => {
    onClose(); // Закрываем форму
  };

  return (
    <div className="modal-overlay">
      <div className="modal-content">
        <span className="close" onClick={handleClose}>&times;</span>
        <form onSubmit={handleSubmit}>
          <div>
            <label htmlFor="title">Title:</label>
            <input type="text" id="title" name="title" value={formData.title} onChange={handleChange} />
          </div>
          <div>
            <label htmlFor="description">Description:</label>
            <textarea id="description" name="description" value={formData.description} onChange={handleChange}></textarea>
          </div>

          <div>
            <label htmlFor="category">Category:</label>
            <select id="category" name="category" value={formData.category} onChange={handleChange}>
              <option value="">Select category</option>
              {categories.map(category => (
                <option key={category.id} value={category.id}>{category.title}</option>
              ))}
            </select>
          </div>
          <button type="submit">Add Point</button>
        </form>
      </div>
    </div>
  );
};

export default AddPointForm;
