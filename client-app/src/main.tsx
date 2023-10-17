import React from "react";
import { createRoot } from "react-dom/client";
import App from "./app/layout/App";
import "semantic-ui-css/semantic.min.css";
import "./app/layout/styles.css";
import { StoreContext, store } from "./app/stores/store";

const rootElement = createRoot(document.getElementById("root")!);

rootElement.render(
  <StoreContext.Provider value={store}>
    <App />
  </StoreContext.Provider>
);
