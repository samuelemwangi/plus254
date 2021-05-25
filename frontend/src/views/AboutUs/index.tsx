import React from "react";
import type { FC } from "react";

// Material
import {
  Container,
  Box,
  Grid,
  Typography,
  experimentalStyled as styled,
  useTheme,
} from "@material-ui/core";

// Components
import Page from "../../components/Page";
import Footer from "../Footer";

// Animation
import { varFadeInUp, MotionInView } from "../../components/Animate";

// Theme
import { Theme } from "../../theme";

// Styles
const PageStyle = styled(Page)(() => {
  const appTheme: Theme = useTheme();

  return {
    backgroundColor: appTheme.palette.background.default,
    paddingTop: 155,
    paddingBottom: 155,
    paddingLeft: 40,
    [appTheme.breakpoints.down("md")]: {
      paddingTop: 80,
      paddingBottom: 60,
      paddingLeft: 5,
    },
  };
});

const AboutUsImageStyle = styled("div")(() => ({
  perspectiveOrigin: "left center",
  transformStyle: "preserve-3d",
  perspective: 1500,
  "& > img": {
    maxWidth: "100%",
    height: "auto",
    padding: 20,
    transform: "rotateY(-35deg) rotateX(15deg)",
    backfaceVisibility: "hidden",
  },
}));

// Interfaces
interface IAboutUsProps {
  className?: string;
}

const AboutUs: FC<IAboutUsProps> = () => {
  return (
    <>
      <PageStyle title="About Us">
        <Container maxWidth="lg">
          <Grid container spacing={3}>
            <Grid item xs={12} md={5}>
              <Box
                display="flex"
                flexDirection="column"
                justifyContent="center"
                height="100%"
              >
                <Typography variant="h1" color="primary" paddingBottom="5px">
                  About us
                </Typography>
                <Typography variant="body1" color="textSecondary">
                  We are about documenting the beautiful plus254
                </Typography>
              </Box>
            </Grid>
            <Grid item xs={12} md={7}>
              <Box position="relative">
                <AboutUsImageStyle>
                  <MotionInView variants={varFadeInUp}>
                    <Box
                      component="img"
                      alt="Contact us"
                      src="/static/about-us/personal-information.svg"
                      height="400px"
                      sx={{ m: "auto" }}
                    />
                  </MotionInView>
                </AboutUsImageStyle>
              </Box>
            </Grid>
          </Grid>
        </Container>
      </PageStyle>
      <Footer />
    </>
  );
};

export default AboutUs;
