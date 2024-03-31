import React, { useState, useEffect } from 'react';
import { fetchPointNameByCoordinates } from '../lib/imports';

const PointsBox = ({ points, setPoints }) => {
  const [pointNames, setPointNames] = useState([]);

  useEffect(() => {
    const fetchNames = async () => {
      const names = [];
      for (const point of points) {
        const [latitude, longitude] = point;
        const name = await fetchPointNameByCoordinates(latitude, longitude);
        names.push(name || 'Unknown');
      }
      setPointNames(names);
    };

    fetchNames();
  }, [points]);

  const handlePointDelete = (index) => {
    const newPoints = [...points];
    newPoints.splice(index, 1);
    setPoints(newPoints);
  };

  return (
    <div className="points-box">
      <h2>Точки маршрута:</h2>
      <ul>
        {points.map((point, index) => (
          <li key={index}>
            Имя: {pointNames[index] || 'Unknown'}, 
            Широта: {point[0]}, 
            Долгота: {point[1]}
            <button onClick={() => handlePointDelete(index)}>✖</button>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default PointsBox;
