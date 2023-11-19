import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import companyService from '../services/CompanyService';

const Home = () => {

    const [companies, setCompanies] = useState([]);
    const [searchQuery, setSearchQuery] = useState('');


    useEffect(() => {
        companyService.getCompanies()
          .then((response) => {
            setCompanies(response.data);
          })
          .catch((error) => {
            console.error('Error fetching companies:', error);
          });
      }, []);

      const filteredCompanies = companies.filter((company) =>
      company.name.toLowerCase().includes(searchQuery.toLowerCase())
    );

    return (
        <div className="container">
            <h1>Welcome to Get Equipment!</h1>
            <div>
                <Link to="/register">
                <button className="btn btn-primary">Register</button>
                </Link>
            </div>
            <div>
            <h2>Companies:</h2>
                <input
                  type="text"
                  placeholder="Search companies..."
                  value={searchQuery}
                  onChange={(e) => setSearchQuery(e.target.value)}
                />
              <ul>
                {filteredCompanies.map((company) => (
                  <li key={company.id}>{company.name}</li>
                ))}
              </ul>
            </div>
        </div>
    );
};

export default Home;