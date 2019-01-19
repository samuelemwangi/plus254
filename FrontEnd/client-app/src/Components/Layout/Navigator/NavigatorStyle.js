export const drawerWidth = 256;

export const navigatorStyle = theme => ({
  drawer: {
    [theme.breakpoints.up("sm")]: {
      width: drawerWidth,
      flexShrink: 0
    }
  },
  categoryHeader: {
    paddingTop: 16,
    paddingBottom: 16
  },
  categoryHeaderPrimary: {
    color: theme.palette.common.white
  },
  item: {
    paddingTop: 4,
    paddingBottom: 4,
    color: "rgba(255, 255, 255, 0.7)"
  },
  itemCategory: {
    backgroundColor: "#f6f6f6",
    paddingTop: 16,
    paddingBottom: 16,
    color: theme.palette.common.black
  },
  profileHeader: {
    fontSize: 24,
    fontFamily: theme.typography.fontFamily,
    height: "25vh"
  },
  itemActionable: {
    "&:hover": {
      backgroundColor: "rgba(255, 255, 255, 0.08)"
    }
  },
  itemActiveItem: {
    color: "#4fc3f7"
  },
  itemPrimary: {
    color: "inherit",
    fontSize: theme.typography.fontSize,
    "&$textDense": {
      fontSize: theme.typography.fontSize
    }
  },
  textDense: {},
  divider: {
    marginTop: theme.spacing.unit * 2
  }
});
