import React from "react";

import PropTypes from "prop-types";
import { forwardRef } from "react";

// material
import { alpha, useTheme } from "@material-ui/core/styles";
import { IconButton } from "@material-ui/core";

// Animations
import { ButtonAnimate } from "../Animate";

const MIconButton = forwardRef(
  ({ color = "default", onClick, children, sx, ...other }, ref) => {
    const theme = useTheme();

    if (
      color === "default" ||
      color === "inherit" ||
      color === "primary" ||
      color === "secondary"
    ) {
      return (
        <ButtonAnimate>
          <IconButton
            onClick={onClick}
            ref={ref}
            color={color}
            sx={sx}
            {...other}
          >
            {children}
          </IconButton>
        </ButtonAnimate>
      );
    }

    return (
      <ButtonAnimate>
        <IconButton
          onClick={onClick}
          ref={ref}
          sx={{
            color: theme.palette[color].main,
            "&:hover": {
              bgcolor: alpha(
                theme.palette[color].main,
                theme.palette.action.hoverOpacity
              ),
            },
            ...sx,
          }}
          {...other}
        >
          {children}
        </IconButton>
      </ButtonAnimate>
    );
  }
);

MIconButton.propTypes = {
  children: PropTypes.node,
  sx: PropTypes.object,
  onClick: PropTypes.func,
  color: PropTypes.oneOf([
    "default",
    "inherit",
    "primary",
    "secondary",
    "info",
    "success",
    "warning",
    "error",
  ]),
};

export default MIconButton;
