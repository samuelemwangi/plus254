import React from "react";
import type { FC } from "react";

// Router
import { Link } from "react-router-dom";

// Material
import {
  Box,
  Button,
  Container,
  Grid,
  Typography,
  useMediaQuery,
  experimentalStyled as styled,
  useTheme,
} from "@material-ui/core";

// Animation
import { varFadeInUp, MotionInView } from "../../../components/Animate";

// Components
import Page from "../../../components/Page";

// Paths
import { PATHS } from "../../../routes/paths";
import { Theme } from "../../../theme";

const PageStyle = styled(Page)(() => {
  const appTheme = useTheme();

  return {
    backgroundColor: appTheme.palette.background.default,
    minHeight: "70vh",
    display: "flex",
    alignItems: "center",
    padding: appTheme.spacing(2),
    paddingTop: 150,
    paddingBottom: 170,
    [appTheme.breakpoints.down("md")]: {
      paddingTop: 80,
      paddingBottom: 600,
    },
  };
});

const TypographyMainLinkStyled = styled(Typography)(() => {
  const appTheme: Theme = useTheme();

  return {
    textAlign: "center",
    textDecoration: "none",
    paddingBottom: 30,
    "& a": {
      color: appTheme.palette.primary.main,
    },
  };
});

// Interfaces
interface INotFoundViewProps {
  className?: string;
}

const NotFoundView: FC<INotFoundViewProps> = () => {
  const theme = useTheme();
  const mobileDevice = useMediaQuery(theme.breakpoints.down("sm"));

  return (
    <PageStyle>
      <Container maxWidth="lg">
        <Grid
          container
          spacing={3}
          direction="row"
          justifyContent="center"
          alignItems="center"
        >
          <Grid item md={6} sm={8} xs={10}>
            <TypographyMainLinkStyled variant="h3">
              <Link to="/"> plus254</Link>
            </TypographyMainLinkStyled>
            <Typography
              align="center"
              variant={mobileDevice ? "h4" : "h3"}
              color="textPrimary"
            >
              404: Page not found
            </Typography>
            <Typography
              align="center"
              variant="subtitle2"
              color="textSecondary"
              paddingBottom="30px"
            >
              This page is not available. Sorry about that.
            </Typography>

            <MotionInView variants={varFadeInUp}>
              <Box
                mt={6}
                display="flex"
                justifyContent="center"
                component="img"
                alt="Contact us"
                src="/static/not_found.svg"
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
                component={Link}
                to={PATHS.HOME}
                variant="contained"
              >
                Back to home
              </Button>
            </Box>
          </Grid>
        </Grid>
      </Container>
    </PageStyle>
  );
};

export default NotFoundView;
