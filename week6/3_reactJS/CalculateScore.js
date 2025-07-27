import React, { useState } from "react";

function CalculateScore() {
  const [name, setName] = useState("");
  const [school, setSchool] = useState("");
  const [total, setTotal] = useState("");
  const [goal, setGoal] = useState("");
  const [average, setAverage] = useState(null);

  const calculateAverage = () => {
    const avg = (parseInt(total) / parseInt(goal)) * 100;
    setAverage(avg.toFixed(2));
  };

  return (
    <div className="score-container">
      <h1>Student Score Calculator</h1>
      <div className="input-group">
        <input
          type="text"
          placeholder="Name"
          value={name}
          onChange={(e) => setName(e.target.value)}
        />
      </div>
      <div className="input-group">
        <input
          type="text"
          placeholder="School"
          value={school}
          onChange={(e) => setSchool(e.target.value)}
        />
      </div>
      <div className="input-group">
        <input
          type="number"
          placeholder="Total Marks"
          value={total}
          onChange={(e) => setTotal(e.target.value)}
        />
      </div>
      <div className="input-group">
        <input
          type="number"
          placeholder="Goal Marks"
          value={goal}
          onChange={(e) => setGoal(e.target.value)}
        />
      </div>
      <button onClick={calculateAverage}>Calculate Average</button>
      {average !== null && (
        <div className="result">
          <h3>
            Result for {name} ({school}):
          </h3>
          <p>Average Score: {average}%</p>
        </div>
      )}
    </div>
  );
}

export default CalculateScore;
