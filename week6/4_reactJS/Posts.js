import React, { Component } from "react";
import Post from "./Post";

class Posts extends Component {
  constructor(props) {
    super(props);
    this.state = {
      posts: [],
      error: null,
    };
  }

  loadPosts = () => {
    fetch("https://jsonplaceholder.typicode.com/posts")
      .then((response) => response.json())
      .then((data) => {
        const posts = data.map(
          (post) => new Post(post.userId, post.id, post.title, post.body)
        );
        this.setState({ posts });
      })
      .catch((error) => this.setState({ error }));
  };

  componentDidMount() {
    this.loadPosts();
  }

  componentDidCatch(error, info) {
    alert(`Error: ${error}\nInfo: ${info.componentStack}`);
  }

  render() {
    const { posts, error } = this.state;

    if (error) return <div>Error loading posts!</div>;

    return (
      <div className="posts-container">
        <h1>Blog Posts</h1>
        {posts.map((post) => (
          <div key={post.id} className="post">
            <h2>{post.title}</h2>
            <p>{post.body}</p>
          </div>
        ))}
      </div>
    );
  }
}

export default Posts;
