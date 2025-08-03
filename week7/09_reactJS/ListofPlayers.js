import React from "react";

const ListofPlayers = () => {
  const players = [
    { name: "Virat Kohli", score: 120 },
    { name: "Rohit Sharma", score: 85 },
    { name: "KL Rahul", score: 65 },
    { name: "Rishabh Pant", score: 45 },
    { name: "Hardik Pandya", score: 70 },
  ];

  return (
    <div>
      <h2>All Players</h2>
      <ul>
        {players.map((player, index) => (
          <li key={index}>
            {player.name} - {player.score}
          </li>
        ))}
      </ul>

      <h2>Players with Score Below 70</h2>
      <ul>
        {players
          .filter((player) => player.score < 70)
          .map((player, index) => (
            <li key={index}>
              {player.name} - {player.score}
            </li>
          ))}
      </ul>
    </div>
  );
};

export default ListofPlayers;
