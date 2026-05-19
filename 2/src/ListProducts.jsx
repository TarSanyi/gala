import React from 'react'
import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

export default function ListProducts() {
    const [data, setData] = useState(null);

    useEffect(() => {
        fetch("https://localhost:7082/api/Tipusok")
            .then((res) => res.json())
            .then((data) => setData(data));
    }, []);

    return (
        <div className='row justify-content-center'>
            <h1>Tipusok:</h1>
            {data &&
                data.map((item) => {
                    return (
                        <div key={item.id} className="card" style={{ width: "18rem"}}>
                            <Link to={"/tip/" + item.id}>
                                <div className="card-body">
                                    <h5 className="card-title">{item.megnevezes}</h5>
                                    <p className="card-text">{item.leiras}</p>
                                    <img src={item.kepek} className="img-fluid" style={{ maxHeight: 200 }}/>
                                </div>
                            </Link>
                        </div>
                    )
                })}
        </div>
    );
}
