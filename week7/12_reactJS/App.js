import React, { useState } from "react";

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const GuestView = () => (
    <div>
      <h1>Welcome, Guest!</h1>
      <p>Flight Details:</p>
      <ul>
        <li>Flight 101: Delhi → Mumbai (10:00 AM)</li>
        <li>Flight 202: Mumbai → Bangalore (2:00 PM)</li>
      </ul>
      <button onClick={() => setIsLoggedIn(true)}>Login</button>
    </div>
  );

  const UserView = () => (
    <div>
      <h1>Welcome, User!</h1>
      <p>Book your ticket:</p>
      <form>
        <input type="text" placeholder="Flight Number" />
        <input type="text" placeholder="Passenger Name" />
        <button type="submit">Book Ticket</button>
      </form>
      <button onClick={() => setIsLoggedIn(false)}>Logout</button>
    </div>
  );

  return isLoggedIn ? <UserView /> : <GuestView />;
}

export default App;
