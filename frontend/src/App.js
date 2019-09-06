import React from "react";
import "./App.css";
import Button from "@material-ui/core/Button";

function App({ featureToggles }) {
  const apiUrl = process.env.REACT_APP_BASE_API_URL;

  function handleClick1() {
    const firstFeatureApiUrl = `${apiUrl}/resource/firstFeature`;
    fetch(firstFeatureApiUrl)
      .then(response => {
        if (response.ok) {
          alert("First feature is ENABLED");
        } else {
          alert(`API returned ${response.status} HTTP code.`);
        }
      })
      .catch(error => alert(error));
  }

  function handleClick2() {
    const secondFeatureApiUrl = `${apiUrl}/resource/secondFeature`;
    fetch(secondFeatureApiUrl)
      .then(response => {
        if (response.ok) {
          response.text().then(result => {
            alert(`Second feature result: ${result}`);
          });
        } else {
          alert("API returned " + response.status + " HTTP code.");
        }
      })
      .catch(error => alert(error));
  }

  return (
    <div className="App">
      <div className="button-container">
        <Button
          onClick={handleClick1}
          variant="contained"
          color="default"
          disabled={!featureToggles.isFirstFeatureEnabled}
        >
          Feature 1
        </Button>
      </div>
      <div className="button-container">
        <Button onClick={handleClick2} variant="contained" color="primary">
          Feature 2
        </Button>
      </div>
    </div>
  );
}

export default App;
