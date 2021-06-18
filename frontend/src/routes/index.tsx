import React, { Suspense, Fragment, lazy } from "react";
import { Switch, Redirect, Route } from "react-router-dom";

// Custom components
import MainLayout from "../layouts/MainLayout";
import LoadingScreen from "../components/LoadingScreen";

// Paths
import { PATHS } from "./paths";

// Interfaces & types
type Routes = {
  exact?: boolean;
  path?: string | string[];
  guard?: any;
  layout?: any;
  component?: any;
  routes?: Routes;
}[];

export const renderRoutes = (routes: Routes = []): JSX.Element => (
  <Suspense fallback={<LoadingScreen />}>
    <Switch>
      {routes.map((route, i) => {
        const Guard = route.guard || Fragment;
        const Layout = route.layout || Fragment;
        const Component = route.component;

        return (
          <Route
            key={i}
            path={route.path}
            exact={route.exact}
            render={(props) => (
              <Guard>
                <Layout>
                  {route.routes ? (
                    renderRoutes(route.routes)
                  ) : (
                    <Component {...props} />
                  )}
                </Layout>
              </Guard>
            )}
          />
        );
      })}
    </Switch>
  </Suspense>
);

const routes: Routes = [
  {
    path: "/auth",
    routes: [
      {
        exact: true,
        path: PATHS.LOGIN,
        component: lazy(() => import("../views/Auth/Login")),
      },
      {
        exact: true,
        path: PATHS.REGISTER,
        component: lazy(() => import("../views/Auth/Register")),
      },
    ],
  },
  {
    path: "/error",
    routes: [
      {
        exact: true,
        path: PATHS.ERROR_500,
        component: lazy(() => import("../views/Errors/SystemErrorView")),
      },
      {
        exact: true,
        path: PATHS.ERROR_404,
        component: lazy(() => import("../views/Errors/NotFoundView")),
      },
    ],
  },
  {
    path: "*",
    layout: MainLayout,
    routes: [
      {
        exact: true,
        path: PATHS.HOME,
        component: lazy(() => import("../views/Home")),
      },
      {
        exact: true,
        path: PATHS.ABOUT_US,
        component: lazy(() => import("../views/AboutUs")),
      },
      {
        exact: true,
        path: PATHS.CONTACT_US,
        component: lazy(() => import("../views/ContactUs")),
      },

      {
        component: () => <Redirect to={PATHS.ERROR_404} />,
      },
    ],
  },
];

export default routes;
