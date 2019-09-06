import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import App from "./App";
import * as serviceWorker from "./serviceWorker";
import defaultFeatureToggles from "./featureToggles";

const apiUrl = process.env.REACT_APP_BASE_API_URL;

fetch(`${apiUrl}/FeatureToggles`)
  .then(response => response.json())
  .then(featureToggles => {
    ReactDOM.render(
      <App featureToggles={featureToggles} />,
      document.getElementById("root")
    );
  })
  .catch(() => {
    ReactDOM.render(
      <App featureToggles={defaultFeatureToggles} />,
      document.getElementById("root")
    );
  });

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
