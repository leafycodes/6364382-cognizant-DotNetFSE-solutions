import React from "react";
import "./App.css";

function App() {
  const office = {
    Name: "DBS",
    Rent: 50000,
    Address: "Chennai",
  };

  const rentColor = office.Rent <= 60000 ? "textRed" : "textGreen";

  return (
    <div className="app">
      <h1>Office Space at Affordable Range</h1>

      <div className="office-details">
        <h2>Name: {office.Name}</h2>
        <h3 className={rentColor}>Rent: Rs. {office.Rent}</h3>
        <h3>Address: {office.Address}</h3>
      </div>
    </div>
  );
}

export default App;
