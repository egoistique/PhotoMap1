import React from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faUser } from '@fortawesome/free-solid-svg-icons';
import '../css/Account.css';

const Account = () => {
  const uemail = localStorage.getItem('email');
  const upassword = localStorage.getItem('password');

  return (
    <div className="account">
      <div className="avatar-placeholder">
        <div className="avatar-container">
          <FontAwesomeIcon icon={faUser} size="6x" color="#9c27b0" />
        </div>
      </div>
      <div className="account-info">
        <h2>Данные пользователя</h2>
        <div>
          <strong>Email:</strong> {uemail}
        </div>
        <div>
          <strong>Пароль:</strong> {upassword}
        </div>
      </div>
    </div>
  );
};

export default Account;
