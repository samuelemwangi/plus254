export const productItemStyle = theme => ({
  detailImage: {
    borderTopLeftRadius: "4px",
    borderTopRightRadius: "4px"
  },
  detailBody: {
    padding: "10px 15px 0px 15px",
    fontSize: "12px"
  },
  detailAvatar: {
    marginTop: "-35px",
    "&>div": {
      height: "35px",
      width: "35px"
    }
  },
  productName: {
    paddingTop: "4px",
    textTransform: "capitalize",
    "& a": {
      color: "inherit",
      textDecoration: "none"
    }
  },
  detailDescription: {
    textAlign: "left",
    "& a": {
      color: "inherit",
      textDecoration: "none"
    }
  },
  ratingWrapper: {
    paddingTop: "5px",
    "& svg": {
      fontSize: "15px"
    },
    "& span": {
      fontSize: "11px",
      color: "#888"
    }
  },

  cardActions: {
    display: "flex",
    padding: "10px 5px"
  },
  cardActionsFarLeftIcons: {
    marginLeft: "auto",
    minWidth: "25px",
    minHeight: "25px",
    fontSize: "12px",
    backgroundColor: "#EEE",
    "&:hover,:focus": {
      color: "#FFF",
      backgroundColor: theme.palette.primary.main
    },
    "& svg": {
      fontSize: "15px"
    }
  }
});
