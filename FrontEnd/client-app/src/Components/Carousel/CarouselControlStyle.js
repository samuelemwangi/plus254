export const thumbsShown = 3;
export const thumbsWidth = 90;
export const thumbsHeight = 84;

export const primaryColor = "#150b6a";

export const carouselControlStyle = {
  btn: {
    width: "20px",
    height: `${thumbsHeight}px`,
    display: "inline-block",
    margin: "0",
    border: "none",
    verticalAlign: "top",
    background: "none",
    fontSize: "2rem",
    color: `${primaryColor}`,
    outline: "none"
  },
  btnDisabled: {
    color: "#ccc"
  },
  controlsWrapper: {
    overflow: "hidden",
    display: "inline-block",
    width: `${thumbsShown * thumbsWidth + thumbsShown * 3}px`,
    height: `${thumbsHeight + 2}px`,
    position: "relative",
    margin: " 0 auto"
  },
  controls: {
    height: `${thumbsHeight + 2}px`,
    margin: "0",
    position: "relative",
    overflow: "hidden",
    padding: "0px",
    "& li": {
      listStyleType: "none",
      width: thumbsWidth,
      height: thumbsHeight,
      border: "1px solid transparent",
      cursor: "pointer",
      display: "inline-block"
    },
    "& button": {
      display: "block",
      borderRadius: "0px",
      padding: "0px",
      height: `${thumbsHeight - 3}px`,
      width: `${thumbsWidth - 3}px`,
      "-webkit-user-select": "none",
      "-moz-user-select": "none",
      "-ms-user-select": "none",
      "user-select": "none",
      background: "none",
      border: "none",
      outline: "none"
    },

    "& img": {
      display: "inline-block",
      borderRadius: "0px"
    }
  },
  isActive: {
    "& button": {
      border: `1px solid ${primaryColor}`
    }
  }
};
