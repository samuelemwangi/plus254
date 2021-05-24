import React from "react";
import type { FC } from "react";
import { useState, useRef } from "react";
import { NavLink as RouterLink, useLocation } from "react-router-dom";

// material
import { alpha, experimentalStyled as styled } from "@material-ui/core/styles";
import {
  Box,
  List,
  Link,
  AppBar,
  Toolbar,
  MenuItem,
  Container,
  ListItemText,
  IconButton,
  useMediaQuery,
  makeStyles,
} from "@material-ui/core";

// hooks
import useOffSetTop from "../../hooks/useOffSetTop";

// components
import Logo from "../../components/Logo";
import MenuPopover from "../../components/MenuPopover";
import { Theme } from "../../theme";

// interfaces
interface INavbarProps {
  className?: string;
}

// links
const MENU_LINKS = [
  { title: "Home", href: "/" },
  { title: "About Us", href: "/about-us" },
  { title: "Contact Us", href: "/contact-us" },
];

const APP_BAR_MOBILE = 64;
const APP_BAR_DESKTOP = 96;

// Styles
const useStyles = makeStyles((theme: Theme) => ({
  link: {
    "&.isDesktopActive": {
      color: theme.palette.primary.main + "!important",
    },
    "&.isMobileActive": {
      color: theme.palette.primary.main,
      fontWeight: theme.typography.fontWeightMedium,
      backgroundColor: alpha(
        theme.palette.primary.main,
        theme.palette.action.selectedOpacity
      ),
    },
  },
}));

const RootStyle = styled(AppBar)(({}) => ({
  boxShadow: "none",
}));

const ToolbarStyle = styled(Toolbar)(({ theme }) => ({
  height: APP_BAR_MOBILE,
  transition: theme.transitions.create(["height", "background-color"], {
    easing: theme.transitions.easing.easeInOut,
    duration: theme.transitions.duration.shorter,
  }),
  [theme.breakpoints.up("md")]: { height: APP_BAR_DESKTOP },
}));

const ToolbarShadowStyle = styled("div")(({ theme }) => ({
  left: 0,
  right: 0,
  bottom: 0,
  height: 24,
  zIndex: -1,
  margin: "auto",
  borderRadius: "50%",
  position: "absolute",
  width: `calc(100% - 48px)`,
  boxShadow: theme.shadows[24],
}));

const Navbar: FC<INavbarProps> = () => {
  const anchorRef = useRef(null);
  const { pathname } = useLocation();
  const offset = useOffSetTop(100);
  const [openMenu, setOpenMenu] = useState(false);
  const isHome = pathname === "/";

  const classes = useStyles();

  const renderMenuDesktop = (
    <>
      {MENU_LINKS.map((link) => (
        <Link
          exact
          to={link.href}
          key={link.title}
          underline="none"
          variant="subtitle2"
          component={RouterLink}
          activeClassName="isDesktopActive"
          className={classes.link}
          sx={{
            mr: 5,
            color: (theme) => theme.palette.text.secondary,
            transition: (theme) =>
              theme.transitions.create("opacity", {
                duration: theme.transitions.duration.shortest,
              }),
            "&:hover": { opacity: 0.48 },
            ...(isHome && { color: "#000" }),
            ...(offset && { color: (theme) => theme.palette.text.secondary }),
          }}
        >
          {link.title}
        </Link>
      ))}
    </>
  );

  const menuPopoverProps = {
    anchorEl: anchorRef.current,
    onClose: () => setOpenMenu(false),
  };

  const renderMenuMobile = (
    <MenuPopover open={openMenu} disablePortal {...menuPopoverProps}>
      <List>
        {MENU_LINKS.map((link) => (
          <MenuItem
            exact
            to={link.href}
            key={link.title}
            component={RouterLink}
            onClick={() => setOpenMenu(false)}
            activeClassName="isMobileActive"
            sx={{ color: "text.secondary", py: 1 }}
          >
            <ListItemText primaryTypographyProps={{ typography: "body2" }}>
              {link.title}
            </ListItemText>
          </MenuItem>
        ))}
      </List>
    </MenuPopover>
  );

  const mdUP = useMediaQuery((theme: Theme) => theme.breakpoints.up("md"));
  const mdDown = useMediaQuery((theme: Theme) => theme.breakpoints.down("md"));

  return (
    <RootStyle color="transparent">
      <ToolbarStyle
        disableGutters
        sx={{
          ...(offset && {
            bgcolor: "background.default",
            height: { md: APP_BAR_DESKTOP - 20 },
          }),
        }}
      >
        <Container
          maxWidth="lg"
          sx={{
            display: "flex",
            alignItems: "center",
            justifyContent: "space-between",
          }}
        >
          <RouterLink to="/">
            <Logo name="plus254" />
          </RouterLink>
          <Box sx={{ flexGrow: 1 }} />

          {!mdDown && renderMenuDesktop}

          {!mdUP && (
            <>
              <IconButton
                onClick={() => setOpenMenu(true)}
                ref={anchorRef}
                sx={{
                  ml: 1,
                  ...(isHome && { color: "#FFF" }),
                  ...(offset && {
                    color: (theme) => theme.palette.primary.main,
                  }),
                }}
              ></IconButton>
              {renderMenuMobile}
            </>
          )}
        </Container>
      </ToolbarStyle>

      {offset && <ToolbarShadowStyle />}
      {/* {!isHome && <ToolbarShadowStyle />} */}
    </RootStyle>
  );
};

export default Navbar;
