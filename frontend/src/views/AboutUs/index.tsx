import React from "react";
import type { FC } from "react";
import { Typography, Container, Box, Grid } from "@material-ui/core";
import clsx from "clsx";

import Page from "../../components/Page";
import FAQS from "../Home/FAQs";
// Styles
import useStyles from "./AboutUsStyles";

interface IAboutUsProps {
  className?: string;
}

const AboutUs: FC<IAboutUsProps> = ({ className }) => {
  const classes = useStyles();

  return (
    <Page className={clsx(classes.root, className)} title="About Us">
      <Container maxWidth="lg" className={classes.aboutUs}>
        <Box mt={8}>
          <Grid container spacing={3}>
            <Grid item md={8} sm={8} xs={10}>
              <Typography variant="h2" align="left" color="textPrimary">
                About Us
              </Typography>
              <Typography component="p" className={classes.aboutBody}>
                We are we
              </Typography>
              <Typography component="p" className={classes.aboutCaption}>
                We ....
              </Typography>
            </Grid>
          </Grid>
        </Box>
      </Container>
      <FAQS />
    </Page>
  );
};

export default AboutUs;
