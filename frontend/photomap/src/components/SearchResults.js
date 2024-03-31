import React, { useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faAngleDown, faAngleUp } from '@fortawesome/free-solid-svg-icons';

const SearchResults = ({ results, onPointClick }) => {
    const [isCollapsed, setIsCollapsed] = useState(false);

    const handleToggleCollapse = () => {
        setIsCollapsed(!isCollapsed);
    };

    const handlePointClick = (point) => {
        onPointClick(point);
    };

    return (
        <div className={`search-results ${isCollapsed ? 'collapsed' : ''}`}>
            {!isCollapsed && (
                <>
                    {results.map((result, index) => (
                        <div key={index} className="search-result" onClick={() => handlePointClick(result)}>
                            {result.title}
                        </div>
                    ))}
                </>
            )}
            <div className="collapse-toggle" onClick={handleToggleCollapse}>
                <FontAwesomeIcon icon={isCollapsed ? faAngleDown : faAngleUp} /> {/* Используем иконки из Font Awesome */}
            </div>
        </div>
    );
};

export default SearchResults;
