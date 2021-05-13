import { makeStyles } from "@material-ui/core/styles";
import { Theme } from "../../../theme";

export default makeStyles((theme: Theme) => ({
  root: {
    backgroundColor: theme.palette.background.default,
    paddingTop: 200,
    paddingBottom: 200,
    [theme.breakpoints.down("md")]: {
      paddingTop: 60,
      paddingBottom: 60,
    },
  },
  technologyIcon: {
    height: 40,
    margin: theme.spacing(1),
  },
  image: {
    perspectiveOrigin: "left center",
    transformStyle: "preserve-3d",
    perspective: 1500,
    "& > img": {
      maxWidth: "100%",
      height: "auto",
      padding: 20,
      // transform: "rotateY(-35deg) rotateX(15deg)",
      backfaceVisibility: "hidden",
      boxShadow: theme.shadows[16],
    },
  },
  shape: {
    position: "absolute",
    top: 0,
    left: 0,
    "& > img": {
      maxWidth: "90%",
      height: "auto",
    },
  },
}));
