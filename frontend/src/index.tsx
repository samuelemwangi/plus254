import "react-app-polyfill/ie11";
import "react-app-polyfill/stable";
import "react-perfect-scrollbar/dist/css/styles.css";
import "nprogress/nprogress.css";

import React from "react";
import ReactDOM from "react-dom";
import { enableES5 } from "immer";
import { Provider } from "react-redux";

import { SettingsProvider } from "./contexts/SettingsContext";
import App from "./App";
import reportWebVitals from "./reportWebVitals";
import configureStore from "./store";

enableES5();

const store = configureStore();

ReactDOM.render(
  <Provider store={store}>
    <SettingsProvider>
      <App />
    </SettingsProvider>
  </Provider>,
  document.getElementById("root")
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
