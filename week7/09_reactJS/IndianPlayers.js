import React from "react";

const IndianPlayers = () => {
  const players = ["Virat", "Rohit", "Dhoni", "Bumrah", "Jadeja"];

  const [first, second, third, fourth, fifth] = players;
  const oddPlayers = [first, third, fifth];
  const evenPlayers = [second, fourth];

  const T20Players = ["Virat", "Rohit"];
  const RanjiPlayers = ["Pujara", "Rahane"];
  const mergedPlayers = [...T20Players, ...RanjiPlayers];

  return (
    <div>
      <h2>Odd Team Players</h2>
      <ul>
        {oddPlayers.map((p, i) => (
          <li key={i}>{p}</li>
        ))}
      </ul>

      <h2>Even Team Players</h2>
      <ul>
        {evenPlayers.map((p, i) => (
          <li key={i}>{p}</li>
        ))}
      </ul>

      <h2>Merged Players</h2>
      <ul>
        {mergedPlayers.map((p, i) => (
          <li key={i}>{p}</li>
        ))}
      </ul>
    </div>
  );
};

export default IndianPlayers;
