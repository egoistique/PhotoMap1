import React, { useState, useEffect } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import '../css/Settings.css';

const Settings = () => {
  // Состояние для настройки темной темы
  const [darkTheme, setDarkTheme] = useState(false);

  // Состояние для настройки уведомлений о добавлении новых точек
  const [notifyNewPoints, setNotifyNewPoints] = useState(false);

  // Загрузка сохраненной информации при первом рендере компонента
  useEffect(() => {
    const savedTheme = localStorage.getItem('darkTheme');
    if (savedTheme) {
      setDarkTheme(savedTheme === 'true');
    }
  }, []);

  // Обработчик изменения настройки темной темы
  const handleDarkThemeChange = () => {
    const newTheme = !darkTheme;
    setDarkTheme(newTheme);
    localStorage.setItem('darkTheme', newTheme);
    // Здесь можно добавить логику для сохранения настройки
  };

  // Обработчик изменения настройки уведомлений о новых точках
  const handleNotifyNewPointsChange = () => {
    setNotifyNewPoints(!notifyNewPoints);
    // Здесь можно добавить логику для сохранения настройки
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
