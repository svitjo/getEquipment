import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import Header from './Header';
import companyService from '../services/CompanyService';

const Home = () => {
  const [companies, setCompanies] = useState([]);
  const [filteredCompanies, setFilteredCompanies] = useState([]);
  const [searchQuery, setSearchQuery] = useState('');

  useEffect(() => {
    companyService.getCompanies()
      .then((response) => {
        setCompanies(response.data);
        setFilteredCompanies(response.data);
      })
      .catch((error) => {
        console.error('Error fetching companies:', error);
      });
  }, []);

  useEffect(() => {
    const updatedCompanies = companies.filter((company) =>
      company.name.toLowerCase().includes(searchQuery.toLowerCase())
    );
    setFilteredCompanies(updatedCompanies);
  }, [searchQuery, companies]);

  return (
    <div className="container">
      <Header />
      <div>
        <h2>Companies:</h2>
        <input
          type="text"
          placeholder="Search companies..."
          value={searchQuery}
          onChange={(e) => setSearchQuery(e.target.value)}
        />
        {filteredCompanies.map((company) => (
          <div key={company.companyID} className="company-frame">
            <div className="company-details">
              <p>{company.name}</p>
              <p>{company.address}</p>
            </div>
            <Link to={`/company-details/${company.companyID}`}>
                <button className="btn btn-details">DETAILS</button>
            </Link>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Home;
