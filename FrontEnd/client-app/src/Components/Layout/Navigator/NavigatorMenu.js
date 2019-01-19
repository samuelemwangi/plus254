import React from "react";
import CategoryIcon from "@material-ui/icons/Category";
import Lock from "@material-ui/icons/Lock";

export const navigatorMenu = [
  {
    id: "Menu",
    children: [{ id: "Items", link: "/items", icon: <CategoryIcon /> }]
  },
  {
    id: "Settings",
    children: [{ id: "Authentication", link: "/auth", icon: <Lock /> }]
  }
];
