import React, { useState } from "react";

function App() {
  const [count, setCount] = useState(0);
  const [message, setMessage] = useState("");
  const [rupees, setRupees] = useState(0);
  const [euros, setEuros] = useState(0);

  const increment = () => setCount(count + 1);
  const sayHello = () => setMessage("Hello, React!");

  const handleWelcome = (msg) => setMessage(msg);

  const handleClick = (e) => {
    e.preventDefault();
    setMessage("I was clicked!");
  };

  const convertCurrency = () => setEuros(rupees / 90);

  return (
    <div>
      <h1>Event Examples</h1>

      <div>
        <h2>Counter: {count}</h2>
        <button
          onClick={() => {
            increment();
            sayHello();
          }}
        >
          Increment (+1 & Say Hello)
        </button>
      </div>

      <div>
        <button onClick={() => handleWelcome("Welcome!")}>Say Welcome</button>
        <p>{message}</p>
      </div>

      <div>
        <button onClick={handleClick}>Click Me (Synthetic Event)</button>
      </div>

      <div>
        <h2>Currency Converter</h2>
        <input
          type="number"
          value={rupees}
          onChange={(e) => setRupees(e.target.value)}
        />
        <button onClick={convertCurrency}>Convert to Euros</button>
        <p>
          ₹{rupees} = €{euros.toFixed(2)}
        </p>
      </div>
    </div>
  );
}

export default App;
