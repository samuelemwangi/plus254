export const productSpecsStyle = theme => ({
  root: {
    width: "100%",
    padding: "5px 10px"
  },
  productHeader: {
    padding: "10px 15px"
  },
  productName: {
    color: "#3C4858",
    fontWeight: "600",
    fontSize: "25px"
  },
  productCaption: {
    padding: "10px 0px 25px 5px",
    fontSize: "15px"
  },
  expansionPanel: {
    background: "transparent",
    boxShadow: "none",
    borderBottom: "1px solid #aaa",
    "&:first-child": {
      borderTopRightRadius: "0px",
      borderTopLeftRadius: "0px"
    },
    "&:last-child": {
      borderBottomRightRadius: "0px",
      borderBottomLeftRadius: "0px"
    }
  },
  isActivePanel: {
    "& p, svg": {
      color: theme.palette.primary.main,
      fontWeight: "600"
    }
  },
  cardActions: {
    display: "flex",
    padding: "20px 0px 0px 0px"
  },
  cardActionsFarLeftIcons: {
    marginLeft: "auto"
  },

  heading: {
    fontSize: theme.typography.pxToRem(15),
    flexBasis: "auto"
  },
  secondaryHeading: {
    fontSize: theme.typography.pxToRem(15),
    color: theme.palette.text.secondary
  }
});
