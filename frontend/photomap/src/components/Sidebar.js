// Sidebar.js
import React from 'react';
import { Link } from 'react-router-dom';
import '../css/Sidebar.css'; // Импортируем файл со стилями

const Sidebar = ({ isOpen }) => {
  return (
    <div className={`sidebar ${isOpen ? 'open' : ''}`}>
      <Link to="/" className="sidebar-link">Dashboard</Link>
      <Link to="/points-list" className="sidebar-link">Points List</Link>
      <Link to="/account" className="sidebar-link">Account</Link>
      <Link to="/newpage" className="sidebar-link">New Page</Link>
      <Link to="/routepage" className="sidebar-link">Route Page</Link>
    </div>
  );
};

export default Sidebar;
