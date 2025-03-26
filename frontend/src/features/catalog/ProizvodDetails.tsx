import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Proizvod } from "../../app/models/proizvod";
import { Divider, Grid, Typography, Table, TableContainer, TableBody, TableRow, TableCell } from "@mui/material";

export default function ProizvodDetails() {

    const {id} = useParams<{id : string}>();

    const [proizvod, setProizvod] = useState<Proizvod | null>(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        axios.get(`http://localhost:5251/api/Proizvod/${id}`).then(response => setProizvod(response.data.data))
        .catch(error => console.log(error)).finally(() => setLoading(false));
    }, [id])

    if (loading) return <h3>Ucitavanje...</h3>

    if (!proizvod) return <h3>Proizvod nije pronadjen</h3>

    return (
        <Grid container spacing={6}>
            <Grid item xs={6}>
                <img src='http://picsum.photos/200' alt={proizvod.naziv} style={{width: '100%'}} />
            </Grid>
            <Grid item xs={6}>
                <Typography variant='h3'>{proizvod.naziv}</Typography>
                <Divider sx={{mb: 2}}/>
                <Typography variant='h4' color='secondary'>{proizvod.cena} RSD</Typography>
                <TableContainer>
                    <Table>
                        <TableBody>
                            <TableRow>
                                <TableCell>Naziv</TableCell>
                                <TableCell>{proizvod.naziv}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Opis</TableCell>
                                <TableCell>{proizvod.opis}</TableCell>
                            </TableRow>
                            <TableRow>
                                <TableCell>Materijal</TableCell>
                                <TableCell>{proizvod.materijal}</TableCell>
                            </TableRow>
                        </TableBody>
                    </Table>
                </TableContainer>
            </Grid>
        </Grid>
    )
}