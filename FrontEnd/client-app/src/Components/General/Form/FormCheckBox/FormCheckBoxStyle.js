export const formCheckBoxStyle = theme => ({
  root: {
    color: theme.palette.primary.main
  },
  cheked: {
    color: `${theme.palette.primary.main} !important`
  },
  checkedIcon: {
    width: "23px",
    color: theme.palette.primary.main,
    height: "23px",
    border: `1.5px solid ${theme.palette.primary.main}`,
    borderRadius: "3px"
  },
  uncheckedIcon: {
    width: "23px",
    height: "23px",
    padding: "9px",
    border: "1.5px solid rgba(0, 0, 0, .54)",
    borderRadius: "3px"
  },
  label: {
    cursor: "pointer",
    paddingLeft: "0",
    color: "rgba(0, 0, 0, 0.26)",
    fontSize: "14px",
    lineHeight: "1.428571429",
    fontWeight: "400",
    display: "inline-flex",
    transition: "0.3s ease all",
    marginBottom: "-2px"
  },
  formControl: {
    marginLeft: "-5px",
    marginRight: "10px"
  }
});
