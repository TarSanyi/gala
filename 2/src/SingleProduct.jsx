import React from 'react'
import { useState, useEffect } from 'react';
import { Link, useParams } from 'react-router-dom';

export default function SingleProduct() {

    const [data, setData] = useState({});

    const { id } = useParams()

    useEffect(() => {
        fetch("https://localhost:7082/api/Tipusok/" + id)
            .then((res) => res.json())
            .then((data) => setData(data));
    }, []);

    return (
        <div className='row justify-content-center'>
            
            <div className="card" style={{ width: "18rem" }}>

                <div className="card-body">
                    <h5 className="card-title">{data.megnevezes}</h5>
                    <p className="card-text">{data.leiras}</p>
                    <img src={data.kepek} className="img-fluid" style={{ maxHeight: 200 }} />
                </div>

            <Link to={"/"}>
                <i className="bi bi-arrow-left-circle-fill"></i>
            </Link>

            </div>
        </div>
    )
}
