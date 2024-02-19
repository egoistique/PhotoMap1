// App.js

import React, { useState } from 'react';
import './App.css';
import Header from './components/Header';
import Sidebar from './components/Sidebar';

function App() {
  const [menuOpen, setMenuOpen] = useState(false);

  const toggleMenu = () => {
    setMenuOpen(!menuOpen);
  };

  return (
    <div className="App">
      <Header toggleMenu={toggleMenu} />
      <Sidebar isOpen={menuOpen} />
      <div className="content">
        {/* Здесь будет ваш контент */}
      </div>
    </div>
  );
}

export default App;
