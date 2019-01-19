/*  global document */
import React from "react";
import ReactDOM from "react-dom";
import { Provider } from "react-redux";
import BrowserRouter from "react-router-dom/BrowserRouter";
import * as serviceWorker from "./serviceWorker";

// Custom Imports
import App from "./App";
import configureStore from "./Store/ConfigureStore";

const store = configureStore();

ReactDOM.render(
  <Provider store={store}>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </Provider>,
  document.getElementById("root")
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: http://bit.ly/CRA-PWA
serviceWorker.unregister();
