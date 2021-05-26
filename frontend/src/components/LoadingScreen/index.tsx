import React from "react";
import type { FC } from "react";

// Material
import {
  Box,
  LinearProgress,
  experimentalStyled as styled,
  useTheme,
  useMediaQuery,
} from "@material-ui/core";

// Theme
import { Theme } from "../../theme";

// Styles
const LoadingWrapperStyle = styled("div")(() => {
  const appTheme: Theme = useTheme();

  return {
    alignItems: "center",
    backgroundColor: appTheme.palette.background.default,
    display: "flex",
    flexDirection: "column",
    height: "100%",
    justifyContent: "center",
    minHeight: "100%",
    padding: appTheme.spacing(3),
  };
});

const LoadingScreen: FC = () => {
  const theme = useTheme();

  const isDesktop = useMediaQuery(theme.breakpoints.up("md"));

  return (
    <LoadingWrapperStyle>
      <Box
        sx={{
          width: isDesktop ? "400px" : "40vw",
        }}
      >
        <LinearProgress color="secondary" />
      </Box>
    </LoadingWrapperStyle>
  );
};

export default LoadingScreen;
