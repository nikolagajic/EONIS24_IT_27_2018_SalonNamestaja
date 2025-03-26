import Catalog from "../../features/catalog/Catalog";
import { Container, CssBaseline, ThemeProvider, createTheme} from "@mui/material";
import Header from "./Header";
import { Outlet } from "react-router-dom";


function App() {
  
  const theme = createTheme({
    palette: {
      mode: 'light',
      background: {
        default: '#eaeaea'
      }
    }
  })

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Header />
      <Container>
        <Outlet />
      </Container>
    </ThemeProvider> 
  )
}

export default App
