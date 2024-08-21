import React, { useState } from "react";
import axios from "axios";

function Login() {
    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");

    const handleSubmit = (event) => {
        event.preventDefault(); // Prevent the form from refreshing the page

        // Create a payload for login
        const loginData = { username, password };

        // Send a POST request to login API
        axios.post("http://localhost:5000/api/login", loginData)
            .then(response => {
                console.log("Login successful", response.data);
            })
            .catch(error => {
                console.error("There was an error logging in!", error);
            });
    };

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <label htmlFor="username">Username</label><br />
                <input
                    type="text"
                    id="username"
                    name="username"
                    value={username}
                    onChange={(e) => setUsername(e.target.value)}
                /><br />

                <label htmlFor="password">Password</label><br />
                <input
                    type="password"
                    id="password"
                    name="password"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                /><br /><br />

                <input type="submit" value="Submit" />
            </form>
        </div>
    );
}

export default Login;
