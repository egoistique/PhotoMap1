import React, { useState, useEffect } from 'react';
import { MapContainer, TileLayer, Marker, Popup, useMapEvents } from 'react-leaflet';
import 'leaflet/dist/leaflet.css';
import L from 'leaflet';
import markerIcon from '../res/marker-icon.png';
import '../css/Dashboard.css';
import iconShadow from 'leaflet/dist/images/marker-shadow.png';
import AddPointForm from '../components/AddPointForm';
import PointPopup from '../components/PointPopup';
const Dashboard = () => {
  const [points, setPoints] = useState([]);
  const [toggleState, setToggleState] = useState(false);
  const [showAddPointForm, setShowAddPointForm] = useState(false);
  const [clickPosition, setClickPosition] = useState({ lat: 0, lng: 0 });
  const [selectedPoint, setSelectedPoint] = useState(null); // Состояние для отслеживания выбранной точки

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

  const handleMapClick = (e) => {
    if (toggleState) {
      setClickPosition(e.latlng);
      setShowAddPointForm(true);
    }
  };

  const handleMarkerClick = (point) => { // Обработчик клика на маркере
    setSelectedPoint(point);
  }

  const handleFormSubmit = async (formData) => {
    const newPoint = {
      id: points.length + 1,
      latitude: clickPosition.lat,
      longitude: clickPosition.lng,
      title: formData.title,
      description: formData.description,
      imagePathes: formData.imagePathes || []
    };
    setPoints([...points, newPoint]);
    setShowAddPointForm(false);
  };

  const handleCloseForm = () => {
    setShowAddPointForm(false);
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
        <ClickHandler
          setPoints={setPoints}
          points={points}
          toggleState={toggleState}
          onClick={handleMapClick}
        />
        {points.map(point => (
          <PointPopup key={point.id} point={point} onClick={() => handleMarkerClick(point)} /> // Используйте новый компонент
        ))}

      </MapContainer>

      {showAddPointForm && toggleState && (
        <AddPointForm
          latitude={clickPosition.lat} 
          longitude={clickPosition.lng} 
          onAdd={handleFormSubmit}
          onClose={handleCloseForm}
        />
      )}
    </div>
  );
};

const ClickHandler = ({ setPoints, points, toggleState, onClick }) => {
  const map = useMapEvents({
    click(e) {
      onClick(e);
    },
  });

  return null;
};

export default Dashboard;
