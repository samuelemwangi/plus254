export const conatinerFluid = {
  paddingRight: "20px",
  paddingLeft: "0px",
  marginRight: "auto",
  marginLeft: "auto",
  width: "100%"
};
export const container = {
  ...conatinerFluid,
  "@media (min-width: 576px)": {
    maxWidth: "540px"
  },
  "@media (min-width: 768px)": {
    maxWidth: "720px"
  },
  "@media (min-width: 992px)": {
    maxWidth: "960px"
  },
  "@media (min-width: 1200px)": {
    maxWidth: "1140px"
  }
};
