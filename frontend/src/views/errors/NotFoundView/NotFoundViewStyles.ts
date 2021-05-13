import { makeStyles } from "@material-ui/core/styles";
import { Theme } from "../../../theme";

export default makeStyles((theme: Theme) => ({
  root: {
    backgroundColor: theme.palette.background.default,
    minHeight: "100%",
    display: "flex",
    alignItems: "center",
    padding: theme.spacing(3),
    paddingTop: 80,
    paddingBottom: 80,
  },
  image: {
    maxWidth: "100%",
    width: 560,
    maxHeight: 300,
    height: "auto",
  },
}));
