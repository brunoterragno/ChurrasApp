import axios from "axios";

const contentType = "application/json";

axios.defaults.baseURL = "http://localhost:5000/api/";
axios.defaults.headers.post["Content-Type"] = contentType;
axios.defaults.headers.put["Content-Type"] = contentType;

export const getAllBarbecues = () => axios.get("barbecues");

export const getBarbecue = id => axios.get(`barbecues/${id}`);

export const createBarbecue = barbecue =>
  axios.post(`barbecues`, JSON.stringify(barbecue));

export const editBarbecue = barbecue =>
  axios.put(`barbecues`, JSON.stringify(barbecue));

export const deleteBarbecue = id => axios.delete(`barbecues/${id}`);
