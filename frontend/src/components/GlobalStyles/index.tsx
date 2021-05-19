import type { FC } from "react";
import { createStyles, makeStyles } from "@material-ui/styles";
import { Theme } from "../../theme";

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    "@global": {
      "*": {
        boxSizing: "border-box",
        margin: 0,
        padding: 0,
      },
      html: {
        "-webkit-font-smoothing": "antialiased",
        "-moz-osx-font-smoothing": "grayscale",
        height: "100%",
        width: "100%",
      },
      body: {
        height: "100%",
        width: "100%",
        backgroundColor: theme.palette.background.default,
      },
      "#root": {
        height: "100%",
        width: "100%",
      },
      a: { textDecoration: "none" },
      img: { display: "block", maxWidth: "100%" },

      // Lazy Load Img
      ".blur-up": {
        WebkitFilter: "blur(5px)",
        filter: "blur(5px)",
        transition: "filter 400ms, -webkit-filter 400ms",
      },
      ".blur-up.lazyloaded ": {
        WebkitFilter: "blur(0)",
        filter: "blur(0)",
      },
    },
  })
);

const GlobalStyles: FC = () => {
  useStyles();

  return null;
};

export default GlobalStyles;
