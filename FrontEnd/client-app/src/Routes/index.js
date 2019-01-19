import NotFoundContainer from "../Containers/NotFound";
import SignUpFormed from "../Containers/Auth/SignUpContainer";

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
    path: "*",
    matching: true,
    pageTitle: "Page Not Found",
    component: NotFoundContainer,
    connectedlinks: []
  }
];
