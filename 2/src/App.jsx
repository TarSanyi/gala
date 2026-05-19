import './App.css'
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import ListProducts from './ListProducts';
import SingleProduct from './SingleProduct';
import NewProduct from './NewProduct';
import Navbar from './Navbar';

function App() {

  return (
    <BrowserRouter>
    <Navbar/>

      <Routes>
        <Route path="/" element={<ListProducts />} />
        <Route path="/tip/:id" element={<SingleProduct />} />
        <Route path="/uj-tip" element={<NewProduct />} />
      </Routes>
    </BrowserRouter>
  )
}

export default App
