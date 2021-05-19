import React from "react";
import type { FC } from "react";

// Material
import { Box, LinearProgress } from "@material-ui/core";
import { experimentalStyled as styled } from "@material-ui/core/styles";

// Styles
const LoadingWrapperStyle = styled("div")(({ theme }) => ({
  alignItems: "center",
  backgroundColor: theme.palette.background.default,
  display: "flex",
  flexDirection: "column",
  height: "100%",
  justifyContent: "center",
  minHeight: "100%",
  padding: theme.spacing(3),
}));

const LoadingScreen: FC = () => {
  return (
    <LoadingWrapperStyle>
      <Box width={400}>
        <LinearProgress color="secondary" />
      </Box>
    </LoadingWrapperStyle>
  );
};

export default LoadingScreen;
