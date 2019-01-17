/*  global document */
import React, { Component } from "react";
import PropTypes from "prop-types";
import MuiThemeProvider from "@material-ui/core/styles/MuiThemeProvider";
import CssBaseline from "@material-ui/core/CssBaseline";

// Custom Components
// import HeaderContainer from "./HeaderContainer";
import { appTheme } from "../../Components/Layout/AppTheme";
import Navigator from "../../Components/Layout/Navigator";
import Content from "../../Components/Layout/Content";
import Header from "../../Components/Layout/Header";

class Layout extends Component {
  constructor() {
    super();
    this.state = {
      mobileOpen: false
    };
    this.handleDrawerToggle = this.handleDrawerToggle.bind(this);
  }

  componentDidMount() {
    const { routeProps } = this.props;
    document.title = routeProps.pageTitle;
  }

  handleDrawerToggle() {
    this.setState(prevState => ({ mobileOpen: !prevState.mobileOpen }));
  }

  render() {
    const { contentComponent, routeProps } = this.props;

    const { mobileOpen } = this.state;

    const headerComponent = (
      <Header
        onDrawerToggle={this.handleDrawerToggle}
        routeProps={routeProps}
      />
    );
    return (
      <MuiThemeProvider theme={appTheme}>
        <div style={{ display: "flex", minHeight: "100vh" }}>
          <CssBaseline />
          <Navigator
            handleDrawerToggle={this.handleDrawerToggle}
            mobileOpen={mobileOpen}
            currentLink={routeProps.path}
          />
          <Content
            headerComponent={headerComponent}
            contentComponent={contentComponent}
          />
        </div>
      </MuiThemeProvider>
    );
  }
}

Layout.propTypes = {
  contentComponent: PropTypes.object.isRequired,
  routeProps: PropTypes.object.isRequired
};

export default Layout;
