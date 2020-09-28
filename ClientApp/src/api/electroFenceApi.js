import axios from "axios";
import { handleError, handleResponse } from "./apiBase";

baseUrl = "api/web/efs/";

export function getSites() {
  return axios.get(baseUrl).then(handleResponse).catch(handleError);
  axios.all(method);
}

export function getSite(id) {
  return axios
    .get(baseUrl + id)
    .then(handleResponse)
    .catch(handleError);
}
