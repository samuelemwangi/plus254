import React from "react";
import type { FC } from "react";

// Material
import {
  Box,
  Container,
  Typography,
  experimentalStyled as styled,
  useTheme,
} from "@material-ui/core";

// Animation
import { varFadeInUp, MotionInView } from "../../../components/Animate";

// Theme
import { Theme } from "../../../theme";

// Styles
const RootStyle = styled("div")(() => {
  const appTheme: Theme = useTheme();

  return {
    paddingTop: appTheme.spacing(15),
    paddingBottom: appTheme.spacing(10),
  };
});

const ContentStyle = styled("div")(() => {
  const appTheme: Theme = useTheme();

  return {
    maxWidth: 520,
    margin: "auto",
    textAlign: "center",
    [appTheme.breakpoints.up("md")]: {
      textAlign: "left",
      position: "absolute",
    },
  };
});

// Main component
const Summary: FC = () => {
  return (
    <RootStyle>
      <Container maxWidth="lg">
        <ContentStyle>
          <MotionInView variants={varFadeInUp}>
            <Typography
              gutterBottom
              variant="overline"
              sx={{ color: "text.secondary", display: "block" }}
            >
              Come and Enjoy...
            </Typography>
          </MotionInView>

          <MotionInView variants={varFadeInUp}>
            <Typography variant="h2" paragraph>
              We are friendly!
            </Typography>
          </MotionInView>
        </ContentStyle>

        <MotionInView variants={varFadeInUp}>
          <Box
            component="img"
            alt="multipage"
            src="/static/home/giraffe.png"
            sx={{ m: "auto" }}
          />
        </MotionInView>
      </Container>
    </RootStyle>
  );
};

export default Summary;
