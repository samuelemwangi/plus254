import React, { Suspense, Fragment, lazy } from "react";
import { Switch, Redirect, Route } from "react-router-dom";

// Custom components
import MainLayout from "./layouts/MainLayout";
import LoadingScreen from "./components/LoadingScreen";

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
    path: "*",
    layout: MainLayout,
    routes: [
      {
        exact: true,
        path: "/",
        component: lazy(() => import("./views/Home")),
      },
      {
        exact: true,
        path: "/about-us",
        component: lazy(() => import("./views/AboutUs")),
      },
      {
        exact: true,
        path: "/contact-us",
        component: lazy(() => import("./views/ContactUs")),
      },
      {
        exact: true,
        path: "/500",
        component: lazy(() => import("./views/Errors/SystemErrorView")),
      },
      {
        exact: true,
        path: "/404",
        component: lazy(() => import("./views/Errors/NotFoundView")),
      },
      {
        component: () => <Redirect to="/404" />,
      },
    ],
  },
];

export default routes;
