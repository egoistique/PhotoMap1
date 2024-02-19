import React, { useState, useEffect } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faBars } from '@fortawesome/free-solid-svg-icons';
import Modal from './LoginForm'; // Импортируйте ваш компонент модального окна

function Header({ toggleMenu }) {
  const [showModal, setShowModal] = useState(false);
  const [isLoggedIn, setIsLoggedIn] = useState(false); // Состояние для отслеживания входа пользователя
  const [userEmail, setUserEmail] = useState('');

  useEffect(() => {
    const token = localStorage.getItem('token');
    const email = localStorage.getItem('email');
    if (token && email) {
      setIsLoggedIn(true);
      setUserEmail(email);
    }
  }, []);

  const handleLoginClick = () => {
    setShowModal(true);
  };

  const handleCloseModal = () => {
    setShowModal(false);
  };

  const handleLogin = () => {
    setIsLoggedIn(true); // Устанавливаем состояние входа пользователя как true
    setUserEmail(localStorage.getItem('email'));
    handleCloseModal(); // Закрываем модальное окно
  };

  const handleLogout = () => {
    setIsLoggedIn(false); // Устанавливаем состояние входа пользователя как false
    setUserEmail('');
    localStorage.removeItem('token');
    localStorage.removeItem('email');
  };

  return (
    <header className="header">
      <div className="menu-icon" onClick={toggleMenu}>
        <FontAwesomeIcon icon={faBars} />
      </div>
      <h1>Photo Map</h1>
      {isLoggedIn ? (
        <div className="user-info">
          <span>{userEmail}</span>
          <div className="login-button" onClick={handleLogout}>Log out</div>
        </div>
      ) : (
        <div className="login-button" onClick={handleLoginClick}>Log in</div>
      )}
      {showModal && <Modal onClose={handleCloseModal} onLogin={handleLogin} />}
    </header>
  );
}

export default Header;
