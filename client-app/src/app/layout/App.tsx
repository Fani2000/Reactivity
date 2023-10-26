import { useEffect } from "react";
import { Container } from "semantic-ui-react";
import Navbar from "./Navbar";
import LoadingComponent from "./LoadingComponent";
import { useStore } from "../stores/store";
import { observer } from "mobx-react-lite";
import { Outlet, useLocation } from "react-router-dom";
import HomePage from "../../features/home/HomePage";
import { ToastContainer } from "react-toastify";

const App = () => {
  const location = useLocation();

  return (
    <>
      <ToastContainer position="bottom-right" hideProgressBar theme="colored" />

      {location.pathname === "/" ? (
        <HomePage />
      ) : (
        <>
          <Navbar />
          <Container style={{ marginTop: "7em" }}>
            <Outlet />
          </Container>
        </>
      )}
    </>
  );
};

export default observer(App);
