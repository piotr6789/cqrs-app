import axios from 'axios';

const instance = axios.create({
  baseURL: 'https://localhost:7278/api'
});

export default instance;
