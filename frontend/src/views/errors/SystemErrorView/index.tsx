import React from "react";
import type { FC } from "react";
import { Link as RouterLink } from "react-router-dom";

import {
  Box,
  Button,
  Container,
  Typography,
  useMediaQuery,
  experimentalStyled as styled,
  useTheme,
} from "@material-ui/core";

import Page from "../../../components/Page";

// Animation
import { varFadeInUp, MotionInView } from "../../../components/Animate";

// Components
import Footer from "../../Footer";

const PageStyle = styled(Page)(() => {
  const appTheme = useTheme();

  return {
    backgroundColor: appTheme.palette.background.default,
    minHeight: "70vh",
    display: "flex",
    alignItems: "center",
    padding: appTheme.spacing(2),
  };
});

// Interfaces
interface ISystemErrorViewProps {
  className?: string;
}

const SystemErrorView: FC<ISystemErrorViewProps> = () => {
  const theme = useTheme();
  const mobileDevice = useMediaQuery(theme.breakpoints.down("sm"));

  return (
    <>
      <PageStyle>
        <Container maxWidth="lg">
          <Typography
            align="center"
            variant={mobileDevice ? "h4" : "h1"}
            color="textPrimary"
          >
            500: System Error
          </Typography>
          <Typography align="center" variant="subtitle2" color="textSecondary">
            A System error occured. Sorry about that.
          </Typography>

          <MotionInView variants={varFadeInUp}>
            <Box
              mt={6}
              display="flex"
              justifyContent="center"
              component="img"
              alt="Contact us"
              src="/static/server_down.svg"
              height="400px"
              sx={{
                m: "auto",
                maxWidth: "100%",
                width: 560,
                maxHeight: 300,
                height: "auto",
              }}
            />
          </MotionInView>

          <Box mt={6} display="flex" justifyContent="center">
            <Button
              color="secondary"
              component={RouterLink}
              to="/"
              variant="outlined"
            >
              Back to home
            </Button>
          </Box>
        </Container>
      </PageStyle>
      <Footer />
    </>
  );
};

export default SystemErrorView;
