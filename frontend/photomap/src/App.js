// App.js
import React, { useState } from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import './App.css';
import Header from './components/Header';
import Sidebar from './components/Sidebar';
import Dashboard from './pages/Dashboard';
import NewPage from './pages/NewPage';
import PointsList from './pages/PointsList';
import Account from './pages/Account';
import RoutePage from './pages/RoutePage';

function App() {
  const [menuOpen, setMenuOpen] = useState(false);

  const toggleMenu = () => {
    setMenuOpen(!menuOpen);
  };

  return (
    <Router>
      <div className="App">
        <Header toggleMenu={toggleMenu} />
        <Sidebar isOpen={menuOpen} />
        <div className="content">
          <Routes>
            <Route path="/" element={<Dashboard />} />
            <Route path="/points-list" element={<PointsList />} />
            <Route path="/account" element={<Account />} />
            <Route path="/newpage" element={<NewPage />} />
            <Route path="/routepage" element={<RoutePage />} />
          </Routes>
        </div>
      </div>
    </Router>
  );
}

export default App;
