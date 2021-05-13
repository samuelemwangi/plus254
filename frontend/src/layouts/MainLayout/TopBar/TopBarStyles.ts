import { makeStyles } from "@material-ui/core/styles";
import { Theme } from "../../../theme";

export default makeStyles((theme: Theme) => ({
  root: {
    backgroundColor: theme.palette.background.dark,
  },
  toolbar: {
    height: 75,
    maxWidth: theme.breakpoints.width("lg"),
    width: "100%",
    margin: "0 auto",
    paddingLeft: "16px",
    paddingRight: "16px",
  },
  logoLink: {
    textDecoration: "none",
  },
  logo: {
    marginRight: theme.spacing(1),
  },
  link: {
    fontWeight: theme.typography.fontWeightMedium,
    "& + &": {
      marginLeft: theme.spacing(2),
    },
  },
  divider: {
    width: 1,
    height: 32,
    marginLeft: theme.spacing(2),
    marginRight: theme.spacing(2),
  },
  toolbarContainer: {
    lineHeight: 0,
    display: "flex",
    alignItems: "center",
    justifyContent: "space-between",
  },
}));
