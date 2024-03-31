import { React, useState, useEffect, useRef, MapContainer, TileLayer, Marker, Popup, SearchBar, useMapEvents, L, markerIcon, iconShadow, AddPointForm, PointPopup, fetchPointsBySearch, fetchCategories, fetchPointNameByCoordinates} from '../lib/imports';
import 'leaflet-routing-machine';
import 'leaflet/dist/leaflet.css';
import 'leaflet-routing-machine/dist/leaflet-routing-machine.css';
import '../css/RoutePage.css';
import PointsBox from '../components/PointsBox';
import SearchResults from '../components/SearchResults';

const createMap = () => {
    const map = L.map('map').setView([51.505, -0.09], 13);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; OpenStreetMap contributors'
    }).addTo(map);

    return map;
};

const addMarkers = (map, points) => {
    points.forEach(point => {
        L.marker(point).addTo(map);
    });
};

const RoutePage = () => {
    const [searchResults, setSearchResults] = useState([]);
    const [searchQuery, setSearchQuery] = useState('');
    const [map, setMap] = useState(null);
    const [points, setPoints] = useState([]);
    const [routingControl, setRoutingControl] = useState(null);
    useEffect(() => {
        const map = createMap();
        setMap(map);

        return () => {
            if (map) {
                map.remove();
            }
        };
    }, []);

    useEffect(() => {
        if (map && points.length > 1) {
            
            if (routingControl) {
                map.removeControl(routingControl);
            }
            
            
            const newRoutingControl = L.Routing.control({
                waypoints: points.map(point => L.latLng(point)),
                routeWhileDragging: true
            });
            
            
            setRoutingControl(newRoutingControl);
            
            
            newRoutingControl.addTo(map);
        }
    }, [map, points]);

    const handleSearch = async (query) => {
        setSearchQuery(query);
        try {
            if (query.trim() !== '') {
                const data = await fetchPointsBySearch(query);
                setSearchResults(data);
            }
        } catch (error) {
            console.error('Ошибка при выполнении запроса', error);
        }
    };

    const handlePointClick = (point) => {
        const { latitude, longitude } = point;
        setPoints([...points, [latitude, longitude]]);
    };
    
    return (
        <div className="route-page-container">
            <div className="search">
                <SearchBar onSearch={handleSearch} />
                {searchResults.length > 0 && <SearchResults results={searchResults} onPointClick={handlePointClick} />}
            </div>
            <div className="map-and-points-container">
                <div className="map-container">
                    <div id="map" style={{ width: '100%', height: 'calc(100vh - 200px)' }}></div>
                </div>
                <div className="points-container">        
                    <PointsBox points={points} setPoints={setPoints}/>
                </div>
            </div>
        </div>
    );
};

export default RoutePage;
