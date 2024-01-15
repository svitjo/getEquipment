import React from 'react';
import { Link } from 'react-router-dom';

const Header = () => {
  return (
    <header>
      <h1>Welcome to Get Equipment!</h1>
      <div>
        <Link to="/register">
          <button className="btn btn-primary">Register</button>
        </Link>
        <Link to="/login">
          <button className="btn btn-secondary">Login</button>
        </Link>
      </div>
    </header>
  );
};

export default Header;
