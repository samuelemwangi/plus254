import React from "react";
import withStyles from "@material-ui/core/styles/withStyles";

// Custom Components
import { contentStyle } from "./ContentStyle";

const Content = ({ ...contentProps }) => {
  const { contentComponent, classes } = contentProps;

  return <section className={classes.wrapper}>{contentComponent}</section>;
};

export default withStyles(contentStyle)(Content);
