// LoginForm.js
import React, { useState } from 'react';
import axios from 'axios';
import { backendConfig } from '../backendConfig';

function LoginForm({ onSuccess, onClose }) {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');

  const handleLoginSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post(`${backendConfig.identityRoot}/connect/token`, {
        grant_type: 'password',
        client_id: backendConfig.clientId,
        client_secret: backendConfig.clientSecret,
        username,
        password
      });
      const accessToken = response.data.access_token;
      // Сохраните accessToken в localStorage или в состоянии вашего приложения
      console.log('Аутентификация успешна. Получен токен:', accessToken);
      onSuccess();
    } catch (error) {
      console.error('Ошибка аутентификации:', error);
      setError('Неверное имя пользователя или пароль');
    }
  };

  return (
    <div className="login-modal">
      <form onSubmit={handleLoginSubmit}>
        <input type="text" placeholder="Имя пользователя" value={username} onChange={(e) => setUsername(e.target.value)} />
        <input type="password" placeholder="Пароль" value={password} onChange={(e) => setPassword(e.target.value)} />
        <button type="submit">Войти</button>
        <button type="button" onClick={onClose}>Отмена</button>
        {error && <div style={{ color: 'red' }}>{error}</div>}
      </form>
    </div>
  );
}

export default LoginForm;
