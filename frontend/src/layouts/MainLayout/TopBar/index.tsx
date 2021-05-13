import React from "react";
import type { FC } from "react";
import { Link as RouterLink } from "react-router-dom";
import clsx from "clsx";
import PropTypes from "prop-types";
import { AppBar, Box, Button, Divider, Toolbar, Link } from "@material-ui/core";

import Logo from "../../../components/Logo";

// Styles
import topBarStyles from "./TopBarStyles";

interface TopBarProps {
  className?: string;
}

const TopBar: FC<TopBarProps> = ({ className, ...rest }) => {
  const classes = topBarStyles();

  return (
    <AppBar className={clsx(classes.root, className)} color="default" {...rest}>
      <Toolbar className={classes.toolbar}>
        <RouterLink to="/" className={classes.logoLink}>
          <Logo className={classes.logo} name="Upfik" />
        </RouterLink>
        <Box flexGrow={1} />
        <Link
          className={classes.link}
          color="textSecondary"
          component={RouterLink}
          to="/"
          underline="none"
          variant="body2"
        >
          Home
        </Link>
        <Link
          className={classes.link}
          color="textSecondary"
          component={RouterLink}
          to="/about"
          underline="none"
          variant="body2"
        >
          About us
        </Link>
        <Divider className={classes.divider} />
        <Button
          component={RouterLink}
          to="/hire-us"
          color="secondary"
          variant="outlined"
          size="small"
        >
          Hire us
        </Button>
      </Toolbar>
    </AppBar>
  );
};

TopBar.propTypes = {
  className: PropTypes.string,
};

export default TopBar;
