import React from "react";
import type { FC } from "react";
import { BrowserRouter } from "react-router-dom";
import { create } from "jss";
import rtl from "jss-rtl";
import { StylesProvider, ThemeProvider } from "@material-ui/styles";
import { jssPreset } from "@material-ui/styles";

// Custom Components
import GlobalStyles from "./components/GlobalStyles";
import ScrollReset from "./components/ScrollReset";
import useSettings from "./hooks/useSettings";
import { createAppTheme } from "./theme";
import routes, { renderRoutes } from "./routes";

const jss = create({ plugins: [...jssPreset().plugins, rtl()] });

const App: FC = () => {
  const { settings } = useSettings();

  const theme = createAppTheme({
    direction: settings.direction,
    responsiveFontSizes: settings.responsiveFontSizes,
    theme: settings.theme,
  });

  return (
    <ThemeProvider theme={theme}>
      <StylesProvider jss={jss}>
        <BrowserRouter>
          <GlobalStyles />
          <ScrollReset />
          {renderRoutes(routes)}
        </BrowserRouter>
      </StylesProvider>
    </ThemeProvider>
  );
};

export default App;
