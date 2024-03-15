import React from 'react';
import { YMaps, Map, Placemark, RoutePanel } from '@pbe/react-yandex-maps';

class Account extends React.Component {
  render() {
    const mapStyles = {
      width: '90vw', 
      height: '90vh', 
    };

    return (
      <YMaps query={{apikey: '7c779eb6-845b-4c78-a612-a2397737206e'}}>
        <div style={mapStyles}>
          <Map defaultState={{ center: [55.751574, 37.573856], zoom: 9 }} style={mapStyles}>
            <RoutePanel />
          </Map>
        </div>
      </YMaps>
    );
  }
}

export default Account;
