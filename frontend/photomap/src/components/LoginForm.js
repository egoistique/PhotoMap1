import React, { useState } from 'react';
import axios from 'axios';
import '../css/LoginForm.css';
import RegisterForm from './RegisterForm';

const Modal = ({ onClose, onLogin }) => {
  const [formData, setFormData] = useState({
    username: '',
    password: ''
  });
  const [errorMessage, setErrorMessage] = useState('');
  const [successMessage, setSuccessMessage] = useState('');
  const [showRegisterForm, setShowRegisterForm] = useState(false);

  const handleChange = (e) => {
    setFormData({
      ...formData,
      [e.target.name]: e.target.value
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const { data } = await axios.post(
        'http://localhost:10001/connect/token',
        `grant_type=password&username=${formData.username}&password=${formData.password}&scope=points_read points_write`,
        {
          headers: {
            'Content-Type': 'application/x-www-form-urlencoded',
            'Authorization': 'Basic ' + btoa('frontend:A3F0811F2E934C4F1114CB693F7D785E')
          }
        }
      );

      // Успешная авторизация
      setSuccessMessage('Authentication successful.');
      setErrorMessage('');

      // В data будет содержаться ответ от сервера, включая JWT токен и информацию о пользователе
      console.log('JWT token:', data.access_token);
      console.log('User email:', formData.username);
      
      // Здесь можно сохранить токен и информацию о пользователе в localStorage или состоянии приложения для последующего использования
      localStorage.setItem('token', data.access_token);
      localStorage.setItem('email', formData.username);
      localStorage.setItem('password', formData.password);

      // Закрываем модальное окно после успешной аутентификации
      onClose();
      
      // Вызываем функцию обратного вызова для обновления состояния в родительском компоненте
      onLogin();

    } catch (error) {
      console.error('Authentication error:', error.response.data);
      // Ошибка аутентификации
      setErrorMessage('Authentication failed. Please check your credentials.');
      setSuccessMessage('');
    }
  };

  const handleRegisterClick = () => {
    setShowRegisterForm(true); // Открываем форму регистрации при клике на ссылку
  };

  return (
    <div className="modal" style={{display: 'block'}}>
      <div className="modal-content">
        <span className="close" onClick={onClose}>&times;</span>
        {errorMessage && <div style={{ color: 'red' }}>{errorMessage}</div>}
        {successMessage && <div style={{ color: 'green' }}>{successMessage}</div>}
        <form onSubmit={handleSubmit}>
          <label>
              Username
            <input type="text" name="username" value={formData.username} onChange={handleChange} />
          </label>
          <label>
            Password
            <input type="password" name="password" value={formData.password} onChange={handleChange} />
          </label>
          <button type="submit">Login</button>
        </form>
        <p>Не зарегистрированы? <a href="#" onClick={handleRegisterClick}>Зарегистрироваться</a></p>
      </div>
      {showRegisterForm && <RegisterForm onClose={() => setShowRegisterForm(false)} />}
    </div>
  );
};

export default Modal;