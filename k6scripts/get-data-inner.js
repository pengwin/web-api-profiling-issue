import http from 'k6/http';

export default function () {
  http.get('http://localhost:5001/data');
}