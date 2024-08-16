import React, { useState } from 'react';
import axios from 'axios';

const UserList = () => {
    const [users, setUsers] = useState([]);
    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);

    const fetchUsers = async () => {
        setLoading(true);
        setError(null);
        try {
            const response = await axios.get('http://localhost:5000/api/users'); // Replace with your API endpoint
            setUsers(response.data);
        } catch (err) {
            setError('Error fetching users');
        } finally {
            setLoading(false);
        }
    };

    return (
        <div>
            <button onClick={fetchUsers}>Load Users</button>
            {loading && <p>Loading...</p>}
            {error && <p>{error}</p>}
            <ul>
                {users.map(user => (
                    <li key={user.id}>{user.username}</li>
                ))}
            </ul>
        </div>
    );
};

export default UserList;
