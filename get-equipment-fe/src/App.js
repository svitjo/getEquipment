import logo from './logo.svg';
import './App.css';
import { Route, Routes,  BrowserRouter } from 'react-router-dom';
import Register from './components/Registration';
import Home from './components/InitialPage';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/register" element={<Register />} />
      </Routes>
      </BrowserRouter>
    </div>
  );
};

export default App;