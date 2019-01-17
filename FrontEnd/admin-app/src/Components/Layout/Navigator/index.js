import React from "react";
import Hidden from "@material-ui/core/Hidden";
import classNames from "classnames";
import withStyles from "@material-ui/core/styles/withStyles";
import Drawer from "@material-ui/core/Drawer";
import List from "@material-ui/core/List";
import ListItem from "@material-ui/core/ListItem";
import Divider from "@material-ui/core/Divider";
import ListItemIcon from "@material-ui/core/ListItemIcon";
import ListItemText from "@material-ui/core/ListItemText";
import HomeIcon from "@material-ui/icons/Home";
import Link from "react-router-dom/Link";

// Custom Components
import { navigatorStyle, drawerWidth } from "./NavigatorStyle";
import { navigatorMenu } from "./NavigatorMenu";

const Navigator = ({ ...navigatorProps }) => {
  const {
    classes,
    handleDrawerToggle,
    mobileOpen,
    currentLink
  } = navigatorProps;

  const drawerProps = {
    variant: "temporary",
    open: mobileOpen,
    onClose: handleDrawerToggle
  };

  const paperProps = { style: { width: drawerWidth } };

  const appDrawerList = (
    <List disablePadding>
      <ListItem
        className={classNames(
          classes.firebase,
          classes.item,
          classes.itemCategory
        )}
      >
        Admin Portal
      </ListItem>
      <ListItem className={classNames(classes.item, classes.itemCategory)}>
        <ListItemIcon>
          <HomeIcon />
        </ListItemIcon>
        <ListItemText
          classes={{
            primary: classes.itemPrimary
          }}
        >
          Manage App
        </ListItemText>
      </ListItem>
      {navigatorMenu.map(({ id, children }) => (
        <React.Fragment key={id}>
          <ListItem className={classes.categoryHeader}>
            <ListItemText
              classes={{
                primary: classes.categoryHeaderPrimary
              }}
            >
              {id}
            </ListItemText>
          </ListItem>
          {children.map(({ id: childId, icon, link }) => (
            <ListItem
              button
              dense
              key={childId}
              className={classNames(
                classes.item,
                classes.itemActionable,
                currentLink.includes(link) && classes.itemActiveItem
              )}
              component={Link}
              to={link}
            >
              <ListItemIcon>{icon}</ListItemIcon>
              <ListItemText
                classes={{
                  primary: classes.itemPrimary,
                  textDense: classes.textDense
                }}
              >
                {childId}
              </ListItemText>
            </ListItem>
          ))}
          <Divider className={classes.divider} />
        </React.Fragment>
      ))}
    </List>
  );

  return (
    <nav className={classes.drawer}>
      <Hidden smUp implementation="js">
        <Drawer {...drawerProps} PaperProps={paperProps}>
          {appDrawerList}
        </Drawer>
      </Hidden>
      <Hidden xsDown implementation="css">
        <Drawer variant="permanent" PaperProps={paperProps}>
          {appDrawerList}
        </Drawer>
      </Hidden>
    </nav>
  );
};

export default withStyles(navigatorStyle)(Navigator);
