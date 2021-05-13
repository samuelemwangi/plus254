import { makeStyles } from "@material-ui/core/styles";
import { Theme } from "../../theme";

export default makeStyles((theme: Theme) => ({
  root: {
    backgroundColor: theme.palette.background.default,
    paddingTop: 0,
    // paddingBottom: 128,
  },
  aboutUs: {
    paddingTop: 130,
    paddingBottom: 250,
    paddingLeft: "50px",
  },
  aboutBody: {
    paddingTop: "20px",
    paddingBottom: "20px",
  },
  aboutCaption: {
    paddingTop: "20px",
  },
}));
