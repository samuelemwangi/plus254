import NotFoundContainer from "../Containers/NotFoundContainer";
import ListUsersContainer from "../Containers/Users/ListUsersContainer";

export const usersLinks = [
  {
    id: 0,
    link: "/users",
    linkTitle: "View Users"
  },
  {
    id: 1,
    link: "/users/add-user",
    linkTitle: "Add User"
  }
];

export const appSettings = [
  {
    id: 0,
    link: "/app-settings",
    linkTitle: "App Settings"
  },
  {
    id: 1,
    link: "/app-settings/email-settings",
    linkTitle: "Email Settings"
  }
];

export const appItems = [
  {
    id: 0,
    link: "/items",
    linkTitle: "Main Items"
  }
];

export const appRoutes = [
  {
    path: usersLinks[0].link,
    matching: true,
    pageTitle: "Manage Users",
    component: ListUsersContainer,
    connectedlinks: usersLinks
  },
  {
    path: usersLinks[1].link,
    matching: true,
    pageTitle: "Manage Users",
    component: NotFoundContainer,
    connectedlinks: usersLinks
  },
  {
    path: appSettings[0].link,
    matching: true,
    pageTitle: "App Settings",
    component: NotFoundContainer,
    connectedlinks: appSettings
  },
  {
    path: appSettings[1].link,
    matching: true,
    pageTitle: "App Settings",
    component: NotFoundContainer,
    connectedlinks: appSettings
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
    pageTitle: "Page not found ...",
    component: NotFoundContainer,
    connectedlinks: []
  }
];
