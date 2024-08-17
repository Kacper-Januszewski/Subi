import React, { useState } from "react";
import axios from "axios";

function UsersList() {
    const [users, setUsers] = useState([]);

    const fetchUsers = () => {
        axios.get("https://localhost:5000/UserLogin/users")
            .then(response => {
                setUsers(response.data);
            })
            .catch(error => {
                console.error("There was an error fetching the users!", error);
            });
    };

    return (
        <div>
            <button onClick={fetchUsers}>Fetch Users2</button>
            <ul>
                {users.map(user => (
                    <li key={user.id}>
                        {user.username} - {user.otherField}
                    </li>
                ))}
            </ul>
        </div>
    );
}

export default UsersList;
