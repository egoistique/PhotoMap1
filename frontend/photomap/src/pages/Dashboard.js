import {  React,  useState,  useEffect,  useRef,  MapContainer,  TileLayer,  Marker,  Popup,  useMapEvents,  L,  markerIcon,
  iconShadow,  AddPointForm,  PointPopup,  fetchPoints,  fetchCategories} from '../lib/imports'; 

const Dashboard = () => {
  const [points, setPoints] = useState([]);
  const [categories, setCategories] = useState([]);
  const [toggleState, setToggleState] = useState(false);
  const [showAddPointForm, setShowAddPointForm] = useState(false);
  const [clickPosition, setClickPosition] = useState({ lat: 0, lng: 0 });
  const [selectedCategory, setSelectedCategory] = useState(null); 
  const [miniSidebarState, setMiniSidebarState] = useState(false);
  const [selectedMarkers, setSelectedMarkers] = useState(Array.from({ length: 5 }, () => null)); 

  const [toggleRouteState, setToggleRouteState] = useState(true);
  
  useEffect(() => {
    async function fetchData() {
      const pointsData = await fetchPoints(selectedCategory); 
      setPoints(pointsData); 
      const categoriesData = await fetchCategories();
      setCategories(categoriesData); 
    }
    fetchData();
  }, [selectedCategory]);

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

  const handleMarkerSelection = (index) => {
    setToggleRouteState(true);
    console.log(toggleRouteState); 
    const markerToAdd = points[index];
    if (markerToAdd && selectedMarkers[index] === null) {
      const updatedMarkers = [...selectedMarkers];
      updatedMarkers[index] = markerToAdd;
      setSelectedMarkers(updatedMarkers);
      console.log(updatedMarkers); 
    }
    setToggleRouteState(!toggleRouteState);
    console.log(toggleRouteState); 
  };

  const handleRoute= () => {
    //реализовать
  }
  return (
    <div>
      <div className="categories">
        {categories.map(category => (
          <div 
            key={category.id} 
            className={`category ${(!selectedCategory && category.id === 'all') || selectedCategory === category.id ? 'active' : ''}`} 
            onClick={() => handleCategoryClick(category.id)}
          >
            {category.title}
          </div>
        ))}
      </div>
      
      <button className="mini-sidebar-toggle" onClick={() => setMiniSidebarState(!miniSidebarState)}> Маршрут </button>

      <div className={`mini-sidebar ${miniSidebarState ? 'active' : ''}`}>
        <div className="mini-sidebar-content">
          <p>Панель маршрутов</p>      
          {selectedMarkers.map((marker, index) => (
          <div key={index} className="marker-row">
            <button className="marker-button" onClick={() => handleMarkerSelection(index)}>+</button>
            <p>{marker ? marker.title : 'Выберите маркер'}</p>
          </div>
        ))}
        <button  onClick={() => handleRoute()}>Построить маршрут</button>
        </div>
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
    <PointPopup key={point.id} point={point}  /> 
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