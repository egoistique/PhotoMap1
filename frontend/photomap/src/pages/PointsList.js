import React, { useState, useEffect } from 'react';

const PointsList = () => {
  const [points, setPoints] = useState([]);

  useEffect(() => {
    fetchPoints();
  }, []);

  const fetchPoints = async () => {
    try {
      const response = await fetch('http://localhost:5247/v1/Point', {
        headers: {
          'Authorization': 'Bearer YOUR_ACCESS_TOKEN_HERE',
          'Accept': 'application/json'
        }
      });
      const data = await response.json();
      setPoints(data);
    } catch (error) {
      console.error('Error fetching points:', error);
    }
  };

  return (
    <div>
      <h2>Points List</h2>
      <ul>
        {points.map(point => (
          <li key={point.id}>
            <h3>{point.title}</h3>
            <p>{point.description}</p>
            <p>Coordinates: {point.latitude}, {point.longitude}</p>
            <p>Feedbacks: {point.feedbacks.join(', ')}</p>
            {point.imagePathes.length > 0 &&
              <img src={point.imagePathes[0]} alt={point.title} />
            }
          </li>
        ))}
      </ul>
    </div>
  );
};

export default PointsList;
