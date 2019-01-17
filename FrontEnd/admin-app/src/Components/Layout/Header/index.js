import React, { Fragment } from "react";
import AppBar from "@material-ui/core/AppBar";
import Avatar from "@material-ui/core/Avatar";
import Button from "@material-ui/core/Button";
import Grid from "@material-ui/core/Grid";
import HelpIcon from "@material-ui/icons/Help";
import Hidden from "@material-ui/core/Hidden";
import IconButton from "@material-ui/core/IconButton";
import MenuIcon from "@material-ui/icons/Menu";
import NotificationsIcon from "@material-ui/icons/Notifications";
import Tab from "@material-ui/core/Tab";
import Tabs from "@material-ui/core/Tabs";
import Toolbar from "@material-ui/core/Toolbar";
import Tooltip from "@material-ui/core/Tooltip";
import Typography from "@material-ui/core/Typography";
import withStyles from "@material-ui/core/styles/withStyles";
import Link from "react-router-dom/Link";

// Custom Components
import { headerStyle } from "./HeaderStyle";

const avatarImage =
  "https://pbs.twimg.com/profile_images/815809675614679040/cv9gLydN_400x400.jpg";

const Header = ({ ...headerProps }) => {
  const { classes, onDrawerToggle, routeProps } = headerProps;

  const subHeaderLinks = [];
  let subHeader = "";

  let targetLinkIndex = 0;

  for (let index = 0; index < routeProps.connectedlinks.length; index++) {
    if (routeProps.path === routeProps.connectedlinks[index].link) {
      targetLinkIndex = index;
    }

    subHeaderLinks.push(
      <Tab
        textColor="inherit"
        label={routeProps.connectedlinks[index].linkTitle}
        key={routeProps.connectedlinks[index].id}
        component={Link}
        to={routeProps.connectedlinks[index].link}
      />
    );
  }

  subHeader = (
    <Tabs value={targetLinkIndex} textColor="inherit">
      {subHeaderLinks}
    </Tabs>
  );

  return (
    <Fragment>
      <AppBar color="primary" position="sticky" elevation={0}>
        <Toolbar>
          <Grid container spacing={8} alignItems="center">
            <Hidden smUp>
              <Grid item>
                <IconButton
                  color="inherit"
                  aria-label="Open drawer"
                  onClick={onDrawerToggle}
                  className={classes.menuButton}
                >
                  <MenuIcon />
                </IconButton>
              </Grid>
            </Hidden>
            <Grid item xs />
            <Grid item>
              <Typography className={classes.link} component={Link} to="/">
                User Guides
              </Typography>
            </Grid>
            <Grid item>
              <Tooltip title="Alerts • No alters">
                <IconButton color="inherit">
                  <NotificationsIcon />
                </IconButton>
              </Tooltip>
            </Grid>
            <Grid item>
              <IconButton color="inherit" className={classes.iconButtonAvatar}>
                <Avatar className={classes.avatar} src={avatarImage} />
              </IconButton>
            </Grid>
          </Grid>
        </Toolbar>
      </AppBar>
      <AppBar
        component="div"
        className={classes.secondaryBar}
        color="primary"
        position="static"
        elevation={0}
      >
        <Toolbar>
          <Grid container alignItems="center" spacing={8}>
            <Grid item xs>
              <Typography color="inherit" variant="h5">
                {routeProps.pageTitle}
              </Typography>
            </Grid>
            <Grid item>
              <Button
                className={classes.button}
                variant="outlined"
                color="inherit"
                size="small"
                component={Link}
                to="/"
              >
                Front End
              </Button>
            </Grid>
            <Grid item>
              <Tooltip title="Help">
                <IconButton color="inherit">
                  <HelpIcon />
                </IconButton>
              </Tooltip>
            </Grid>
          </Grid>
        </Toolbar>
      </AppBar>
      <AppBar
        component="div"
        className={classes.secondaryBar}
        color="primary"
        position="static"
        elevation={0}
      >
        {subHeader}
      </AppBar>
    </Fragment>
  );
};

export default withStyles(headerStyle)(Header);
