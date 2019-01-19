import React from "react";
import ListItem from "@material-ui/core/ListItem";
import List from "@material-ui/core/List";
import Link from "react-router-dom/Link";
import Button from "@material-ui/core/Button";
import Person from "@material-ui/icons/Person";
import Help from "@material-ui/icons/Help";
import withStyles from "@material-ui/core/styles/withStyles";

// Custom Componenets
import { linksStyle } from "./LinksStyle";

const LeftLinks = ({ ...leftLinksProps }) => {
  const { classes, customHeaderClasses, pageTitle } = leftLinksProps;
  return (
    <List className={`${classes.list} ${customHeaderClasses}`}>
      <ListItem className={classes.listItem}>
        <Button className={classes.navLink}>{pageTitle}</Button>
      </ListItem>
    </List>
  );
};

const RightLinks = ({ ...rightLinksProps }) => {
  const { classes, customHeaderClasses } = rightLinksProps;

  return (
    <List className={`${classes.list} ${customHeaderClasses}`}>
      <ListItem className={classes.listItem}>
        <Button className={classes.navLink} component={Link} to="/help">
          <Help className={classes.icons} />
        </Button>
      </ListItem>
      <ListItem className={classes.listItem}>
        <Button
          type="Flat"
          component={Link}
          to="/sign-up"
          className={classes.navLink}
        >
          {rightLinksProps.signedIn && rightLinksProps.signedIn === 1 && (
            <Person className={classes.icons} />
          )}
          {((rightLinksProps.signedIn && rightLinksProps.signedIn !== 1) ||
            rightLinksProps.signedIn === undefined) &&
            "Sign Up"}
        </Button>
      </ListItem>
    </List>
  );
};

const HeaderRightLinks = withStyles(linksStyle)(RightLinks);
const HeaderLeftLinks = withStyles(linksStyle)(LeftLinks);

export { HeaderRightLinks, HeaderLeftLinks };
