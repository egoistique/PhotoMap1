// Sidebar.js

import React from 'react';

function Sidebar({ isOpen }) {
  return (
    <div className={`sidebar ${isOpen ? 'open' : ''}`}>
      <ul>
        <li>Пункт меню 1</li>
        <li>Пункт меню 2</li>
        <li>Пункт меню 3</li>
      </ul>
    </div>
  );
}

export default Sidebar;
