import { createBrowserRouter } from "react-router-dom";
import ProizvodDetails from "../../features/catalog/ProizvodDetails";
import Catalog from "../../features/catalog/Catalog";
import App from "../layout/App";

export const router = createBrowserRouter([
    {
        path: '/',
        element: <App />,
        children: [
            {
                path: 'catalog',
                element: <Catalog />
            },
            {
                path: 'catalog/:id',
                element: <ProizvodDetails />
            }
        ]
    }
])