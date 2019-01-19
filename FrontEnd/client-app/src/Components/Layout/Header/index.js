import React from "react";
import AppBar from "@material-ui/core/AppBar";
import Toolbar from "@material-ui/core/Toolbar";
import Hidden from "@material-ui/core/Hidden";
import Button from "@material-ui/core/Button";
import IconButton from "@material-ui/core/IconButton";
import MenuIcon from "@material-ui/icons/Menu";
import withStyles from "@material-ui/core/styles/withStyles";
import classNames from "classnames";
import Link from "react-router-dom/Link";

// Custom Components

import { headerStyle } from "./HeaderStyle";
import { HeaderRightLinks, HeaderLeftLinks } from "./Links";

const Header = ({ ...headerProps }) => {
  const { classes, onDrawerToggle, pageTitle } = headerProps;

  const appBarClasses = classNames({
    [classes.appBar]: true,
    [classes.absolute]: true,
    [classes.fixed]: true
  });

  return (
    <AppBar color="primary" position="fixed" className={appBarClasses}>
      <Toolbar className={classes.container}>
        <Hidden smUp>
          <IconButton
            color="inherit"
            aria-label="Open drawer"
            onClick={onDrawerToggle}
            className={classes.menuButton}
          >
            <MenuIcon />
          </IconButton>
        </Hidden>
        <Hidden smDown implementation="css">
          <Button className={classes.title} component={Link} to="/">
            App
          </Button>
        </Hidden>
        <HeaderLeftLinks pageTitle={pageTitle} />
        <div className={classes.flex} />
        <Hidden smDown implementation="css">
          <HeaderRightLinks />
        </Hidden>
      </Toolbar>
    </AppBar>
  );
};

export default withStyles(headerStyle)(Header);
