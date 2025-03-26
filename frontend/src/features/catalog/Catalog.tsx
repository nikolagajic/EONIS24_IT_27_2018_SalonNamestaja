import { Proizvod } from "../../app/models/proizvod";
import ProizvodList from "./ProizvodList";
import { useState, useEffect } from "react";




export default function Catalog(){

    const[proizvodi, setProizvodi] = useState<Proizvod[]>([]);

    useEffect(() => {
    fetch('http://localhost:5251/api/Proizvod').then(response => response.json()).then(data => setProizvodi(data.data))
    }, [])

    return (
    <>
        <ProizvodList proizvodi={proizvodi}></ProizvodList>    
        
    </>
    )
}