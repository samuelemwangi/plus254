import React from "react";
import withStyles from "@material-ui/core/styles/withStyles";
import Grid from "@material-ui/core/Grid";
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import Link from "react-router-dom/Link";

// Custom Components
import { notFoundStyles } from "./NotFoundStyles";

const NotFound = ({ ...notFoundProps }) => {
  const { classes } = notFoundProps;

  return (
    <Grid xs={12} sm={12} md={6}>
      <Card>
        <CardContent className={classes.cardBodyStyle}>
          <div>
            Oops..! <br />
            We could not find a page to serve your request.
            <br />
            Click
            <Link to="/" className="go-back-link">
              here
            </Link>
            to get home.
          </div>
        </CardContent>
      </Card>
    </Grid>
  );
};

export default withStyles(notFoundStyles)(NotFound);
