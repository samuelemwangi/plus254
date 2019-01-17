import React from "react";
import withStyles from "@material-ui/core/styles/withStyles";

// Custom Components
import { contentStyle } from "./ContentStyle";

const Content = ({ ...contentProps }) => {
  const { classes, headerComponent, contentComponent } = contentProps;

  return (
    <div className={classes.appContent}>
      {headerComponent}
      <main className={classes.mainContent}>{contentComponent}</main>
    </div>
  );
};

export default withStyles(contentStyle)(Content);
