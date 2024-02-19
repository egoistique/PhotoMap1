import React, { useState, useEffect } from 'react';
import { MapContainer, TileLayer, Marker, Popup, useMapEvents } from 'react-leaflet';
import 'leaflet/dist/leaflet.css';
import L from 'leaflet';
import markerIcon from '../res/marker-icon.png';
import '../css/Dashboard.css';
import iconShadow from 'leaflet/dist/images/marker-shadow.png';

const Dashboard = () => {
  const [points, setPoints] = useState([]);
  const [toggleState, setToggleState] = useState(false);

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

  useEffect(() => {
    delete L.Icon.Default.prototype._getIconUrl;
    L.Icon.Default.mergeOptions({
      iconUrl: markerIcon,
      shadowUrl: iconShadow
    });
  }, []);

  const handleToggle = () => {
    setToggleState(!toggleState);
  };

  return (
    <div>
      <h2 className="dashboard-title">
        Dashboard
      </h2>
      <p className="add-point-label">Add Point</p>
      <div className="switch-container">
        <label className="switch">
          <input type="checkbox" checked={toggleState} onChange={handleToggle} />
          <span className="slider round"></span>
        </label>
      </div>

      <MapContainer center={[51.505, -0.09]} zoom={13} style={{ height: '600px', width: '100%', zIndex: 1 }}>
        <TileLayer
          attribution='&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
          url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png"
        />
        {toggleState && <ClickHandler setPoints={setPoints} points={points} />}
        {points.map(point => (
          <Marker key={point.id} position={[point.latitude, point.longitude]}>
            <Popup>
              <h3>{point.title}</h3>
              <p>{point.description}</p>
              {point.imagePathes.length > 0 &&
                <img src={point.imagePathes[0]} alt={point.title} style={{ maxWidth: '100%' }} />
              }
            </Popup>
          </Marker>
        ))}
      </MapContainer>
    </div>
  );
};

const ClickHandler = ({ setPoints, points }) => {
  const map = useMapEvents({
    click(e) {
      const { lat, lng } = e.latlng;
      const newPoint = {
        id: points.length + 1,
        latitude: lat,
        longitude: lng,
        title: "New Point",
        description: "Description of the new point",
        imagePathes: [] // assuming no images initially
      };
      setPoints([...points, newPoint]);
    },
  });

  return null;
};

export default Dashboard;
