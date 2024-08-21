import React, { useState } from "react";
import axios from "axios";

function UsersList() {
    const [users, setUsers] = useState([]);

    const fetchUsers = () => {
        axios.get("http://localhost:5000/api/users")
            .then(response => {
                setUsers(response.data);
            })
            .catch(error => {
                console.error("There was an error fetching the users!", error);
            });
    };

    return (
        <div>
            <button onClick={fetchUsers}>Fetch Users</button>
            <ul>
                {users.map(user => (
                    <li key={user.id}>
                        {user.username} - {user.password}
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default UsersList;
