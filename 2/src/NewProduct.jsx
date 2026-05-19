import React from 'react'
import { useNavigate } from 'react-router-dom';

export default function NewProduct() {
    const navigate = useNavigate();

    function Bekuld(event) {
        event.preventDefault();

        let datas = {
            kepek: document.getElementById("kepek").value,
            megnevezes: document.getElementById("megnevezes").value,
            leiras: document.getElementById("leiras").value,
        }

         fetch("https://localhost:7082/api/UjTipusok", {
            method: "POST",
            body: JSON.stringify(datas),
            headers: {
                "Content-Type" : "application/json"
            }
            
         })
            .then((res) => {
                alert("Siker!");
                navigate("/")
    })
            .catch((error) => console.log(error));
        
    }
    return (
        <div className='row justify-content-center'>
            <h2>Új termék felvitele</h2>

            <form onSubmit={Bekuld} className="col-12 col-md-6">
                <div className="mb-3">
                    <label htmlFor="megnevezes" className="form-label">Termék megnevezése</label>
                    <input id="megnevezes" type="text" className="form-control" />
                </div>

                <div className="mb-3">
                    <label htmlFor="kepek" className="form-label">Termék képe (URL)</label>
                    <input id="kepek" type="text" className="form-control" />
                </div>

                <div className="mb-3">
                    <label htmlFor="leiras" className="form-label">Termék leírása</label>
                    <textarea id="leiras" className="form-control" rows="4"></textarea>
                </div>

                <button type="submit" className="btn btn-primary">Küldés</button>
            </form>
        </div>
    )
}
