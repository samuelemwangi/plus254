import { makeStyles } from "@material-ui/core/styles";
import { Theme } from "../../../theme";

export default makeStyles((theme: Theme) => ({
  root: {
    backgroundColor: theme.palette.background.dark,
    paddingTop: theme.spacing(6),
    paddingBottom: theme.spacing(6),
    "& dt": {
      marginTop: theme.spacing(2),
    },
  },
  services: {
    paddingTop: "20px",
    "& li": {
      padding: "2px 0px 2px 0px",
    },
  },
  socialLinks: {
    paddingTop: "10px",
    textDecoration: "none",
    "& a": {
      textDecoration: "none",
      paddingRight: "10px",
    },
  },
}));
