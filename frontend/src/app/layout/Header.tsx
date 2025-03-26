import { ShoppingCart } from "@mui/icons-material";
import { AppBar, Badge, Box, IconButton, List, ListItem, Toolbar, Typography } from "@mui/material";
import { NavLink } from "react-router-dom";

const rightLinks = [
    {title: 'login', path:'/login'},
    {title: 'register', path:'/register'}
]

export default function Header() {
    return (
    <>
        <AppBar postion='static'>
            <Toolbar sx={{display: 'flex', justifyContent:'space-between', alignItems:'center'}}>
                <Typography variant='h6'>
                    SALON
                </Typography>
                <Box display='flex' alignItems='center'> 
                <IconButton size='large' edge='start' color='inherit' sx={{mr: 2}}>
                    <Badge badgeContent='4' color='secondary'>
                        <ShoppingCart/>
                    </Badge>
                </IconButton>
                <List sx={{display: 'flex'}}>
                    {rightLinks.map(({title, path}) => (
                        <ListItem component={NavLink} to={path} key={path} sx={{color: 'inherit', typography:'h6',
                            '&:hover': {
                                color: 'grey.500'
                            },
                            '&.active': {
                                color: 'text.secondary'
                            }
                        }}>
                            {title.toUpperCase()}
                        </ListItem>
                    ))}
                </List>
                </Box>
            </Toolbar>
        </AppBar>
        <Toolbar sx={{mb: 4}}/>
    </>
    )
}