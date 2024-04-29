import React, { useState, useEffect } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import '../css/Settings.css';

const Settings = () => {
  const [darkTheme, setDarkTheme] = useState(false);
  const [notifyNewPoints, setNotifyNewPoints] = useState(false);
  const [email, setEmail] = useState('');
  useEffect(() => {
    const savedTheme = localStorage.getItem('darkTheme');
    if (savedTheme) {
      setDarkTheme(savedTheme === 'true');
    }
  }, []);

  useEffect(() => {
    const savedTheme = localStorage.getItem('darkTheme');
    if (savedTheme) {
      setDarkTheme(savedTheme === 'true');
    }

    const savedEmail = localStorage.getItem('email');
    if (savedEmail) {
      setEmail(savedEmail);
    }
  }, []);

  const handleDarkThemeChange = () => {
    const newTheme = !darkTheme;
    setDarkTheme(newTheme);
    localStorage.setItem('darkTheme', newTheme);
  };

  // Обработчик изменения настройки уведомлений о новых точках
  const handleNotifyNewPointsChange = async () => {
    // Изменяем состояние настройки уведомлений
    setNotifyNewPoints(!notifyNewPoints);

    // Если уведомления включены, выполняем запрос к бекенду
    if (!notifyNewPoints) {
      try {
        const response = await fetch('http://localhost:10000/v1/Subscriber', {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json'
          },
          body: JSON.stringify({
            email: email
          })
        });
        console.log('Email to subscribe:', email);

        if (!response.ok) {
          throw new Error('Failed to subscribe for new points notifications');
        }

        console.log('Subscribed successfully for new points notifications');
      } catch (error) {
        console.error('Error subscribing for new points notifications:', error.message);
        // Возможно, здесь стоит добавить логику для обработки ошибки
      }
    }else {
      try {
        const response = await fetch(`http://localhost:10000/v1/Subscriber/${encodeURIComponent(email)}`, {
          method: 'DELETE',
          headers: {
            'Accept': '*/*'
          }
        });

        if (!response.ok) {
          throw new Error('Failed to unsubscribe from new points notifications');
        }

        console.log('Unsubscribed successfully from new points notifications');
      } catch (error) {
        console.error('Error unsubscribing from new points notifications:', error.message);
        // Возможно, здесь стоит добавить логику для обработки ошибки
      }
    }
  };

  return (
    <div className={`settings-container ${darkTheme ? 'dark-theme' : ''}`}>
      <div className="settings-box" >

        <h2>Настройки</h2>
        <div className="setting">
          <span className="setting-label">Темная тема:</span>
          <label className="toggle-switch">
            <input
              type="checkbox"
              checked={darkTheme}
              onChange={handleDarkThemeChange}
            />
            <span className="slider round"></span>
          </label>
        </div>
        <div className="setting">
          <span className="setting-label">Уведомлять меня о новых точках:</span>
          <label className="toggle-switch">
            <input
              type="checkbox"
              checked={notifyNewPoints}
              onChange={handleNotifyNewPointsChange}
            />
            <span className="slider round"></span>
          </label>
        </div>
      </div>
    </div>
  );
};

export default Settings;
