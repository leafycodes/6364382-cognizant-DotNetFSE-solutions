import React, { useState } from "react";
import ListofPlayers from "./ListofPlayers";
import IndianPlayers from "./IndianPlayers";

function App() {
  const [flag, setFlag] = useState(true);

  return (
    <div>
      <button onClick={() => setFlag(!flag)}>Toggle View</button>
      {flag ? <ListofPlayers /> : <IndianPlayers />}
    </div>
  );
}

export default App;
