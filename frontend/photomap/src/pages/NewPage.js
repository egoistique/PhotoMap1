import React, { useEffect } from 'react';
import L from 'leaflet';
import 'leaflet-routing-machine';
import 'leaflet/dist/leaflet.css';
import 'leaflet-routing-machine/dist/leaflet-routing-machine.css';

const NewPage = () => {
  useEffect(() => {
    // Создание карты
    const map = L.map('map').setView([51.505, -0.09], 13);

    // Добавление слоя OpenStreetMap
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      attribution: '&copy; OpenStreetMap contributors'
    }).addTo(map);

    // Указание координат точек
    const points = [
      [51.5, -0.09], // Точка 1
      [51.51, -0.1], // Точка 2
      [51.52, -0.1], // Точка 3
      [51.53, -0.11] // Точка 4
    ];

    // Построение маршрутов между точками
    const routingControl = L.Routing.control({
      waypoints: [
        L.latLng(points[0]),
        L.latLng(points[1]),
        L.latLng(points[2]),
        L.latLng(points[3])
      ],
      routeWhileDragging: true,
      createMarker: () => null // Скрыть маркеры точек
    }).addTo(map);

    // Обработчик изменения пути маршрута
    routingControl.on('routeselected', function(e) {
      console.log(e);
    });

    return () => {
      map.remove();
    };
  }, []);

  return <div id="map" style={{ width: '100%', height: '600px' }}></div>;
};

export default NewPage;
