import React from "react";
import Grid from "@material-ui/core/Grid";
import withStyles from "@material-ui/core/styles/withStyles";

// Custom Components
import { subHeaderStyle } from "./SubHeaderStyle";

const SubHeader = ({ ...subHeaderProps }) => {
  const { classes, children, className } = subHeaderProps;

  return (
    <Grid
      item
      md={12}
      sm={12}
      xs={12}
      className={`${classes.wrapper} ${className}`}
    >
      {children}
    </Grid>
  );
};

export default withStyles(subHeaderStyle)(SubHeader);
