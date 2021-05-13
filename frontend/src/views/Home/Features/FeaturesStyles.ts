import { makeStyles } from "@material-ui/core/styles";
import { Theme } from "../../../theme";

export default makeStyles((theme: Theme) => ({
  root: {
    backgroundColor: theme.palette.background.default,
    paddingTop: 0,
    paddingBottom: 128,
  },
  card: {
    minHeight: "200px",
  },
  avatar: {
    backgroundColor: theme.palette.secondary.main,
    color: theme.palette.secondary.contrastText,
    width: "5rem",
    height: "5rem",
    "& *": {
      fontSize: "3rem",
    },
  },
}));
