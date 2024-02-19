import React, { useState } from 'react';

const AddPointForm = ({ onAdd }) => {
  const [formData, setFormData] = useState({
    title: '',
    description: '',
    latitude: '',
    longitude: ''
  });

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({
      ...formData,
      [name]: value
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    // Вызываем функцию onAdd и передаем ей данные из формы
    onAdd(formData);
    // Очищаем форму после отправки
    setFormData({
      title: '',
      description: '',
      latitude: '',
      longitude: ''
    });
  };

  return (
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
        <label htmlFor="latitude">Latitude:</label>
        <input type="text" id="latitude" name="latitude" value={formData.latitude} onChange={handleChange} />
      </div>
      <div>
        <label htmlFor="longitude">Longitude:</label>
        <input type="text" id="longitude" name="longitude" value={formData.longitude} onChange={handleChange} />
      </div>
      <button type="submit">Add Point</button>
    </form>
  );
};

export default AddPointForm;
