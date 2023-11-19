import axios from 'axios';

const apiUrl = "https://localhost:44320/api/v1/auth/Register";

const registerUser = (data) => {
  return axios.post(apiUrl, data);
};

export default { registerUser };
