import React, { useState } from 'react';
import RegistrationService from '../services/RegistrationService';

const Register = (props) => {
  const [data, setData] = useState(
    { email: '', 
    password: '', 
    name: '', 
    lastname: '', 
    address: '',  
    city: '', 
    country: '', 
    phone: '', 
    gender: '', 
    company: '',
    confirmPassword: ''});

  const Registration = (e) => {
    e.preventDefault();

    
    if (data.password !== data.confirmPassword) {
        alert('Passwords do not match');
        return;
    }

    const dataToSubmit = { email: data.email, password: data.password, name: data.name, lastname: data.lastname, address: data.address, city: data.city, country: data.country, phone: data.phone, gender: data.gender, company: data.company};

    RegistrationService.registerUser(dataToSubmit)
      .then((result) => {
        if (result.data.Status === 'Invalid') {
          alert('Try different email!');
        } else {
            alert('Successfully registered!');
        }
      })
      .catch((error) => {
        console.error('Error registering user:', error);
      });
  };

  const onChange = (e) => {
    e.persist();
    setData({ ...data, [e.target.name]: e.target.value });
  };

  return (
    <div className="container">
      <div className="form">
        <div className="form-body">
          <div className="username">
            <label className="form__label" htmlFor="firstName">
              First Name
            </label>
            <input
              className="form__input"
              type="text"
              id="firstName"
              name="name"
              placeholder="First Name"
              value={data.name}
              onChange={onChange}
            />
          </div>
          <div className="lastname">
            <label className="form__label" htmlFor="lastName">
              Last Name
            </label>
            <input
              type="text"
              id="lastName"
              name="lastname"
              className="form__input"
              placeholder="Last Name"
              value={data.lastname}
              onChange={onChange}
            />
          </div>
          <div className="email">
            <label className="form__label" htmlFor="email">
              Email
            </label>
            <input
              type="email"
              id="email"
              name="email"
              className="form__input"
              placeholder="Email"
              value={data.email}
              onChange={onChange}
            />
          </div>
          <div className="password">
            <label className="form__label" htmlFor="password">
              Password
            </label>
            <input
              className="form__input"
              type="password"
              id="password"
              name="password"
              placeholder="Password"
              value={data.password}
              onChange={onChange}
            />
          </div>
          <div className="confirm-password">
            <label className="form__label" htmlFor="confirmPassword">
              Confirm Password
            </label>
            <input
              className="form__input"
              type="password"
              id="confirmPassword"
              name="confirmPassword"
              placeholder="Confirm Password"
              value={data.confirmPassword}
              onChange={onChange}
            />
          </div>
          <div className="address">
            <label className="form__label" htmlFor="address">
              Address
            </label>
            <input
              className="form__input"
              type="text"
              id="address"
              name="address"
              placeholder="Address"
              value={data.address}
              onChange={onChange}
            />
          </div>
          <div className="city">
            <label className="form__label" htmlFor="city">
              City
            </label>
            <input
              className="form__input"
              type="text"
              id="city"
              name="city"
              placeholder="City"
              value={data.city}
              onChange={onChange}
            />
          </div>
          <div className="country">
            <label className="form__label" htmlFor="country">
              Country
            </label>
            <input
              className="form__input"
              type="text"
              id="country"
              name="country"
              placeholder="Country"
              value={data.country}
              onChange={onChange}
            />
          </div>
          <div className="phone">
            <label className="form__label" htmlFor="phone">
              Phone
            </label>
            <input
              className="form__input"
              type="text"
              id="phone"
              name="phone"
              placeholder="Phone"
              value={data.phone}
              onChange={onChange}
            />
          </div>
          <div className="gender">
            <label className="form__label" htmlFor="gender">
              Gender
            </label>
            <input
              className="form__input"
              type="text"
              id="gender"
              name="gender"
              placeholder="Gender"
              value={data.gender}
              onChange={onChange}
            />
          </div>
          <div className="company">
            <label className="form__label" htmlFor="company">
              Company
            </label>
            <input
              className="form__input"
              type="text"
              id="company"
              name="company"
              placeholder="Company"
              value={data.company}
              onChange={onChange}
            />
          </div>
        </div>
        <div className="footer">
          <button type="submit" className="btn" onClick={Registration}>
            Register
          </button>
        </div>
      </div>
    </div>
  );
};

export default Register;