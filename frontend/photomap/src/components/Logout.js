// Logout.js
import React from 'react';

function Logout({ onLogout }) {
  const handleLogout = () => {
    // Реализуйте здесь выход пользователя
    onLogout(); // Вызываем onLogout, чтобы обновить состояние входа пользователя
  };

  return (
    <button onClick={handleLogout}>Log out</button>
  );
}

export default Logout;
