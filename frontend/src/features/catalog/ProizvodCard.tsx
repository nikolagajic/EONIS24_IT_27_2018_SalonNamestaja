import { Avatar, Button, Card, CardActions, CardContent, CardHeader, CardMedia, Typography } from "@mui/material";
import { Proizvod } from "../../app/models/proizvod";
import { Link } from "react-router-dom";

interface Props {
    proizvod: Proizvod;
}

export default function ProizvodCard({proizvod}: Props) {
    return (
    <Card>
      <CardHeader avatar={
        <Avatar sx={{bgcolor: 'secondary.main'}}>
          {proizvod.naziv.charAt(0).toUpperCase()}
        </Avatar>
      } 
      title={proizvod.naziv}
      titleTypographyProps={{
        sx: {fontWeight: 'bold', color: 'primary.main'}
      }}
      />
      <CardMedia
        sx={{ height: 140, backgroundSize: 'contain' }}
        image="http://picsum.photos/200"
        title={proizvod.naziv}
      />
      <CardContent>
        <Typography gutterBottom color='secondary'variant="h5">
          {proizvod.cena}
        </Typography>
        <Typography variant="body2" color="text.secondary">
          {proizvod.opis}
        </Typography>
      </CardContent>
      <CardActions>
        <Button size="small">Dodaj u korpu</Button>
        <Button component={Link} to={`/catalog/${proizvod.proizvodId}`} size="small">Pogledaj</Button>
      </CardActions>
    </Card>
    )
}