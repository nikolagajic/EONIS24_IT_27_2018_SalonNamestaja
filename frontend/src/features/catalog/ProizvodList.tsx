import { Grid } from "@mui/material";
import { Proizvod } from "../../app/models/proizvod";
import ProizvodCard from "./ProizvodCard";

interface Props {
    proizvodi: Proizvod[];
}

export default function ProizvodList({proizvodi} : Props) {
    return (
    <Grid container spacing={4}>
        {proizvodi.map(p => (
            <Grid item xs={3} key={p.proizvodId}>
                <ProizvodCard proizvod={p} />
            </Grid>
        ))}
    </Grid>
    )
}