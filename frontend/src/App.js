import React from "react";
import "./App.css";
import Button from "@material-ui/core/Button";
import Snackbar from "@material-ui/core/Snackbar";
import SnackbarContentWrapper from "./SnackbarContentWrapper";

function App({ featureToggles }) {
  const firstFeatureApiUrl =
    process.env.REACT_APP_BASE_API_URL + "resource/firstFeature";
  const secondFeatureApiUrl =
    process.env.REACT_APP_BASE_API_URL + "resource/secondFeature";

  const [openFeature1, setOpenFeature1] = React.useState(false);
  const [openFeature2, setOpenFeature2] = React.useState(false);

  function handleClick1() {
    fetch(firstFeatureApiUrl, {
      crossDomain: true,
      headers: {
        "Content-Type": "application/json",
        "Access-Control-Allow-Origin": "*",
        "Access-Control-Allow-Headers": "*"
      }
    })
      .then(response => response.json())
      .then(response => {
        if (response.ok) {
          setOpenFeature1(true);
        } else {
          alert("API returned " + response.status + " HTTP code.");
        }
      })
      .catch(error => alert(error));
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

  return (
    <div className="App">
      {
        featureToggles.isFirstFeatureEnabled && (
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
        )
      }
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
            message={`Feature 2 in variant ${featureToggles.secondFeatureVariant}`}
          />
        </Snackbar>
      </div>
    </div>
  );
}

export default App;
