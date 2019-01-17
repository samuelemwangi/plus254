import React from "react";
import PeopleIcon from "@material-ui/icons/People";
import DnsRoundedIcon from "@material-ui/icons/DnsRounded";
import PublicIcon from "@material-ui/icons/Public";
import TimerIcon from "@material-ui/icons/Timer";
import SettingsIcon from "@material-ui/icons/Settings";
import Lock from "@material-ui/icons/Lock";

export const navigatorMenu = [
  {
    id: "Settings",
    children: [
      { id: "Users", link: "/users", icon: <PeopleIcon /> },
      { id: "App Items", link: "/items", icon: <DnsRoundedIcon /> },
      { id: "App Settings", link: "/app-settings", icon: <PublicIcon /> },
      { id: "Authentication", link: "/auth", icon: <Lock /> }
    ]
  },
  {
    id: "Reports",
    children: [
      { id: "Analytics", link: "/analytics", icon: <SettingsIcon /> },
      { id: "Performance", link: "/performance", icon: <TimerIcon /> }
    ]
  }
];
