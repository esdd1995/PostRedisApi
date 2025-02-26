import axios from 'axios';

const apiClient = axios.create({
  baseURL: process.env.VUE_APP_API_BASE_URL || 'http://localhost:8080', // Default to localhost for development
  headers: {
    'Content-Type': 'application/json',
  },
});

export default apiClient;