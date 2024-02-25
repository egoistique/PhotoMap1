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
  const [categories, setCategories] = useState([]);
  const [toggleState, setToggleState] = useState(false);
  const [showAddPointForm, setShowAddPointForm] = useState(false);
  const [clickPosition, setClickPosition] = useState({ lat: 0, lng: 0 });
  const [selectedPoint, setSelectedPoint] = useState(null);
  const [selectedCategory, setSelectedCategory] = useState(null); 

  useEffect(() => {
    fetchPoints(selectedCategory);
    fetchCategories();
  }, [selectedCategory]);

  const fetchPoints = async (category = null) => {
    try {
      let url = 'http://localhost:5247/v1/Point';
      if (category) {
        url = `http://localhost:5247/v1/Point/category/${category}`;
      }
      const response = await fetch(url, {
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

  const fetchCategories = async () => {
    try {
      const response = await fetch('http://localhost:5247/v1/PointCategory');
      const data = await response.json();
      setCategories([{ id: 'all', title: 'Все' }, ...data]);
    } catch (error) {
      console.error('Error fetching categories:', error);
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

  const handleMarkerClick = (point) => { 
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

  const handleCategoryClick = (categoryId) => {
    setSelectedCategory(categoryId === 'all' ? null : categoryId); 
  };

  return (
    <div>
      <div className="categories">
        {categories.map(category => (
          <div 
            key={category.id} 
            className={`category ${(!selectedCategory && category.id === 'all') || selectedCategory === category.id ? 'active' : ''}`} // Добавляем класс active для активной категории
            onClick={() => handleCategoryClick(category.id)}
          >
            {category.title}
          </div>
        ))}
      </div>
      <p className="add-point-label">Add Point</p>
      <div className="switch-container">
        <label className="switch">
          <input type="checkbox" checked={toggleState} onChange={handleToggle} />
          <span className="slider round"></span>
        </label>
      </div>
      <MapContainer center={[51.505, -0.09]} zoom={13} style={{ height: '700px', width: '100%', zIndex: 1 }}>
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
          <PointPopup key={point.id} point={point} onClick={() => handleMarkerClick(point)} /> 
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
