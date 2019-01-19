import { container } from "../Style";

export const headerStyle = {
  appBar: {
    display: "inline-block",
    border: "0",
    borderRadius: "0px",
    padding: "0.625rem 0",
    marginBottom: "20px",
    color: "#fff",
    width: "100%",
    boxShadow: "none", // '0 4px 18px 0px rgba(0, 0, 0, 0.12), 0 7px 10px -5px rgba(0, 0, 0, 0.15)',
    transition: "all 150ms ease 0s",
    alignItems: "center",
    flexFlow: "row nowrap",
    justifyContent: "flex-start",
    position: "relative",
    zIndex: "unset",
    height: "64px",
    paddingTop: "4px"
  },
  container: {
    ...container,
    minHeight: "50px",
    flex: "1",
    alignItems: "center",
    display: "flex",
    flexWrap: "nowrap"
  },
  absolute: {
    position: "absolute"
  },
  fixed: {
    position: "fixed",
    zIndex: "1100"
  },
  flex: {
    flex: 1
  },
  title: {
    lineHeight: "30px",
    fontSize: "25px",
    borderRadius: "3px",
    textTransform: "none",
    color: "inherit",
    "&:hover,&:focus": {
      color: "inherit",
      background: "transparent"
    }
  }
};
