import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';

import { initializeApp } from "firebase/app";


const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);



// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
  apiKey: "AIzaSyCb5Ys9dovR2xEvqTzkmLGI-aAKY20dba4",
  authDomain: "photomap-5496a.firebaseapp.com",
  projectId: "photomap-5496a",
  storageBucket: "photomap-5496a.appspot.com",
  messagingSenderId: "640164589340",
  appId: "1:640164589340:web:4cf05e97b45ea01bd254d9",
  measurementId: "G-9GCFYP8JRY"
};

const app = initializeApp(firebaseConfig);

reportWebVitals();
