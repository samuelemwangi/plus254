import React from "react";
import withStyles from "@material-ui/core/styles/withStyles";
import Grid from "@material-ui/core/Grid";
import Card from "@material-ui/core/Card";
import CardContent from "@material-ui/core/CardContent";
import Typography from "@material-ui/core/Typography";
import Link from "react-router-dom/Link";

// Custom Components
import SubHeader from "../General/SubHeader";
import GridContainer from "../General/GridContainer";
import { notFoundStyles } from "./NotFoundStyles";

const NotFound = ({ ...notFoundProps }) => {
  const { classes } = notFoundProps;

  return (
    <React.Fragment>
      <SubHeader className={classes.customSubHeaderStyle}>
        <div />
      </SubHeader>
      <GridContainer>
        <Grid item xs={12} sm={12} md={6}>
          <Card className={classes.cardStyle}>
            <CardContent className={classes.cardBodyStyle}>
              <Typography gutterBottom variant="h5" component="h2">
                Oops...!
              </Typography>
              <Typography component="p">
                We could not find a page to serve your request.
                <br />
                Click
                <Link to="/" className="go-back-link">
                  here
                </Link>
                to get home.
              </Typography>
            </CardContent>
          </Card>
        </Grid>
      </GridContainer>
    </React.Fragment>
  );
};

export default withStyles(notFoundStyles)(NotFound);
