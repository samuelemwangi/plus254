import NotFoundContainer from "../Containers/Layout/NotFoundContainer";

export const appItems = [
  {
    id: 0,
    link: "/items",
    linkTitle: "Main Items"
  }
];

export const appRoutes = [
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
