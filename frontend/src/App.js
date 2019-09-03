import React from "react";
import "./App.css";
import Button from "@material-ui/core/Button";
import Snackbar from "@material-ui/core/Snackbar";
import SnackbarContentWrapper from "./SnackbarContentWrapper";

function App() {
  const [openFeature1, setOpenFeature1] = React.useState(false);
  const [openFeature2, setOpenFeature2] = React.useState(false);
  const [openFeature3, setOpenFeature3] = React.useState(false);

  function handleClick1() {
    setOpenFeature1(true);
  }

  function handleClose1() {
    setOpenFeature1(false);
  }

  function handleClick2() {
    setOpenFeature2(true);
  }

  function handleClose2() {
    setOpenFeature2(false);
  }

  function handleClick3() {
    setOpenFeature3(true);
  }

  function handleClose3() {
    setOpenFeature3(false);
  }

  return (
    <div className="App">
      <div className="button-container">
        <Button onClick={handleClick1} variant="contained" color="default">
          Feature 1
        </Button>
        <Snackbar
          anchorOrigin={{
            vertical: "top",
            horizontal: "center"
          }}
          open={openFeature1}
          autoHideDuration={4000}
          onClose={handleClose1}
        >
          <SnackbarContentWrapper
            onClose={handleClose1}
            variant="success"
            message="Feature 1 is enabled"
          />
        </Snackbar>
      </div>

      <div className="button-container">
        <Button onClick={handleClick2} variant="contained" color="primary">
          Feature 2
        </Button>
        <Snackbar
          anchorOrigin={{
            vertical: "top",
            horizontal: "center"
          }}
          open={openFeature2}
          autoHideDuration={4000}
          onClose={handleClose2}
        >
          <SnackbarContentWrapper
            onClose={handleClose2}
            variant="info"
            message="Feature 2 in variant 1"
          />
        </Snackbar>
      </div>
      <div className="button-container">
        <Button onClick={handleClick3} variant="contained" color="secondary">
          Feature 3
        </Button>
        <Snackbar
          anchorOrigin={{
            vertical: "top",
            horizontal: "center"
          }}
          open={openFeature3}
          autoHideDuration={4000}
          onClose={handleClose3}
        >
          <SnackbarContentWrapper
            onClose={handleClose3}
            variant="error"
            message="Feature 3 is disabled"
          />
        </Snackbar>
      </div>
    </div>
  );
}

export default App;
