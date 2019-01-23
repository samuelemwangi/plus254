import NotFoundContainer from "../Containers/NotFound";
import SignUpFormed from "../Containers/Auth/SignUpContainer";
import ProductContainer from "../Containers/Product";

import { appItems, authItems } from "./RouteItems";

export const appRoutes = [
  {
    path: authItems[0].link,
    matching: true,
    pageTitle: "Sign Up",
    component: SignUpFormed,
    connectedlinks: authItems
  },
  {
    path: appItems[0].link,
    matching: true,
    pageTitle: "App Items",
    component: NotFoundContainer,
    connectedlinks: appItems
  },
  {
    path: "/product",
    matching: true,
    pageTitle: "Product Item",
    component: ProductContainer,
    connectedlinks: []
  },
  {
    path: "*",
    matching: true,
    pageTitle: "Page Not Found",
    component: NotFoundContainer,
    connectedlinks: []
  }
];
