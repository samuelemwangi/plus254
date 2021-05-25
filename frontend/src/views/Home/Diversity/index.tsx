import React from "react";
import type { FC } from "react";

// Router
import { Link as RouterLink } from "react-router-dom";

// Material
import {
  Box,
  Grid,
  Button,
  Container,
  Typography,
  useMediaQuery,
  experimentalStyled as styled,
  useTheme,
  alpha,
} from "@material-ui/core";

// Animation
import {
  varFadeInUp,
  varFadeInRight,
  MotionInView,
} from "../../../components/Animate";

// Theme
import { Theme } from "../../../theme";

// Styles
const RootStyle = styled("div")(() => {
  const appTheme: Theme = useTheme();

  return {
    padding: appTheme.spacing(15, 0),
    paddingTop: 175,
    backgroundImage:
      appTheme.palette.mode === "light"
        ? `linear-gradient(180deg, ${alpha(
            appTheme.palette.grey[300],
            0
          )} 0%, ${appTheme.palette.grey[300]} 100%)`
        : "none",
  };
});

const ContentStyle = styled("div")(() => {
  const appTheme: Theme = useTheme();

  return {
    maxWidth: 520,
    margin: "auto",
    textAlign: "center",
    marginBottom: appTheme.spacing(10),
    [appTheme.breakpoints.up("md")]: {
      height: "100%",
      marginBottom: 0,
      textAlign: "left",
      display: "inline-flex",
      flexDirection: "column",
      alignItems: "flex-start",
      justifyContent: "center",
      paddingRight: appTheme.spacing(5),
    },
  };
});

const ScreenStyle = styled(MotionInView)({
  bottom: 0,
  maxWidth: 460,
  position: "absolute",
});

const variantScreenLeftMoblie = {
  initial: { x: "22%", y: -10, opacity: 0 },
  animate: { x: 0, y: 0, opacity: 1 },
};
const variantScreenRightMobile = {
  initial: { x: "26%", y: -30, opacity: 0 },
  animate: { x: "48%", y: -40, opacity: 1 },
};
const variantScreenLeft = {
  initial: { x: "30%", y: -30, opacity: 0 },
  animate: { x: 0, y: 0, opacity: 1 },
};
const variantScreenCenter = {
  initial: { opacity: 0 },
  animate: { opacity: 1 },
};
const variantScreenRight = {
  initial: { x: "34%", y: -50, opacity: 0 },
  animate: { x: "64%", y: -80, opacity: 1 },
};

// Interfaces
interface IDiversityProps {
  className?: string;
}

const Diversity: FC<IDiversityProps> = () => {
  const theme = useTheme();
  const isRTL = theme.direction === "rtl";
  const upSm = useMediaQuery(theme.breakpoints.up("sm"));
  const upMd = useMediaQuery(theme.breakpoints.up("md"));

  const textAnimate = upMd ? varFadeInRight : varFadeInUp;
  const screenLeftAnimate = upSm ? variantScreenLeft : variantScreenLeftMoblie;
  const screenCenterAnimate = variantScreenCenter;
  const screenRightAnimate = upSm
    ? variantScreenRight
    : variantScreenRightMobile;

  return (
    <RootStyle>
      <Container maxWidth="lg">
        <Grid container spacing={5}>
          <Grid item xs={12} md={4} lg={5}>
            <ContentStyle>
              <MotionInView variants={textAnimate}>
                <Typography variant="h2" paragraph color="primary">
                  Diversity
                </Typography>
              </MotionInView>

              <MotionInView variants={textAnimate}>
                <Typography sx={{ color: "text.secondary" }}>
                  From Wildlife to diverse cultures, water bodies breath-taking
                  scenery...you are limited to your sight
                </Typography>
              </MotionInView>

              <MotionInView variants={textAnimate}>
                <br />
                <br />
                <Button
                  size="large"
                  color="inherit"
                  variant="outlined"
                  component={RouterLink}
                  to="/explore"
                >
                  Start Exploring
                </Button>
              </MotionInView>
            </ContentStyle>
          </Grid>

          <Grid
            dir="ltr"
            item
            xs={12}
            md={8}
            lg={7}
            sx={{
              position: "relative",
              pl: { sm: "16% !important", md: "0 !important" },
            }}
          >
            {[...Array(3)].map((_, index) => (
              <ScreenStyle
                key={index}
                threshold={0.72}
                variants={{
                  ...(index === 0 && screenLeftAnimate),
                  ...(index === 1 && screenCenterAnimate),
                  ...(index === 2 && screenRightAnimate),
                }}
                transition={{ duration: 0.5, ease: "easeOut" }}
                sx={{
                  ...(index === 0 && { zIndex: 3 }),
                  ...(index === 2 && { zIndex: 1 }),
                  ...(index === 1 && {
                    position: "relative",
                    zIndex: 2,
                    bottom: { xs: 20, sm: 40 },
                    transform: {
                      xs: isRTL ? "translateX(-24%)" : "translateX(24%)",
                      sm: isRTL ? "translateX(-32%)" : "translateX(32%)",
                    },
                  }),
                }}
              >
                <Box
                  component="img"
                  alt={`screen ${index + 1}`}
                  src={`/static/home/screen_${index + 1}.jpg`}
                  sx={{ width: { xs: "80%", sm: "100%" } }}
                />
              </ScreenStyle>
            ))}
          </Grid>
        </Grid>
      </Container>
    </RootStyle>
  );
};

export default Diversity;
