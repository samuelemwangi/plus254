/*  global document */
import React, { Component } from "react";
import PropTypes from "prop-types";
import MuiThemeProvider from "@material-ui/core/styles/MuiThemeProvider";
import CssBaseline from "@material-ui/core/CssBaseline";

// Custom Components
import { appTheme } from "../../Components/Layout/AppTheme";
import Navigator from "../../Components/Layout/Navigator";
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
    this.setState(prevstate => ({ mobileOpen: !prevstate.mobileOpen }));
  }

  render() {
    const { currentComponent, routeProps } = this.props;

    const { mobileOpen } = this.state;

    return (
      <MuiThemeProvider theme={appTheme}>
        <div style={{ display: "flex", minHeight: "100vh" }}>
          <CssBaseline />
          <Navigator
            handleDrawerToggle={this.handleDrawerToggle}
            mobileOpen={mobileOpen}
            currentLink={routeProps.path}
          />
          <div style={{ display: "flex", flexDirection: "column" }}>
            <Header
              onDrawerToggle={this.handleDrawerToggle}
              pageTitle={routeProps.pageTitle}
            />
          </div>
        </div>
      </MuiThemeProvider>
    );
  }
}

Layout.propTypes = {
  currentComponent: PropTypes.object.isRequired,
  routeProps: PropTypes.object.isRequired
};

export default Layout;
