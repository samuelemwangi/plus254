import React from "react";
import type { FC } from "react";

// Material
import { experimentalStyled as styled } from "@material-ui/core/styles";
import { Box, Container, Typography } from "@material-ui/core";
//
import { varFadeInUp, MotionInView } from "../../../components/Animate";

// Styles
const RootStyle = styled("div")(({ theme }) => ({
  paddingTop: theme.spacing(15),
  paddingBottom: theme.spacing(10),
}));

const ContentStyle = styled("div")(({ theme }) => ({
  maxWidth: 520,
  margin: "auto",
  textAlign: "center",
  [theme.breakpoints.up("md")]: {
    textAlign: "left",
    position: "absolute",
  },
}));

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
