import React, { useState } from "react";
import axios from "axios";

function Login() {
    const [formData, setFormData] = useState({
        username: "",
        password: ""
    });

    // Update state on input change
    const handleInputChange = (event) => {
        const { name, value } = event.target;
        setFormData({
            ...formData,
            [name]: value,
        });
    };

    // Handle form submission
    const handleSubmit = (event) => {
        event.preventDefault();

        axios.post("http://localhost:5000/api/login", {
            username: formData.username,
            password: formData.password,
        }, {
            headers: {
                'Content-Type': 'application/json',
            }
        })
            .then(response => {
                console.log("Login successful!", response.data);
            })
            .catch(error => {
                console.error("There was an error with the login!", error.response.data);
            });
    };

    return (
        <div>
            <form onSubmit={handleSubmit}>
                <label htmlFor="username">Username:</label><br />
                <input
                    type="text"
                    id="username"
                    name="username"
                    value={formData.username}
                    onChange={handleInputChange}
                /><br />

                <label htmlFor="password">Password:</label><br />
                <input
                    type="password"
                    id="password"
                    name="password"
                    value={formData.password}
                    onChange={handleInputChange}
                /><br /><br />

                <input type="submit" value="Submit" />
            </form>
        </div>
    );
}

export default Login;
