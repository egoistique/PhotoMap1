import React, { useState } from 'react';
import '../css/SearchBar.css';

const SearchBar = ({ onSearch }) => {
  const [query, setQuery] = useState('');

  const handleChange = (event) => {
    setQuery(event.target.value);
  };

  const handleSubmit = (event) => {
    event.preventDefault();
    onSearch(query);
  };

  return (
    <form onSubmit={handleSubmit} className="search-bar">
      <input
        type="text"
        placeholder="Поиск..."
        value={query}
        onChange={handleChange}
        className="search-input"
      />
      <button type="submit" className="search-button">
        <svg
          xmlns="http://www.w3.org/2000/svg"
          width="16"
          height="16"
          fill="currentColor"
          className="bi bi-search"
          viewBox="0 0 16 16"
        >
          <path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398l3.86 3.86a1 1 0 0 0 1.415-1.414l-3.858-3.86zM6.5 11A4.5 4.5 0 1 1 11 6.5 4.506 4.506 0 0 1 6.5 11z" />
        </svg>
      </button>
    </form>
  );
};

export default SearchBar;
