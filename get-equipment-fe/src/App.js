import logo from './logo.svg';
import './App.css';
import { Route, Routes,  BrowserRouter } from 'react-router-dom';
import Register from './components/Registration';
import Home from './components/InitialPage';
import CompanyDetails from './components/CompanyDetails';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/register" element={<Register />} />
        <Route path="/company-details/:companyID" element={<CompanyDetails />} />
      </Routes>
      </BrowserRouter>
    </div>
  );
};

export default App;