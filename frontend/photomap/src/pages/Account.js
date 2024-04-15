import React, { useEffect, useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faUser, faEye, faEyeSlash } from '@fortawesome/free-solid-svg-icons'; // Импорт иконок глаза
import '../css/Account.css';

const Account = () => {
  const uemail = localStorage.getItem('email');
  const upassword = localStorage.getItem('password');
  const [darkTheme, setDarkTheme] = useState(false);
  const [showPassword, setShowPassword] = useState(false); // Состояние для отслеживания показа пароля

  // Загрузка сохраненной информации о теме при первом рендере компонента
  useEffect(() => {
    const savedTheme = localStorage.getItem('darkTheme');
    if (savedTheme) {
      setDarkTheme(savedTheme === 'true');
    }
  }, []);

  // Функция для переключения видимости пароля
  const togglePasswordVisibility = () => {
    setShowPassword(!showPassword);
  };

  return (
    <div className={`account ${darkTheme ? 'dark-theme' : ''}`}>
      <div className="avatar-placeholder">
        <div className="avatar-container">
          <FontAwesomeIcon icon={faUser} size="6x" color="#9c27b0" />
        </div>
      </div>
      <div className="account-info">
        <h2>Данные пользователя</h2>
        <div>
          <h2>Email: {uemail}</h2>
        </div>
        <div>
          {/* Показывать пароль в виде точек, если не нажат глаз */}
          <h2>Пароль: {showPassword ? upassword : '*'.repeat(upassword.length)} <FontAwesomeIcon icon={showPassword ? faEyeSlash : faEye} onClick={togglePasswordVisibility} /></h2>
          
        </div>
      </div>
    </div>
  );
};

export default Account;
