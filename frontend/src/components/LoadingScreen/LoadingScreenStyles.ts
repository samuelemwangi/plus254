import { makeStyles } from "@material-ui/core/styles";
import { Theme } from "../../theme";

export default makeStyles((theme: Theme) => ({
  root: {
    alignItems: "center",
    backgroundColor: theme.palette.background.default,
    display: "flex",
    flexDirection: "column",
    height: "100%",
    justifyContent: "center",
    minHeight: "100%",
    padding: theme.spacing(3),
  },
}));
