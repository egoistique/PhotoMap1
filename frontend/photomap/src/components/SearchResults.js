import React from 'react';

const SearchResults = ({ results, onPointClick }) => {
    const handlePointClick = (point) => {
        onPointClick(point);
    };

    return (
        <div className="search-results">
            {results.map((result, index) => (
                <div key={index} className="search-result" onClick={() => handlePointClick(result)}>
                    {result.title}
                </div>
            ))}
        </div>
    );
};

export default SearchResults;
