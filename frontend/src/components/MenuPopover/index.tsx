import React from "react";
import type { FC, ReactNode } from "react";

// material
import {
  colors,
  Popover,
  experimentalStyled as styled,
  useTheme,
  alpha,
} from "@material-ui/core";

// Theme
import { Theme } from "../../theme";

const ArrowStyle = styled("span")(() => {
  const appTheme: Theme = useTheme();

  return {
    [appTheme.breakpoints.up("sm")]: {
      top: -7,
      zIndex: 1,
      width: 12,
      right: 20,
      height: 12,
      content: "''",
      position: "absolute",
      borderRadius: "0 0 4px 0",
      transform: "rotate(-135deg)",
      background: appTheme.palette.background.paper,
      borderRight: `solid 1px ${alpha(appTheme.palette.grey[500], 0.12)}`,
      borderBottom: `solid 1px ${alpha(appTheme.palette.grey[500], 0.12)}`,
    },
  };
});

// interfaces
interface IMenuPopoverProps {
  children?: ReactNode;
  sx?: { [key: string]: any };
  open: boolean;
  disablePortal: boolean;
}

const MenuPopover: FC<IMenuPopoverProps> = ({
  children,
  sx,
  disablePortal,
  open,
  ...other
}) => {
  return (
    <Popover
      open={open}
      disablePortal={disablePortal}
      keepMounted
      anchorOrigin={{ vertical: "bottom", horizontal: "right" }}
      transformOrigin={{ vertical: "top", horizontal: "right" }}
      PaperProps={{
        sx: {
          mt: 1.5,
          ml: 0.5,
          overflow: "inherit",
          boxShadow: (theme) => theme.shadows[16],
          border: () => `solid 1px ${colors.grey[500]}`,
          width: 200,
          ...sx,
        },
      }}
      {...other}
    >
      <ArrowStyle />

      {children}
    </Popover>
  );
};

export default MenuPopover;
