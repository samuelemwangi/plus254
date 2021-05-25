import React from "react";
import type { FC } from "react";
import { useState, useRef } from "react";

// Router
import { NavLink as RouterLink, useLocation } from "react-router-dom";

// Material
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
  experimentalStyled as styled,
  useTheme,
  alpha,
} from "@material-ui/core";
import { Menu as MenuIcon } from "@material-ui/icons";

// hooks
import useOffSetTop from "../../hooks/useOffSetTop";

// components
import Logo from "../../components/Logo";
import MenuPopover from "../../components/MenuPopover";

// Theme
import { Theme } from "../../theme";

// links
const MENU_LINKS = [
  { title: "Home", href: "/" },
  { title: "Explore", href: "/explore" },
  { title: "About Us", href: "/about-us" },
  { title: "Contact Us", href: "/contact-us" },
];

const APP_BAR_MOBILE = 64;
const APP_BAR_DESKTOP = 75;

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

const ToolbarStyle = styled(Toolbar)(() => {
  const appTheme: Theme = useTheme();

  return {
    height: APP_BAR_MOBILE,
    transition: appTheme.transitions.create(["height", "background-color"], {
      easing: appTheme.transitions.easing.easeInOut,
      duration: appTheme.transitions.duration.shorter,
    }),
    [appTheme.breakpoints.up("md")]: { height: APP_BAR_DESKTOP },
  };
});

// interfaces
interface INavbarProps {
  className?: string;
}

const Navbar: FC<INavbarProps> = () => {
  const anchorRef = useRef(null);
  const { pathname } = useLocation();
  const offset = useOffSetTop(100);
  const [openMenu, setOpenMenu] = useState(false);
  const isHome = pathname === "/";

  const appTheme: Theme = useTheme();

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
            color: appTheme.palette.text.secondary,
            transition: () =>
              appTheme.transitions.create("opacity", {
                duration: appTheme.transitions.duration.shortest,
              }),
            "&:hover": { opacity: 0.48 },
            ...(isHome && { color: "#000" }),
            ...(offset && { color: appTheme.palette.text.secondary }),
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

  const mdUP = useMediaQuery(appTheme.breakpoints.up("md"));
  const mdDown = useMediaQuery(appTheme.breakpoints.down("md"));

  return (
    <RootStyle
      color="transparent"
      sx={{
        ...(offset && {
          backgroundColor: appTheme.palette.background.dark,
          boxShadow: appTheme.shadows[24],
        }),
        ...(!isHome && {
          backgroundColor: appTheme.palette.background.dark,
          boxShadow: appTheme.shadows[24],
        }),
      }}
    >
      <ToolbarStyle disableGutters>
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
                    color: appTheme.palette.primary.main,
                  }),
                }}
              >
                <MenuIcon />
              </IconButton>
              {renderMenuMobile}
            </>
          )}
        </Container>
      </ToolbarStyle>
    </RootStyle>
  );
};

export default Navbar;
