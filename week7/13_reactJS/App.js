import React, { useState } from "react";
import BookDetails from "./BookDetails";
import BlogDetails from "./BlogDetails";
import CourseDetails from "./CourseDetails";

function App() {
  const [view, setView] = useState("book");

  const renderView = () => {
    if (view === "book") return <BookDetails />;
    else if (view === "blog") return <BlogDetails />;
    else return <CourseDetails />;
  };

  return (
    <div>
      <h1>Blogger App</h1>
      <button onClick={() => setView("book")}>Book</button>
      <button onClick={() => setView("blog")}>Blog</button>
      <button onClick={() => setView("course")}>Course</button>

      <h2>Method 1: If-else</h2>
      {renderView()}

      <h2>Method 2: Ternary</h2>
      {view === "book" ? (
        <BookDetails />
      ) : view === "blog" ? (
        <BlogDetails />
      ) : (
        <CourseDetails />
      )}

      <h2>Method 3: Logical &&</h2>
      {view === "book" && <BookDetails />}
      {view === "blog" && <BlogDetails />}
      {view === "course" && <CourseDetails />}
    </div>
  );
}

export default App;
