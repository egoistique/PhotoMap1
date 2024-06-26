import React, { useState, useEffect, useRef } from 'react';
import { MapContainer, TileLayer, Marker, Popup, useMapEvents } from 'react-leaflet';
import 'leaflet/dist/leaflet.css';
import L from 'leaflet';
import markerIcon from '../res/marker.png';
import 'leaflet-routing-machine';
import 'leaflet-routing-machine/dist/leaflet-routing-machine.css';
import '../css/Dashboard.css';
import iconShadow from 'leaflet/dist/images/marker-shadow.png';
import AddPointForm from '../components/AddPointForm';
import PointPopup from '../components/PointPopup';
import SearchBar  from '../components/SearchBar';
import { fetchPoints, fetchCategories, fetchPointsBySearch,  fetchPointNameByCoordinates} from './api'; 

export {
  React,
  useState,
  useEffect,
  useRef,
  MapContainer,
  TileLayer,
  Marker,
  Popup,
  useMapEvents,
  L,
  markerIcon,
  AddPointForm,
  PointPopup,
  SearchBar,
  fetchPoints,
  fetchCategories,
  fetchPointsBySearch,
  fetchPointNameByCoordinates,
  iconShadow 
};
