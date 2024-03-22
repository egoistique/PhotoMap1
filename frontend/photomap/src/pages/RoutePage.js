import { React, useState, useEffect, useRef, MapContainer, TileLayer, Marker, Popup, SearchBar, useMapEvents, L, markerIcon, iconShadow, AddPointForm, PointPopup, fetchPointsBySearch, fetchCategories } from '../lib/imports';
import 'leaflet-routing-machine';
import 'leaflet/dist/leaflet.css';
import 'leaflet-routing-machine/dist/leaflet-routing-machine.css';
import '../css/RoutePage.css';
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

const addRoutes = (map, points) => {
    const routingControl = L.Routing.control({
        waypoints: points.map(point => L.latLng(point)),
        routeWhileDragging: true
    }).addTo(map);

    routingControl.on('routeselected', function (e) {
        console.log(e);
    });
};

const RoutePage = () => {
    const [searchResults, setSearchResults] = useState([]);
    const [searchQuery, setSearchQuery] = useState('');
    const [map, setMap] = useState(null);
    const [points, setPoints] = useState([]);

    useEffect(() => {
        const map = createMap();
        setMap(map);
        const initialPoints = [
            [51.5, -0.09], // Точка 1
            [51.51, -0.1], // Точка 2
            [51.52, -0.1], // Точка 3
            [51.53, -0.11] // Точка 4
        ];
        setPoints(initialPoints);
        addMarkers(map, initialPoints);
        addRoutes(map, initialPoints);

        return () => {
            if (map) {
                map.remove();
            }
        };
    }, []);

    useEffect(() => {
        if (map && points.length > 1) {
            const routingControl = L.Routing.control({
                waypoints: points.map(point => L.latLng(point)),
                routeWhileDragging: true
            });
            map.eachLayer(layer => {
                if (layer instanceof L.Routing.Control) {
                    map.removeLayer(layer);
                }
            });
            routingControl.addTo(map);
        }
    }, [map, points]);

    const handleSearch = async (query) => {
        setSearchQuery(query);
        try {
            const data = await fetchPointsBySearch(query);
            setSearchResults(data);
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
            <div className="map-container">
                <div id="map" style={{ width: '100%', height: 'calc(100vh - 200px)' }}></div>
            </div>
        </div>
    );
};

export default RoutePage;
