/*  global window */
import React, { Fragment } from "react";
import Route from "react-router-dom/Route";
import Switch from "react-router-dom/Switch";

// CUstom Components
import { appRoutes } from "./Routes";
import Layout from "./Containers/Layout";

const ScrollToTop = () => {
  window.scrollTo(0, 0);
  return null;
};

const App = () => (
  <Fragment>
    <Route component={ScrollToTop} />
    <Switch>
      {appRoutes.map(prop => (
        <Route
          exact={prop.matching}
          path={prop.path}
          key={prop.pageTitle.trim()}
          render={props => {
            const currentComponent = <prop.component {...props} />;
            return (
              <Layout contentComponent={currentComponent} routeProps={prop} />
            );
          }}
        />
      ))}
    </Switch>
  </Fragment>
);

export default App;
