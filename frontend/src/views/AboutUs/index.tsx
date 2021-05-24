import React from "react";
import type { FC } from "react";
import clsx from "clsx";

// Material
import {
  Typography,
  Container,
  Box,
  Grid,
  experimentalStyled as styled,
} from "@material-ui/core";

// Components
import Page from "../../components/Page";
import Footer from "../Home/Footer";

// Styles
import useStyles from "./AboutUsStyles";

const ContentStyle = styled("div")(({ theme }) => ({
  overflow: "hidden",
  position: "relative",
  backgroundColor: theme.palette.background.default,
}));

interface IAboutUsProps {
  className?: string;
}

const AboutUs: FC<IAboutUsProps> = ({ className }) => {
  const classes = useStyles();

  return (
    <Page className={clsx(classes.root, className)} title="About Us">
      <ContentStyle>
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
        <Footer />
      </ContentStyle>
    </Page>
  );
};

export default AboutUs;
