import React from "react";
import type { FC, ReactNode } from "react";
import PropTypes from "prop-types";
import TopBar from "./TopBar";

// Styles
import mainLayoutStyles from "./MainLayoutStyles";

interface MainLayoutProps {
  children?: ReactNode;
}

const MainLayout: FC<MainLayoutProps> = ({ children }) => {
  const classes = mainLayoutStyles();

  return (
    <div className={classes.root}>
      <TopBar />
      <div className={classes.wrapper}>
        <div className={classes.contentContainer}>
          <div className={classes.content}>{children}</div>
        </div>
      </div>
    </div>
  );
};

MainLayout.propTypes = {
  children: PropTypes.node,
};

export default MainLayout;
