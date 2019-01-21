export const authStyle = theme => ({
  authSubHeaderWrapper: {
    background: "transparent"
  },
  authCard: {
    background: "#f6f6f6"
  },
  authCardHeader: {
    padding: "15px 20px",
    "& span": {
      fontSize: "20px"
    }
  },
  authCardContent: {
    padding: "10px 30px 24px",
    "& a": {
      textDecoration: "none"
    }
  },
  authFormGroup: {
    padding: "10px 0px",
    color: "#222",
    "&>fieldset": {
      width: "80%"
    }
  },
  authHouseCheckBox: {
    lineHeight: "1.42857",
    color: "#AAAAAA",
    fontWeight: "400",
    paddingTop: "4px",
    cursor: "pointer",
    alignItems: "center",
    "-webkit-tap-highlight-color": "transparent"
  },
  authCheckboxLabel: {
    color: "#000000c4",
    cursor: "pointer",
    verticalAlign: "middle",
    transition: "0.3s ease all",
    lineHeight: "1.428571429",
    paddingLeft: "0px",
    paddingTop: "5px"
  },
  radioGroup: {
    paddingLeft: "5px",
    "& svg": {
      fontSize: "30px",
      width: "0.8em",
      height: "0.8em"
    }
  },
  margin: {
    margin: theme.spacing.unit
  },
  menu: {
    width: "200px",
    border: "10px solid yellow"
  }
});
