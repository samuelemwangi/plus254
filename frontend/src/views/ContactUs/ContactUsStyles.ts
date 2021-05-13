import { makeStyles } from "@material-ui/core";
import { Theme } from "../../theme";

export default makeStyles((theme: Theme) => ({
  root: {},
  hireUsWrapper: {
    paddingTop: 80,
    paddingBottom: 50,
    paddingLeft: 50,
  },
  formWrapper: {
    "& form": {
      paddingLeft: 0,
      paddingRight: 5,
    },
  },
  formHelperResult: {
    fontSize: 14,
    // fontStyle: "italic",
    paddingBottom: 15,
  },
  "@keyframes animatesubmit": {
    "0% ": { backgroundColor: theme.palette.background.default },
    "25% ": { backgroundColor: theme.palette.background.dark },
    "50%": { backgroundColor: theme.palette.background.default },
    "100%": { backgroundColor: theme.palette.background.dark },
  },
  buttonProgress: {
    backgroundColor: theme.palette.background.default,
    animationName: "$animatesubmit",
    animationDuration: "4s",
    animationIterationCount: "infinite",
  },
}));
