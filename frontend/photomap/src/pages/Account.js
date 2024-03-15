import React, { useRef } from 'react';
import { YMaps, Map } from 'react-yandex-maps';

const Account = () => {
  const map = useRef(null);
  const multiRouteRef = useRef(null);

  const mapState = {
    center: [55.739625, 37.5412],
    zoom: 12
  };

  const addRoute = (ymaps) => {
    const pointA = [55.749, 37.524];
    const pointB = "Москва, Красная площадь";
    const pointC = "Москва, Павелецкий вокзал";
    const pointD = "Москва, Таганская";

    if (multiRouteRef.current) {
      map.current.geoObjects.remove(multiRouteRef.current);
    }

    const multiRoute = new ymaps.multiRouter.MultiRoute(
      {
        referencePoints: [pointA, pointB, pointC, pointD],
        params: {
          routingMode: "pedestrian"
        }
      },
      {
        boundsAutoApply: true
      }
    );

    map.current.geoObjects.add(multiRoute);
    multiRouteRef.current = multiRoute;
  };

  return (
    <div className="App" style={{ width: '100vw', height: '100vh' }}>
      <YMaps query={{ apikey: '7c779eb6-845b-4c78-a612-a2397737206e' }}>
        <Map
          state={mapState}
          instanceRef={map}
          modules={['multiRouter.MultiRoute']}
          onLoad={addRoute}
          style={{ width: '100%', height: '100%' }}
        />
      </YMaps>
    </div>
  );
}

export default Account;
